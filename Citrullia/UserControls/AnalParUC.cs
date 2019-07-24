using System;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>The parameter control in Analysis.</summary>
    internal partial class AnalParUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalParUC"/>.
        /// </summary>
        internal AnalParUC()
        {
            InitializeComponent();
            metroComboBoxPME.SelectedIndex = 0;
            metroComboBoxFME.SelectedIndex = 1; 
        }

        /// <summary>
        /// Change the parent mass error unit used by X!Tandem.
        /// </summary>
        private void MetroComboBoxPME_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.XTandemInput.PMEType = metroComboBoxPME.SelectedItem.ToString();
        }

        /// <summary>
        /// Change the fragment mass unit used by X!Tandem.
        /// </summary>
        private void MetroComboBoxFME_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.XTandemInput.FMEType = metroComboBoxFME.SelectedItem.ToString();
        }

        /// <summary>
        /// Select the CID/HCD fragmentation method.
        /// Changes the possible ion types that X!Tandem should search for.
        /// </summary>
        private void MetroButtonHCD_Click(object sender, EventArgs e)
        {
            metroToggleAions.Checked = true;
            metroToggleBions.Checked = true;
            metroToggleCions.Checked = false;
            metroToggleXions.Checked = false;
            metroToggleYions.Checked = true;
            metroToggleZions.Checked = false;
        }

        /// <summary>
        /// Select the ECD/ETD fragmentation method.
        /// Changes the possible ion types that X!Tandem should search for.
        /// </summary>
        private void MetroButtonETD_Click(object sender, EventArgs e)
        {
            metroToggleAions.Checked = false;
            metroToggleBions.Checked = false;
            metroToggleCions.Checked = true;
            metroToggleXions.Checked = false;
            metroToggleYions.Checked = false;
            metroToggleZions.Checked = true;
        }

        /// <summary>
        /// Change if X!Tandem should search for A-ions.
        /// </summary>
        private void MetroToggleAions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleAions.Checked == true)
            {
                External.XTandemInput.Aions = "yes";
            }
            else
            {
                External.XTandemInput.Aions = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should search for B-ions.
        /// </summary>
        private void MetroToggleBions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleBions.Checked == true)
            {
                External.XTandemInput.Bions = "yes";
            }
            else
            {
                External.XTandemInput.Bions = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should search for C-ions.
        /// </summary>
        private void MetroToggleCions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleCions.Checked == true)
            {
                External.XTandemInput.Cions = "yes";
            }
            else
            {
                External.XTandemInput.Cions = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should search for Y-ions.
        /// </summary>
        private void MetroToggleYions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleYions.Checked == true)
            {
                External.XTandemInput.Yions = "yes";
            }
            else
            {
                External.XTandemInput.Yions = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should search for X-ions.
        /// </summary>
        private void MetroToggleXions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleXions.Checked == true)
            {
                External.XTandemInput.Xions = "yes";
            }
            else
            {
                External.XTandemInput.Xions = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should search for Z-ions.
        /// </summary>
        private void MetroToggleZions_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleZions.Checked == true)
            {
                External.XTandemInput.Zions = "yes";
            }
            else
            {
                External.XTandemInput.Zions = "no";
            }
        }

        /// <summary>
        /// Change the parent mass error minus? used by X!Tandem.
        /// </summary>
        private void MetroTextBoxPMEMinus_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.PMEMinus = metroTextBoxPMEMinus.Text;
        }

        /// <summary>
        /// Change the parent mass error plus? used by X!Tandem.
        /// </summary>
        private void MetroTextBoxPMEPLus_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.PMEPlus = metroTextBoxPMEPLus.Text;
        }

        /// <summary>
        /// Change the fragment error used by X!Tandem.
        /// </summary>
        private void MetroTextBoxFMError_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.FMError = metroTextBoxFMError.Text;
        }

        /// <summary>
        /// Change the total peaks used by X!Tandem.
        /// </summary>
        private void MetroTextBoxTPUsed_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.TPUsed = metroTextBoxTPUsed.Text;
        }

        /// <summary>
        /// Change the minimum peaks used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMPUsed_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MPUsed = metroTextBoxMPUsed.Text;
        }

        /// <summary>
        /// Change the minimum parent MZ-value used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMPmz_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MPmz = metroTextBoxMPmz.Text;
        }

        /// <summary>
        /// Change the minimum fragment MZ-value used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMFmz_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MFmz = metroTextBoxMFmz.Text;
        }

        /// <summary>
        /// Change the minimum parent charge used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMPCharge_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MPCharge = metroTextBoxMPCharge.Text;
        }

        /// <summary>
        /// Change the minimum e-value used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMEValue_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MEValue = metroTextBoxMEValue.Text;
        }

        /// <summary>
        /// Change the minimum ion count used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMICount_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MICount = metroTextBoxMICount.Text;
        }

        /// <summary>
        /// Change the maximum number of missed cleavages used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMMCleavages_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MMCleavages = metroTextBoxMMCleavages.Text;
        }

        /// <summary>
        /// Change the max e-value for refinment used by X!Tandem.
        /// </summary>
        private void MetroTextBoxRMEValue_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.RMEVaue = metroTextBoxRMEValue.Text;
        }

        /// <summary>
        /// Change the modification mass of the N-terminal used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMMNterm_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MMNterm = metroTextBoxMMNterm.Text;
        }

        /// <summary>
        /// Change the modification mass of the C-terminal used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMMCterm_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MMCterm = metroTextBoxMMCterm.Text;
        }

        /// <summary>
        /// Change the mass change of the N-terminal used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMCNterm_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MCNterm = metroTextBoxMCNterm.Text;
        }

        /// <summary>
        /// Change the mass change of the C-terminal used by X!Tandem.
        /// </summary>
        private void MetroTextBoxMCCterm_TextChanged(object sender, EventArgs e)
        {
            External.XTandemInput.MCCterm = metroTextBoxMCCterm.Text;
        }
    }
}
