using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;

namespace Citrullia
{
    /// <summary>
    /// Sstatic utility class for reading and writing files.
    /// </summary>
    internal static class FileReader
    {
        /// <summary>The number format to be used.</summary>
        internal static NumberFormatInfo NumberFormat = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "," };
        /// <summary>The mode of file loading. Either X!Tandem or Result file.</summary>
        internal static FileLoadMode fileLoadMode;

        #region Results file methods
        /// <summary>The list of tuples with MGX- and X!Tandem-file.</summary>
        internal static List<Tuple<string, string>> inputResultPairs = new List<Tuple<string, string>>();
        /// <summary>The result file.</summary>
        internal static ResultFile resultFile;
        /// <summary>
        /// Open result files via OpenFileDialog.
        /// </summary>
        /// <returns>A list of filepaths.</returns>
        internal static string OpenResultFileViaDialog()
        {
            //Makes new FileDialog and sets its parameters: 
            OpenFileDialog oFD = new OpenFileDialog
            {
                Filter = "Citrullia result-file (*.CRX)|*.CRX",
                Multiselect = false,
                Title = "Citrullia File Browser"
            };

            //Opens the Dialog window, selects file and get filename:
            string filePath = "";
            DialogResult dr = oFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filePath = oFD.FileName;
            }
            // Return the list of file paths.
            return filePath;
        }

        /// <summary>
        /// Load the results.
        /// </summary>
        /// <param name="resultFilePath">The the filepath to the result file.</param>
        internal static void LoadResults(string resultFilePath)
        {
            // Get the base path
            string path = Path.GetDirectoryName(resultFilePath);
            // Get the result file
            ResultFile result = ReadResultFile(resultFilePath);

            List<string> foundMgxFile = new List<string>();
            // Loop through all of the result pairs
            foreach (ResultPair pair in result.Results)
            {
                string mgxFull = Path.Combine(path, pair.MGXFile);
                string xtFull = Path.Combine(path, pair.XTandemFile);

                // Check that file exists
                if (File.Exists(mgxFull) && File.Exists(xtFull))
                {
                    inputResultPairs.Add(new Tuple<string, string>(mgxFull, xtFull));
                    foundMgxFile.Add(mgxFull);
                }                
            }

            MakeMGFs(foundMgxFile);
            resultFile = result;

        }

        /// <summary>
        /// Load the quantified citrullination spectra.
        /// </summary>
        internal static void LoadQuantifiedCitSpectra()
        {
            List<KeyValuePair<int, int>> quantifiedCitSpectraIds = new List<KeyValuePair<int, int>>();

            // Loop through all of the files
            foreach (string mgxFile in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
            {
                foreach (string mgxFile1 in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
                {
                    // Add quantified spectras that have the correct files
                    if (resultFile.QuantifiedCitrullinatedSpectra.ContainsKey(mgxFile))
                    {
                        if (resultFile.QuantifiedCitrullinatedSpectra[mgxFile].ContainsKey(mgxFile1))
                        {
                            quantifiedCitSpectraIds.AddRange(resultFile.QuantifiedCitrullinatedSpectra[mgxFile][mgxFile1]);
                        }
                    }
                }
            }

            // If validation results has bee found, it is possible to recive the saved spectra
            if (Validation.citValResults.Count != 0)
            {
                // Get the list of quantified spectra
                List<KeyValuePair<XTSpectrum, XTSpectrum>> quantifiedCitSpectra = FindCitSpectra(quantifiedCitSpectraIds);
                // Loop through found spectra and add them to quantification
                foreach (KeyValuePair<XTSpectrum, XTSpectrum> spectrum in quantifiedCitSpectra.Distinct())
                {
                    // Add the spectrum to the quantification
                    Quantification.AddTokvpCitSpecSpecDict(spectrum.Key, spectrum.Value);
                    // Add the spectrum ID to the list
                    Validation.citChosenForQuantList.Add(spectrum.Key.ID);
                }
            }
        }
        /// <summary>
        /// Load the quantified arginine spectra.
        /// </summary>
        internal static void LoadQuantifiedArgSpectra()
        {
            List<KeyValuePair<int, int>> quantifiedArgSpectraIds = new List<KeyValuePair<int, int>>();

            // Loop through all of the files
            foreach (string mgxFile in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
            {
                foreach (string mgxFile1 in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
                {
                    // Add quantified spectras that have the correct files
                    if (resultFile.QuantifiedArginineSpectra.ContainsKey(mgxFile1))
                    {
                        if (resultFile.QuantifiedArginineSpectra[mgxFile1].ContainsKey(mgxFile))
                        {
                            quantifiedArgSpectraIds.AddRange(resultFile.QuantifiedArginineSpectra[mgxFile1][mgxFile]);
                        }
                    }
                }
            }

            // If validation results has bee found, it is possible to recive the saved spectra
            if (Validation.argValResults.Count != 0)
            {
                // Get the list of quantified spectra
                List<KeyValuePair<XTSpectrum, RawScan>> quantifiedArgSpectra = FindArgSpectra(quantifiedArgSpectraIds);
                // Loop through found spectra and add them to quantification
                foreach (KeyValuePair<XTSpectrum, RawScan> spectrum in quantifiedArgSpectra.Distinct())
                {
                    // Add the spectrum to the quantification
                    Quantification.AddTokvpArgSpecScanDict(spectrum.Key, spectrum.Value);
                    // Add the spectrum ID to the list
                    Validation.argChosenForQuantList.Add(spectrum.Key.ID);
                }
            }
        }
        /// <summary>
        /// Load the quantified lone citrullination spectra.
        /// </summary>
        internal static void LoadQuantifiedLoneCitSpectra()
        {
            List<int> quantifiedLoneCitSpectraIds = new List<int>();

            // Loop through all of the files
            foreach (string mgxFile in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
            {
                foreach (string mgxFile1 in inputResultPairs.Select(x => Path.GetFileName(x.Item1)))
                {
                    if (resultFile.QuantifiedLoneCitrullinatedSpectra.ContainsKey(mgxFile)) quantifiedLoneCitSpectraIds.AddRange(resultFile.QuantifiedLoneCitrullinatedSpectra[mgxFile]);
                    if (resultFile.QuantifiedLoneCitrullinatedSpectra.ContainsKey(mgxFile1)) quantifiedLoneCitSpectraIds.AddRange(resultFile.QuantifiedLoneCitrullinatedSpectra[mgxFile1]);

                }
            }
            // If validation results has bee found, it is possible to recive the saved spectra
            if (Validation.loneCitValResults.Count != 0)
            {
                // Get the list of quantified spectra
                List<XTSpectrum> quantifiedLoneCitSpectra = FindLoneCitSpectra(quantifiedLoneCitSpectraIds);
                // Loop through found spectra and add them to quantification
                foreach (XTSpectrum spectrum in quantifiedLoneCitSpectra.Distinct())
                {
                    // Add the spectrum to the quantification
                    Quantification.AddToLoneCitSpecList(spectrum);
                    // Add the spectrum ID to the list
                    Validation.loneCitChosenForQuantList.Add(spectrum.ID);
                }
            }
        }
        /// <summary>
        /// Find the lone citrullination spectra from their IDs.
        /// </summary>
        /// <param name="quantifiedLoneCitSpectraIds">The list of lone quantified spectra IDs.</param>
        /// <returns>The list of line citrullination spectra.</returns>
        private static List<XTSpectrum> FindLoneCitSpectra(List<int> quantifiedLoneCitSpectraIds)
        {
            // Create an empty list of spectra
            List<XTSpectrum> spectra = new List<XTSpectrum>();
            // Loop through all of the ids and add them to the list
            foreach (int spectraId in quantifiedLoneCitSpectraIds)
            {
                spectra.Add(Validation.loneCitValResults.Select(result => result.ModifiedSpectra.Where(pair => pair.ID == spectraId).FirstOrDefault()).FirstOrDefault());
            }
            // The list of spectra
            return spectra;
        }
        
        /// <summary>
        /// Find the arginine spectra from the IDs.
        /// </summary>
        /// <param name="quantifiedArgSpectraIds">The list of Ids.</param>
        /// <returns>The list of quantified spectra.</returns>
        private static List<KeyValuePair<XTSpectrum, RawScan>> FindArgSpectra(List<KeyValuePair<int, int>> quantifiedArgSpectraIds)
        {
            List<KeyValuePair<XTSpectrum, RawScan>> spectra = new List<KeyValuePair<XTSpectrum, RawScan>>();

            // Loop through all of the list if ids
            foreach (KeyValuePair<int, int> spectraIds in quantifiedArgSpectraIds)
            {
                // Create an empty pair
                KeyValuePair<XTSpectrum, List<RawScan>> pair = new KeyValuePair<XTSpectrum, List<RawScan>>(null, null);

                // Loop through all of the results and try to find the correct pair
                foreach (ValResult valResult in Validation.argValResults)
                {
                    pair = valResult.ArgSpectraDictionary.Where(argPairs => argPairs.Key.ID == spectraIds.Value).FirstOrDefault();
                    // If an valid pair has been found add it and break out of the loop.
                    if (pair.Key != null && pair.Value != null)
                    {
                        XTSpectrum argSpectrum = pair.Key;
                        RawScan citSpectrum = pair.Value.Where(x => x.ScanNumber == spectraIds.Key).FirstOrDefault();

                        spectra.Add(new KeyValuePair<XTSpectrum, RawScan>(argSpectrum, citSpectrum));
                        break;
                    };
                }
            }

            return spectra;
        }
        /// <summary>
        /// Find the citrullination spectra from the IDs.
        /// </summary>
        /// <param name="quantifiedCitSpectraIds">The list of Ids.</param>
        /// <returns>The list of quantified spectra.</returns>
        private static List<KeyValuePair<XTSpectrum, XTSpectrum>> FindCitSpectra(List<KeyValuePair<int, int>> quantifiedCitSpectraIds)
        {
            List<KeyValuePair<XTSpectrum, XTSpectrum>> spectra = new List<KeyValuePair<XTSpectrum, XTSpectrum>>();
            // Loop through all of the list if ids
            foreach (KeyValuePair<int,int> spectraIds in quantifiedCitSpectraIds)
            {
                // Create an empty pair
                KeyValuePair<XTSpectrum, List<XTSpectrum>> pair = new KeyValuePair<XTSpectrum, List<XTSpectrum>>(null, null);

                // Loop through all of the results and try to find the correct pair
                foreach (ValResult valResult in Validation.citValResults)
                {
                    pair = valResult.CitSpectraDictionary.Where(citPairs => citPairs.Key.ID == spectraIds.Key).FirstOrDefault();
                    // If an valid pair has been found add it and break out of the loop.
                    if (pair.Key != null && pair.Value != null)
                    {

                        XTSpectrum citSpectrum = pair.Key;
                        XTSpectrum argSpectrum = pair.Value.Where(x => x.ID == spectraIds.Value).FirstOrDefault();

                        spectra.Add(new KeyValuePair<XTSpectrum, XTSpectrum>(citSpectrum, argSpectrum));
                        break;
                    }
                }
            }

            return spectra;
        }

        /// <summary>
        /// Copy the result X!Tandem files to the output folder
        /// </summary>
        internal static void CopyXTFilesToOutputFolder()
        {
            // Loop through all of the input files, get the filename and copy them.
            foreach (Tuple<string, string> inputFiles in inputResultPairs)
            {
                string filename = Path.GetFileName(inputFiles.Item2);
                File.Copy(inputFiles.Item2, Path.Combine(External.CitrulliaSettings.OutputXTandemFilesFolder, filename));
            }
        }

        /// <summary>
        /// Read the result file.
        /// </summary>
        /// <param name="resultFilePath">The path of the result path.</param>
        /// <returns>The parsed result file.</returns>
        internal static ResultFile ReadResultFile(string resultFilePath)
        {
            // Get the path
            string path = Path.GetFullPath(resultFilePath);
            // Create an empty result file
            ResultFile resultFile = null; 
            using (StreamReader streamReader = new StreamReader(path))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                resultFile = (ResultFile)jsonSerializer.Deserialize(streamReader, typeof(ResultFile));
            }

            if(resultFile == null)
            {
                // Throw error
                Console.WriteLine($"ERROR: Unable to path result file from file '{resultFilePath}'");
            }

            return resultFile;
        }

        /// <summary>
        /// Copy files.
        /// </summary>
        /// <param name="directory">The directory they should be copied to as out parameter.</param>
        /// <param name="filePair">The dictionary of filepairs as out parameter.</param>
        internal static void CopyFilesTo(out string directory, out Dictionary<string, string> filePair)
        {
            // Create a list of filenames
            List<string> mgxFileNames = new List<string>(); 
            List<string> xtFileNames = new List<string>();
            // Get the folder path for the MGX files
            string mgxFilePath = Path.GetDirectoryName(inputFiles[0].FilePath);
            // Get the input filenames
            foreach (Input input in inputFiles)
            {
                mgxFileNames.Add(Path.GetFileName(input.FilePath));
            }
            // Get the list of X!Tandem files
            string[] xtFiles = Directory.GetFiles(External.CitrulliaSettings.OutputXTandemFilesFolder);
            // Loop the files, copy them and add the name to the list of filenames
            foreach (string xtFile in xtFiles)
            {
                string newXtFileName = string.Format("{0}.XML", Path.GetFileName(xtFile).Split('.')[0]);
                xtFileNames.Add(newXtFileName);
                string newXtFilePath = Path.Combine(mgxFilePath, newXtFileName);
                File.Copy(xtFile, newXtFilePath, true);
            }
            // Get the filepairs
            filePair = new Dictionary<string, string>();
            foreach (string inputFile in mgxFileNames)
            {
                foreach (string xtFileName in xtFileNames)
                {
                    if (Path.GetFileNameWithoutExtension(inputFile).Split('.')[0] == Path.GetFileNameWithoutExtension(xtFileName))
                        filePair.Add(inputFile, xtFileName);
                }
            }
            // Set the directory
            directory = mgxFilePath;
        }
        /// <summary>
        /// Create the result file.
        /// </summary>
        /// <param name="resultFile">The result file.</param>
        /// <param name="resultFilePath">The result file save path.</param>
        internal static void CreateResultFile(ResultFile resultFile, string resultFilePath)
        {
            // Get the filepath
            string path = Path.GetFullPath(resultFilePath);
            // Serialize the result file
            string json = JsonConvert.SerializeObject(resultFile, typeof(ResultFile), new JsonSerializerSettings());
            // Create the file and append the json text to it
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(json);
                writer.Flush();
            }
        }

        /// <summary>
        /// Generate the result file.
        /// </summary>
        /// <param name="quantResults">The list of quantification results.</param>
        /// <returns></returns>
        internal static void GenerateResultFile(List<QuantResult> quantResults)
        {
            // Copy files and get the directory and filepairs
            CopyFilesTo(out string directory, out Dictionary<string, string> filePairs);
            // Get the quantified spectra
            Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> quantCitSpectra = CreateSpectraFileList(quantResults.Where(spec => spec.ValidationBy == "Cit-paired").ToList());
            Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> quantArgSpectra = CreateSpectraFileList(quantResults.Where(spec => spec.ValidationBy == "Arg-paired").ToList());
            Dictionary<string, List<int>> quantLoneCitSpectra = CreateSpectraFileListLoneCit(quantResults.Where(spec => spec.ValidationBy == "Lone").ToList());
            // Create and save the result file
            ResultFile file = new ResultFile(filePairs, quantCitSpectra, quantArgSpectra, quantLoneCitSpectra);
            CreateResultFile(file, Path.Combine(directory, GenerateFileName(directory, "result", "crx")));

        }

        /// <summary>
        /// Get the dictionary of filenames and spectra IDs.
        /// </summary>
        /// <param name="results">The list of quantification results.</param>
        /// <returns>The dictionary of the result files.</returns>
        private static Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> CreateSpectraFileList(List<QuantResult> results)
        {
            // Create an empty dictionary of spectra file list
            Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> quantifiedSpectra = new Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>>();

            // Loop through the results
            foreach (QuantResult result in results)
            {
                // If the dictionary does not contain the name of the citrullination file is not a key, create the key 
                if (quantifiedSpectra.ContainsKey(result.CitFileName) == false)
                {
                    quantifiedSpectra[result.CitFileName] = new Dictionary<string, List<KeyValuePair<int, int>>>();
                }
                // If the dictionary does not contain the name of the arginine file is not a key, create the key 
                if (quantifiedSpectra[result.CitFileName].ContainsKey(result.ArgFileName) == false)
                {
                    quantifiedSpectra[result.CitFileName][result.ArgFileName] = new List<KeyValuePair<int, int>>();
                }
                // Add the spectrum to the dictionary.
                quantifiedSpectra[result.CitFileName][result.ArgFileName].Add(new KeyValuePair<int, int>(result.CitSpectrumID, result.ArgSpectrumID));
            }
            // Return the dictionary
            return quantifiedSpectra;
        }

        /// <summary>
        /// Create a collection of quantified spectra and their files.
        /// </summary>
        /// <param name="quantResults">The quantification results.</param>
        /// <returns>The collection of quantified spectra and their files.</returns>
        private static Dictionary<string, List<int>> CreateSpectraFileListLoneCit(List<QuantResult> quantResults)
        {
            // Create an empty dictionary
            Dictionary<string, List<int>> quantifiedSpectras = new Dictionary<string, List<int>>();

            // Loop through all of the quantified results
            foreach (QuantResult result in quantResults)
            {
                // If the dictionary does not contain the name of the citrullination file is not a key, create the key 
                if (quantifiedSpectras.ContainsKey(result.CitFileName) == false)
                {
                    quantifiedSpectras[result.CitFileName] = new List<int>();
                }
                // Add the spectrum to the dictionary.
                quantifiedSpectras[result.CitFileName].Add(result.CitSpectrumID);

            }
            // Return the dictionary of quantified spectra
            return quantifiedSpectras;
        }
        #endregion

        #region X!Tandem inputs methods
        /// <summary>The list of inputs.</summary>
        internal static List<Input> inputFiles = new List<Input>();

        /// <summary>
        /// Open MGX-files via OpenFileDialog.
        /// </summary>
        /// <returns>A list of file paths.</returns>
        internal static List<string> OpenMGXFilesViaDialog()
        {
            //Makes new FileDialog and sets its parameters: 
            OpenFileDialog oFD = new OpenFileDialog
            {
                Filter = "Mascot Generic Extended-file (*.MGX)|*.MGX",
                Multiselect = true,
                Title = "Citrullia File Browser"
            };

            //Opens the Dialog window, selects files, and parse filepaths as list:
            var filePaths = new List<string>();
            DialogResult dr = oFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filePaths.AddRange(oFD.FileNames);
            }
            // Return the list of file paths.
            return filePaths;
        }

        /// <summary>
        /// Read the scans from a file.
        /// </summary>
        /// <param name="path">The filepath.</param>
        /// <returns>A list of scans.</returns>
        internal static List<RawScan> ReadInputFile(string path)
        {
            // Create a temporary list of scans
            List<RawScan> scans = new List<RawScan>();
            // Create an array of scan info keywords
            string[] scanInfo = new string[] { "BEGIN", "SCANS", "MS LEVEL", "RTINSECONDS", "PEPMASS", "CHARGE", "BASE PEAK", "BASE INTENSITY", "TIC", "PARENT SCAN", "END"};
            // Create lists for temporary storage of data
            List<string> singleScanInfo = new List<string>();
            List<double> singleScanMZ = new List<double>();
            List<double> singleScanInt = new List<double>();
            string singleScanTitle = "";
            // Read all lines in the file
            string[] mgxLines = File.ReadAllLines(path);
            // Loop through all of the lines
            foreach (string line in mgxLines)
            {
                // Check if the line is a comment or is empty. If so, skip the currrent line
                if (line.StartsWith("#") || line == "" || line.StartsWith("<"))
                {
                    continue;
                }
                else
                {
                    // Check if line is end line
                    if (line == "END IONS")
                    {
                        // Add the line to the list of scan info
                        singleScanInfo.Add("END IONS");

                        if (singleScanInfo.Find(x => x.Contains("SCANS=")).Split('=').Last() == "") { singleScanInfo.Remove("SCANS="); singleScanInfo.Add("SCANS=0"); }
                        if (singleScanInfo.Find(x => x.Contains("MS LEVEL=")).Split('=').Last() == "") { singleScanInfo.Remove("MS LEVEL="); singleScanInfo.Add("MS LEVEL=0"); }
                        if (singleScanInfo.Find(x => x.Contains("RTINSECONDS=")).Split('=').Last() == "") { singleScanInfo.Remove("RTINSECONDS="); singleScanInfo.Add("RTINSECONDS=0"); }
                        if (singleScanInfo.Find(x => x.Contains("CHARGE=")).Split('=').Last() == "") { singleScanInfo.Remove("CHARGE="); singleScanInfo.Add("CHARGE=0"); }
                        if (singleScanInfo.Find(x => x.Contains("BASE PEAK=")).Split('=').Last() == "") { singleScanInfo.Remove("BASE PEAK="); singleScanInfo.Add("BASE PEAK=0"); }
                        if (singleScanInfo.Find(x => x.Contains("BASE INTENSITY=")).Split('=').Last() == "") { singleScanInfo.Remove("BASE INTENSITY="); singleScanInfo.Add("BASE INTENSITY=0"); }
                        if (singleScanInfo.Find(x => x.Contains("TIC=")).Split('=').Last() == "") { singleScanInfo.Remove("TIC="); singleScanInfo.Add("TIC=0"); }
                        // Add a new scan
                        scans.Add(new RawScan
                        {
                            Begin = singleScanInfo.Find(x => x.Contains("BEGIN")),
                            // Find and parse the scan number
                            ScanNumber = int.Parse(singleScanInfo.Find(x => x.Contains("SCANS=")).Split('=').Last()),
                            // Find and parse the MS Level
                            MSLevel = int.Parse(singleScanInfo.Find(x => x.Contains("MS LEVEL=")).Split('=').Last()),
                            // Set the title of the scan
                            Title = singleScanTitle,
                            // Find and parse the Retention time
                            RetentionTime = int.Parse(singleScanInfo.Find(x => x.Contains("RTINSECONDS=")).Split('=').Last()),
                            // Find and parse the precursor MZ-value
                            PreCursorMz = double.Parse(singleScanInfo.Find(x => x.Contains("PEPMASS=")).Split(' ').First().Replace("PEPMASS=", ""), NumberFormat),
                            // Find and parse the precursor intensity
                            PreCursorIntencity = double.Parse(singleScanInfo.Find(x => x.Contains("PEPMASS=")).Split(' ').Last(), NumberFormat),
                            // Find and parse the charge
                            Charge = int.Parse(singleScanInfo.Find(x => x.Contains("CHARGE=")).Split('=').Last().Replace("+", "")),
                            // Find and parse the base peak MZ-value
                            BasePeak = double.Parse(singleScanInfo.Find(x => x.Contains("BASE PEAK=")).Split('=').Last(), NumberFormat),
                            // Find and parse the base peak intensity
                            BaseIntensity = double.Parse(singleScanInfo.Find(x => x.Contains("BASE INTENSITY=")).Split('=').Last(), NumberFormat),
                            // Find and parse the total ion count
                            TotalIonCount = int.Parse(singleScanInfo.Find(x => x.Contains("TIC=")).Split('=').Last()),
                            // Find and parse the parent scan number
                            ParentScanNumber = int.Parse(singleScanInfo.Find(x => x.Contains("PARENT SCAN=")).Split('=').Last()),
                            // Set the MZ and intensities
                            MzValues = singleScanMZ.ToArray(),
                            Intencities = singleScanInt.ToArray(),
                            End = singleScanInfo.Last(),
                        });
                        // Clear temporary data storage.
                        singleScanInfo.Clear();
                        singleScanMZ.Clear();
                        singleScanInt.Clear();
                        singleScanTitle = "";
                    }
                    else
                    {
                        // If not end line continue reading.
                        // Check if is scan info. If so, add it to the list of scan info.
                        if (scanInfo.Any(line.Contains) & line.Contains("TITLE=") == false)
                        {
                            singleScanInfo.Add(line);
                        }
                        else
                        {
                            // Check if is title. If so, read title.
                            if (line.Contains("TITLE="))
                            {
                                singleScanTitle = line;
                            }
                            else if(char.IsDigit(line[0]))
                            {
                                // If the line is not a scan info or title line it must be an peak-information line.
                                // Parse the MZ-value and intensity.
                                singleScanMZ.Add(double.Parse(line.Split(' ').First(), NumberFormat));
                                singleScanInt.Add(double.Parse(line.Split(' ').Last(), NumberFormat));
                            }
                        }
                    }
                }
            }
            return scans;
        }

        /// <summary>
        /// Load the input files.
        /// </summary>
        /// <param name="filePaths">The list of filepaths.</param>
        /// <returns>A list of input files.</returns>
        internal static List<Input> LoadFiles(List<string> filePaths)
        {
            // Create a list for temporary storage of input files
            List<Input> inputFiles = new List<Input>();
            // Loop through all of the file paths.
            foreach (string path in filePaths)
            {
                Console.WriteLine(path);
                // Create temporary lists for MS1- and MS2-scans
                List<RawScan> ms1s = new List<RawScan>();
                List<RawScan> ms2s = new List<RawScan>();
                // Read the scans from the file
                List<RawScan> scans = ReadInputFile(path);
                // Loop through all of the scans and classify them afther their MS-Level
                foreach (RawScan s in scans)
                {
                    if (s.MSLevel == 2)
                    {
                        ms2s.Add(s);
                    }
                    else
                    {
                        ms1s.Add(s);
                    }
                }
                // Add the scans to the input
                inputFiles.Add(new Input
                {
                    // Set the filepath
                    FilePath = path,
                    // Set the MS1- and MS2-scans
                    MS1Scans = ms1s,
                    MS2Scans = ms2s
                });
            }
            // Return the inputs
            return inputFiles;
        }

        /// <summary>
        /// Convert the MGX-files to MGF-files.
        /// </summary>
        /// <param name="filePaths">The list of paths to the files to be converted.</param>
        internal static void MakeMGFs(List<string> filePaths)
        {
            // Load the files.
            List<Input> inputs = LoadFiles(filePaths);
            // Set the input files
            ReturnInput(inputs);
            // Delete the existing input MGF-files
            DeleteExistingInputMGFs();
            // Loop through the input files
            foreach (Input input in inputs)
            {
                // Create a new filename of the file.
                string fileName = External.CitrulliaSettings.InputMgfFilesFolder + @"\" + input.FilePath.Split('\\').Last() + ".mgf";
                // Create a stream writer
                using (StreamWriter file = new StreamWriter(fileName))
                {
                    // Loop through all of the MS2-level scans
                    foreach (RawScan scan in input.MS2Scans)
                    {                      
                        file.WriteLine(scan.Begin);
                        // Write the scan number
                        file.WriteLine("SCAN={0}",scan.ScanNumber);
                        // Write the precursor MZ-value and intensity
                        file.WriteLine("PEPMASS={0} {1}", scan.PreCursorMz.ToString(NumberFormat), scan.PreCursorIntencity.ToString(NumberFormat));
                        // Write the charge
                        file.WriteLine("CHARGE={0}+", scan.Charge);
                        // Write the the title
                        file.WriteLine(scan.Title);
                        // Loop through all of the MZ-values and intensities and write them to the file
                        for (int i = 0; i <= scan.MzValues.Length - 1; i++)
                        {
                            file.WriteLine("{0} {1}", scan.MzValues[i].ToString(NumberFormat), scan.Intencities[i].ToString(NumberFormat));
                        }
                        file.WriteLine(scan.End);
                    }
                }
            }

        }

        /// <summary>
        /// Delete existing input MGF-files.
        /// </summary>
        internal static void DeleteExistingInputMGFs()
        {
            // Get all the files in the input MGF file folder
            string[] filepaths = Directory.GetFiles(External.CitrulliaSettings.InputMgfFilesFolder);
            // Loop through all of the files and delete them
            foreach (string file in filepaths)
            {
                File.Delete(file);
            }
        }

        private static List<Input> ReturnInput(List<Input> inputs)
        {
            inputFiles = inputs;
            return inputFiles;
        }
        #endregion

        #region X!Tandem output methods
        /// <summary>The X!Tandem search results.</summary>
        internal static List<XTResult> XTandemSearchResults = new List<XTResult>();

        /// <summary>
        /// Read the result XML from X!Tandem.
        /// </summary>
        internal static void ReadResultXMLs()
        {
            // Get the current directory
            string currentDir = Environment.CurrentDirectory.ToString();
            // Set the folder path for the output
            string folderpath = currentDir + "\\Externals\\XTandem\\Outputs";
            // Create a temporary list of X!Tandem results
            var xTandemResults = new List<XTResult>();
            // Get the files in the directory and loop though them.
            foreach (string file in Directory.GetFiles(External.CitrulliaSettings.OutputXTandemFilesFolder))
            {
                // Create an empty result
                var result = new XTResult();
                // Read the result to the empty result
                result = ReadXML(file);
                // Add the result to the temporary list
                xTandemResults.Add(result);
                // Set the new X!Tandem results
                ReturnXResult(xTandemResults);
                
            }
        }

        /// <summary>
        /// Set the X!Tandem results.
        /// </summary>
        /// <param name="xTandemResults">The new X!Tandem results.</param>
        /// <returns>The new X!Tandem results.</returns>
        private static List<XTResult> ReturnXResult(List<XTResult> xTandemResults)
        {
            XTandemSearchResults = xTandemResults;
            return XTandemSearchResults;
        }

        /// <summary>
        /// Read the X!Tandem result from a file.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <returns>The <see cref="XTResult"/>.</returns>
        internal static XTResult ReadXML(string filename)
        {
            // Load the file into an XML Document
            XDocument xml = XDocument.Load(filename);
            // Set the df?? TODO: Rename
            string df = "{http://www.bioml.com/gaml/}";
            // Create an temporary list of X!Tandem spectra
            var spectrums = new List<XTSpectrum>();
            // Get the orginal name of the input file
            string originalInputFileName = xml.Root.Attribute("label").ToString().Split(' ').Last().Replace("'","").Split('\\').Last().Replace("\"","").Replace(".mgf","");
            // Loop through each of the element in the root
            foreach (var el in xml.Root.Elements())
            {
                Console.WriteLine(el.FirstAttribute.ToString());
                // Create an empty instance of spectrum
                var spectrum = new XTSpectrum();
                // Check if the first attribute in the element is equal to id
                if (el.FirstAttribute == el.Attribute("id"))
                {
                    // If so, parse the element
                    // Get the group data
                    spectrum = ExtractGroupData(el, spectrum);
                    //Console.WriteLine("Underelements of spectrum: {0}", el.Elements().Count());
                    // Create a temporary list of proteins
                    var proteins = new List<XTProtein>();
                    // Loop through each of the subelements
                    foreach (var el2 in el.Elements())
                    {

                        //Console.WriteLine("Name of spectrum underelement: {0}",el2.Name);
                        // Check if the name of the subelement is protein
                        if (el2.Name == "protein")
                        {
                            //Protein data:
                            var protein = new XTProtein();
                            protein = ExtractProteinData(el2, protein);
                            //Console.WriteLine("Protein: {0}", protein.ProtID);
                            proteins.Add(protein);

                        }
                        else
                        {
                            // If not protein data
                            // Check that if the first attribute is "supporting data"

                            if (el2.FirstAttribute.Value == "supporting data")
                            {
                                // If so, extract supporting data
                                //Supporting data:
                                spectrum = ExtractSupportingData(el2, df, spectrum);
                            }
                            else
                            {
                                // If not supporting data extract spectrum data
                                //Spectrum data:
                                spectrum = ExtractSpectrumData(el2, df, spectrum);
                            }
                        }
                    }
                    // Add the proteins to the spectrum
                    spectrum.Proteins = proteins;
                    // Add the spectrum to the temporary list of spectra
                    spectrums.Add(spectrum);
                    //Console.WriteLine(spectrum.ID.ToString());
                }
            }
            // Create a new instance of X!Tandem result
            var result = new XTResult
            {
                // Set the filepath
                FilePath = filename,
                // Set the filename
                FileName = filename.Split('\\').Last(),
                // Set the list of spectra
                XSpectrums = spectrums,
                // Set the filename of the input file
                OriginalInputFile = originalInputFileName
            };
            // Return the result
            return result;
        }

        /// <summary>
        /// Extract the group data from the result file.
        /// </summary>
        /// <param name="group">The group data.</param>
        /// <param name="spectrum">The spectrum.</param>
        /// <returns>The spectrum with the group data.</returns>
        internal static XTSpectrum ExtractGroupData(XElement group, XTSpectrum spectrum)
        {
            // Get the spectrum ID
            spectrum.ID = int.Parse(group.Attribute("id").Value);
            // Get the parent mass
            spectrum.ParentMass = double.Parse(group.Attribute("mh").Value, NumberFormat);
            // Get the parent ion mass
            spectrum.ParentIonCharge = int.Parse(group.Attribute("z").Value);
            // Get the e-value for the spectrum
            spectrum.SpectrumEVal = double.Parse(group.Attribute("expect").Value, NumberFormat);
            // Get the spectrum
            spectrum.SpectrumLabel = group.Attribute("label").Value;
            // Get the log10(intensity sum)
            spectrum.LogSumFragIons = double.Parse(group.Attribute("sumI").Value, NumberFormat);
            // Get the max fragment intensity.
            spectrum.MaxFragIonInt = double.Parse(group.Attribute("maxI").Value, NumberFormat);
            // Get the norm multiplier.
            spectrum.NormMulitplier = double.Parse(group.Attribute("fI").Value, NumberFormat);
            // Return the spectrum
            return spectrum;
        }

        /// <summary>
        /// Extract protein data from the result file.
        /// </summary>
        /// <param name="pData">The protein data.</param>
        /// <param name="protein">The protein.</param>
        /// <returns>The protein with the protein data.</returns>
        internal static XTProtein ExtractProteinData(XElement pData, XTProtein protein) // Contians: note, file, peptide, domain and aa
        {
            /* Protein information */
            // Get the protein ID
            protein.ProtID = double.Parse(pData.Attribute("id").Value.Trim(), NumberFormat);
            // Get the E-value for the protein
            protein.ProtEVal = double.Parse(pData.Attribute("expect").Value, NumberFormat);
            // Get the sum of fragment ions identified
            protein.ProtLogFragIonInt = double.Parse(pData.Attribute("sumI").Value, NumberFormat);

            /* Note information */
            // Get and set the protein label
            var note = pData.Element("note");
            protein.ProtLabel = note.Value;

            /* File information */
            // Get the URL for the FASTA file
            protein.ProtFasta = pData.Element("file").Attribute("URL").Value;

            /* Peptide information */
            // Get the peptide XML element
            var peptide = pData.Element("peptide");
            // Get the start position of the peptide
            protein.ProtStartPos = int.Parse(peptide.Attribute("start").Value);
            // Get the end position of the peptide
            protein.ProtEndPos = int.Parse(peptide.Attribute("end").Value);
            // Get the sequence of the peptide
            protein.ProtSeq = peptide.Value;

            /* Domain information*/
            // Get the start position of the domain
            protein.DomainStartPos = int.Parse(peptide.Element("domain").Attribute("start").Value);
            // Get the end position of the domain
            protein.DomainEndPos = int.Parse(peptide.Element("domain").Attribute("end").Value);
            // Get the e-value for the domain
            protein.DomainExpect = double.Parse(peptide.Element("domain").Attribute("expect").Value, NumberFormat);
            // Get the protein mass
            protein.DomainMZ = double.Parse(peptide.Element("domain").Attribute("mh").Value, NumberFormat);
            // Get the difference between the spectrum and calculated mass
            protein.Delta = double.Parse(peptide.Element("domain").Attribute("delta").Value, NumberFormat);
            // Get X!Tandem identification score
            protein.Hyperscore = double.Parse(peptide.Element("domain").Attribute("hyperscore").Value, NumberFormat);
            protein.NextScore = double.Parse(peptide.Element("domain").Attribute("nextscore").Value, NumberFormat);
            protein.YScore = double.Parse(peptide.Element("domain").Attribute("y_score").Value, NumberFormat);
            protein.YIons = int.Parse(peptide.Element("domain").Attribute("y_ions").Value);
            protein.BScore = double.Parse(peptide.Element("domain").Attribute("b_score").Value, NumberFormat);
            protein.BIons = int.Parse(peptide.Element("domain").Attribute("b_ions").Value);
            // Get the 4 amino acids before the domain
            protein.PreSeq = peptide.Element("domain").Attribute("pre").Value;
            // Get the 4 amino acids after the domain
            protein.PostSeq = peptide.Element("domain").Attribute("post").Value;
            // Get the sequence of the domain
            protein.DoaminSeq = peptide.Element("domain").Attribute("seq").Value;
            // Get the number of potential missed cleavage sites
            protein.MissedCleavages = int.Parse(peptide.Element("domain").Attribute("missed_cleavages").Value);
            
            /* Modifications */
            // Create an temporary list of modifications
            var modifications = new List<XTModification>();
            // Loop through all of the modifications
            foreach (var mod in pData.Descendants("aa"))
            {
                // Create an empty instance of modification
                var modi = new XTModification
                {
                    AminoAcid = mod.Attribute("type").Value,
                    AtPosition = int.Parse(mod.Attribute("at").Value),
                    MassChange = double.Parse(mod.Attribute("modified").Value, NumberFormat)
                };
                // Add the modification to the temporary list of modifications
                modifications.Add(modi);
            }
            // Set the modification list to the protein
            protein.Modifications = modifications;
            // Return the protein
            return protein;
        }

        /// <summary>
        /// Extract the supporting data from the result file.
        /// </summary>
        /// <param name="supData">The suplementary data.</param>
        /// <param name="df"></param>
        /// <param name="spectrum">The spectrum.</param>
        /// <returns>The specturm with the supporting data.</returns>
        internal static XTSpectrum ExtractSupportingData(XElement supData, string df, XTSpectrum spectrum) //Contains: trace, attribute, Xdata, Ydata and values
        {
            // Get the hyperscore expectation function
            var traceHyperscore = supData.Descendants(df + "trace").FirstOrDefault(el => el.Attribute("type").Value == "hyperscore expectation function");
            // From hyperscore get and set A0 and A1
            spectrum.A0 = double.Parse(traceHyperscore.Descendants(df + "attribute").FirstOrDefault(el => el.Attribute("type").Value == "a0").Value, NumberFormat);
            spectrum.A1 = double.Parse(traceHyperscore.Descendants(df + "attribute").FirstOrDefault(el => el.Attribute("type").Value == "a1").Value, NumberFormat);
            // Get the number of hyperscores
            var hScoreNumbs = traceHyperscore.Element(df + "Xdata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the number of hyperscores
            spectrum.HyperscoreNumbs = Array.ConvertAll(hScoreNumbs.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);
            // Get the count of hyperscores
            var hScoreCounts = traceHyperscore.Element(df + "Ydata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the number of hyperscores
            spectrum.HyperscoreCounts = Array.ConvertAll(hScoreCounts.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);

            // Get the convolution survival function
            var traceSurvival = supData.Descendants(df + "trace").FirstOrDefault(el => el.Attribute("type").Value == "convolution survival function");
            // Get the number of convolution survival function
            var cSurvivalNumbs = traceSurvival.Element(df + "Xdata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the number of convolution survival function
            spectrum.ConSurvivalNumbs = Array.ConvertAll(cSurvivalNumbs.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);
            // Get the count of convolution survival function
            var cSurvivalCounts = traceSurvival.Element(df + "Ydata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the count of convolution survival function
            spectrum.ConSurvivalCounts = Array.ConvertAll(cSurvivalCounts.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);

            // Get the b ion trace
            var traceB = supData.Descendants(df + "trace").FirstOrDefault(el => el.Attribute("type").Value == "b ion histogram");
            // Get the number of b ions
            var bIonNumbs = traceB.Element(df + "Xdata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the number of b ions
            spectrum.BIonNumbs = Array.ConvertAll(bIonNumbs.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);
            // Get the count of b ions
            var bIonCounts = traceB.Element(df + "Ydata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the count of b ions
            spectrum.BIonCounts = Array.ConvertAll(bIonCounts.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);

            var traceY = supData.Descendants(df + "trace").FirstOrDefault(el => el.Attribute("type").Value == "y ion histogram");
            // Get the number of y ions
            var yIonNumbs = traceY.Element(df + "Xdata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the number of y ions
            spectrum.YIonNumbs = Array.ConvertAll(yIonNumbs.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);
            // Get the count of y ions
            var yIonCounts = traceY.Element(df + "Ydata").Element(df + "values").Value.Replace("\n", "").Split(' ').ToArray();
            // Set the count of y ions
            spectrum.YIonCounts = Array.ConvertAll(bIonCounts.Where(x => string.IsNullOrEmpty(x) == false).ToArray(), int.Parse);

            // Return the spectrum
            return spectrum;
        }

        /// <summary>
        /// Extract the spectrum data from the result file.
        /// </summary>
        /// <param name="specData">The spectrum data.</param>
        /// <param name="df"></param>
        /// <param name="spectrum">The spectrum.</param>
        /// <returns>The specturm with the spectrum data.</returns>
        internal static XTSpectrum ExtractSpectrumData(XElement specData, string df, XTSpectrum spectrum) //Contians: note, trace, attribute, Xdata, Ydata and values
        {
            // Get and set the spectrum description
            var note = specData.Element("note");
            spectrum.SpectrumDescription = note.Value;

            var trace = specData.Element(df + "trace");
            // Get the M/Z-value of the spectrum (M+H)
            spectrum.SpectrumMZ = double.Parse(trace.Descendants(df + "attribute").FirstOrDefault(el => el.Attribute("type").Value == "M+H").Value, NumberFormat);
            // Get the charge of the spectrum
            spectrum.Charge = double.Parse(trace.Descendants(df + "attribute").FirstOrDefault(el => el.Attribute("type").Value == "charge").Value, NumberFormat);

            // Get the MZ-values
            var mzVals = trace.Element(df + "Xdata").Element(df + "values").Value.Replace("\n", " ").Split(' ').ToArray();
            // Convert the found non-empty M/Z-values to doubles and set them to the spectra
            spectrum.MzValues = mzVals.Where(x => string.IsNullOrEmpty(x) == false).Select(val => double.Parse(val, NumberFormat)).ToArray();

            // Get the intensities
            var ints = trace.Element(df + "Ydata").Element(df + "values").Value.Replace("\n", " ").Split(' ').ToArray();
            // Convert the found non-empty intensities to doubles and set them to the spectra
            spectrum.Intencities = ints.Where(x => string.IsNullOrEmpty(x) == false).Select(val => double.Parse(val, NumberFormat)).ToArray();
            // Return the spectrum
            return spectrum;
        }
        #endregion

        /// <summary>
        /// Generate a filename for the file. 
        /// </summary>
        /// <param name="directory">The directory of the file.</param>
        /// <param name="baseFilename">The base filename.</param>
        /// <param name="extension">The file extension without the period (.).</param>
        /// <returns>The unique generated filename.</returns>
        internal static string GenerateFileName(string directory, string baseFilename, string extension)
        {
            string filename = Path.Combine(directory, baseFilename);
            if(File.Exists(string.Format("{0}.{1}", filename, extension)))
            {
                int i = 1;
                while (File.Exists(string.Format("{0}.{1}", filename, extension)))
                {
                    filename = string.Format("{0}_{1}", filename, i);
                    i++;
                }
            }
            
            return string.Format("{0}.{1}", filename, extension);
        }

        /// <summary>
        /// Get an output path for an image via SaveFileDialog.
        /// </summary>
        /// <param name="filePath">The filepath as out parameter.</param>
        /// <returns>True, if filepath is found; Otherwise, false.</returns>
        internal static bool GetImageOutputPathViaDialog(out string filePath)
        {
            //Makes new FileDialog and sets its parameters: 
            SaveFileDialog sFD = new SaveFileDialog
            {
                FileName = "Image",
                Filter = "TIFF (.Tiff) | *.Tiff"
            };
            //Opens the Dialog window, selects files, and parse filepaths as list:
            DialogResult dr = sFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filePath = sFD.FileName;
                return true;
            }

            filePath = "";
            return false;
        }
    }

    /// <summary>
    /// The mode of file loading.
    /// </summary>
    internal enum FileLoadMode
    {
        /// <summary>Load via an result file.</summary>
        ResultFile,
        /// <summary>Load via XTandem run.</summary>
        XTandemRun,
    }
}
