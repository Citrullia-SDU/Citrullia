using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>
    /// Validation from lonely citrullinations.
    /// </summary>
    internal partial class ValFromLoneCit : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="ValFromLoneCit"/>.
        /// </summary>
        internal ValFromLoneCit()
        {
            InitializeComponent();
            metroSpinner.Visible = false;
            metroSpinner.Spinning = false;
        }

        /// <summary>
        /// Find the lonely citrullinated spectra.
        /// </summary>
        private void MetroButtonFindCitSpectra_Click(object sender, EventArgs e)
        {
            // Check that the the list of cit validations contains entries.
            if(Validation.citValResults.Count < 1)
            {
                // If not, show warning message and quit out of the method
                MessageBox.Show("Cannot run lone citrullination validation before citrullination validation has ran", "Error - Citrullia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if background worker is running.
            if (backgroundWorker.IsBusy == false)
            {
                // If not, give user feedback
                metroSpinner.Visible = true;
                metroSpinner.Spinning = true;
                // Run the background worker
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                // If the background workeer is running, notify the user that it is running
                metroLabelProgress.Text = "Patients Master...";
            }
        }

        /// <summary>
        /// Background worker - Finding spectra.
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Find the lonely citrullinations
            Validation.FindLonelyCitrullinatedSpectra();
            // Loop through all of the lone citrullinated validation results. TODO: Decide how to score lone citrullinated spectrum.
            foreach (ValResult result in Validation.loneCitValResults)
            {
                result.ModifiedSpectra = ScoreFunction.ScoreLoneCitrullinationSpectra(result.ModifiedSpectra);
            }

            if (FileReader.fileLoadMode == FileLoadMode.ResultFile)
            {
                FileReader.LoadQuantifiedLoneCitSpectra();
            }

        }

        /// <summary>
        /// Background worker - Done finding spectra.
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update the data grid with information
            UpdateGrid(metroGridSelectedPeptides);
            metroSpinner.Visible = false;
            metroSpinner.Spinning = false;
            metroLabelProgress.Text = "";
        }
 
        /// <summary>
        /// Open a validation window.
        /// </summary>
        /// <param name="spectrumID">The ID of the spectra to be validated.</param>
        private void ValidationWindow(int spectrumID)
        {
            FormMain myParent = (FormMain)Parent.Parent.Parent;
            myParent.OpenLonelyValidationWindow(spectrumID);
        }

        /// <summary>
        /// Update data grid.
        /// </summary>
        /// <param name="grid">The grid to be updated.</param>
        private void UpdateGrid(DataGridView grid)
        {
            // Clear the grid
            grid.Rows.Clear();
            // Loop through all of the validation results
            foreach (ValResult result in Validation.loneCitValResults)
            {
                // Loop through all of the spectra in the validation result
                foreach (XTSpectrum spec in result.ModifiedSpectra)
                {
                    // Get the spectrum ID
                    string id = spec.ID.ToString();
                    // Get the protein label
                    string wholeProtein = spec.Proteins[0].ProtLabel.ToString();
                    // Get the e-value for the spectrum
                    string eVal = spec.SpectrumEVal.ToString();
                    // Get the number of scans
                    string spectraCount = "0";
                    // Get the score
                    string score = spec.CitScore.ToString();
                    // Get the sequence of the protein
                    string sequence =spec.Proteins[0].DoaminSeq;
                    // Get the filename
                    string fileName = result.ParentResult.OriginalInputFile.Split('.').First();
                    // Set the row
                    string[] row = { wholeProtein, sequence, score, eVal, id, spectraCount };
                    // Add the row
                    grid.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// An new spectrum has been sellected.
        /// </summary>
        private void MetroGridSelectedPeptides_SelectionChanged(object sender, EventArgs e)
        {
            if (metroGridSelectedPeptides.SelectedRows.Count > 0)
            {
                // Get the spectrum id
                var spectrumID = Convert.ToInt32(metroGridSelectedPeptides.SelectedRows[0].Cells[4].Value);
                // Loop through the validation results
                foreach (ValResult result in Validation.loneCitValResults)
                {
                    // Loop through the spectras to find the correct spectra
                    foreach (XTSpectrum spec in result.ModifiedSpectra)
                    {
                        if (spec.ID == spectrumID)
                        {
                            // When the correct spectra is found open the validation window for the spectra.
                            ValidationWindow(spectrumID);
                        }
                    }
                }
            }
        }
    }
}