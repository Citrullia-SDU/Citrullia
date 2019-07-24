using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Citrullia
{
    /// <summary>
    /// Validation form for arginine.
    /// </summary>
    internal partial class QuantificationPaired : Form
    {

        QuantResult _result;
        MsSpectrum citSpectrum;
        MsSpectrum argSpectrum;

        /// <summary>
        /// Create a new instance of <see cref="QuantificationPaired"/>.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        internal QuantificationPaired(QuantResult result)
        {
            InitializeComponent();
            UpdateWindow(result);
        }

        /// <summary>
        /// Update the quantification window.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        internal void UpdateWindow(QuantResult result)
        {
            // Set the result
            _result = result;
            // Get the spectra
            GetSpectra(_result);
            // Add the info
            SetCitInfo();
            SetArgInfo();
            // Clear the charts
            ValidationUIUtilities.ClearChart(chartArgMS1);
            ValidationUIUtilities.ClearChart(chartCitMS1);
            ValidationUIUtilities.ClearChart(chartMS2);
            // Create the charts
            ValidationUIUtilities.CreateMS1Chart(chartArgMS1, argSpectrum);
            ValidationUIUtilities.CreateMS1Chart(chartCitMS1, citSpectrum);
            ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, citSpectrum, argSpectrum);
            // Create the ion grid
            ValidationUIUtilities.FillIonGridGeneral(metroGridArgIons, argSpectrum, HelperUtilities.CreateAAArray(_result.Sequence));
            ValidationUIUtilities.FillIonGridGeneral(metroGridCitIons, citSpectrum, HelperUtilities.CreateAAArray(_result.Sequence));
            // Set the title and spectrum ID
            labelTitel.Text = string.Format("Quantification - Paired (By {0})", _result.ValidationBy);
            metroLabelCitSpectrumID.Text = _result.CitSpectrumID.ToString();
            metroLabelArgSpectrumID.Text = _result.ArgSpectrumID.ToString();

            if (Quantification.QuantificationResults.Contains(result))
            {
                metroButtonAddQuant.Enabled = false;
                metroButtonRemoveQuant.Enabled = true;
            }
            else
            {
                metroButtonAddQuant.Enabled = true;
                metroButtonRemoveQuant.Enabled = false;
            }
        }

        /// <summary>
        /// Set the citrullinated spectra information.
        /// </summary>
        private void SetCitInfo()
        {
            // Get and set the scan id and protein
            string scanIDProtein = string.Format("{0} / {1}", _result.CitSpectrumID, _result.Protein.Split('|')[0]);
            metroLabelCitID.Text = scanIDProtein;
            metroLabelCitCharge.Text = citSpectrum.Charge.ToString();
            double pMass = 1.007276470;
            metroLabelCitPMass.Text = Math.Round((citSpectrum.PreCursorMz * citSpectrum.Charge) - ((citSpectrum.Charge - 1) * pMass), 3).ToString();
            metroLabelCitSeq.Text = _result.Sequence;
            metroLabelCitRTime.Text = string.Format("{0} sec.", citSpectrum.RetentionTime);
            // Set the retention time
            metroLabelCitMS1RTime.Text = string.Format("{0} sec.", citSpectrum.ParentScan.RetentionTime);
            // Set the filename
            metroLabelCitFileName.Text = citSpectrum.OriginalFileName.Split('.')[0];
            metroLabelCitScore.Text = citSpectrum.CitScore.ToString();
        }
        /// <summary>
        /// Set the arginine spectra information.
        /// </summary>
        private void SetArgInfo()
        {
            string scanIDProtein = string.Format("{0} / {1}", _result.ArgSpectrumID, _result.Protein.Split('|')[0]);
            metroLabelArgID.Text = scanIDProtein;
            metroLabelArgCharge.Text = argSpectrum.Charge.ToString();
            double pMass = 1.007276470;
            metroLabelArgPMass.Text = Math.Round((argSpectrum.PreCursorMz * argSpectrum.Charge) - ((argSpectrum.Charge - 1) * pMass), 3).ToString();
            metroLabelArgSeq.Text = _result.Sequence;
            metroLabelArgRTime.Text = string.Format("{0} sec.", argSpectrum.RetentionTime);
            // Set the retention time
            metroLabelArgMS1RTime.Text = string.Format("{0} sec.", argSpectrum.ParentScan.RetentionTime);
            // Set the filename
            metroLabelArgFileName.Text = argSpectrum.OriginalFileName.Split('.')[0];
            metroLabelMatchScore.Text = argSpectrum.MatchScore.ToString();
        }

        /// <summary>
        /// Get the spectra from the new quantification.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        private void GetSpectra(QuantResult result)
        {
            // Get the cit spectrum ID
            int citSpectrumId = result.CitSpectrumID;

            // From the validation type, get the spectra information            
            if (result.ValidationBy == "Cit-paired")
            {
                // Loop through all of the cit spectra to get the spectra
                foreach (var item in Quantification.citSpecSpecDict)
                {
                    if (item.Key.ID == citSpectrumId)
                    {
                        citSpectrum = item.Key;
                        argSpectrum = item.Value;
                    }
                }
            }
            else
            {
                // Loop through all of the arg spectra to get the spectra
                foreach (var item in Quantification.argSpecScanDict)
                {
                    if (item.Value.ScanNumber == citSpectrumId)
                    {
                        citSpectrum = item.Value;
                        argSpectrum = item.Key;
                    }

                }
            }

        }

        #region Form moving with mouse
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
        /// Close the form.
        /// </summary>
        private void LabelExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Minimize the form.
        /// </summary>
        private void LabelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Add result from quantification.
        /// </summary>
        private void MetroButtonAddQuant_Click(object sender, EventArgs e)
        {
            Quantification.QuantificationResults.Add(_result);
            metroButtonAddQuant.Enabled = false;
            metroButtonRemoveQuant.Enabled = true;
        }

        /// <summary>
        /// Remove result from quantification.
        /// </summary>
        private void MetroButtonRemoveQuant_Click(object sender, EventArgs e)
        {
            Quantification.QuantificationResults.Remove(_result);
            metroButtonAddQuant.Enabled = true;
            metroButtonRemoveQuant.Enabled = false;
        }

        #region Save and reset zoom on MS1 and MS2 spectra
        /// <summary>
        /// Save the MS2 chart as image.
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
        /// Reset the zoom on the MS2 chart.
        /// </summary>
        private void MetroButtonZoomResetMS2_Click(object sender, EventArgs e)
        {
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        /// <summary>
        /// Save the MS1 arginine chart as image.
        /// </summary>
        private void MetroButtonSaveMS1Arg_Click(object sender, EventArgs e)
        {
            // Get the filepath
            if (FileReader.GetImageOutputPathViaDialog(out string filePath))
            {
                // If it is not empty save the image
                chartArgMS1.SaveImage(filePath, ChartImageFormat.Tiff);
            }
            else
            {
                // If no destination was selected, notify user
                MessageBox.Show("No file destination were selected!");
            }
        }
        /// <summary>
        /// Reset the zoom on the MS1 arginine chart.
        /// </summary>
        private void MetroButtonResetZoomArgMS1_Click(object sender, EventArgs e)
        {
            chartArgMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartArgMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        /// <summary>
        /// Save the MS1 citrullination chart as image.
        /// </summary>
        private void MetroButtonSaveMS1Cit_Click(object sender, EventArgs e)
        {
            // Get the filepath
            if (FileReader.GetImageOutputPathViaDialog(out string filePath))
            {
                // If it is not empty save the image
                chartCitMS1.SaveImage(filePath, ChartImageFormat.Tiff);
            }
            else
            {
                // If no destination was selected, notify user
                MessageBox.Show("No file destination were selected!");
            }
        }
        /// <summary>
        /// Reset the zoom on the MS1 citrullinations chart.
        /// </summary>
        private void MetroButtonResetZoomCitMS1_Click(object sender, EventArgs e)
        {
            chartCitMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartCitMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        #endregion
        /// <summary>
        /// Export the ion grids.
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
        /// Background worker - Exportation of the ion grids.
        /// </summary>
        private void BackgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            Export.ExportDataGrid(metroGridCitIons, metroGridArgIons, _result.CitSpectrumID, _result.ArgSpectrumID);
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

        Point? prevPositionMs1Arg = null;
        readonly ToolTip tooltipMs1Arg = new ToolTip();

        private void ChartArgMS1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the location and if the location is valid and does have a value, continue
            var pos = e.Location;
            if (prevPositionMs1Arg.HasValue && pos == prevPositionMs1Arg.Value)
                return;
            // Remove previous tool tips
            tooltipMs1Arg.RemoveAll();
            // Set the previous position to the current position
            prevPositionMs1Arg = pos;
            // Try to find all of the hits
            var results = chartArgMS1.HitTest(pos.X, pos.Y, false,
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
                            tooltipMs1Arg.Show("m/z = " + prop.XValue + ", Intensity = " + Math.Abs(prop.YValues[0]).ToString("E1"), chartArgMS1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }


        Point? prevPositionMs1Cit = null;
        readonly ToolTip tooltipMs1Cit = new ToolTip();

        private void ChartCitMS1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the location and if the location is valid and does have a value, continue
            var pos = e.Location;
            if (prevPositionMs1Cit.HasValue && pos == prevPositionMs1Cit.Value)
                return;
            // Remove previous tool tips
            tooltipMs1Cit.RemoveAll();
            // Set the previous position to the current position
            prevPositionMs1Cit = pos;
            // Try to find all of the hits
            var results = chartCitMS1.HitTest(pos.X, pos.Y, false,
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
                            tooltipMs1Cit.Show("m/z = " + prop.XValue + ", Intensity = " + Math.Abs(prop.YValues[0]).ToString("E1"), chartCitMS1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
    }
}
