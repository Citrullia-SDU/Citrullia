using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Citrullia
{
    /// <summary>
    /// Class for creating the spectra images.
    /// </summary>
    internal partial class SpectrumWriterUI : Form
    {
        readonly bool _createAnnotationFile;
        readonly StringBuilder _annotationWriter;

        /// <summary>
        /// Create a new instance of <see cref="SpectrumWriterUI"/>.
        /// </summary>
        /// <param name="directory">The save directory.</param>
        /// <param name="createAnnotationFile">Indicates that the a file with the annotation should be created.</param>
        internal SpectrumWriterUI(string directory, bool createAnnotationFile)
        {
            InitializeComponent();
            _createAnnotationFile = createAnnotationFile;
            _annotationWriter = new StringBuilder();
            CreateImages(directory);

        }

        /// <summary>
        /// Create the images.
        /// </summary>
        /// <param name="directory">The directory the images should be saved to.</param>
        private void CreateImages(string directory)
        {
            // Get the quantification results
            Dictionary<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>> quantResults = CreateQuantificationResultDictionary();
            // Loop through all of the results
            foreach (KeyValuePair<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>> quantResult in quantResults)
            {
                CreateImage(directory, quantResult);
            }

            // If a annotation file should be generated
            if (_createAnnotationFile)
            {
                // Generate the filename
                string filename = FileReader.GenerateFileName(directory, "AnnotationFile", "txt");
                // Append all of the text from the annotation writer to the file
                File.AppendAllText(filename, _annotationWriter.ToString());
                // Clear the annotation writer
                _annotationWriter.Clear();
            }
        }

        /// <summary>
        /// Create the image.
        /// </summary>
        /// <param name="directory">The directory the image should be saved to.</param>
        /// <param name="result">The result the image should be created from.</param>
        private void CreateImage(string directory, KeyValuePair<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>> result)
        {
            KeyValuePair<MsSpectrum, MsSpectrum> spectraData = result.Value;
            // Get the filename
            string baseFilename = string.Format("{0}_{1}_{2}", result.Key.Protein.Split('|')[0], result.Key.Sequence, result.Key.ValidationBy);
            string filename = FileReader.GenerateFileName(directory, baseFilename, "tiff");
            // Append the file to the annotation writer
            if (_createAnnotationFile)
            {
                _annotationWriter.AppendLine($"** {filename.Split(new string[] { @"\" }, System.StringSplitOptions.None).Last() } **");
            }

            // From the validation type, create the graph
            if (result.Key.ValidationBy == "Lone")
            {
                ValidationUIUtilities.CreateLoneCitMs2Chart(chartMS2, spectraData.Key);
                ValidationUIUtilities.AnnotateSingleSpectra(chartMS2, spectraData.Key, HelperUtilities.CreateAAArray(result.Key.Sequence), true, _createAnnotationFile, _annotationWriter);
            }
            else
            {
                ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, spectraData.Key, spectraData.Value);
                ValidationUIUtilities.AnnotatePairedSpectra(chartMS2, spectraData.Key, spectraData.Value, HelperUtilities.CreateAAArray(result.Key.Sequence), _createAnnotationFile, _annotationWriter);
            }

            // Clear the old titles
            chartMS2.Titles.Clear();
            // And add a new one
            chartMS2.Titles.Add(string.Format("{0}_{1}_{2}", result.Key.Protein.Split('|')[0], result.Key.Sequence, result.Key.ValidationBy));
            chartMS2.Titles[0].Font = new Font(chartMS2.Titles[0].Font.FontFamily, 13F);
            chartMS2.Titles[0].IsDockedInsideChartArea = false;
            chartMS2.Titles[0].Docking = Docking.Top;
            chartMS2.Titles[0].DockingOffset = 10;

            chartMS2.SaveImage(filename, ChartImageFormat.Tiff);
            ValidationUIUtilities.ClearChart(chartMS2);
            chartMS2.Annotations.Clear();
        }

        /// <summary>
        /// Create the quantification result dictionary.
        /// </summary>
        /// <returns>The dictionary with the quantification result and the spectra in keyvaluepair.</returns>
        private Dictionary<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>> CreateQuantificationResultDictionary()
        {
            // Create an empty dictionary to hold the the results
            Dictionary<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>> dict = new Dictionary<QuantResult, KeyValuePair<MsSpectrum, MsSpectrum>>();

            // Loop through all of the quantification results
            foreach (QuantResult result in Quantification.QuantificationResults)
            {
                MsSpectrum citSpectrum = null;
                MsSpectrum argSpectrum = null;

                // Get the spectra depending on on the validation type
                if(result.ValidationBy == "Cit-paired")
                {
                    var spec = Quantification.citSpecSpecDict.Where(citSpec => citSpec.Key.ID == result.CitSpectrumID).First();
                    citSpectrum = spec.Key;
                    argSpectrum = spec.Value;
                }
                else if(result.ValidationBy == "Arg-paired")
                {
                    var spec = Quantification.argSpecScanDict.Where(citSpec => citSpec.Value.ScanNumber == result.CitSpectrumID).First();
                    citSpectrum = spec.Value;
                    argSpectrum = spec.Key;
                }
                else if(result.ValidationBy == "Lone")
                {
                    citSpectrum = Quantification.loneCitSpecList.Where(citSpec => citSpec.ID == result.CitSpectrumID).First();
                    argSpectrum = null;
                }
                else
                {
                    // If it is none if them, something is wrong. Write to debug console and contine
                    System.Console.WriteLine($"WARNING: Quantification result (Citrullination: ID {result.CitSpectrumID} from '{result.CitFileName}'." +
                        $"Arginine: ID {result.ArgSpectrumID} from '{result.ArgFileName})' has an invalid validation type '{result.ValidationBy}'");
                    continue;
                }

                // Add data to dictionary
                dict.Add(result, new KeyValuePair<MsSpectrum, MsSpectrum>(citSpectrum, argSpectrum));
            }

            // Return result
            return dict;

        }
    }
}
