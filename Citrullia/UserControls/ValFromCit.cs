﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>Validation from citrullinations.</summary>
    internal partial class ValFromCit : UserControl
    {
        /// <summary>
        /// Create an instance of <see cref="ValFromCit"/>.
        /// </summary>
        internal ValFromCit()
        {
            InitializeComponent();
            metroSpinner.Visible = false;
            metroSpinner.Spinning = false;
        }

       /// <summary>Default parent mass error: 0.05.</summary>
        internal double pMError = 0.05;

        /// <summary>
        /// Find the citrullinated spectra.
        /// </summary>
        private void MetroButtonFindCitSpectra_Click(object sender, EventArgs e)
        {
            // Check if background worker is running.
            if (backgroundWorker.IsBusy == false)
            {
                // If not, give user feedback
                metroSpinner.Visible = true;
                metroSpinner.Spinning = true;
                // Run the background worker
                backgroundWorker.RunWorkerAsync(pMError);
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
            // Parse the parent mass error
            double bgwPMError = Convert.ToDouble(e.Argument, FileReader.NumberFormat);
            // Find the citrullinated spectra
            Validation.FindCitrullinatedSpectra();
            // Find the complementary spectra
            Validation.FindComplementaryArginineSpectra(bgwPMError);
            // Loop through all of the validation results
            foreach (ValResult result in Validation.citValResults)
            {
                // Score the citrullinated spectra
                result.CitSpectraDictionary = ScoreFunction.ScoreCitrullinationSpectra(result.CitSpectraDictionary);
            }

            if (FileReader.fileLoadMode == FileLoadMode.ResultFile)
            {
                FileReader.LoadQuantifiedCitSpectra();
            }
        }

        /// <summary>
        /// Background worker - Done finding spectra.
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update the data grid with information
            UpdateGrid(metroGridSelectedPeptides);
            // Set user feedback
            metroSpinner.Spinning = false;
            metroSpinner.Visible = false;
            metroLabelProgress.Text = "";
        }

        /// <summary>
        /// Change parent mass error when changed in textbox.
        /// </summary>
        private void MetroTextBoxMPmz_TextChanged(object sender, EventArgs e)
        {
            double error = double.Parse(metroTextBoxMPmz.Text, FileReader.NumberFormat);
            ReturnPMError(error);
        }
        
        /// <summary>
        /// Open validation window for a spectrum.
        /// </summary>
        /// <param name="spectrumID">The spectrum ID.</param>
        private void ValidationWindow(int spectrumID)
        {
            FormMain myParent = (FormMain)Parent.Parent.Parent;
            myParent.OpenCitValidationWindow(spectrumID);
        }

        private double ReturnPMError(double error)
        {
            pMError = error;
            return pMError;
        }

        /// <summary>
        /// Update the grid.
        /// </summary>
        /// <param name="grid">The data grid to be updated.</param>
        private void UpdateGrid(DataGridView grid)
        {
            // Clear the grid
            grid.Rows.Clear();
            // Loop through the validation results
            foreach (ValResult result in Validation.citValResults)
            {
                // Loop through the spectra in the validation result
                foreach (KeyValuePair<XTSpectrum, List<XTSpectrum>> kvp in result.CitSpectraDictionary)
                {
                    // Get the spectrum ID
                    string id = kvp.Key.ID.ToString();
                    // Get the protein label
                    string wholeProtein = kvp.Key.Proteins[0].ProtLabel.ToString();
                    // Get the e-value for the spectrum
                    string eVal = kvp.Key.SpectrumEVal.ToString();
                    // Get the number of scans
                    string spectraCount = kvp.Value.Count().ToString();
                    // Get the score
                    string score = kvp.Key.CitScore.ToString();
                    // Get the max match score
                    string matchScore = "";
                    if (kvp.Value.Count > 0)
                    {
                        matchScore = kvp.Value.Select(scan => scan.MatchScore).ToArray()[0].ToString();
                    }
                    else
                    {
                        matchScore = "N/A";
                    }

                    // Get the sequence of the protein
                    string sequence = kvp.Key.Proteins[0].DoaminSeq;
                    // Get the filename
                    string fileName = result.ParentResult.OriginalInputFile.Split('.').First();
                    // Set the row
                    string[] row = { wholeProtein, sequence, score, matchScore, eVal, id, spectraCount };
                    // Add the row
                    grid.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// An new spectrum has been selected.
        /// </summary>
        private void MetroGridSelectedPeptides_SelectionChanged(object sender, EventArgs e)
        {
            if(metroGridSelectedPeptides.SelectedRows.Count > 0)
            {
                // Get the spectrum id
                var spectrumID = Convert.ToInt32(metroGridSelectedPeptides.SelectedRows[0].Cells[5].Value);
                // Loop through the validation results
                foreach (ValResult result in Validation.citValResults)
                {
                    // Loop through the spectras to find the correct spectra
                    foreach (KeyValuePair<XTSpectrum, List<XTSpectrum>> kvp in result.CitSpectraDictionary)
                    {
                        if (kvp.Key.ID == spectrumID)
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