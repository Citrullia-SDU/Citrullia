using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Citrullia
{
    /// <summary>
    /// Validation form for arginine.
    /// </summary>
    internal partial class ValidationArgUI : Form
    {
        readonly FormMain mainWindow;
        /// <summary>
        /// Create an instance of <see cref="ValidationArgUI"/>.
        /// </summary>
        /// <param name="callingForm">The form calling this form.</param>
        internal ValidationArgUI(FormMain callingForm)
        {
            InitializeComponent();
            // Set the main window
            mainWindow = callingForm;
            // Get the spectrum ID to be viewed
            int index = mainWindow.argSpectrumValID;
            UpdateValidationArgUI(index);


        }

        private static KeyValuePair<XTSpectrum, List<RawScan>> valKVP = new KeyValuePair<XTSpectrum, List<RawScan>>();

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

        #region Adding information to labels
        /// <summary>
        /// Add the arginine data.
        /// </summary>
        private void AddArgInfo()
        {
            // Get the spectrum
            XTSpectrum argSpec = valKVP.Key;
            // Get and set the scan id and protein
            string scanIDProtein = string.Format("{0} / {1}", argSpec.ID, argSpec.SpectrumLabel.Split('|')[1]);
            metroLabelArgID.Text = scanIDProtein;
            // Set the parent mass
            metroLabelArgPMass.Text = Math.Round(argSpec.ParentMass, 3).ToString();
            // Set the charge
            metroLabelArgCharge.Text = argSpec.ParentIonCharge.ToString();
            // Set the sequence
            metroLabelArgSeq.Text = argSpec.Proteins[0].DoaminSeq;
            // Set the spectrum e-value
            metroLabelArgEval.Text = argSpec.SpectrumEVal.ToString();
            // Set the retention time
            metroLabelArgRTime.Text = string.Format("{0} sec.", argSpec.RetentionTime);
            // Set the retention time
            metroLabelArgMS1RTime.Text = string.Format("{0} sec.", argSpec.ParentScan.RetentionTime);
            // Set the filename
            metroLabelArgFileName.Text = argSpec.OriginalFileName.Split('.')[0];
        }

        /// <summary>
        /// Add the info for a potential citrullination.
        /// </summary>
        /// <param name="index">The index of the potential citrullination.</param>
        private void AddPotCitInfo(int index)
        {
            // Set the parent mass
            double pMass = 1.007276470;
            // Get the spectrum
            XTSpectrum argSpec = valKVP.Key;
            // Get the scan
            RawScan potCitScan = valKVP.Value[index];
            string scanIDProtein = string.Format("{0} / {1}", potCitScan.ScanNumber, argSpec.SpectrumLabel.Split('|')[1]);
            // Set the scan id
            metroLabelCitID.Text = scanIDProtein;
            // Set the parent mass
            metroLabelCitPMass.Text = Math.Round((potCitScan.PreCursorMz * potCitScan.Charge) - ((potCitScan.Charge - 1) * pMass), 3).ToString();
            // Set the charge
            metroLabelCitCharge.Text = potCitScan.Charge.ToString();
            // Set the sequence
            metroLabelCitSeq.Text = string.Format("({0})", argSpec.Proteins[0].DoaminSeq);
            // Set the retention time for the arginine spectrum
            metroLabelCitRTime.Text = string.Format("{0} sec.", potCitScan.RetentionTime);
            // Set the retention time for the MS1 Serie spectrum
            metroLabelPotCitMS1RTime.Text = string.Format("{0} sec.", potCitScan.RetentionTime);
            // Set the filename
            metroLabelPotCitFileName.Text = potCitScan.OriginalFileName.Split('.')[0];
            // Set the scores
            metroLabelCitScore.Text = potCitScan.CitScore.ToString();
            metroLabelMatchScore.Text = potCitScan.MatchScore.ToString();
        }
        #endregion

        #region Arginine containg scans
        /// <summary>
        /// Check if there are more than one scan in the spectrum.
        /// </summary>
        private void CheckBeforeButtonDisabling()
        {
            // Check if there are more than one scan in the spectrum.
            if (valKVP.Value.Count > 1)
            {
                // If so, enable the next potential citrullination button
                metroButtonNextPotCitScan.Enabled = true;
                metroButtonPrevPotCitScan.Enabled = false;
            }
            else
            {
                // If not, disable both buttons
                metroButtonNextPotCitScan.Enabled = false;
                metroButtonPrevPotCitScan.Enabled = false;
            }
        }

        private int potCitIndex = 0;

        /// <summary>
        /// Go to the next potential citrullination scan.
        /// </summary>
        private void MetroButtonNextPotCitScan_Click(object sender, EventArgs e)
        {
            // Check if has reached the end
            int length = valKVP.Value.Count() - 1;
            int index = potCitIndex + 1;
            if (index == length)
            {
                // If so, disable the next button
                metroButtonNextPotCitScan.Enabled = false;
            }
            // Get the next potential citrullination series
            AddNextPotCitSeries(index);
            // Get the next potential citrullination series to MS1 chart
            AddNextPotCitMS1Series(valKVP.Value[index]);
            // Fill the ion grid
            ValidationUIUtilities.FillArgIonGrid(metroGridPotCitIons, valKVP.Value[index], valKVP.Key);
            // Enable the previous button
            metroButtonPrevPotCitScan.Enabled = true;
            // Add the potential citrullination info the the form
            AddPotCitInfo(index);
            ReturnPotCitIndex(index);
        }

        /// <summary>
        /// Go to the previous potential citrullination scan.
        /// </summary>
        private void MetroButtonPrevPotCitScan_Click(object sender, EventArgs e)
        {
            // Check if has reached the start
            int index = potCitIndex - 1;
            if (index == 0)
            {
                // If so, disable the previous button
                metroButtonPrevPotCitScan.Enabled = false;
            }
            // Get the next potential citrullination series
            AddNextPotCitSeries(index);
            // Get the next potential citrullination series to MS1 chart
            AddNextPotCitMS1Series(valKVP.Value[index]);
            // Fill the ion grid
            ValidationUIUtilities.FillArgIonGrid(metroGridPotCitIons, valKVP.Value[index], valKVP.Key);
            // Enable the next button
            metroButtonNextPotCitScan.Enabled = true;
            // Add potential citrullination info to the window
            AddPotCitInfo(index);
            ReturnPotCitIndex(index);
        }

        private int ReturnPotCitIndex(int index)
        {
            potCitIndex = index;
            return potCitIndex;
        }
        #endregion

        #region MS2 Charts
        #region Peak tool tip
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

        /// <summary>
        /// Add the next potential citrullination series.
        /// </summary>
        /// <param name="index">The series index.</param>
        private void AddNextPotCitSeries(int index)
        {
            ValidationUIUtilities.ClearChart(chartMS2);
            ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, valKVP.Value[index], valKVP.Key);
        }

        /// <summary>
        /// Reset the zoom on the MS2 chart.
        /// </summary>
        private void MetroButtonZoomResetMS2_Click(object sender, EventArgs e)
        {
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        #endregion

        #region MS1 Charts
        /// <summary>
        /// Reset the zoom on the MS1 arginine spectra.
        /// </summary>
        private void MetroButtonResetZoomArgMS1_Click(object sender, EventArgs e)
        {
            chartArgMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartArgMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }

        /// <summary>
        /// Reset the zoom on the MS1 potential Serie spectra.
        /// </summary>
        private void MetroButtonResetZoomPotCitMS1_Click(object sender, EventArgs e)
        {
            chartPotCitMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartPotCitMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
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

        private void ChartPotCitMS1_MouseMove(object sender, MouseEventArgs e)
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
            var results = chartPotCitMS1.HitTest(pos.X, pos.Y, false,
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
                            tooltipMs1Cit.Show("m/z = " + prop.XValue + ", Intensity = " + Math.Abs(prop.YValues[0]).ToString("E1"), chartPotCitMS1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
  

        /// <summary>
        /// Add the next potnetial cirullination MS1 series.
        /// </summary>
        /// <param name="scanMS1">The MS1 scan.</param>
        private void AddNextPotCitMS1Series(RawScan scanMS1)
        {
            //Removes old series:
            chartPotCitMS1.Series.Remove(chartPotCitMS1.Series["Serie"]);
            //Add Data:
            chartPotCitMS1.Series.Add("Serie");
            chartPotCitMS1.Series["Serie"].ChartType = SeriesChartType.StackedColumn;
            chartPotCitMS1.Series["Serie"].AxisLabel = "m/z";
            chartPotCitMS1.Series["Serie"]["PixelPointWidth"] = "2";
            double[] mzVals = scanMS1.ParentScan.MzValues;
            double[] intVals = scanMS1.ParentScan.Intencities;
            for (int i = 0; i <= mzVals.Length - 1; i++)
            {
                chartPotCitMS1.Series["Serie"].Points.AddXY(mzVals[i], intVals[i]);
            }
            chartPotCitMS1.Series["Serie"].ChartArea = "ChartArea";

            chartPotCitMS1.Legends.Clear();

            double ms2PrecursorMzVal = scanMS1.PreCursorMz;
            double tolerance = 0.05;
            for (int i = 0; i <= chartPotCitMS1.Series["Serie"].Points.Count() - 1; i++)
            {
                double error = Math.Abs(chartPotCitMS1.Series["Serie"].Points[i].XValue - ms2PrecursorMzVal);
                if (error <= tolerance)
                {
                    chartPotCitMS1.Series["Serie"].Points[i].Color = Color.Blue;
                }

                if(chartPotCitMS1.Series["Serie"].Points[i].XValue == scanMS1.IsoCyanicMzMs1)
                {
                    chartPotCitMS1.Series["Serie"].Points[i].Color = Color.Cyan;
                }
            }

            //Add X-Axis Maximum to chart:
            int xAxisMax = (int)Math.Ceiling(mzVals.Last() / 100) * 100;
            chartPotCitMS1.ChartAreas["ChartArea"].AxisX.Maximum = xAxisMax;

            //Make Custom Labels for X-Axis, interval 100:
            int endIndex = xAxisMax / 100;
            for (int i = 1; i <= endIndex; i++)
            {
                int index = i * 100;
                chartPotCitMS1.ChartAreas["ChartArea"].AxisX.CustomLabels.Add(index - 25, index + 25, string.Format("{0}", index), 2, LabelMarkStyle.None, GridTickTypes.TickMark);
            }
        }
        #endregion

        #region Buttons/Clickable objects
        /// <summary>
        /// Add the spectrum to quantification.
        /// </summary>
        private void MetroButtonAddQuant_Click(object sender, EventArgs e)
        {
            // Add the spectrum to the dictionary
            Quantification.AddTokvpArgSpecScanDict(valKVP.Key, valKVP.Value[potCitIndex]);
            // Update the quantification id list
            UpdateChosenForQuant(valKVP.Key.ID, true);

            // Enable and disable the button
            // Prevent moving back and forth through the complementary spectra
            metroButtonNextPotCitScan.Enabled = false;
            metroButtonPrevPotCitScan.Enabled = false;
            // Enable the remove button and disable the add button
            metroButtonAddQuant.Enabled = false;
            metroButtonRemoveQuant.Enabled = true;
        }

        /// <summary>
        /// Remove the spectrum from quantification.
        /// </summary>
        private void MetroButtonRemoveQuant_Click(object sender, EventArgs e)
        {
            // Remove the spectrum from the dictionary
            Quantification.RemoveFromkvpArgSpecScanDict(valKVP.Key);
            // Update the quantification id list
            UpdateChosenForQuant(valKVP.Key.ID, false);

            // Enable and disable the button
            // Enable moving back and forth through the complementary spectra
            metroButtonNextPotCitScan.Enabled = true;
            metroButtonPrevPotCitScan.Enabled = true;

            // Check if has reached the end
            int length = valKVP.Value.Count() - 1;
            int index = potCitIndex + 1;
            if (index > length)
            {
                // If so, disable the next button
                metroButtonNextPotCitScan.Enabled = false;
            }
            //Check if has reached the start
            int index1 = potCitIndex - 1;
            if (index1 < 0)
            {
                // If so, disable the previous button
                metroButtonPrevPotCitScan.Enabled = false;
            }

            // Disable the remove button and enable the add button
            metroButtonRemoveQuant.Enabled = false;
            metroButtonAddQuant.Enabled = true;
        }

        /// <summary>
        /// Export the spectra to an excel file.
        /// </summary>
        private void MetroButtonExportDataGrid_Click(object sender, EventArgs e)
        {
            // Check if the background worker is working
            if (backgroundWorkerExport.IsBusy ==false)
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
        /// Save the MS2 spectrum as an image.
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
        /// Save the MS1 arginine spectrum as an image.
        /// </summary>
        private void MetroButtonMS1Arg_Click(object sender, EventArgs e)
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
        /// Save the MS1 citrullination spectrum as an image.
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
                Validation.argChosenForQuantList.Add(id);
            }
            else
            {
                // If it should be removed, remove it to the list.
                Validation.argChosenForQuantList.Remove(id);
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
            if (Validation.argChosenForQuantList.Contains(spec.ID))
            {
                // If so, disable the add button
                metroButtonAddQuant.Enabled = false;
                // Enable the remove button
                metroButtonRemoveQuant.Enabled = true;
                // Prevent moving back and forth through the complementary spectra
                metroButtonNextPotCitScan.Enabled = false;
                metroButtonPrevPotCitScan.Enabled = false;
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
        /// Background worker - Export the ion grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            //Export.ExportDataGrid(metroGridArgIons, metroGridPotCitIons, valKVP.Key.ID, valKVP.Value[potCitIndex].ScanNumber);
            Export.ExportDataGrid(metroGridPotCitIons, metroGridArgIons, valKVP.Value[potCitIndex].ScanNumber, valKVP.Key.ID);
        }

        /// <summary>
        /// Find the KeyValuePair containing information about the arginine spectra.
        /// </summary>
        /// <param name="spectrumId">The spectrum ID.</param>
        internal void FindArginineSpectraKeyValuePair(int spectrumId)
        {
            // Loop through the validation results
            foreach (ValResult result in Validation.argValResults)
            {
                // Loop through the entries in the spectra scan dictionary and find the spectra that matches the given spectrum ID
                foreach (KeyValuePair<XTSpectrum, List<RawScan>> kvp in result.ArgSpectraDictionary)
                {
                    if (kvp.Key.ID == spectrumId)
                    {
                        Console.WriteLine(kvp.Key.ID);
                        // Set the keyvaluepapir
                        ReturnDict(kvp);
                    }
                }
            }
        }

        private static KeyValuePair<XTSpectrum, List<RawScan>> ReturnDict(KeyValuePair<XTSpectrum, List<RawScan>> kvp)
        {
            valKVP = kvp;
            return valKVP;
        }

        /// <summary>
        /// Set the new spectrum ID as the label.
        /// </summary>
        private void ChangeSpectrumIDAndScoreLabel()
        {
            string id = valKVP.Key.ID.ToString();
            metroLabelID.Text = id;
        }

        /// <summary>
        /// Update the validation window with a new spectrum
        /// </summary>
        /// <param name="argSpectrumValID">The new spectrum ID.</param>
        internal void UpdateValidationArgUI(int argSpectrumValID)
        {
            // Get the spectrum
            FindArginineSpectraKeyValuePair(argSpectrumValID);
            // If the spectra is marked for quantification, get the index of the complementary spectra that has been marked
            int complIndex = 0;
            if (Validation.argChosenForQuantList.Contains(valKVP.Key.ID))
            {
                complIndex = Quantification.GetQuantifiedComplementaryCitSpectrumIndex(valKVP.Key, valKVP.Value);
            }
            // Update the spectrum ID label
            ChangeSpectrumIDAndScoreLabel();
            // Clear the chart
            ValidationUIUtilities.ClearChart(chartMS2);
            // Create the chart
            ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, valKVP.Value[complIndex], valKVP.Key);
            ValidationUIUtilities.ClearChart(chartArgMS1);
            ValidationUIUtilities.ClearChart(chartPotCitMS1);
            // Update the MS1 charts
            ValidationUIUtilities.CreateMS1Chart(chartArgMS1, valKVP.Key);
            ValidationUIUtilities.CreateMS1Chart(chartPotCitMS1, valKVP.Value[complIndex]);
            // Fill the ion grid with data
            ValidationUIUtilities.FillCitIonGrid(metroGridArgIons, valKVP.Key);
            ValidationUIUtilities.FillArgIonGrid(metroGridPotCitIons, valKVP.Value[complIndex], valKVP.Key);
            // Check if buttons should be enabled or disabled

            CheckBeforeButtonDisabling();
            EnableQuantButtons(valKVP.Key);
            
            ReturnPotCitIndex(complIndex);
            // Add information about peptides
            AddArgInfo();
            AddPotCitInfo(complIndex);
        }
    }
}
