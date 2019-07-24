using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citrullia
{
    public class CitrulliaFileSettings
    {
        #region Modification filepaths
        /// <summary>The filename of the file that contains variable modifications (Monoisotopic mass).</summary>
        public string VariableModificationsMonoFile { get; }
        /// <summary>The filename of the file that contains variable modifications (Average mass).</summary>
        public string VariableModificationsAverageFile { get; }
        /// <summary>The filename of the file that contains fixed modifications.</summary>
        public string FixedModificationsFile { get; }
        #endregion

        /// <summary>
        /// Create a new instance of <see cref="CitrulliaFileSettings/>.
        /// </summary>
        public CitrulliaFileSettings()
        {
            // Get the current directory
            string currentDir = Environment.CurrentDirectory.ToString();

            // Create the filepaths for the modification files
            VariableModificationsMonoFile = currentDir + @"\Externals\VModMono.txt";
            VariableModificationsAverageFile = currentDir + @"\Externals\VModAvg.txt";
            FixedModificationsFile = currentDir + @"\Externals\\FMod.txt";

        }
    }
}
