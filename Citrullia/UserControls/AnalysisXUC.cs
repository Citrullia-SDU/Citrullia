using System;
using System.Windows.Forms;
using System.IO;

namespace Citrullia.UserControls
{
    /// <summary>The main Analysis control.</summary>
    internal partial class AnalysisXUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalysisXUC"/>.
        /// </summary>
        internal AnalysisXUC()
        {
            InitializeComponent();
            analGenUC1.BringToFront();
            panelIndicator.Width = buttonGeneral.Width - 50;
            panelIndicator.Left = buttonGeneral.Left + 25;
        }

        /// <summary>
        /// Run X!Tandem.
        /// </summary>
        private void Run_Click(object sender, EventArgs e)
        {
            panelIndicator.Width = panelBack.Width;
            panelIndicator.Left = panelBack.Left;
            // Delete the existing outputs.
            External.DeleteExistingOutputs();
            if (FileReader.fileLoadMode == FileLoadMode.XTandemRun)
            {
                // Check that the FASTA sequence file has been loaded
                if (string.IsNullOrEmpty(External.XTandemInput.SequenceFile))
                {
                    // Notify the user
                    MessageBox.Show("No Sequence file has been loaded.\nPlease load a sequence file and try again.", "Error - Citrullia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Go to the general page
                    ButtonGeneral_Click(this, EventArgs.Empty);
                    // Return
                    return;
                }

                // Create the taxonomy xml file for X!Tandem
                External.MakeTaxonomyXml();
                // Search for each MGF- input file
                External.XTandemSearchForEachMGF();

                // Check that results exist
                if (Directory.GetFiles(External.CitrulliaSettings.OutputXTandemFilesFolder, "*.xml").Length == 0)
                {
                    // Notify the user
                    MessageBox.Show("No result files was loaded.\nPlease check your settings and try again.", "Error - Citrullia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Return
                    return;
                }
            }
            else if(FileReader.fileLoadMode == FileLoadMode.ResultFile)
            {
                FileReader.CopyXTFilesToOutputFolder();
            }

            // Read the X!Tandem XML results
            FileReader.ReadResultXMLs();

            // Check that results could be read
            if(FileReader.inputFiles.Count == 0)
            {
                // Notify the user
                MessageBox.Show("Result files was found, but no result was read.\nPlease check your settings and try again.", "Error - Citrullia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Return
                return;
            }

            

            // Go to validation.
            ChangeToValdiation();
        }

        /// <summary>
        /// Go to the general analysis-tab.
        /// </summary>
        private void ButtonGeneral_Click(object sender, EventArgs e)
        {
            analGenUC1.BringToFront();
            panelIndicator.Width = buttonGeneral.Width-50;
            panelIndicator.Left = buttonGeneral.Left+25;
        }

        /// <summary>
        /// Go to the parameter-tab.
        /// </summary>
        private void ButtonParameters_Click(object sender, EventArgs e)
        {
            analParUC1.BringToFront();
            panelIndicator.Width = buttonParameters.Width - 30;
            panelIndicator.Left = buttonParameters.Left + 15;
        }

        /// <summary>
        /// Go to the modifications-tab.
        /// </summary>
        private void ButtonModifications_Click(object sender, EventArgs e)
        {
            analModUC1.BringToFront();
            panelIndicator.Width = buttonModifications.Width - 20;
            panelIndicator.Left = buttonModifications.Left + 10;
        }

        /// <summary>
        /// Go to the options-tab.
        /// </summary>
        private void ButtonOptions_Click(object sender, EventArgs e)
        {
            analOptUC1.BringToFront();
            panelIndicator.Width = buttonOptions.Width - 60;
            panelIndicator.Left = buttonOptions.Left + 30;
        }

        /// <summary>
        /// Go to the validation-step.
        /// </summary>
        private void ChangeToValdiation()
        {
            FormMain myParent = (FormMain)Parent.Parent;
            myParent.ChangeToValidation();
        }

        /// <summary>
        /// Update the list of loaded MGX-files.
        /// </summary>
        internal void ChangeAnalGenUCFilesLoadedBox()
        {
            analGenUC1.UpdateTextBoxLFiles();
        }

        /// <summary>
        /// Go to the advanced settings-step.
        /// </summary>
        private void ButtonAdvanced_Click(object sender, EventArgs e)
        {
            analAdvancedUC1.BringToFront();
            panelIndicator.Width = buttonAdvanced.Width - 20;
            panelIndicator.Left = buttonAdvanced.Left + 10;
        }
    }
}
