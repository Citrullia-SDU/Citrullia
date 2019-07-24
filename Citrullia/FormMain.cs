using System;
using System.Linq;
using System.Windows.Forms;

namespace Citrullia
{
    /// <summary>
    /// The main form.
    /// </summary>
    internal partial class FormMain : Form
    {
        /// <summary>
        /// Create a new instance of <see cref="FormMain"/>.
        /// </summary>
        internal FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Create the AA Mass dictionary
            IonCalculation.MakeAaMassDictionary();

            startUC1.BringToFront();
            labelTitel.Text = "Home";
        }

        #region Move form around with mouse
        /// <summary>
        /// Move form around using mouse.
        /// Source: https://stackoverflow.com/a/7125686
        /// </summary>
        private void P2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, NativeMethods.ZERO_INTPTR);
            }
        }

        /// <summary>
        /// Move form around using mouse.
        /// Source: https://stackoverflow.com/a/7125686
        /// </summary>
        private void PCenter_MouseDown(object sender, MouseEventArgs e) //This is not working with the current setup
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, NativeMethods.ZERO_INTPTR);
            }
        }
        #endregion

        #region Buttons/Clickable objects
        /// <summary>
        /// Exit the program.
        /// </summary>
        private void ExitL_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimize the form.
        /// </summary>
        private void LabMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Go to the Validation-step.
        /// </summary>
        private void CitValB_Click(object sender, EventArgs e)
        {
            citValUC1.BringToFront();
            labelTitel.Text = "Validation";
            //Moves indicator panel to this button:
            indicatorP.Height = citValB.Height;
            indicatorP.Top = citValB.Top;
        }

        /// <summary>
        /// Go to the Home-step.
        /// </summary>
        private void HomeB_Click(object sender, EventArgs e)
        {
            startUC1.BringToFront();
            labelTitel.Text = "Home";
            //Moves indicator panel to this button:
            indicatorP.Height = homeB.Height;
            indicatorP.Top = homeB.Top;
        }

        /// <summary>
        /// Go to the Analysis-step.
        /// </summary>
        private void AnalysisB_Click(object sender, EventArgs e)
        {
            analysisXUC1.BringToFront();
            labelTitel.Text = "Analysis";
            //Moves indicator panel to this button:
            indicatorP.Height = analysisB.Height;
            indicatorP.Top = analysisB.Top;
        }

        /// <summary>
        /// Go to the Quantification-step.
        /// </summary>
        private void Ms1ValB_Click(object sender, EventArgs e)
        {
            mS1Val1.BringToFront(); //Remember mS1Val is the UserControl
            labelTitel.Text = "Finishing";
            //Moves indicator panel to this button:
            indicatorP.Height = ms1ValB.Height;
            indicatorP.Top = ms1ValB.Top;
        }

        /// <summary>
        /// Change to Validation-step.
        /// </summary>
        internal void ChangeToValidation()
        {
            citValUC1.BringToFront();
            labelTitel.Text = "Validation";
            //Moves indicator panel to this button:
            indicatorP.Height = citValB.Height;
            indicatorP.Top = citValB.Top;
        }
        /// <summary>
        /// Go to Analysis-step.
        /// </summary>
        internal void ChangeToAnalysis()
        {
            analysisXUC1.ChangeAnalGenUCFilesLoadedBox();
            analysisXUC1.BringToFront();
            labelTitel.Text = "Analysis";
            indicatorP.Height = analysisB.Height;
            indicatorP.Top = analysisB.Top;
            
        }
        #endregion

        #region Open validation windows
        #region Citrullination validation
        /// <summary>The validation form for citrullinations.</summary>
        ValidationCitUI ValidationUI { get; set; }
        /// <summary>The citrullination validation spectrum id.</summary>
        internal int citSpectrumValID = 0;

        /// <summary>
        /// Open validation spectrum for citrullinations.
        /// </summary>
        /// <param name="spectrumID">The spectrum ID.</param>
        internal void OpenCitValidationWindow(int spectrumID)
        {
            // Check if an form already is open
            if (Application.OpenForms.OfType<ValidationCitUI>().Count() == 1)
            {
                // Set the spectrum id.
                ReturnSpecID(spectrumID);
                // If form is already open, update the validation form.
                ValidationUI.UpdateValidationUI(citSpectrumValID);
            }
            else
            {
                // Set the spectrum id.
                ReturnSpecID(spectrumID);
                // If a form is not already open, create a new one
                ValidationUI = new ValidationCitUI(this);
                // And show.
                ValidationUI.Show();
            }
        }

        private int ReturnSpecID(int spectrumID)
        {
            citSpectrumValID = spectrumID;
            return citSpectrumValID;
        }
        #endregion

        #region Arginine validation
        /// <summary>The validation form for arginines.</summary>
        ValidationArgUI ValidationArgUI { get; set; }
        /// <summary>The arginine validation spectrum id.</summary>
        internal int argSpectrumValID = 0;

        /// <summary>
        /// Open validation spectrum for arginines.
        /// </summary>
        /// <param name="spectrumID">The spectrum ID.</param>
        internal void OpenArgValidationWindow(int spectrumID)
        {
            // Check if an form already is open
            if (Application.OpenForms.OfType<ValidationArgUI>().Count() == 1)
            {
                // Set the spectrum id.
                ReturnArgSpecID(spectrumID);
                // If form is already open, update the validation form.
                ValidationArgUI.UpdateValidationArgUI(argSpectrumValID);
            }
            else
            {
                // Set the spectrum id.
                ReturnArgSpecID(spectrumID);
                // If a form is not already open, create a new one
                ValidationArgUI = new ValidationArgUI(this);
                // And show.
                ValidationArgUI.Show();
            }
        }

        private int ReturnArgSpecID(int spectrumID)
        {
            argSpectrumValID = spectrumID;
            return argSpectrumValID;
        }
        #endregion

        #region Lonely citrullinations validation
        /// <summary>The validation form for lone citrullinations.</summary>
        ValidationLoneCitUI ValidationLoneCitUI { get; set; }
        /// <summary>The lonely citrullination validation spectrum id.</summary>
        internal int lonelySpectrumValID = 0;

        /// <summary>
        /// Open validation spectrum for lonely citrullinations.
        /// </summary>
        /// <param name="spectrumID">The spectrum ID.</param>
        internal void OpenLonelyValidationWindow(int spectrumID)
        {
            // Check if an form already is open
            if (Application.OpenForms.OfType<ValidationLoneCitUI>().Count() == 1)
            {
                // Set the spectrum id.
                ReturnLonelySpecID(spectrumID);
                // If form is already open, update the validation form.
                ValidationLoneCitUI.UpdateValidationUI(lonelySpectrumValID);
            }
            else
            {
                // Set the spectrum id.
                ReturnLonelySpecID(spectrumID);
                // If a form is not already open, create a new one
                ValidationLoneCitUI = new ValidationLoneCitUI(this);
                // And show.
                ValidationLoneCitUI.Show();
            }
        }

        private int ReturnLonelySpecID(int spectrumID)
        {
            lonelySpectrumValID = spectrumID;
            return lonelySpectrumValID;
        }
        #endregion
        #endregion
    }
}
