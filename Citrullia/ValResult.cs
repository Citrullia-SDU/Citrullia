using System.Collections.Generic;

namespace Citrullia
{
    /// <summary>
    /// Data class the that represent the validation data.
    /// </summary>
    internal class ValResult
    {
        /// <summary>The dictionary with X!Tandem citrullinated spectra and their complementary arginine spectra.</summary>
        internal Dictionary<XTSpectrum, List<XTSpectrum>> CitSpectraDictionary { get; set; }
        /// <summary>The parent X!Tandem result.</summary>
        internal XTResult ParentResult { get; set; }
        /// <summary>The list of citrulliated spectra.</summary>
        internal List<XTSpectrum> ModifiedSpectra { get; set; }
        /// <summary>The list of arginine spectra.</summary>
        internal List<XTSpectrum> ArginineSpectra { get; set; }
        /// <summary>The dictionary with X!Tandem arginine spectra and their complementary citrullinated scans.</summary>
        internal Dictionary<XTSpectrum, List<RawScan>> ArgSpectraDictionary { get; set; }
    }
}
