using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Citrullia
{
    /// <summary>
    /// Validation form for citrullinations.
    /// </summary>
    internal partial class ValidationCitUI : Form
    {
        readonly FormMain mainWindow;
        /// <summary>
        /// Create an instance of <see cref="ValidationCitUI"/>.
        /// </summary>
        /// <param name="callingForm">The form calling this form.</param>
        internal ValidationCitUI(FormMain callingForm)
        {
            InitializeComponent();
            mainWindow = callingForm;

            int index = mainWindow.citSpectrumValID;
            UpdateValidationUI(index);
        }

        private static KeyValuePair<XTSpectrum,List<XTSpectrum>> valKVP = new KeyValuePair<XTSpectrum,List<XTSpectrum>>();

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

        #region MS2 chart
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
        /// Reset the zoom on the MS2 chart.
        /// </summary>
        private void MetroButtonZoomReset_Click(object sender, EventArgs e)
        {
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }
        #endregion

        #region Arginine containing scans
        /// <summary>
        /// Check if there are more than one scan in the spectrum.
        /// </summary>
        private void CheckBeforeButtonDisabling()
        {
            // Check if there are more than one scan in the spectrum.
            if (valKVP.Value.Count > 1)
            {
                // If so, enable the next arginine button
                metroButtonNextArgScan.Enabled = true;
                metroButtonPrevArgScan.Enabled = false;
            }
            else
            {
                // If not, disable both buttons
                metroButtonNextArgScan.Enabled = false;
                metroButtonPrevArgScan.Enabled = false;
            }
        }

        private int argIndex = 0;
        /// <summary>
        /// Go to the next arginine scan.
        /// </summary>
        private void MetroButtonNextArgScan_Click(object sender, EventArgs e)
        {
            // Check if has reached the end
            int length = valKVP.Value.Count() - 1;
            int index = argIndex + 1;
            if (index == length)
            {
                // If so, disable the next button
                metroButtonNextArgScan.Enabled = false;
            }
            // Get the next arginine series
            AddNextArgSeries(index);
            // Get the next arginine MS1 series
            AddNextArgMS1Series(valKVP.Value[index]);
            // Fill the ion grid
            ValidationUIUtilities.FillCitIonGrid(metroGridArgIons, valKVP.Value[index]);
            // Add arginine information
            AddArgInfo(index);
            // Disbale the previous button
            metroButtonPrevArgScan.Enabled = true;
            ReturnArgIndex(index);
        }
        /// <summary>
        /// Go to the previous arginine scan.
        /// </summary>
        private void MetroButtonPrevArgScan_Click(object sender, EventArgs e)
        {
            // Check if has reached the start
            int index = argIndex - 1;
            if (index == 0)
            {
                // If so disable the previous button
                metroButtonPrevArgScan.Enabled = false;
            }
            AddNextArgSeries(index);
            AddNextArgMS1Series(valKVP.Value[index]);
            ValidationUIUtilities.FillCitIonGrid(metroGridArgIons, valKVP.Value[index]);
            AddArgInfo(index);
            metroButtonNextArgScan.Enabled = true;
            ReturnArgIndex(index);
        }

        private int ReturnArgIndex(int index)
        {
            argIndex = index;
            return argIndex;
        }
        /// <summary>
        /// Add the next arginine series to the MS2 chart.
        /// </summary>
        /// <param name="index">The index of the chart.</param>
        private void AddNextArgSeries(int index)
        {
            ValidationUIUtilities.ClearChart(chartMS2);
            ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, valKVP.Key, valKVP.Value[index]);
        }
        /// <summary>
        /// Add the next arginine MS1 series to the chart. 
        /// </summary>
        /// <param name="scanMS2">The MS2 spectrum.</param>
        private void AddNextArgMS1Series(XTSpectrum scanMS2)
        {
            //Removes old series:
            chartArgMS1.Series.Remove(chartArgMS1.Series["Serie"]);
            //Add Data:
            chartArgMS1.Series.Add("Serie");
            chartArgMS1.Series["Serie"].ChartType = SeriesChartType.StackedColumn;
            chartArgMS1.Series["Serie"].AxisLabel = "m/z";
            chartArgMS1.Series["Serie"]["PixelPointWidth"] = "2";
            double[] mzVals = scanMS2.ParentScan.MzValues;
            double[] intVals = scanMS2.ParentScan.Intencities;
            for (int i = 0; i <= mzVals.Length - 1; i++)
            {
                chartArgMS1.Series["Serie"].Points.AddXY(mzVals[i], intVals[i]);
            }
            chartArgMS1.Series["Serie"].ChartArea = "ChartArea";

            chartArgMS1.Legends.Clear();

            double tolerance = 0.05;
            double ms2PrecursorMzVal = scanMS2.PreCursorMz;
            for (int i = 0; i <= chartArgMS1.Series["Serie"].Points.Count() - 1; i++)
            {
                double error = Math.Abs(chartArgMS1.Series["Serie"].Points[i].XValue - ms2PrecursorMzVal);
                if (error <= tolerance)
                {
                    chartArgMS1.Series["Serie"].Points[i].Color = Color.Blue;
                }
            }

            //Add X-Axis Maximum to chart:
            int xAxisMax = (int)Math.Ceiling(mzVals.Last() / 100) * 100;
            chartArgMS1.ChartAreas["ChartArea"].AxisX.Maximum = xAxisMax;

            //Make Custom Labels for X-Axis, interval 100:
            int endIndex = xAxisMax / 100;
            for (int i = 1; i <= endIndex; i++)
            {
                int index = i * 100;
                chartArgMS1.ChartAreas["ChartArea"].AxisX.CustomLabels.Add(index - 25, index + 25, string.Format("{0}", index), 2, LabelMarkStyle.None, GridTickTypes.TickMark);
            }
        }
        #endregion

        #region Add info to label
        /// <summary>
        /// Add the citrullination information.
        /// </summary>
        private void AddCitInfo()
        {
            // Get the spectrum
            XTSpectrum citSpec = valKVP.Key;
            // Get and set the scan id and protein
            string scanIDProtein = string.Format("{0} / {1}", citSpec.ID, citSpec.SpectrumLabel.Split('|')[1]);
            metroLabelCitID.Text = scanIDProtein;
            // Set the parent mass
            metroLabelCitPMass.Text = Math.Round(citSpec.ParentMass, 3).ToString();
            // Set the charge
            metroLabelCitCharge.Text = citSpec.ParentIonCharge.ToString();
            // Set the sequence
            metroLabelCitSeq.Text = citSpec.Proteins[0].DoaminSeq;
            // Set the spectrum e-value
            metroLabelCitEval.Text = citSpec.SpectrumEVal.ToString();
            // Set the retention time
            metroLabelCitRTime.Text = string.Format("{0} sec.", citSpec.RetentionTime);
            // Set the retention time
            metroLabelCitMS1RTime.Text = string.Format("{0} sec.", citSpec.ParentScan.RetentionTime);
            // Set the filename
            metroLabelCitFileName.Text = citSpec.OriginalFileName.Split('.')[0]; ;
            // Set the CitScore
            metroLabelCitScore.Text = citSpec.CitScore.ToString();
        }

        /// <summary>
        /// Add the arginine information.
        /// </summary>
        /// <param name="index">The index of the scan.</param>
        private void AddArgInfo(int index)
        {
            // Get the spectrum
            XTSpectrum argSpec = valKVP.Value[index];
            string scanIDProtein = string.Format("{0} / {1}", argSpec.ID, argSpec.SpectrumLabel.Split('|')[1]);
            // Set the scan id
            metroLabelArgID.Text = scanIDProtein;
            // Set the parent mass
            metroLabelArgPMass.Text = Math.Round(argSpec.ParentMass, 3).ToString();
            // Set the charge
            metroLabelArgCharge.Text = argSpec.ParentIonCharge.ToString();
            // Set the sequence
            metroLabelArgSeq.Text = argSpec.Proteins[0].DoaminSeq;
            // Set the spectrum e-value
            metroLabelArgEval.Text = argSpec.SpectrumEVal.ToString();
            // Set the retention time for the arginine spectrum
            metroLabelArgRTime.Text = string.Format("{0} sec.", argSpec.RetentionTime);
            // Set the retention time for the MS1 citrullinated spectrum
            metroLabelArgMS1RTime.Text = string.Format("{0} sec.", argSpec.ParentScan.RetentionTime);
            // Set the filename
            metroLabelArgFileName.Text = argSpec.OriginalFileName.Split('.')[0]; ;
            // Set the score:
            metroLabelMatchScore.Text = argSpec.MatchScore.ToString();
        }
        #endregion

        #region MS1 chart
        /// <summary>
        /// Reset the zoom on the MS1 for the citrullinated spectrum.
        /// </summary>
        private void MetroButtonResetZoomMS1Cit_Click(object sender, EventArgs e)
        {
            chartCitMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartCitMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
        }

        /// <summary>
        /// Reset the zoom on the MS1 for the arginine spectrum.
        /// </summary>
        private void MetroButtonResetZoomMS1Arg_Click(object sender, EventArgs e)
        {
            chartArgMS1.ChartAreas["ChartArea"].AxisX.ScaleView.ZoomReset(0);
            chartArgMS1.ChartAreas["ChartArea"].AxisY.ScaleView.ZoomReset(0);
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
        #endregion
        
        #region Buttons / Clickable objects
        /// <summary>
        /// Add the spectrum to quantification.
        /// </summary>
        private void MetroButtonAddQuant_Click(object sender, EventArgs e)
        {
            // Get the spectra
            XTSpectrum spectrumCit = valKVP.Key;
            XTSpectrum spectrumArg = valKVP.Value[argIndex];

            // Add the spectrum to the dictionary
            Quantification.AddTokvpCitSpecSpecDict(spectrumCit, spectrumArg);
            // Update the quantification id list
            UpdateChosenForQuant(valKVP.Key.ID, true);
            // Prevent moving back and forth through the complementary spectra
            metroButtonNextArgScan.Enabled = false;
            metroButtonPrevArgScan.Enabled = false;
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
            Quantification.RemoveFromkvpCitSpecSpecList(valKVP.Key);
            // Update the quantification id list
            UpdateChosenForQuant(valKVP.Key.ID, false);

            // Enable moving back and forth through the complementary spectra
            metroButtonNextArgScan.Enabled = true;
            metroButtonPrevArgScan.Enabled = true;

            // Check if has reached the end
            int length = valKVP.Value.Count() - 1;
            int index = argIndex + 1;
            if (index > length)
            {
                // If so, disable the next button
                metroButtonNextArgScan.Enabled = false;
            }
            //Check if has reached the start
            int index1 = argIndex - 1;
            if (index1 < 0)
            {
                // If so, disable the previous button
                metroButtonPrevArgScan.Enabled = false;
            }


            // Enable and disable the button
            metroButtonRemoveQuant.Enabled = false;
            metroButtonAddQuant.Enabled = true;
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
        /// Save the MS1 citrullinated spectra.
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
        /// Save the MS1 arginine spectra.
        /// </summary>
        private void MetroButtonSaveMS1Arg_Click(object sender, EventArgs e)
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
                Validation.citChosenForQuantList.Add(id);
            }
            else
            {
                // If it should be removed, remove it to the list.
                Validation.citChosenForQuantList.Remove(id);
            }
            // Return the new list of spectra that should be quantitised
            return Validation.citChosenForQuantList;
        }

        /// <summary>
        /// Check what state the quantificaation buttons should be in. 
        /// </summary>
        /// <param name="spec">The spectrum.</param>
        private void EnableQuantButtons(XTSpectrum spec)
        {
            // Check if the quantification list contains the spectrum.
            if (Validation.citChosenForQuantList.Contains(spec.ID))
            {
                // If so, disable the add button
                metroButtonAddQuant.Enabled = false;
                // Enable the remove button
                metroButtonRemoveQuant.Enabled = true;
                // Prevent moving back and forth through the complementary spectra
                metroButtonNextArgScan.Enabled = false;
                metroButtonNextArgScan.Enabled = false;
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
        /// Background worker - Export the data.
        /// </summary>
        private void BackgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            Export.ExportDataGrid(metroGridCitIons, metroGridArgIons, valKVP.Key.ID, valKVP.Value[argIndex].ID);
        }

        /// <summary>
        /// Find the KeyValuePair containing information about the arginine spectra.
        /// </summary>
        /// <param name="spectrumId">The spectrum ID.</param>
        internal void FindCitrullineSpectraKeyValuePair(int spectrumId)
        {
            // Loop through each of the validation results
            foreach (ValResult result in Validation.citValResults)
            {
                // Loop through all of the spectra and find the spectrum with the id that matches the given id.
                foreach (KeyValuePair<XTSpectrum, List<XTSpectrum>> kvp in result.CitSpectraDictionary)
                {
                    if (kvp.Key.ID == spectrumId)
                    {
                        Console.WriteLine(kvp.Key.ID);
                        ReturnDict(kvp);
                    }
                }
            }
        }

        private static KeyValuePair<XTSpectrum, List<XTSpectrum>> ReturnDict(KeyValuePair<XTSpectrum, List<XTSpectrum>> kvp)
        {
            valKVP = kvp;
            return valKVP;
        }

        /// <summary>
        /// Update the spectrum validation.
        /// </summary>
        /// <param name="spectrumValID">The spectrum ID.</param>
        internal void UpdateValidationUI(int spectrumValID)
        {
            // Find the citrullinated spectrum
            FindCitrullineSpectraKeyValuePair(spectrumValID);
            // If the spectra is marked for quantification, get the index of the complementary spectra that has been marked
            int complIndex = 0;
            if (Validation.citChosenForQuantList.Contains(valKVP.Key.ID))
            {
                complIndex = Quantification.GetQuantifiedComplementaryArgSpectrumId(valKVP.Key, valKVP.Value);
            }

            // Update the spectrum id label
            ChangeSpectrumIDAndScoreLabel();
            // Update the MS2 chart
            ValidationUIUtilities.ClearChart(chartMS2);
            ValidationUIUtilities.CreatePairedMs2Chart(chartMS2, valKVP.Key, valKVP.Value[complIndex]);
            // Update the MS1 charts
            ValidationUIUtilities.ClearChart(chartCitMS1);
            ValidationUIUtilities.ClearChart(chartArgMS1);
            ValidationUIUtilities.CreateMS1Chart(chartCitMS1, valKVP.Key);
            ValidationUIUtilities.CreateMS1Chart(chartArgMS1, valKVP.Value[complIndex]);
            // Update the ion grid
            ValidationUIUtilities.FillCitIonGrid(metroGridCitIons, valKVP.Key);
            ValidationUIUtilities.FillCitIonGrid(metroGridArgIons, valKVP.Value[complIndex]);
            // Update the buttons
            CheckBeforeButtonDisabling();
            EnableQuantButtons(valKVP.Key);
            ReturnArgIndex(complIndex);
            // Update the information
            AddCitInfo();
            AddArgInfo(complIndex);
        }

        /// <summary>
        /// Change the label on the spectrum.
        /// </summary>
        private void ChangeSpectrumIDAndScoreLabel()
        {
            string id = valKVP.Key.ID.ToString();
            metroLabelID.Text = id;
        }

    }
}
