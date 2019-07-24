using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Citrullia.UserControls
{
    /// <summary>The quantification screen.</summary>
    internal partial class MS1Val : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="MS1Val"/>.
        /// </summary>
        internal MS1Val()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start quantification.
        /// </summary>
        private void MetroButtonQuantification_Click(object sender, EventArgs e)
        {
            // Perform the quantification
            Quantification.DoQuantification();
            // Add the quantification results to the list
            AddQuantResultsToGrid(metroGridQuantification);
        }

        /// <summary>
        /// Change the retention time.
        /// </summary>
        private void MetroTextBoxRTInterval_TextChanged(object sender, EventArgs e)
        {
            // Parse the retention time
            int interval = int.Parse(metroTextBoxRTInterval.Text);
            // Calculate a new PPM for the new interval.
            Quantification.ReturnRTInterval(interval);
        }

        /// <summary>
        /// Change the parent mass tolerence
        /// </summary>
        private void MetroTextBoxPMTolerance_TextChanged(object sender, EventArgs e)
        {
            // Parse the parent mass tolerence
            int tolerance = int.Parse(metroTextBoxPMTolerance.Text);
            // Calculate a new PPM for the new tolerence
            Quantification.ReturnPPM(tolerance);
        }

        /// <summary>
        /// Add the quantification results to the grid.
        /// </summary>
        /// <param name="grid">The grid to be added to.</param>
        private void AddQuantResultsToGrid(DataGridView grid)
        {
            // Clear the grid.
            grid.Rows.Clear();
            // Loop through each of the quantification results and get the variables
            foreach (QuantResult result in Quantification.QuantificationResults)
            {
                
                string protein = result.Protein;
                string sequence = result.Sequence;
                string score = result.Score.ToString();
                string matchScore = result.MatchScore.ToString();
                string citXIC = result.CitrullinatedExtractedIonCount.ToString("G4", CultureInfo.InvariantCulture);
                string argXIC = result.ArginineExtractedIonCount.ToString("G4", CultureInfo.InvariantCulture);
                string citP = Math.Round(result.CitPercent, 2).ToString();
                string valBy = result.ValidationBy;
                string citFileName = result.CitFileName;
                string citRetTime = result.CitRetentionTime.ToString();
                string citCharge = result.CitCharge.ToString();
                string citID = result.CitSpectrumID.ToString();
                string argFile = result.ArgFileName;
                string argRetTime = result.ArgRetentionTime.ToString();
                string argCharge = result.ArgCharge.ToString();
                string argID = result.ArgSpectrumID.ToString();
                // Set the row
                string[] row = {  protein, sequence, score, matchScore, citXIC, argXIC, citP, valBy, citID, citFileName, citRetTime, citCharge, argID, argFile, argRetTime, argCharge };
                // Add the row
                grid.Rows.Add(row);
            }
            grid.DefaultCellStyle.SelectionBackColor = grid.DefaultCellStyle.BackColor;
            grid.DefaultCellStyle.SelectionForeColor = grid.DefaultCellStyle.ForeColor;
        }

        /// <summary>
        /// Create the quantification CSV-file.
        /// </summary>
        /// <param name="grid">The grid to be exported.</param>
        /// <param name="csvPath">The path of the CSV-file.</param>
        private void CreateQuantCSV(DataGridView grid, string csvPath)
        {
            // Create the StreamWriter as a resource.
            using (var csvWriter = new StreamWriter(csvPath, false))
            {
                // Write the seperator symbol
                csvWriter.WriteLine("sep=;");
                // Create a holder for the header line
                string headers = "";
                // Loop through the headers in the data grid and add them to the line. TODO: Create StreamWriter.
                for (int i = 0; i <= grid.Columns.Count-1; i++)
                {
                    if (i == grid.Columns.Count-1)
                    {
                        headers += grid.Columns[i].HeaderText;
                    }
                    else
                    {
                        headers += grid.Columns[i].HeaderText + ";";
                    }
                }
                // Write the headers to the file
                csvWriter.WriteLine(headers);
                // Loop through each of the rows and get the data.
                foreach (DataGridViewRow row in grid.Rows)
                {
                    string protein = row.Cells[0].Value.ToString();
                    string sequence = row.Cells[1].Value.ToString();
                    string score = row.Cells[2].Value.ToString();
                    string matchScore = row.Cells[3].Value.ToString();
                    string citXIC = row.Cells[4].Value.ToString();
                    string argXIC = row.Cells[5].Value.ToString();
                    string citP = row.Cells[6].Value.ToString();
                    string valBy = row.Cells[7].Value.ToString();
                    string citID = row.Cells[8].Value.ToString();
                    string citFile = row.Cells[9].Value.ToString();
                    string citRetTime = row.Cells[10].Value.ToString();
                    string citCharge = row.Cells[11].Value.ToString();
                    string argID = row.Cells[12].Value.ToString();
                    string argFile = row.Cells[13].Value.ToString();
                    string argRetTime = row.Cells[14].Value.ToString();
                    string argCharge = row.Cells[15].Value.ToString();
                    // Write the data to the line
                    csvWriter.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15}",
                        protein, sequence, score, matchScore, citXIC, argXIC, citP, valBy, citID, citFile, citRetTime, citCharge, argID, argFile, argRetTime, argCharge );
                }
            }
            // Notify the user that the results has been exported.
            string message = "Quantification results have been exported!";
            MessageBox.Show(message);
        }

        /// <summary>
        /// Get the output path via SaveFileDialog.
        /// </summary>
        /// <returns>The output path.</returns>
        internal string GetOutputPathViaDialog(out bool isCanceled)
        {
            //Makes new FileDialog and sets its parameters: 
            SaveFileDialog sFD = new SaveFileDialog
            {
                FileName = "QuantResults",
                Filter = "CSV (.csv) | *.csv"
            };
            //Opens the Dialog window, selects files, and parse filepaths as list:
            DialogResult dr = sFD.ShowDialog();
            string filePath = "";
            if (dr == DialogResult.OK)
            {
                filePath = sFD.FileName;
                isCanceled = false;
            }
            else
            {
                isCanceled = true;
            }
            // Return the filepath
            return filePath;
        }

        /// <summary>
        /// Export to CSV.
        /// </summary>
        private void MetroButtonExportCSV_Click(object sender, EventArgs e)
        {
            // Get the output path
            string csvPath = GetOutputPathViaDialog(out bool isCanceled);
            // If the operation isn't canceled
            if (isCanceled == false)
            {
                // Create quantification CSV
                CreateQuantCSV(metroGridQuantification, csvPath);
            }
        }

        /// <summary>
        /// Get the output path via SaveFileDialog.
        /// </summary>
        /// <returns>The output path.</returns>
        internal string GetResultPathViaDialog(out bool isCanceled)
        {
            //Makes new FileDialog and sets its parameters: 
            SaveFileDialog sFD = new SaveFileDialog
            {
                FileName = "QuantResults",
                Filter = "Citrullia result-file (*.CRX)|*.CRX"
            };
            //Opens the Dialog window, selects files, and parse filepaths as list:
            DialogResult dr = sFD.ShowDialog();
            string filePath = "";
            if (dr == DialogResult.OK)
            {
                filePath = sFD.FileName;
                isCanceled = false;
            }
            else
            {
                isCanceled = true;
            }
            // Return the filepath
            return filePath;
        }
        /// <summary>
        /// Get the folder via a FolderBrowserDialog.
        /// </summary>
        /// <param name="isCanceled">Indicator that the action was cancelled or that the directory does not exist.</param>
        /// <returns>The path to the folder.</returns>
        internal string GetFolderViaDialog(out bool isCanceled)
        {
            //Makes new FileDialog and sets its parameters: 
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            //Opens the Dialog window, selects files, and parse filepaths as list:
            DialogResult dr = fBD.ShowDialog();
            string filePath = "";
            if (dr == DialogResult.OK)
            {
                filePath = fBD.SelectedPath;
                isCanceled = false;
            }
            else
            {
                isCanceled = true;
            }

            if (Directory.Exists(filePath) == false) isCanceled = true;
            // Return the filepath
            return filePath;
        }
        /// <summary>
        /// Save result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButtonSaveResult_Click(object sender, EventArgs e)
        {
            metroLoadingSpinner.Visible = true;
            metroLoadingSpinner.Spinning = true;
            FileReader.GenerateResultFile(Quantification.QuantificationResults);
            metroLoadingSpinner.Visible = false;
            metroLoadingSpinner.Spinning = false;
        }

        /// <summary>
        /// Save MS2 images.
        /// </summary>
        private void MetroButtonSaveImages_Click(object sender, EventArgs e)
        {
            if (Quantification.QuantificationResults.Count > 0)
            {
                // Get path of where the result should be stored
                string savePath = GetFolderViaDialog(out bool isCanceled);
                // Check that the saving was not 
                if (isCanceled == false)
                {
                    metroLoadingSpinner.Visible = true;
                    metroLoadingSpinner.Spinning = true;
                    SpectrumWriterUI writerUI = new SpectrumWriterUI(savePath, metroToggleAnnoFile.Checked);
                    //_ = new ChartWriterUI(savePath, metroToggleAnnoFile.Checked);
                    metroLoadingSpinner.Visible = false;
                    metroLoadingSpinner.Spinning = false;
                }
            }

        }

        #region Quantification validation
        private void MetroGridQuantification_SelectionChanged(object sender, EventArgs e)
        {
            // Check that the validation is enabled
            if (metroToggleValEnabled.Checked)
            {
                if(metroGridQuantification.SelectedRows.Count > 0)
                {
                    int spectrumID = Convert.ToInt32(metroGridQuantification.SelectedRows[0].Cells[8].Value);
                    QuantResult selectedResult = Quantification.QuantificationResults.Where(res => res.CitSpectrumID == spectrumID).FirstOrDefault();
                    
                    // Check validation type
                    if(selectedResult.ValidationBy == "Lone")
                    {
                        OpenLoneValidationWindow(selectedResult);
                    }
                    else
                    {
                        OpenPairedValidationWindow(selectedResult);
                    }
                }
            }
        }


        QuantificationPaired quantificationPairedUI;
        QuantificationLone quantificationLoneUI;

        /// <summary>
        /// Open the window for paired validation.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        internal void OpenPairedValidationWindow(QuantResult result)
        {
            // Check if an form already is open
            if (Application.OpenForms.OfType<QuantificationPaired>().Count() == 1)
            {
                // If form is already open, update the validation form.
                quantificationPairedUI.UpdateWindow(result);
            }
            else
            {
                // If a form is not already open, create a new one
                quantificationPairedUI = new QuantificationPaired(result);
                // And show.
                quantificationPairedUI.Show();
            }
        }
        /// <summary>
        /// Open the window for lone validation.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        internal void OpenLoneValidationWindow(QuantResult result)
        {
            // Check if an form already is open
            if (Application.OpenForms.OfType<QuantificationLone>().Count() == 1)
            {
                // If form is already open, update the validation form.
                quantificationLoneUI.UpdateWindow(result);
            }
            else
            {
                // If a form is not already open, create a new one
                quantificationLoneUI = new QuantificationLone(result);
                // And show.
                quantificationLoneUI.Show();
            }
        }

        #endregion

        /// <summary>
        /// Update the quantification grid after having added/removed quantification results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButtonUpdate_Click(object sender, EventArgs e)
        {
            AddQuantResultsToGrid(metroGridQuantification);
        }

        /// <summary>
        /// The validation window toogle state has been changed.
        /// </summary>
        private void MetroToggleValEnabled_CheckedChanged(object sender, EventArgs e)
        {
            // If it is now on, trigger an opening of the quantification validation window
            if (metroToggleValEnabled.Checked)
            {
                MetroGridQuantification_SelectionChanged(this, EventArgs.Empty);
            }
        }
    }
}
