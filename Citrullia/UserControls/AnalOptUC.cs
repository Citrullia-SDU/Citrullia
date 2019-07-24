using System;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>The X!Tandem search parameter control in Analysis.</summary>
    internal partial class AnalOptUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalOptUC"/>.
        /// </summary>
        internal AnalOptUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Change if X!Tandem should use Noise supression
        /// </summary>
        private void MetroToggleNSuppression_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleNSuppression.Checked == true)
            {
                External.XTandemInput.NSuppression = "yes";
            }
            else
            {
                External.XTandemInput.NSuppression = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should serch for N-termial acetylations.
        /// </summary>
        private void MetroToggleNTAcetylation_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleNTAcetylation.Checked == true)
            {
                External.XTandemInput.NTAcetylation = "yes";
            }
            else
            {
                External.XTandemInput.NTAcetylation = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should serch for N-terminal pyrolidone.
        /// </summary>
        private void MetroToggleNTPyrolidone_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleNTPyrolidone.Checked == true)
            {
                External.XTandemInput.NTPyrolidone = "yes";
            }
            else
            {
                External.XTandemInput.NTPyrolidone = "no";
            }
        }
        
        /// <summary>
        /// Change if X!Tandem should serch for mass isotope error?
        /// </summary>
        private void MetroToggleMIError_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleMIError.Checked == true)
            {
                External.XTandemInput.MIError = "yes";
            }
            else
            {
                External.XTandemInput.MIError = "no";
            }
        }
        
        /// <summary>
        /// Change if X!Tandem should refine for missed cleavges.
        /// </summary>
        private void MetroToggleSCleavage_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleSCleavage.Checked == true)
            {
                External.XTandemInput.SCleavage = "yes";
            }
            else
            {
                External.XTandemInput.SCleavage = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should refine for unspecific cleavges.
        /// </summary>
        private void MetroToggleUCleavage_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleUCleavage.Checked == true)
            {
                External.XTandemInput.UCleavage = "yes";
            }
            else
            {
                External.XTandemInput.UCleavage = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should refine for point mutations.
        /// </summary>
        private void MetroTogglePMutations_CheckedChanged(object sender, EventArgs e)
        {
            if (metroTogglePMutations.Checked == true)
            {
                External.XTandemInput.PMutations = "yes";
            }
            else
            {
                External.XTandemInput.PMutations = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should refine for spectrum syntheis?.
        /// </summary>
        private void MetroToggleSSynthesis_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleSSynthesis.Checked == true)
            {
                External.XTandemInput.SSynthesis = "yes";
            }
            else
            {
                External.XTandemInput.SSynthesis = "no";
            }
        }

        /// <summary>
        /// Change if X!Tandem should refine for N-termal acetylations.
        /// </summary>
        private void MetroToggleRNTAcetylation_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleRNTAcetylation.Checked == true)
            {
                External.XTandemInput.RNTAcetylation = "yes";
            }
            else
            {
                External.XTandemInput.RNTAcetylation = "no";
            }
        }
    }
}
