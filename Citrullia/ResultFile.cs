using System.Collections.Generic;
using Newtonsoft.Json;

namespace Citrullia
{
    /// <summary>
    /// The class containg the result pair consiting.
    /// </summary>
    [JsonObject]
    internal class ResultPair
    {
        /// <summary>The MGX file name.</summary>
        [JsonProperty]
        internal string MGXFile { get; private set; }

        /// <summary>The X!Tandem result file name.</summary>
        [JsonProperty]
        internal string XTandemFile { get; private set; }


        /// <summary>
        /// Create a new instance of <see cref="ResultPair"/> to export to file.
        /// </summary>
        /// <param name="mgxFile">The filename of the MGX file.</param>
        /// <param name="xTandemFile">The filename of the X!Tandem result file.</param>
        [JsonConstructor]
        internal ResultPair(string mgxFile, string xTandemFile)
        {
            MGXFile = mgxFile;
            XTandemFile = xTandemFile;
        }
    }

    /// <summary>
    /// The class representing the result file.
    /// </summary>
    [JsonObject]
    internal class ResultFile
    {

        /// <summary>The list of <see cref="ResultPair"/>.</summary>
        [JsonProperty]
        internal List<ResultPair> Results { get; set; }

        /// <summary>The dictionary of indices for the citrullinated spectra and complementary spectra marked for quantification.</summary>
        [JsonProperty]
        internal Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> QuantifiedCitrullinatedSpectra { get; set; }
        /// <summary>The dictionary of indices for the arginine spectra and complementary spectra marked for quantification.</summary>
        [JsonProperty]
        internal Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> QuantifiedArginineSpectra { get; set; }
        /// <summary>The dictionary of indices for the lone citrullinated spectra and complementary spectra marked for quantification.</summary>
        [JsonProperty]
        internal Dictionary<string, List<int>> QuantifiedLoneCitrullinatedSpectra { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="ResultFile"/>.
        /// </summary>
        /// <param name="_results">The list of result pairs.</param>
        /// <param name="_quantifiedCitrullinatedSpectra">The two dictionaries containing the filename of the spectra files and a list Keyvaluepairs with the index of the quantified citrullinated spectrum and their complementary arginine spectrum.</param>
        /// <param name="_quantifiedArginineSpectra">The two dictionaries containing the filename of the spectra files and a list of Keyvaluepairs with the index of the quantified arginine spectrum and their complementary citrullinated spectrum.</param>
        /// <param name="_quantifiedLoneCitrullinatedSpectra">The dictionary with the filename and a list of the indecies of the quantified lone spectra.</param>
        [JsonConstructor]
        internal ResultFile(List<ResultPair> _results, Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> _quantifiedCitrullinatedSpectra,
            Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> _quantifiedArginineSpectra, Dictionary<string, List<int>> _quantifiedLoneCitrullinatedSpectra)
        {
            Results = _results;
            QuantifiedCitrullinatedSpectra = _quantifiedCitrullinatedSpectra;
            QuantifiedArginineSpectra = _quantifiedArginineSpectra;
            QuantifiedLoneCitrullinatedSpectra = _quantifiedLoneCitrullinatedSpectra;
        }

        /// <summary>
        /// Create a new instance of <see cref="ResultFile"/> to export to file.
        /// </summary>
        /// <param name="filePairs">The dictionary containing the MGX-file and the X!Tandem file.</param>
        /// <param name="quantCitSpectra">The two dictionaries containing the filename of the spectra files and a list Keyvaluepairs with the index of the quantified citrullinated spectrum and their complementary arginine spectrum.</param>
        /// <param name="quantArgSpectra">The two dictionaries containing the filename of the spectra files and a list of Keyvaluepairs with the index of the quantified arginine spectrum and their complementary citrullinated spectrum.</param>
        /// <param name="quantLoneCitSpectra">The dictionary with the filename and a list of the indecies of the quantified lone spectra.</param>
        internal ResultFile(Dictionary<string, string> filePairs, Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> quantCitSpectra,
                          Dictionary<string, Dictionary<string, List<KeyValuePair<int, int>>>> quantArgSpectra, Dictionary<string, List<int>> quantLoneCitSpectra)
        {
            // Initalize the list of results
            Results = new List<ResultPair>();
            foreach (KeyValuePair<string, string> file in filePairs)
            {
                Results.Add(new ResultPair(file.Key, file.Value));
            }

            QuantifiedCitrullinatedSpectra = quantCitSpectra;
            QuantifiedArginineSpectra = quantArgSpectra;
            QuantifiedLoneCitrullinatedSpectra = quantLoneCitSpectra;


        }

    }
}
