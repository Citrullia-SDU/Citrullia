using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Citrullia.UserControls
{
    /// <summary>The general parameter control in Analysis.</summary>
    internal partial class AnalGenUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalGenUC"/>.
        /// </summary>
        internal AnalGenUC()
        {
            InitializeComponent();
            FindUsableThreads();
            metroComboBoxThreads.SelectedIndex = 0;
        }

        /// <summary>
        /// Load the form.
        /// </summary>
        private void AnalGenUC_Load(object sender, EventArgs e)
        {
            AddEnzymesToDigestionEnzymeList();
            metroComboBoxEnzyme.SelectedIndex = 0;
        }

        #region Controls       
        /// <summary>
        /// Change the digestion enzyme to be used by X!Tandem.
        /// </summary>
        private void MetroComboBoxEnzyme_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.XTandemInput.Enzyme = metroComboBoxEnzyme.SelectedItem.ToString().ToString().Split(' ').Last();
        }

        /// <summary>
        /// Change the number of threads to be used by X!Tandem.
        /// </summary>
        private void MetroComboBoxThreads_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.XTandemInput.Threads = metroComboBoxThreads.SelectedItem.ToString().Split(' ').First();
        }

        /// <summary>
        /// Indicate if X!Tandem should search "Crap List".
        /// </summary>
        private void MetroToggleSearchCrapList_CheckedChanged(object sender, EventArgs e)
        {
            External.XTandemInput.SearchCrapList = metroToggleSearchCrapList.Checked;
        }

        /// <summary>
        /// Indicates if X!Tandem should refine the spectra.
        /// </summary>
        private void MetroToggleRefine_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleRefine.Checked == true)
            {
                External.XTandemInput.Refinement = "yes";
            }
            else
            {
                External.XTandemInput.Refinement = "no";
            }
        }

        /// <summary>
        /// Load sequence file used by X!Tandem.
        /// </summary>
        private void MetroBtnLoadSeqFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog
            {
                Filter = "(*.fasta, *.fa, *.fasta.pro)|*.fasta;*.fa;*.fasta.pro",
                Title = "Select Sequence File"
            };
            DialogResult dr = oFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                metroLabelSelectedFile.Text = oFD.FileName.Split('\\').Last();
            }

            External.XTandemInput.SequenceFile = oFD.FileName;
        }
        #endregion

        #region Load data
        /// <summary>
        /// Find the number of usable threads.
        /// </summary>
        private void FindUsableThreads()
        {
            // Get the number of possible system threads.
            int systemThreads = Environment.ProcessorCount;

            // Create an array of numbers.
            int[] threads = Enumerable.Range(1, systemThreads).ToArray();
            // Loop through the array and add it to the thread-combobox
            for (int i = 0; i < threads.Length - 1; i++)
            {
                metroComboBoxThreads.Items.Add(string.Format("{0} out of {1}", i + 1, threads.Length));
            }
        }

        /// <summary>
        /// Update the text in the file-textbox.
        /// </summary>
        internal void UpdateTextBoxLFiles()
        {
            // Clear the listbox
            metroTextBoxFiles.Text = "";
            StringBuilder fileStringBuilder = new StringBuilder();
            // Loop through all of the files and add them to the textbox.
            if(FileReader.fileLoadMode == FileLoadMode.ResultFile)
            {
                metroLabelInputFile.Text = "Input Files(.MGX/.XML)";
                foreach (Tuple<string, string> filePair in FileReader.inputResultPairs)
                {
                    fileStringBuilder.AppendFormat("{0} - {1}{2}", filePair.Item1.Split('\\').Last(), filePair.Item2.Split('\\').Last(), "\n");
                }
            }
            else
            {
                metroLabelInputFile.Text = "Input Files(.MGX)";
                foreach (Input input in FileReader.inputFiles)
                {
                    fileStringBuilder.AppendFormat("{0}{1}", input.FilePath.Split('\\').Last(), "\n");
                }
            }

            metroTextBoxFiles.Text = fileStringBuilder.ToString();
        }

        /// <summary>
        /// Add the digestion enzyme to the enzyme-combobox.
        /// </summary>
        private void AddEnzymesToDigestionEnzymeList()
        {
            // Get the filepath of the enzyme text file;
            string path = External.CitrulliaSettings.DigestionEnzymeFile;

            // Read the lines in the enzyme list
            string[] enzymeLines = File.ReadAllLines(path);
            // Loop through each of the lines and add the enzyme to the list
            foreach (string line in enzymeLines)
            {
                metroComboBoxEnzyme.Items.Add(line);
            }
        }
        #endregion


    }
}
