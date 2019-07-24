using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>The home screen.</summary>
    internal partial class StartUC : UserControl
    {
        /// <summary>
        /// Create an instance of <see cref="StartUC"/>.
        /// </summary>
        internal StartUC()
        {
            InitializeComponent();
        }

        #region MGX file loader
        /// <summary>
        /// Load the MGX-files.
        /// </summary>
        private void MetroButtonLoad_Click(object sender, EventArgs e)
        {
            // Check if either of the background workers are running.
            if (backgroundWorkerMGX.IsBusy == false)
            {
                // If no background workers are running
                metroLabelLoadedMGXFiles.Text = "Loading Files...";
                // Get the file paths for the MGX files
                List<string> inputs = FileReader.OpenMGXFilesViaDialog();
                // Check that files was selected
                if (inputs != null & inputs.Any())
                {
                    // Run file loader
                    backgroundWorkerMGX.RunWorkerAsync(inputs);
                    // Give user feedback
                    metroLoadingSpinner.Visible = true;
                    metroLoadingSpinner.Spinning = true;
                }
                else
                {
                    // If no files was selected show message.
                    metroLabelLoadedMGXFiles.Text = "No files were selected...";
                }

            }
            else
            {
                // If background worker is running show message.
                metroLabelLoadedMGXFiles.Text = "Already Loading...";
            }
        }

        /// <summary>
        /// Background worker - MGX File loader
        /// </summary>
        private void BackgroundWorkerMGX_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the files from the input and parse it to a string
            object o = e.Argument;
            List<string> inputs = o as List<string>;
            // Convert MGX to MGF
            FileReader.MakeMGFs(inputs);
            // Create the AA Mass dictionary
            IonCalculation.MakeAaMassDictionary();
            FileReader.fileLoadMode = FileLoadMode.XTandemRun;
        }

        /// <summary>
        /// Background worker MGX file loader complete.
        /// </summary>
        private void BackgroundWorkerMGX_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Give user feedback
            metroLabelLoadedMGXFiles.Text = "All MGX files were loaded!";
            metroLoadingSpinner.Visible = false;
            metroLoadingSpinner.Spinning = false;
            // Change to analysis-form
            ChangeToAnalysis();
        }
        #endregion

        #region Result file loader

        private void BackgroundWorkerResult_DoWork(object sender, DoWorkEventArgs e)
        {
            string resultFilePath = (string)e.Argument;
            FileReader.LoadResults(resultFilePath);
            FileReader.fileLoadMode = FileLoadMode.ResultFile;
            // Create the AA Mass dictionary
            IonCalculation.MakeAaMassDictionary();
        }

        private void BackgroundWorkerResult_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // Give user feedback
            metroLabelLoadedResultFiles.Text = "All result files were loaded!";
            metroLoadingSpinner.Visible = false;
            metroLoadingSpinner.Spinning = false;

            ChangeToAnalysis();
        }
        #endregion
        /// <summary>
        /// Load the result files.
        /// </summary>
        private void MetroButtonLoadResult_Click(object sender, EventArgs e)
        {
            // Check if either of the background workers are running.
            if (backgroundWorkerResult.IsBusy == false)
            {
                // If no background workers are running
                metroLabelLoadedResultFiles.Text = "Loading Files...";
                // Get the file paths for the MGX files
                string resultFilePath = FileReader.OpenResultFileViaDialog();
                if (resultFilePath != "")
                {                   
                    // Run file loader
                    backgroundWorkerResult.RunWorkerAsync(resultFilePath);
                    // Give user feedback
                    metroLoadingSpinner.Visible = true;
                    metroLoadingSpinner.Spinning = true;
                }
                else
                {
                    // If no files was selected show message.
                    metroLabelLoadedMGXFiles.Text = "No files were selected...";
                }

            }
            else
            {
                // If background worker is running show message.
                metroLabelLoadedMGXFiles.Text = "Already Loading...";
            }

        }
        

        /// <summary>Change to analysis-form</summary>
        private void ChangeToAnalysis()
        {
            FormMain myParent = (FormMain)Parent.Parent;
            myParent.ChangeToAnalysis();
        }

        private void BackgroundWorkerResult_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
