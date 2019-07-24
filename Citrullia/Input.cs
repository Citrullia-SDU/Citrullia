using System.Collections.Generic;

namespace Citrullia
{
    /// <summary>Data class that represents the Mascot Generic Extended-file input (.MGX-files).</summary>
    internal class Input
    {
        /// <summary>The filepath of the input.</summary>
        internal string FilePath { get; set; }
        /// <summary>The list of MS1 scans.</summary>
        internal List<RawScan> MS1Scans { get; set; }
        /// <summary>The list of MS2 scans.</summary>
        internal List<RawScan> MS2Scans { get; set; }
    }
}
