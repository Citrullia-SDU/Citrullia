using System;
using System.Windows.Forms;


namespace Citrullia.UserControls
{
    /// <summary>The general parameter control in Analysis.</summary>
    internal partial class AnalAdvancedUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalAdvancedUC"/>.
        /// </summary>
        internal AnalAdvancedUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form.
        /// </summary>
        private void AnalAdvancedUC_Load(object sender, EventArgs e)
        {
            ScoreSettings.Load();
            metroTextBoxCutOffScore.Text = ScoreSettings.CutOffScore.ToString();
            metroToggleInclCutoff.Checked = ScoreSettings.IncludeCutOff;
            metroTextBoxAscore.Text = ScoreSettings.AIonMatchScore.ToString();
            metroTextBoxBscore.Text = ScoreSettings.BIonMatchScore.ToString();
            metroTextBoxYscore.Text = ScoreSettings.YIonMatchScore.ToString();
            metroTextBoxScoreDividerLoss.Text = ScoreSettings.LossMatchScoreDivider.ToString();
            metroTextBoxAIsoScore.Text = Properties.ScoreSettings.Default.MS2CyanicAIon.ToString();
            metroTextBoxBIsoScore.Text = Properties.ScoreSettings.Default.MS2CyanicBIon.ToString();
            metroTextBoxYIsoScore.Text = Properties.ScoreSettings.Default.MS2CyanicYIon.ToString();
            metroTextBoxLossDividerIsoScore.Text = Properties.ScoreSettings.Default.MS2CyanicNeuLoss.ToString();
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        private void MetroButtonSave_Click(object sender, EventArgs e)
        {
            ScoreSettings.Save();
        }

        /// <summary>
        /// Set to default settings
        /// </summary>
        private void MetroButtonSetDefault_Click(object sender, EventArgs e)
        {
            // Set the default settings
            metroTextBoxCutOffScore.Text = 50.ToString();
            metroToggleInclCutoff.Checked = true;
            metroTextBoxAscore.Text = 5.ToString();
            metroTextBoxBscore.Text = 10.ToString();
            metroTextBoxYscore.Text = 10.ToString();
            metroTextBoxScoreDividerLoss.Text = 2.ToString();
            metroTextBoxAIsoScore.Text = 5.ToString();
            metroTextBoxBIsoScore.Text = 10.ToString();
            metroTextBoxYIsoScore.Text = 10.ToString();
            metroTextBoxLossDividerIsoScore.Text = 2.ToString();
            // Save the settings
            ScoreSettings.Save();
        }

        #region Settings change events
        /// <summary>Toogle the include spectra in validation above cutoff.</summary>
        private void MetroToggleInclCutoff_CheckedChanged(object sender, EventArgs e)
        {
            ScoreSettings.IncludeCutOff = metroToggleInclCutoff.Checked;
        }
        /// <summary>Toogle the include spectra in validation above cutoff.</summary>
        private void MetroTextBoxCutOffScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if(double.TryParse(metroTextBoxCutOffScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out double cutoff))
            {
                if(cutoff > 0)
                {
                    ScoreSettings.CutOffScore = cutoff;
                }
            }
        }
        /// <summary>Change the A-ion score.</summary>
        private void MetroTextBoxAscore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxAscore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int aScore))
            {
                if (aScore > 0)
                {
                    ScoreSettings.AIonMatchScore = aScore;
                }
            }
        }
        /// <summary>Change the B-ion score.</summary>
        private void MetroTextBoxBscore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxYscore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int bScore))
            {
                if (bScore > 0)
                {
                    ScoreSettings.BIonMatchScore = bScore;
                }
            }
        }
        /// <summary>Change the Y-ion score.</summary>
        private void MetroTextBoxYscore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxYscore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int yScore))
            {
                if (yScore > 0)
                {
                    ScoreSettings.YIonMatchScore = yScore;
                }
            }
        }
        /// <summary>Change the loss ion score divider.</summary>
        private void MetroTextBoxScoreDividerLoss_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxScoreDividerLoss.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int divider))
            {
                if (divider > 0)
                {
                    ScoreSettings.LossMatchScoreDivider = divider;
                }
            }
        }
        /// <summary>Change score for the isocyanic loss at MS1.</summary>
        private void MetroTextBoxMs1IsoCyanLossScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxMs1IsoCyanLossScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int ms1CyanScore))
            {
                if (ms1CyanScore > 0)
                {
                    ScoreSettings.MS1IsoCyanicLossScore = ms1CyanScore;
                }
            }
        }
        /// <summary>Change score for the isocyanic loss from an A-ion at MS2.</summary>
        private void MetroTextBoxAIsoScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxAIsoScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int ms2AIonCyanScore))
            {
                if (ms2AIonCyanScore > 0)
                {
                    ScoreSettings.MS2IsoCyanLossAScore = ms2AIonCyanScore;
                }
            }
        }
        /// <summary>Change score for the isocyanic loss from an B-ion at MS2.</summary>
        private void MetroTextBoxBIsoScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxBIsoScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int ms2BIonCyanScore))
            {
                if (ms2BIonCyanScore > 0)
                {
                    ScoreSettings.MS2IsoCyanLossBScore = ms2BIonCyanScore;
                }
            }
        }
        /// <summary>Change score for the isocyanic loss from an Y-ion at MS2.</summary>
        private void MetroTextBoxYIsoScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxYIsoScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int ms2YIonCyanScore))
            {
                if (ms2YIonCyanScore > 0)
                {
                    ScoreSettings.MS2IsoCyanLossYScore = ms2YIonCyanScore;
                }
            }
        }
        /// <summary>Change score divider for the isocyanic loss from an -17/-18-ion at MS2-</summary>
        private void MetroTextBoxLossDividerIsoScore_TextChanged(object sender, EventArgs e)
        {
            // Try to parse the value. If possible, check that the value is greather than zero
            if (int.TryParse(metroTextBoxLossDividerIsoScore.Text, System.Globalization.NumberStyles.Any, FileReader.NumberFormat, out int ms2LossIonCyanScore))
            {
                if (ms2LossIonCyanScore > 0)
                {
                    ScoreSettings.MS2IsoCyanOnLossScoreDivider = ms2LossIonCyanScore;
                }
            }
        }
    }
    #endregion

}
