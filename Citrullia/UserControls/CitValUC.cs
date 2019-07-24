using System;
using System.Windows.Forms;

namespace Citrullia.UserControls
{
    /// <summary>The validation window.</summary>
    internal partial class CitValUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="CitValUC"/>.
        /// </summary>
        internal CitValUC()
        {
            InitializeComponent();
            valFromCit.BringToFront();
            panelIndicator.Width = buttonFromCit.Width;
            panelIndicator.Left = buttonFromCit.Left;
        }

        /// <summary>
        /// Go to citrullination validation.
        /// </summary>
        private void ButtonFromCit_Click(object sender, EventArgs e)
        {
            valFromCit.BringToFront();
            panelIndicator.Width = buttonFromCit.Width;
            panelIndicator.Left = buttonFromCit.Left;
        }

        /// <summary>
        /// Go to arginine validation.
        /// </summary>
        private void ButtonFromArg_Click(object sender, EventArgs e)
        {
            valFromArg.BringToFront();
            panelIndicator.Width = buttonFromArg.Width;
            panelIndicator.Left = buttonFromArg.Left;
        }

        /// <summary>
        /// Go to lonely citrullination validation.
        /// </summary>
        private void ButtonFromOther_Click(object sender, EventArgs e)
        {
            valFromOther.BringToFront();
            panelIndicator.Width = buttonFromOther.Width;
            panelIndicator.Left = buttonFromOther.Left;
        }
    }
}
