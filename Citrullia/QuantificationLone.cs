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
    internal partial class QuantificationLone : Form
    {
        MsSpectrum citSpectrum;
        QuantResult _result;
        /// <summary>
        /// Create a new instance of <see cref="QuantificationLone"/>.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        internal QuantificationLone(QuantResult result)
        {
            InitializeComponent();
            UpdateWindow(result);
        }

        /// <summary>
        /// Close the window.
        /// </summary>
        private void LabelExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimize the window.
        /// </summary>
        private void LabelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Update the  window
        /// </summary>
        /// <param name="result"></param>
        internal void UpdateWindow(QuantResult result)
        {
            _result = result;
            GetSpectra(_result);
            SetCitInfo();
            ValidationUIUtilities.ClearChart(chartMS1);
            ValidationUIUtilities.ClearChart(chartMS2);
            ValidationUIUtilities.CreateMS1Chart(chartMS1, citSpectrum);
            ValidationUIUtilities.CreateLoneCitMs2Chart(chartMS2, citSpectrum);
            ValidationUIUtilities.FillIonGridGeneral(metroGridCitIons, citSpectrum, HelperUtilities.CreateAAArray(_result.Sequence));
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
        /// Set the quantification information.
        /// </summary>
        private void SetCitInfo()
        {
            // Get and set the scan id and protein
            string scanIDProtein = string.Format("{0} / {1}", _result.CitSpectrumID, _result.Protein.Split('|')[0]);
            metroLabelID.Text = scanIDProtein;
            metroLabelCitSeq.Text = _result.Sequence;
            metroLabelCitCharge.Text = citSpectrum.Charge.ToString();
            double pMass = 1.007276470;
            metroLabelCitPMass.Text = Math.Round((citSpectrum.PreCursorMz * citSpectrum.Charge) - ((citSpectrum.Charge - 1) * pMass), 3).ToString();
            metroLabelCitRTime.Text = string.Format("{0} sec.", citSpectrum.RetentionTime);
            // Set the retention time
            metroLabelCitMS1RTime.Text = string.Format("{0} sec.", citSpectrum.ParentScan.RetentionTime);
            // Set the filename
            metroLabelCitFileName.Text = citSpectrum.OriginalFileName.Split('.')[0];
            metroLabelCitScore.Text = citSpectrum.CitScore.ToString();
        }

        /// <summary>
        /// Get the spectra from the new quantification.
        /// </summary>
        /// <param name="result">The quantification result.</param>
        private void GetSpectra(QuantResult result)
        {
            // Get the cit spectrum ID
            int citSpectrumId = result.CitSpectrumID;
            foreach (var item in Quantification.loneCitSpecList)
            {
                if (item.ID == citSpectrumId)
                {
                    citSpectrum = item;
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
        /// Add the result to quantification.
        /// </summary>
        private void MetroButtonAddQuant_Click(object sender, EventArgs e)
        {
            Quantification.QuantificationResults.Add(_result);
            metroButtonAddQuant.Enabled = false;
            metroButtonRemoveQuant.Enabled = true;
        }
        /// <summary>
        /// Remove the result to quantification.
        /// </summary>
        private void MetroButtonRemoveQuant_Click(object sender, EventArgs e)
        {
            Quantification.QuantificationResults.Remove(_result);
            metroButtonAddQuant.Enabled = true;
            metroButtonRemoveQuant.Enabled = false;
        }


        #region Tool tip
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


        #region Save and reset zoom on MS1 and MS2 chart
        /// <summary>
        /// Save the MS2 chart as an image.
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
        /// Save the MS1 chart as an image.
        /// </summary>
        private void MetroButtonSaveMS1Cit_Click(object sender, EventArgs e)
        {
            // Get the filepath
            if (FileReader.GetImageOutputPathViaDialog(out string filePath))
            {
                // If it is not empty save the image
                chartMS1.SaveImage(filePath, ChartImageFormat.Tiff);
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
        /// Reset the zoom on the MS1 chart.
        /// </summary>
        private void MetroButtonResetZoomMS1_Click(object sender, EventArgs e)
        {
            chartMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        #endregion

        #region Export ion grid
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
            Export.ExportDataGridLonely(metroGridCitIons, _result.CitSpectrumID);
        }
        #endregion


    }
}