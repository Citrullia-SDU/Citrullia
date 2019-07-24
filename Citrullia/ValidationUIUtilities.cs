using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Citrullia
{
    /// <summary>
    /// Utilities class for the Validation UI.
    /// </summary>
    internal static class ValidationUIUtilities
    {
        /// <summary>The spectrum and ion grid color for B-ions.</summary>
        private static readonly Color BIonColor = Color.Blue;
        /// <summary>The spectrum and ion grid color for B-17-ions.</summary>
        private static readonly Color B17IonColor = Color.SteelBlue;
        /// <summary>The spectrum and ion grid color for B-18-ions.</summary>
        private static readonly Color B18IonColor = Color.DodgerBlue;
        /// <summary>The spectrum and ion grid color for Y-ions.</summary>
        private static readonly Color YIonColor = Color.Red;
        /// <summary>The spectrum and ion grid color for Y-17-ions.</summary>
        private static readonly Color Y17IonColor = Color.Purple;
        /// <summary>The spectrum and ion grid color for Y-18-ions.</summary>
        private static readonly Color Y18IonColor = Color.Magenta;
        /// <summary>The spectrum and ion grid color for A-ions.</summary>
        private static readonly Color AIonColor = Color.Orange;
        /// <summary>The spectrum and ion grid color for isocyanic loss ions.</summary>
        private static readonly Color IsoCyanicLossColor = Color.Cyan;
        /// <summary>The spectrum and ion grid color for unidentified ions.</summary>
        private static readonly Color UnidentifiedColor = Color.DimGray;

        /// <summary>
        /// Create the MS2 chart for the lone citrullination.
        /// </summary>
        /// <param name="chartMS2">The chart for the MS2.</param>
        /// <param name="spectrum">The spectrum to be drawn.</param>
        internal static void CreateLoneCitMs2Chart(Chart chartMS2, MsSpectrum spectrum)
        {
            //Chart Properties:
            //Y-axis:
            chartMS2.ChartAreas["ChartArea"].AxisY.Title = "Intensity";
            chartMS2.ChartAreas["ChartArea"].AxisY.Maximum = 130;
            chartMS2.ChartAreas["ChartArea"].AxisY.Minimum = 0;
            chartMS2.ChartAreas["ChartArea"].AxisY.MajorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.MajorTickMark.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.Interval = 0;
            chartMS2.ChartAreas["ChartArea"].AxisY.LabelStyle.Enabled = false;

            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Size = 1;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Interval = 10;
            //X-axis
            chartMS2.ChartAreas["ChartArea"].AxisX.Title = "m/z";
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisX.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.IsStartedFromZero = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.Minimum = 0;

            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.LabelStyle.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Interval = 100;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Size = 2;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;

            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Size = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Interval = 20;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.IntervalOffset = 0;

            //Add chart Data:
            chartMS2.Series.Add("Citrullinated");
            chartMS2.Series["Citrullinated"].ChartType = SeriesChartType.StackedColumn;
            chartMS2.Series["Citrullinated"].IsVisibleInLegend = false;
            chartMS2.Series["Citrullinated"].AxisLabel = "m/z";
            chartMS2.Series["Citrullinated"]["PixelPointWidth"] = "2";
            double[] citMzVals = spectrum.MzValues;
            double[] citIntVals = spectrum.Intencities;
            for (int i = 0; i <= citMzVals.Length - 1; i++)
            {
                chartMS2.Series["Citrullinated"].Points.AddXY(citMzVals[i], citIntVals[i]);
            }
            chartMS2.Series["Citrullinated"].ChartArea = "ChartArea";


            //Color the different ions in the series:
            for (int i = 0; i <= chartMS2.Series["Citrullinated"].Points.Count() - 1; i++)
            {
                foreach (double cyanLossIon in spectrum.IsoCyanicLossMzMs2)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == cyanLossIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = IsoCyanicLossColor;
                    }
                }

                foreach (double bIon in spectrum.SpectrumExistingBIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = BIonColor;
                    }
                }

                foreach (double bIon in spectrum.SpectrumBm17Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = B17IonColor;
                    }
                }

                foreach (double bIon in spectrum.SpectrumBm18Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = B18IonColor;
                    }
                }

                foreach (double yIon in spectrum.SpectrumExistingYIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = YIonColor;
                    }
                }

                foreach (double yIon in spectrum.SpectrumYm17Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = Y17IonColor;
                    }
                }

                foreach (double yIon in spectrum.SpectrumYm18Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color =Y18IonColor;
                    }
                }

                foreach (double aIon in spectrum.SpectrumAIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == aIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = AIonColor;
                    }
                }
            }

            // Add legend
            chartMS2.Legends.Clear();
            chartMS2.Legends.Add("Ions");
            chartMS2.Legends["Ions"].DockedToChartArea = "ChartArea";
            chartMS2.Legends["Ions"].Docking = Docking.Top;
            chartMS2.Legends["Ions"].IsDockedInsideChartArea = true;
            chartMS2.Legends["Ions"].Position.Auto = false;
            chartMS2.Legends["Ions"].Position.X = 10F;
            chartMS2.Legends["Ions"].Position.Y = 3F;
            chartMS2.Legends["Ions"].Position.Height = 5.5F;
            chartMS2.Legends["Ions"].Position.Width = 82F;
            LegendItem bIonLegendItem = new LegendItem() { Name = "B Ions", Color = BIonColor, BorderColor = BIonColor };
            LegendItem b17IonLegendItem = new LegendItem() { Name = "B-17 Ions", Color = B17IonColor, BorderColor = B17IonColor };
            LegendItem b18IonLegendItem = new LegendItem() { Name = "B-18 Ions", Color = B18IonColor, BorderColor = B18IonColor };
            LegendItem yIonLegendItem = new LegendItem() { Name = "Y Ions", Color = YIonColor, BorderColor = YIonColor };
            LegendItem y17IonLegendItem = new LegendItem() { Name = "Y-17 Ions", Color = Y17IonColor, BorderColor = Y17IonColor };
            LegendItem y18IonLegendItem = new LegendItem() { Name = "Y-18 Ions", Color = Y18IonColor, BorderColor = Y18IonColor };
            LegendItem aIonLegendItem = new LegendItem() { Name = "A Ions", Color = AIonColor, BorderColor = AIonColor };
            LegendItem isoCyanLegendItem = new LegendItem() { Name = "Isocyanic loss", Color = IsoCyanicLossColor, BorderColor = IsoCyanicLossColor };
            LegendItem unIdLegendItem = new LegendItem() { Name = "Unidentified", Color = UnidentifiedColor, BorderColor = UnidentifiedColor };
            chartMS2.Legends["Ions"].CustomItems.Add(bIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(b17IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(b18IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(yIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(y17IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(y18IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(aIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(isoCyanLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(unIdLegendItem);


            LegendItem emptyLegend = new LegendItem()
            {
                BorderColor = Color.Transparent,
                Color = Color.Transparent,
            };
            chartMS2.Legends.Add("Cit");
            chartMS2.Legends["Cit"].CustomItems.Add(emptyLegend);
            chartMS2.Legends["Cit"].Title = "Citrullinated";
            chartMS2.Legends["Cit"].TitleFont = new Font(chartMS2.Legends["Cit"].TitleFont.FontFamily, 14);
            chartMS2.Legends["Cit"].BackColor = Color.Transparent;
            chartMS2.Legends["Cit"].TitleBackColor = Color.Transparent;
            chartMS2.Legends["Cit"].Position.Auto = false;
            chartMS2.Legends["Cit"].Position.X = 82f;
            chartMS2.Legends["Cit"].Position.Y = 10f;
            chartMS2.Legends["Cit"].Position.Height = 5.5f;
            chartMS2.Legends["Cit"].Position.Width = 13;

            //Add X-Axis Maximum to chart:
            int xAxisMax = RoundToNext100Lone(citMzVals.Last());
            chartMS2.ChartAreas["ChartArea"].AxisX.Maximum = xAxisMax;

            //Make Custom Labels for X-Axis, interval 100:
            int endIndex = xAxisMax / 100;
            for (int i = 1; i <= endIndex; i++)
            {
                int index = i * 100;
                chartMS2.ChartAreas["ChartArea"].AxisX.CustomLabels.Add(index - 25, index + 25, string.Format("{0}", index), 2, LabelMarkStyle.None, GridTickTypes.TickMark);
            }

            //Add lines to chart:
            StripLine line = new StripLine
            {
                Interval = 0,
                IntervalOffset = 0,
                StripWidth = 1,
                BackColor = Color.Black
            };
            chartMS2.ChartAreas["ChartArea"].AxisY.StripLines.Add(line);

            //Add range:
            double[] range = new double[] { 0, -110 };
            Color rangeColour = Color.FromArgb(75, Color.LightGray);

            Series rangeSeries = new Series("rangeSeries")
            {
                ChartType = SeriesChartType.Range,
                IsVisibleInLegend = false
            };
            DataPoint r = new DataPoint(chartMS2.ChartAreas["ChartArea"].AxisX.Minimum, range);
            rangeSeries.Points.Add(r);
            DataPoint r2 = new DataPoint(chartMS2.ChartAreas["ChartArea"].AxisX.Maximum, range);
            rangeSeries.Points.Add(r2);
            rangeSeries.Color = rangeColour;
            rangeSeries.BorderColor = rangeColour;
            rangeSeries.BorderWidth = 0;
            chartMS2.Series.Add(rangeSeries);
            rangeSeries.ChartArea = "ChartArea";

            //Add Zoom:
            chartMS2.ChartAreas["ChartArea"].CursorX.IsUserSelectionEnabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chartMS2.ChartAreas["ChartArea"].CursorY.IsUserSelectionEnabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.Zoomable = true;
        }

        /// <summary>
        /// Create the MS2 chart for paired validation.
        /// </summary>
        /// <param name="chartMS2">The chart.</param>
        /// <param name="citSpectrum">The Cit spectrum.</param>
        /// <param name="argSpectrum">The arginine spectrum.</param>
        internal static void CreatePairedMs2Chart(Chart chartMS2, MsSpectrum citSpectrum, MsSpectrum argSpectrum)
        {
            //Chart Properties:
            //Y-axis:
            chartMS2.ChartAreas["ChartArea"].AxisY.Title = "Intensity";
            chartMS2.ChartAreas["ChartArea"].AxisY.Maximum = 130;
            chartMS2.ChartAreas["ChartArea"].AxisY.Minimum = -110;
            chartMS2.ChartAreas["ChartArea"].AxisY.MajorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.MajorTickMark.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisY.Interval = 0;
            chartMS2.ChartAreas["ChartArea"].AxisY.LabelStyle.Enabled = false;

            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Size = 1;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisY.MinorTickMark.Interval = 10;
            //X-axis
            chartMS2.ChartAreas["ChartArea"].AxisX.Title = "m/z";
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorGrid.Enabled = false;
            chartMS2.ChartAreas["ChartArea"].AxisX.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.IsStartedFromZero = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.Minimum = 0;

            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.LabelStyle.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Interval = 100;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.IntervalOffset = 0;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.Size = 2;
            chartMS2.ChartAreas["ChartArea"].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;

            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Enabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.LineWidth = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Size = 1;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.Interval = 20;
            chartMS2.ChartAreas["ChartArea"].AxisX.MinorTickMark.IntervalOffset = 0;

            //Add chart Data:
            chartMS2.Series.Add("Citrullinated");
            chartMS2.Series["Citrullinated"].ChartType = SeriesChartType.StackedColumn;
            chartMS2.Series["Citrullinated"].SmartLabelStyle.Enabled = true;
            chartMS2.Series["Citrullinated"].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            chartMS2.Series["Citrullinated"].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
            chartMS2.Series["Citrullinated"].SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Right;
            chartMS2.Series["Citrullinated"].IsVisibleInLegend = false;
            chartMS2.Series["Citrullinated"].AxisLabel = "m/z";
            chartMS2.Series["Citrullinated"]["PixelPointWidth"] = "2";
            double[] citMzVals = citSpectrum.MzValues;
            double[] citIntVals = citSpectrum.Intencities;
            for (int i = 0; i <= citMzVals.Length - 1; i++)
            {
                chartMS2.Series["Citrullinated"].Points.AddXY(citMzVals[i], citIntVals[i]);
            }
            chartMS2.Series["Citrullinated"].ChartArea = "ChartArea";


            //Color the B- and Y-ions of Citrullinated:
            for (int i = 0; i <= chartMS2.Series["Citrullinated"].Points.Count() - 1; i++)
            {
                foreach (double bIon in citSpectrum.SpectrumExistingBIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = BIonColor;
                    }
                }

                foreach (double bIon in citSpectrum.SpectrumBm17Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {

                        chartMS2.Series["Citrullinated"].Points[i].Color = B17IonColor;
                    }
                }

                foreach (double bIon in citSpectrum.SpectrumBm18Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = B18IonColor;
                    }
                }

                foreach (double yIon in citSpectrum.SpectrumExistingYIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = YIonColor;
                    }
                }

                foreach (double yIon in citSpectrum.SpectrumYm17Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = Y17IonColor;
                    }
                }

                foreach (double yIon in citSpectrum.SpectrumYm18Ions)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color =Y18IonColor;
                    }
                }

                foreach (double aIon in citSpectrum.SpectrumAIons)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == aIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = AIonColor;
                    }
                }

                foreach (double cyanLossIon in citSpectrum.IsoCyanicLossMzMs2)
                {
                    if (chartMS2.Series["Citrullinated"].Points[i].XValue == cyanLossIon)
                    {
                        chartMS2.Series["Citrullinated"].Points[i].Color = IsoCyanicLossColor;
                    }
                }
            }

            chartMS2.Series.Add("Arginine");
            chartMS2.Series["Arginine"].ChartType = SeriesChartType.StackedColumn;
            chartMS2.Series["Arginine"].SmartLabelStyle.Enabled = true;
            chartMS2.Series["Arginine"].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            chartMS2.Series["Arginine"].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
            chartMS2.Series["Arginine"].SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Right;
            chartMS2.Series["Arginine"].IsVisibleInLegend = false;
            chartMS2.Series["Arginine"].AxisLabel = "m/z";
            chartMS2.Series["Arginine"]["PixelPointWidth"] = "2";
            double[] argMzVals = argSpectrum.MzValues;
            double[] argIntVals = argSpectrum.Intencities;
            for (int i = 0; i <= argMzVals.Length - 1; i++)
            {
                chartMS2.Series["Arginine"].Points.AddXY(argMzVals[i], -argIntVals[i]);
            }
            chartMS2.Series["Arginine"].ChartArea = "ChartArea";

            //Color the B- and Y-ions of Arginine:
            for (int i = 0; i <= chartMS2.Series["Arginine"].Points.Count() - 1; i++)
            {
               
                foreach (double bIon in argSpectrum.SpectrumExistingBIons)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = BIonColor;
                    }
                }

                foreach (double bIon in argSpectrum.SpectrumBm17Ions)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = B17IonColor;
                    }
                }

                foreach (double bIon in argSpectrum.SpectrumBm18Ions)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == bIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = Color.Teal;
                    }
                }

                foreach (double yIon in argSpectrum.SpectrumExistingYIons)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = YIonColor;
                    }
                }

                foreach (double yIon in argSpectrum.SpectrumYm17Ions)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = Y17IonColor;
                    }
                }

                foreach (double yIon in argSpectrum.SpectrumYm18Ions)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == yIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color =Y18IonColor;
                    }
                }

                foreach (double aIon in argSpectrum.SpectrumAIons)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == aIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = AIonColor;
                    }
                }

                foreach (double cyanLossIon in argSpectrum.IsoCyanicLossMzMs2)
                {
                    if (chartMS2.Series["Arginine"].Points[i].XValue == cyanLossIon)
                    {
                        chartMS2.Series["Arginine"].Points[i].Color = IsoCyanicLossColor;
                    }
                }
            }


            // Add legend
            chartMS2.Legends.Clear();
            chartMS2.Legends.Add("Ions");
            chartMS2.Legends["Ions"].DockedToChartArea = "ChartArea";
            chartMS2.Legends["Ions"].Docking = Docking.Top;
            chartMS2.Legends["Ions"].IsDockedInsideChartArea = true;
            chartMS2.Legends["Ions"].Position.Auto = false;
            chartMS2.Legends["Ions"].Position.X = 10F;
            chartMS2.Legends["Ions"].Position.Y = 3F;
            chartMS2.Legends["Ions"].Position.Height = 5.5F;
            chartMS2.Legends["Ions"].Position.Width = 81F;
            LegendItem bIonLegendItem = new LegendItem() { Name = "B Ions", Color = BIonColor, BorderColor = BIonColor };
            LegendItem b17IonLegendItem = new LegendItem() { Name = "B-17 Ions", Color = B17IonColor, BorderColor = B17IonColor };
            LegendItem b18IonLegendItem = new LegendItem() { Name = "B-18 Ions", Color = B18IonColor, BorderColor = B18IonColor };
            LegendItem yIonLegendItem = new LegendItem() { Name = "Y Ions", Color = YIonColor, BorderColor = YIonColor };
            LegendItem y17IonLegendItem = new LegendItem() { Name = "Y-17 Ions", Color = Y17IonColor, BorderColor = Y17IonColor };
            LegendItem y18IonLegendItem = new LegendItem() { Name = "Y-18 Ions", Color = Y18IonColor, BorderColor = Y18IonColor };
            LegendItem aIonLegendItem = new LegendItem() { Name = "A Ions", Color = AIonColor, BorderColor = AIonColor };
            LegendItem isoCyanLegendItem = new LegendItem() { Name = "Isocyanic loss", Color = IsoCyanicLossColor, BorderColor = IsoCyanicLossColor };
            LegendItem unIdLegendItem = new LegendItem() { Name = "Unidentified", Color = UnidentifiedColor, BorderColor = UnidentifiedColor };
            chartMS2.Legends["Ions"].CustomItems.Add(bIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(b17IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(b18IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(yIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(y17IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(y18IonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(aIonLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(isoCyanLegendItem);
            chartMS2.Legends["Ions"].CustomItems.Add(unIdLegendItem);

            LegendItem emptyLegend = new LegendItem()
            {
                BorderColor = Color.Transparent,
                Color = Color.Transparent,
            };
            // Set the spectra labels
            chartMS2.Legends.Add("Arg");
            chartMS2.Legends["Arg"].CustomItems.Add(emptyLegend);
            chartMS2.Legends["Arg"].Title = "Arginine";
            chartMS2.Legends["Arg"].TitleFont = new Font(chartMS2.Legends["Arg"].TitleFont.FontFamily, 14);
            chartMS2.Legends["Arg"].BackColor = Color.Transparent;
            chartMS2.Legends["Arg"].TitleBackColor = Color.Transparent;
            chartMS2.Legends["Arg"].Position.Auto = false;
            chartMS2.Legends["Arg"].Position.X = 86f; 
            chartMS2.Legends["Arg"].Position.Y = 80f; 
            chartMS2.Legends["Arg"].Position.Height = 5.5f;
            chartMS2.Legends["Arg"].Position.Width = 10;

            chartMS2.Legends.Add("Cit");
            chartMS2.Legends["Cit"].CustomItems.Add(emptyLegend);
            chartMS2.Legends["Cit"].Title = "Citrullinated";
            chartMS2.Legends["Cit"].TitleFont = new Font(chartMS2.Legends["Cit"].TitleFont.FontFamily, 14);
            chartMS2.Legends["Cit"].BackColor = Color.Transparent;
            chartMS2.Legends["Cit"].TitleBackColor = Color.Transparent;
            chartMS2.Legends["Cit"].Position.Auto = false;
            chartMS2.Legends["Cit"].Position.X = 84f; 
            chartMS2.Legends["Cit"].Position.Y = 10f; 
            chartMS2.Legends["Cit"].Position.Height = 5.5f;
            chartMS2.Legends["Cit"].Position.Width = 12;



            //Add X-Axis Maximum to chart:
            int xAxisMax = RoundToNext100(citMzVals.Last(), argMzVals.Last());
            chartMS2.ChartAreas["ChartArea"].AxisX.Maximum = xAxisMax;

            //Make Custom Labels for X-Axis, interval 100:
            int endIndex = xAxisMax / 100;
            for (int i = 1; i <= endIndex; i++)
            {
                int index = i * 100;
                chartMS2.ChartAreas["ChartArea"].AxisX.CustomLabels.Add(index - 25, index + 25, string.Format("{0}", index), 2, LabelMarkStyle.None, GridTickTypes.TickMark);
            }

            //Add lines to chart:
            StripLine line = new StripLine
            {
                Interval = 0,
                IntervalOffset = 0,
                StripWidth = 1,
                BackColor = Color.Black
            };
            chartMS2.ChartAreas["ChartArea"].AxisY.StripLines.Add(line);

            //Add range:
            double[] range = new double[] { 0, -110 };
            Color rangeColour = Color.FromArgb(75, Color.LightGray);

            Series rangeSeries = new Series("rangeSeries")
            {
                ChartType = SeriesChartType.Range,
                IsVisibleInLegend = false
            };
            DataPoint r = new DataPoint(chartMS2.ChartAreas["ChartArea"].AxisX.Minimum, range);
            rangeSeries.Points.Add(r);
            DataPoint r2 = new DataPoint(chartMS2.ChartAreas["ChartArea"].AxisX.Maximum, range);
            rangeSeries.Points.Add(r2);
            rangeSeries.Color = rangeColour;
            rangeSeries.BorderColor = rangeColour;
            rangeSeries.BorderWidth = 0;
            chartMS2.Series.Add(rangeSeries);
            rangeSeries.ChartArea = "ChartArea";

            //Add Zoom:
            chartMS2.ChartAreas["ChartArea"].CursorX.IsUserSelectionEnabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chartMS2.ChartAreas["ChartArea"].CursorY.IsUserSelectionEnabled = true;
            chartMS2.ChartAreas["ChartArea"].AxisY.ScaleView.Zoomable = true;
        }

        /// <summary>
        /// Set the MS1 chart.
        /// </summary>
        /// <param name="chart">The chart to be set.</param>
        /// <param name="scanMS1">The data to be inserted.</param>
        internal static void CreateMS1Chart(Chart chart, MsSpectrum scanMS1)
        {
            //Chart Properties:
            //Y-axis:
            chart.ChartAreas["ChartArea"].AxisY.Title = "Intensity";
            chart.ChartAreas["ChartArea"].AxisY.Minimum = 0;
            chart.ChartAreas["ChartArea"].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas["ChartArea"].AxisY.MinorGrid.Enabled = false;
            chart.ChartAreas["ChartArea"].AxisY.MajorTickMark.Enabled = false;
            chart.ChartAreas["ChartArea"].AxisY.Interval = 0;
            chart.ChartAreas["ChartArea"].AxisY.LabelStyle.Enabled = false;

            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.Enabled = true;
            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.LineWidth = 1;
            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.Size = 1;
            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.IntervalOffset = 0;
            chart.ChartAreas["ChartArea"].AxisY.MinorTickMark.Interval = 10;
            //X-axis
            chart.ChartAreas["ChartArea"].AxisX.Title = "m/z";
            chart.ChartAreas["ChartArea"].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas["ChartArea"].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas["ChartArea"].AxisX.IntervalOffset = 0;
            chart.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chart.ChartAreas["ChartArea"].AxisX.IsStartedFromZero = true;
            chart.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas["ChartArea"].AxisX.Minimum = 0;

            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas["ChartArea"].AxisX.LabelStyle.Enabled = true;
            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.Interval = 100;
            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.IntervalOffset = 0;
            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.LineWidth = 1;
            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.Size = 2;
            chart.ChartAreas["ChartArea"].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;

            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.Enabled = true;
            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.LineWidth = 1;
            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.Size = 1;
            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.Interval = 20;
            chart.ChartAreas["ChartArea"].AxisX.MinorTickMark.IntervalOffset = 0;

            //Add Data:
            chart.Series.Add("Serie");
            chart.Series["Serie"].ChartType = SeriesChartType.StackedColumn;
            chart.Series["Serie"].AxisLabel = "m/z";
            chart.Series["Serie"]["PixelPointWidth"] = "2";
            double[] mzVals = scanMS1.ParentScan.MzValues;
            double[] intVals = scanMS1.ParentScan.Intencities;
            for (int i = 0; i <= mzVals.Length - 1; i++)
            {
                chart.Series["Serie"].Points.AddXY(mzVals[i], intVals[i]);
            }
            chart.Series["Serie"].ChartArea = "ChartArea";

            chart.Legends.Clear();
            
            //Color the MS2 Precursor peak another color in the MS1 Spectrum:
            double ms2PrecursorMzVal = scanMS1.PreCursorMz;
            double tolerance = 0.05;
            for (int i = 0; i <= chart.Series["Serie"].Points.Count() - 1; i++)
            {
                double error = Math.Abs(chart.Series["Serie"].Points[i].XValue - ms2PrecursorMzVal);
                if (error <= tolerance)
                {
                    chart.Series["Serie"].Points[i].Color = BIonColor;
                }

                if (chart.Series["Serie"].Points[i].XValue == scanMS1.IsoCyanicMzMs1)
                {
                    chart.Series["Serie"].Points[i].Color = IsoCyanicLossColor;
                }
            }

            //Add X-Axis Maximum to chart:
            int xAxisMax = (int)Math.Ceiling(mzVals.Last() / 100) * 100;
            chart.ChartAreas["ChartArea"].AxisX.Maximum = xAxisMax;

            //Make Custom Labels for X-Axis, interval 100:
            int endIndex = xAxisMax / 100;
            for (int i = 1; i <= endIndex; i++)
            {
                int index = i * 100;
                chart.ChartAreas["ChartArea"].AxisX.CustomLabels.Add(index - 25, index + 25, string.Format("{0}", index), 2, LabelMarkStyle.None, GridTickTypes.TickMark);
            }

            //Add Zoom:
            chart.ChartAreas["ChartArea"].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas["ChartArea"].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas["ChartArea"].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas["ChartArea"].AxisY.ScaleView.Zoomable = true;
        }

        /// <summary>
        /// Round the next 100.
        /// </summary>
        /// <param name="citVal">The highest citrullination MZ-value.</param>
        /// <param name="argVal">The highest citrullination MZ-value.</param>
        /// <returns>The highest MZ-value rounded to the next 100.</returns>
        internal static int RoundToNext100(double citVal, double argVal)
        {
            int next100;
            if (citVal >= argVal)
            {
                next100 = (int)Math.Ceiling(citVal / 100) * 100;
            }
            else
            {
                next100 = (int)Math.Ceiling(argVal / 100) * 100;
            }
            return next100;
        }

        /// <summary>
        /// Round to the next 100.
        /// </summary>
        /// <param name="citVal">The value.</param>
        /// <returns>The value rounded to next 100.</returns>
        private static int RoundToNext100Lone(double citVal)
        {
            int next100 = (int)Math.Ceiling(citVal / 100) * 100;
            return next100;
        }

        /// <summary>
        /// Clear the chart.
        /// </summary>
        /// <param name="chart">The chart.</param>
        internal static void ClearChart(Chart chart)
        {
            chart.Series.Clear();
        }

        /// <summary>
        /// Fill the ion grid with data.
        /// </summary>
        /// <param name="grid">The grid to be filled.</param>
        /// <param name="citSpectra">The MS2 spectrum.</param>
        internal static void FillCitIonGrid(DataGridView grid, XTSpectrum citSpectra)
        {
            FillIonGridGeneral(grid, citSpectra, citSpectra.SpectrumAminoAcidSequence);
        }
        /// <summary>
        /// Fill the ion grid with data.
        /// </summary>
        /// <param name="grid">The grid to be filled.</param>
        /// <param name="citSpectra">The MS2 scan.</param>
        /// <param name="argSpectra">The arginine sister spectrum.</param>
        internal static void FillArgIonGrid(DataGridView grid, RawScan citSpectra, XTSpectrum argSpectra)
        {
            FillIonGridGeneral(grid, citSpectra, argSpectra.SpectrumAminoAcidSequence);
        }

        /// <summary>
        /// The general fill ion grid.
        /// </summary>
        /// <param name="grid">The grid to be filled.</param>
        /// <param name="spectrum">The spectrum.</param>
        /// <param name="aaSeq">The AA sequence.</param>
        internal static void FillIonGridGeneral(DataGridView grid, MsSpectrum spectrum, string[] aaSeq)
        {
            // Clear the grid
            grid.Rows.Clear();
            // Loop through each of the spectra's peptide's residues
            for (int i = 0; i <= aaSeq.Length - 1; i++)
            {
                // Get the possible A ion for the residue
                string posAIon = spectrum.SpectrumPossibleAIons[i].ToString();
                // Get the possible B-18 ion for the residue
                string posB18Ion = spectrum.SpectrumPossibleBm18Ions[i].ToString();
                // Get the possible B-17 ion for the residue
                string posB17Ion = spectrum.SpectrumPossibleBm17Ions[i].ToString();
                // Get the possible B-ion rounded to 3 digits
                string posBIon = Math.Round(spectrum.SpectrumPossibleBIons[i], 3).ToString();
                // Get the possible Y-ion rounded to 3 digits
                string posYIon = Math.Round(spectrum.SpectrumPossibleYIons[aaSeq.Length - 1 - i], 3).ToString();
                // Get the possible Y-17 ion for the residue
                string posY17Ion = spectrum.SpectrumPossibleYm17Ions[aaSeq.Length - 1 - i].ToString();
                // Get the possible Y-18 ion for the residue
                string posY18Ion = spectrum.SpectrumPossibleYm18Ions[aaSeq.Length - 1 - i].ToString();
                // Get the residue
                string aa = aaSeq[i];
                // Create a string with the b-ion number, the residue and the y-ion number
                string seq = string.Format("b{0} \"{1}\" y{2}", i + 1, aa, aaSeq.Length - i);
                // Set the row
                string[] row = { posAIon, posB18Ion, posB17Ion, posBIon, seq, posYIon, posY17Ion, posY18Ion };
                // Add the row
                grid.Rows.Add(row);
            }

            // Set the style for the sequence colunm
            DataGridViewCellStyle seqStyle = new DataGridViewCellStyle
            {
                Font = new Font(grid.Font, FontStyle.Bold)
            };
            grid.Columns[4].DefaultCellStyle = seqStyle;

            // Set the style for the ions
            DataGridViewCellStyle bIonStyle = new DataGridViewCellStyle { ForeColor = BIonColor };
            DataGridViewCellStyle b17IonStyle = new DataGridViewCellStyle { ForeColor = B17IonColor };
            DataGridViewCellStyle b18IonStyle = new DataGridViewCellStyle { ForeColor = B18IonColor };
            DataGridViewCellStyle yIonStyle = new DataGridViewCellStyle { ForeColor = YIonColor };
            DataGridViewCellStyle y17IonStyle = new DataGridViewCellStyle { ForeColor = Y17IonColor };
            DataGridViewCellStyle y18IonStyle = new DataGridViewCellStyle { ForeColor = Y18IonColor };
            DataGridViewCellStyle aIonStyle = new DataGridViewCellStyle { ForeColor = AIonColor };

            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.BIonIndex)
            {
                grid.Rows[index].Cells[3].Style = bIonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.B17IonIndex)
            {
                grid.Rows[index].Cells[2].Style = b17IonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.B18IonIndex)
            {
                grid.Rows[index].Cells[1].Style = b18IonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.YIonIndex)
            {
                grid.Rows[aaSeq.Length - 1 - index].Cells[5].Style = yIonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.Y17IonIndex)
            {
                grid.Rows[aaSeq.Length - 1 - index].Cells[6].Style = y17IonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.Y18IonIndex)
            {
                grid.Rows[aaSeq.Length - 1 - index].Cells[7].Style = y18IonStyle;
            }
            // Loop through each of the ion index and set it to match the ion type
            foreach (int index in spectrum.AIonIndex)
            {
                grid.Rows[index].Cells[0].Style = aIonStyle;
            }

            grid.DefaultCellStyle.SelectionBackColor = grid.DefaultCellStyle.BackColor;
            grid.DefaultCellStyle.SelectionForeColor = grid.DefaultCellStyle.ForeColor;
        }

        /// <summary>
        /// Annotate a single spectra.
        /// </summary>
        /// <param name="chartMS2">The chart with the annotated chart.</param>
        /// <param name="citSpectra">The citrullinated spectrum to be annotated.</param>
        /// <param name="argSpectra">The arginine spectrum to be annotated.</param>
        /// <param name="aaSeq">The aa sequence.</param>
        /// <param name="createAnnotationFile">Indicates if a file with the annotations should be created.</param>
        /// <param name="annotationWriter">The annotation writer.</param>
        internal static void AnnotatePairedSpectra(Chart chartMS2, MsSpectrum citSpectra, MsSpectrum argSpectra, string[] aaSeq, bool createAnnotationFile, StringBuilder annotationWriter)
        {
            AnnotateSingleSpectra(chartMS2, citSpectra, aaSeq, true, createAnnotationFile, annotationWriter);
            AnnotateSingleSpectra(chartMS2, argSpectra, aaSeq, false, createAnnotationFile, annotationWriter);
        }

        /// <summary>
        /// Annotate a single spectra.
        /// </summary>
        /// <param name="chartMS2">The chart with the annotated chart.</param>
        /// <param name="spectrum">The spectrum to be annotated.</param>
        /// <param name="aaSeq">The aa sequence.</param>
        /// <param name="isCitSpectra">Indicator if it is <paramref name="spectrum"/> is the citrullinated.</param>
        /// <param name="createAnnotationFile">Indicates if a file with the annotations should be created.</param>
        /// <param name="annotationWriter">The annotation writer.</param>
        internal static void AnnotateSingleSpectra(Chart chartMS2, MsSpectrum spectrum, string[] aaSeq, bool isCitSpectra, bool createAnnotationFile, StringBuilder annotationWriter)
        {
            // Add the spectra type to the annotation writer, if should create annotation file
            if (createAnnotationFile)
            {
                annotationWriter.AppendLine(string.Format("*{0} spectra*", isCitSpectra ? "Citrullinated" : "Arginine"));
            }
            
            Dictionary<double, string> ionTypes = new Dictionary<double, string>();
            // Loop through the sequence
            for (int aaIndex = 0; aaIndex < aaSeq.Length - 1; aaIndex++)
            {
                // Check if ion is confirmed
                if (spectrum.BIonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleBIons[aaIndex], "b", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }

                // Check if ion is confirmed
                if (spectrum.B17IonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleBm17Ions[aaIndex], "b-17", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }

                // Check if ion is confirmed
                if (spectrum.B18IonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleBm18Ions[aaIndex], "b-18", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }

                // Check if ion is confirmed
                if (spectrum.AIonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleAIons[aaIndex], "a", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }

                // Check if ion is confirmed
                if (spectrum.YIonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleYIons[aaIndex], "y", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }

                // Check if ion is confirmed
                if (spectrum.Y17IonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleYm17Ions[aaIndex], "y-17", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }
                // Check if ion is confirmed
                if (spectrum.Y18IonIndex.Contains(aaIndex))
                {
                    // Create the notation
                    CreateNotation(chartMS2, spectrum.SpectrumPossibleYm17Ions[aaIndex], "y-18", isCitSpectra, aaIndex, createAnnotationFile, annotationWriter);
                }
            }

            // If Citrullia should generate annotation file
            if (createAnnotationFile)
            {
                // Get and sort the keys
                List<double> sortedMzValues = ionTypes.Keys.ToList();
                sortedMzValues.Sort();
                // Loop through all of the peaks and add them to the annotationWriter
                foreach (double ion in sortedMzValues)
                {
                    annotationWriter.AppendLine($"{ ion.ToString(FileReader.NumberFormat)}: { ionTypes[ion] }");
                }
                // Clear the list
                ionTypes.Clear();
            }

            
        }

        /// <summary>
        /// Create notation.
        /// </summary>
        /// <param name="chartMS2">The chart in which the ion to be notated is.</param>
        /// <param name="mz">The m/z of the ion to be notated.</param>
        /// <param name="ionType">The type of ion.</param>
        /// <param name="isCitSpectra">Indicates that the spectrum is a citrullinated.</param>
        /// <param name="aaIndex">The index of the aa in the sequence.</param>
        /// <param name="createAnnotationFile">Indicates if a file with the annotations should be created.</param>
        /// <param name="annotationWriter">The annotation writer.</param>
        private static void CreateNotation(Chart chartMS2, double mz, string ionType, bool isCitSpectra, int aaIndex, bool createAnnotationFile, StringBuilder annotationWriter)
        {
            // Get the maximum value on the X-axis and set a new one
            double prevXAxisMax = chartMS2.ChartAreas["ChartArea"].AxisX.Maximum;
            chartMS2.ChartAreas["ChartArea"].AxisX.Maximum = double.NaN;
            // Get the point index
            int pointIndex = GetPointIndex(mz, chartMS2.Series[isCitSpectra ? "Citrullinated" : "Arginine"].Points);
            // If point index is vald, create the annotation
            if (pointIndex != -1)
            {
                DataPoint point = chartMS2.Series[isCitSpectra ? "Citrullinated" : "Arginine"].Points[pointIndex];
                string ionNumber = string.Format("{0}({1})", ionType, aaIndex + 1);
                // Create the annotation
                TextAnnotation ta = new TextAnnotation()
                {
                    AnchorDataPoint = point,
                    AnchorX = point.XValue,
                    AnchorY = point.YValues[0],
                    AnchorOffsetX = 0,
                    AnchorOffsetY = 0,
                    Text = ionNumber
                };
                // Add the annotation
                chartMS2.Annotations.Add(ta);

                // If should create annotation file, add the point to the dictionary
                if (createAnnotationFile) { annotationWriter.AppendLine($"{ point.XValue.ToString(FileReader.NumberFormat) }:\t{ ionType }"); }
            }
            // Set the previous X-axis max value
            chartMS2.ChartAreas["ChartArea"].AxisX.Maximum = prevXAxisMax;
        }

        /// <summary>
        /// Get the index of the point with m/z-value equal to the point's X-value.
        /// </summary>
        /// <param name="mz">The m/z-value.</param>
        /// <param name="points">The collection of points.</param>
        /// <returns>The point index.</returns>
        private static int GetPointIndex(double mz, DataPointCollection points)
        {
            // Loop through all of the points and try to find the point which is approxmetly equal to the m/z-value.
            for (int i = 0; i < points.Count; i++)
            {
                if (HelperUtilities.IsApproximately(mz, points[i].XValue, 1)) return i;
            }

            // If no point was found, return -1
            return -1;
        }
    }
}
