using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Citrullia
{
    /// <summary>
    /// Validation form for citrullinations.
    /// </summary>

    internal partial class ValidationLoneCitUI : Form
    {
        readonly FormMain mainWindow;
        /// <summary>
        /// Create an instance of <see cref="ValidationLoneCitUI"/>.
        /// </summary>
        /// <param name="callingForm">The form calling this form.</param>
        internal ValidationLoneCitUI(FormMain callingForm)
        {
            InitializeComponent();
            mainWindow = callingForm;

            int index = mainWindow.lonelySpectrumValID;
            UpdateValidationUI(index);
        }

        private static XTSpectrum valSpec = new XTSpectrum();

        #region Move form using mouse
        /// <summary>
        /// Move form around using mouse.
        /// Source: https://stackoverflow.com/a/7125686
        /// </summary>
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, NativeMethods.ZERO_INTPTR);
            }
        }
        #endregion

        /// <summary>
        /// Find the spectrum.
        /// </summary>
        /// <param name="spectrumId">The spectrum ID.</param>
        internal void FindSpec(int spectrumId)
        {
            // Loop through each of the validation results
            foreach (ValResult result in Validation.citValResults)
            {
                // Loop through all of the spectra and find the spectrum with the id that matches the given id.
                foreach (XTSpectrum spec in result.ModifiedSpectra)
                {
                    if (spec.ID == spectrumId)
                    {
                        ReturnSpec(spec);
                    }
                }
            }
        }

        private static XTSpectrum ReturnSpec(XTSpectrum spec)
        {
            valSpec = spec;
            return valSpec;
        }

        /// <summary>
        /// Update the spectrum validation.
        /// </summary>
        /// <param name="spectrumValID">The spectrum ID.</param>
        internal void UpdateValidationUI(int spectrumValID)
        {
            // Find the spectrum
            FindSpec(spectrumValID);
            // Update the MS2 chart
            ValidationUIUtilities.ClearChart(chartMS2);
            ValidationUIUtilities.CreateLoneCitMs2Chart(chartMS2, valSpec);
            // Update the MS1 chart
            ValidationUIUtilities.ClearChart(chartMS1);
            ValidationUIUtilities.CreateMS1Chart(chartMS1, valSpec);
            // Fill the ion grid
            ValidationUIUtilities.FillCitIonGrid(metroGridCitIons, valSpec);
            // Update the quantification buttons.
            EnableQuantButtons(valSpec);
            // Add the citrullination information
            AddCitInfo();
        }
        /// <summary>
        /// Add the citrullination information.
        /// </summary>
        private void AddCitInfo()
        {
            XTSpectrum citSpec = valSpec;
            metroLabelID.Text = citSpec.ID.ToString();
            metroLabelCitPMass.Text = Math.Round(citSpec.ParentMass, 3).ToString();
            metroLabelCitCharge.Text = citSpec.ParentIonCharge.ToString();
            metroLabelCitSeq.Text = citSpec.Proteins[0].DoaminSeq;
            metroLabelCitEval.Text = citSpec.SpectrumEVal.ToString();
            metroLabelCitRTime.Text = string.Format("{0} sec.", citSpec.RetentionTime);
            metroLabelCitMS1RTime.Text = string.Format("{0} sec.", citSpec.ParentScan.RetentionTime);
            metroLabelCitFileName.Text = citSpec.OriginalFileName.Split('.')[0];
            metroLabelCitScore.Text = citSpec.CitScore.ToString();
        }

        #region Peak tool tips
        Point? prevPositionMs1 = null;
        readonly ToolTip tooltipMs1 = new ToolTip();

        private void ChartMS1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the location and if the location is valid and does have a value, continue
            var pos = e.Location;
            if (prevPositionMs1.HasValue && pos == prevPositionMs1.Value)
                return;
            // Remove previous tool tips
            tooltipMs1.RemoveAll();
            // Set the previous position to the current position
            prevPositionMs1 = pos;
            // Try to find all of the hits
            var results = chartMS1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            // Loop through all of the hits and limit the search to datapoints that have a DataPoint object
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        // Get the pixel position
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // Check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 15)
                        {
                            // Show the tool tip
                            tooltipMs1.Show("m/z = " + prop.XValue + ", Intensity = " + Math.Abs(prop.YValues[0]).ToString("E1"), chartMS1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        Point? prevPositionMs2 = null;
        readonly ToolTip tooltipMs2 = new ToolTip();

        private void ChartMS2_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the location and if the location is valid and does have a value, continue
            var pos = e.Location;
            if (prevPositionMs2.HasValue && pos == prevPositionMs2.Value)
                return;
            // Remove previous tool tips
            tooltipMs2.RemoveAll();
            // Set the previous position to the current position
            prevPositionMs2 = pos;
            // Try to find all of the hits
            var results = chartMS2.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            // Loop through all of the hits and limit the search to datapoints that have a DataPoint object
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        // Get the pixel position
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 15)
                        {
                            // Show the tool tip
                            tooltipMs2.Show("m/z = " + prop.XValue + ", Intensity = " + Math.Abs(prop.YValues[0]), chartMS2,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
        #endregion

        #region Buttons / Clickable objects
        /// <summary>
        /// Add the spectrum to quantification.
        /// </summary>
        private void MetroButtonAddQuant_Click(object sender, EventArgs e)
        {
            // Get the spectrum
            XTSpectrum spectrumCit = valSpec;
            // Add the spectrum to the dictionary
            Quantification.AddToLoneCitSpecList(spectrumCit);
            // Update the quantification id list
            UpdateChosenForQuant(valSpec.ID, true);

            // Enable and disable the button
            metroButtonAddQuant.Enabled = false;
            metroButtonRemoveQuant.Enabled = true;
        }

        /// <summary>
        /// Remove the spectrum from quantification.
        /// </summary>
        private void MetroButtonRemoveQuant_Click(object sender, EventArgs e)
        {
            // Remove the spectrum from the dictionary
            Quantification.RemoveFromLoneCitSpecList(valSpec);
            // Update the quantification id list
            UpdateChosenForQuant(valSpec.ID, false);

            // Enable and disable the button
            metroButtonRemoveQuant.Enabled = false;
            metroButtonAddQuant.Enabled = true;
        }

        /// <summary>
        /// Reset the zoom on the MS2.
        /// </summary>
        private void MetroButtonZoomResetMS2_Click(object sender, EventArgs e)
        {
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }

        /// <summary>
        /// Reset the zoom on the MS1.
        /// </summary>
        private void MetroButtonResetZoomMS1_Click(object sender, EventArgs e)
        {
            chartMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }

        /// <summary>
        /// Save the MS2 chart.
        /// </summary>
        private void MetroButtonSaveMS2_Click(object sender, EventArgs e)
        {
            // Get the filepath
            if (FileReader.GetImageOutputPathViaDialog(out string filePath))
            {
                // If it is not empty save the image
                chartMS2.SaveImage(filePath, ChartImageFormat.Tiff);
            }
            else
            {
                // If no destination was selected, notify user
                MessageBox.Show("No file destination were selected!");
            }
        }

        /// <summary>
        /// Save the MS1 chart.
        /// </summary>
        private void MetroButtonSaveMS1Cit_Click(object sender, EventArgs e)
        {
            // Get the filepath
            if (FileReader.GetImageOutputPathViaDialog(out string filePath))
            {
                // If it is not empty save the image
                chartMS2.SaveImage(filePath, ChartImageFormat.Tiff);
            }
            else
            {
                // If no destination was selected, notify user
                MessageBox.Show("No file destination were selected!");
            }
        }

        /// <summary>
        /// Export the ion grid.
        /// </summary>
        private void MetroButtonExportDataGrid_Click(object sender, EventArgs e)
        {
            // Check if the background worker is working
            if (backgroundWorkerExport.IsBusy == false)
            {
                // If not, run the worker
                backgroundWorkerExport.RunWorkerAsync();
            }
            else
            {
                // If it is, notify the user
                MessageBox.Show("Still making the Excel file...");
            }
        }

        /// <summary>
        /// Exit the form.
        /// </summary>
        private void LabelExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        /// <summary>
        /// Update which spectra should be quantitised.
        /// </summary>
        /// <param name="id">The spectrum id.</param>
        /// <param name="state">True, if should be added; If false, it should be removed.</param>
        /// <returns>The new list of spectra that should be quantitised.</returns>
        private List<int> UpdateChosenForQuant(int id, bool state)
        {
            // Check if the spectrum should be added or removed
            if (state == true)
            {
                // If it should be added, add it to the list.
                Validation.loneCitChosenForQuantList.Add(id);
            }
            else
            {
                // If it should be removed, remove it to the list.
                Validation.loneCitChosenForQuantList.Remove(id);
            }
            // Return the new list of spectra that should be quantitised
            return Validation.argChosenForQuantList;
        }

        /// <summary>
        /// Check what state the quantificaation buttons should be in. 
        /// </summary>
        /// <param name="spec">The spectrum.</param>
        private void EnableQuantButtons(XTSpectrum spec)
        {
            // Check if the quantification list contains the spectrum.
            if (Validation.loneCitChosenForQuantList.Contains(spec.ID))
            {
                // If so, disable the add button
                metroButtonAddQuant.Enabled = false;
                // Enable the remove button
                metroButtonRemoveQuant.Enabled = true;
            }
            else
            {
                // If not, enable the add button
                metroButtonAddQuant.Enabled = true;
                // Disable the remove button
                metroButtonRemoveQuant.Enabled = false;
            }
        }

        /// <summary>
        /// Background worker - Export ion grid.
        /// </summary>
        private void BackgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            Export.ExportDataGridLonely(metroGridCitIons, valSpec.ID);
        }


    }
}
