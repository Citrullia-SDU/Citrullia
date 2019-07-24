using System;

namespace Citrullia.UserControls
{
    partial class AnalAdvancedUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroToggleInclCutoff = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxCutOffScore = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxAscore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxYscore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxBscore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxScoreDividerLoss = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonSetDefault = new MetroFramework.Controls.MetroButton();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxMs1IsoCyanLossScore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxLossDividerIsoScore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxBIsoScore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxYIsoScore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxAIsoScore = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroToggleInclCutoff
            // 
            this.metroToggleInclCutoff.AutoSize = true;
            this.metroToggleInclCutoff.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggleInclCutoff.Location = new System.Drawing.Point(44, 118);
            this.metroToggleInclCutoff.Name = "metroToggleInclCutoff";
            this.metroToggleInclCutoff.Size = new System.Drawing.Size(80, 17);
            this.metroToggleInclCutoff.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggleInclCutoff.TabIndex = 2;
            this.metroToggleInclCutoff.Text = "Off";
            this.metroToggleInclCutoff.UseCustomBackColor = true;
            this.metroToggleInclCutoff.UseSelectable = true;
            this.metroToggleInclCutoff.UseStyleColors = true;
            this.metroToggleInclCutoff.CheckedChanged += new System.EventHandler(this.MetroToggleInclCutoff_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(130, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(259, 19);
            this.metroLabel2.TabIndex = 1000;
            this.metroLabel2.Text = "Include spectra automatically above cut-off";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(130, 93);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.TabIndex = 1000;
            this.metroLabel1.Text = "Cut-off score";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroTextBoxCutOffScore
            // 
            // 
            // 
            // 
            this.metroTextBoxCutOffScore.CustomButton.Image = null;
            this.metroTextBoxCutOffScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxCutOffScore.CustomButton.Name = "";
            this.metroTextBoxCutOffScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxCutOffScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxCutOffScore.CustomButton.TabIndex = 1;
            this.metroTextBoxCutOffScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxCutOffScore.CustomButton.UseSelectable = true;
            this.metroTextBoxCutOffScore.CustomButton.Visible = false;
            this.metroTextBoxCutOffScore.Lines = new string[] {
        "50"};
            this.metroTextBoxCutOffScore.Location = new System.Drawing.Point(73, 89);
            this.metroTextBoxCutOffScore.MaxLength = 32767;
            this.metroTextBoxCutOffScore.Name = "metroTextBoxCutOffScore";
            this.metroTextBoxCutOffScore.PasswordChar = '\0';
            this.metroTextBoxCutOffScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxCutOffScore.SelectedText = "";
            this.metroTextBoxCutOffScore.SelectionLength = 0;
            this.metroTextBoxCutOffScore.SelectionStart = 0;
            this.metroTextBoxCutOffScore.ShortcutsEnabled = true;
            this.metroTextBoxCutOffScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxCutOffScore.TabIndex = 1;
            this.metroTextBoxCutOffScore.Text = "50";
            this.metroTextBoxCutOffScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxCutOffScore.UseSelectable = true;
            this.metroTextBoxCutOffScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxCutOffScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxCutOffScore.TextChanged += new System.EventHandler(this.MetroTextBoxCutOffScore_TextChanged);
            // 
            // metroButtonSave
            // 
            this.metroButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonSave.ForeColor = System.Drawing.Color.White;
            this.metroButtonSave.Highlight = true;
            this.metroButtonSave.Location = new System.Drawing.Point(697, 393);
            this.metroButtonSave.Name = "metroButtonSave";
            this.metroButtonSave.Size = new System.Drawing.Size(75, 38);
            this.metroButtonSave.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonSave.TabIndex = 21;
            this.metroButtonSave.Text = "Save";
            this.metroButtonSave.UseCustomBackColor = true;
            this.metroButtonSave.UseCustomForeColor = true;
            this.metroButtonSave.UseSelectable = true;
            this.metroButtonSave.Click += new System.EventHandler(this.MetroButtonSave_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel9.Location = new System.Drawing.Point(73, 57);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(82, 25);
            this.metroLabel9.TabIndex = 1000;
            this.metroLabel9.Text = "CitScore";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(575, 57);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(116, 25);
            this.metroLabel3.TabIndex = 1000;
            this.metroLabel3.Text = "Match score";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(632, 89);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(143, 19);
            this.metroLabel4.TabIndex = 1000;
            this.metroLabel4.Text = "Score per A-ion match";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroTextBoxAscore
            // 
            // 
            // 
            // 
            this.metroTextBoxAscore.CustomButton.Image = null;
            this.metroTextBoxAscore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxAscore.CustomButton.Name = "";
            this.metroTextBoxAscore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxAscore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxAscore.CustomButton.TabIndex = 1;
            this.metroTextBoxAscore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxAscore.CustomButton.UseSelectable = true;
            this.metroTextBoxAscore.CustomButton.Visible = false;
            this.metroTextBoxAscore.Lines = new string[] {
        "5"};
            this.metroTextBoxAscore.Location = new System.Drawing.Point(575, 85);
            this.metroTextBoxAscore.MaxLength = 32767;
            this.metroTextBoxAscore.Name = "metroTextBoxAscore";
            this.metroTextBoxAscore.PasswordChar = '\0';
            this.metroTextBoxAscore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxAscore.SelectedText = "";
            this.metroTextBoxAscore.SelectionLength = 0;
            this.metroTextBoxAscore.SelectionStart = 0;
            this.metroTextBoxAscore.ShortcutsEnabled = true;
            this.metroTextBoxAscore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxAscore.TabIndex = 10;
            this.metroTextBoxAscore.Text = "5";
            this.metroTextBoxAscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxAscore.UseSelectable = true;
            this.metroTextBoxAscore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxAscore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxAscore.TextChanged += new System.EventHandler(this.MetroTextBoxAscore_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(632, 147);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(142, 19);
            this.metroLabel5.TabIndex = 1000;
            this.metroLabel5.Text = "Score per Y-ion match";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroTextBoxYscore
            // 
            // 
            // 
            // 
            this.metroTextBoxYscore.CustomButton.Image = null;
            this.metroTextBoxYscore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxYscore.CustomButton.Name = "";
            this.metroTextBoxYscore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxYscore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxYscore.CustomButton.TabIndex = 1;
            this.metroTextBoxYscore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxYscore.CustomButton.UseSelectable = true;
            this.metroTextBoxYscore.CustomButton.Visible = false;
            this.metroTextBoxYscore.Lines = new string[] {
        "10"};
            this.metroTextBoxYscore.Location = new System.Drawing.Point(575, 143);
            this.metroTextBoxYscore.MaxLength = 32767;
            this.metroTextBoxYscore.Name = "metroTextBoxYscore";
            this.metroTextBoxYscore.PasswordChar = '\0';
            this.metroTextBoxYscore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxYscore.SelectedText = "";
            this.metroTextBoxYscore.SelectionLength = 0;
            this.metroTextBoxYscore.SelectionStart = 0;
            this.metroTextBoxYscore.ShortcutsEnabled = true;
            this.metroTextBoxYscore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxYscore.TabIndex = 12;
            this.metroTextBoxYscore.Text = "10";
            this.metroTextBoxYscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxYscore.UseSelectable = true;
            this.metroTextBoxYscore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxYscore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxYscore.TextChanged += new System.EventHandler(this.MetroTextBoxYscore_TextChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(632, 118);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(142, 19);
            this.metroLabel6.TabIndex = 1000;
            this.metroLabel6.Text = "Score per B-ion match";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroTextBoxBscore
            // 
            // 
            // 
            // 
            this.metroTextBoxBscore.CustomButton.Image = null;
            this.metroTextBoxBscore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxBscore.CustomButton.Name = "";
            this.metroTextBoxBscore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxBscore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxBscore.CustomButton.TabIndex = 1;
            this.metroTextBoxBscore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxBscore.CustomButton.UseSelectable = true;
            this.metroTextBoxBscore.CustomButton.Visible = false;
            this.metroTextBoxBscore.Lines = new string[] {
        "10"};
            this.metroTextBoxBscore.Location = new System.Drawing.Point(575, 114);
            this.metroTextBoxBscore.MaxLength = 32767;
            this.metroTextBoxBscore.Name = "metroTextBoxBscore";
            this.metroTextBoxBscore.PasswordChar = '\0';
            this.metroTextBoxBscore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxBscore.SelectedText = "";
            this.metroTextBoxBscore.SelectionLength = 0;
            this.metroTextBoxBscore.SelectionStart = 0;
            this.metroTextBoxBscore.ShortcutsEnabled = true;
            this.metroTextBoxBscore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxBscore.TabIndex = 11;
            this.metroTextBoxBscore.Text = "10";
            this.metroTextBoxBscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxBscore.UseSelectable = true;
            this.metroTextBoxBscore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxBscore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxBscore.TextChanged += new System.EventHandler(this.MetroTextBoxBscore_TextChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(632, 176);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(132, 19);
            this.metroLabel7.TabIndex = 1000;
            this.metroLabel7.Text = "Score divider for loss";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // metroTextBoxScoreDividerLoss
            // 
            // 
            // 
            // 
            this.metroTextBoxScoreDividerLoss.CustomButton.Image = null;
            this.metroTextBoxScoreDividerLoss.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxScoreDividerLoss.CustomButton.Name = "";
            this.metroTextBoxScoreDividerLoss.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxScoreDividerLoss.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxScoreDividerLoss.CustomButton.TabIndex = 1;
            this.metroTextBoxScoreDividerLoss.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxScoreDividerLoss.CustomButton.UseSelectable = true;
            this.metroTextBoxScoreDividerLoss.CustomButton.Visible = false;
            this.metroTextBoxScoreDividerLoss.Lines = new string[] {
        "2"};
            this.metroTextBoxScoreDividerLoss.Location = new System.Drawing.Point(575, 172);
            this.metroTextBoxScoreDividerLoss.MaxLength = 32767;
            this.metroTextBoxScoreDividerLoss.Name = "metroTextBoxScoreDividerLoss";
            this.metroTextBoxScoreDividerLoss.PasswordChar = '\0';
            this.metroTextBoxScoreDividerLoss.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxScoreDividerLoss.SelectedText = "";
            this.metroTextBoxScoreDividerLoss.SelectionLength = 0;
            this.metroTextBoxScoreDividerLoss.SelectionStart = 0;
            this.metroTextBoxScoreDividerLoss.ShortcutsEnabled = true;
            this.metroTextBoxScoreDividerLoss.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxScoreDividerLoss.TabIndex = 13;
            this.metroTextBoxScoreDividerLoss.Text = "2";
            this.metroTextBoxScoreDividerLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxScoreDividerLoss.UseSelectable = true;
            this.metroTextBoxScoreDividerLoss.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxScoreDividerLoss.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxScoreDividerLoss.TextChanged += new System.EventHandler(this.MetroTextBoxScoreDividerLoss_TextChanged);
            // 
            // metroButtonSetDefault
            // 
            this.metroButtonSetDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonSetDefault.ForeColor = System.Drawing.Color.White;
            this.metroButtonSetDefault.Highlight = true;
            this.metroButtonSetDefault.Location = new System.Drawing.Point(616, 393);
            this.metroButtonSetDefault.Name = "metroButtonSetDefault";
            this.metroButtonSetDefault.Size = new System.Drawing.Size(75, 38);
            this.metroButtonSetDefault.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonSetDefault.TabIndex = 20;
            this.metroButtonSetDefault.Text = "Set default";
            this.metroButtonSetDefault.UseCustomBackColor = true;
            this.metroButtonSetDefault.UseCustomForeColor = true;
            this.metroButtonSetDefault.UseSelectable = true;
            this.metroButtonSetDefault.Click += new System.EventHandler(this.MetroButtonSetDefault_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(130, 145);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(148, 19);
            this.metroLabel10.TabIndex = 1000;
            this.metroLabel10.Text = "MS1 Isocyanic loss score";
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // metroTextBoxMs1IsoCyanLossScore
            // 
            // 
            // 
            // 
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Image = null;
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Name = "";
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.TabIndex = 1;
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.UseSelectable = true;
            this.metroTextBoxMs1IsoCyanLossScore.CustomButton.Visible = false;
            this.metroTextBoxMs1IsoCyanLossScore.Lines = new string[] {
        "10"};
            this.metroTextBoxMs1IsoCyanLossScore.Location = new System.Drawing.Point(73, 141);
            this.metroTextBoxMs1IsoCyanLossScore.MaxLength = 32767;
            this.metroTextBoxMs1IsoCyanLossScore.Name = "metroTextBoxMs1IsoCyanLossScore";
            this.metroTextBoxMs1IsoCyanLossScore.PasswordChar = '\0';
            this.metroTextBoxMs1IsoCyanLossScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxMs1IsoCyanLossScore.SelectedText = "";
            this.metroTextBoxMs1IsoCyanLossScore.SelectionLength = 0;
            this.metroTextBoxMs1IsoCyanLossScore.SelectionStart = 0;
            this.metroTextBoxMs1IsoCyanLossScore.ShortcutsEnabled = true;
            this.metroTextBoxMs1IsoCyanLossScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxMs1IsoCyanLossScore.TabIndex = 3;
            this.metroTextBoxMs1IsoCyanLossScore.Text = "10";
            this.metroTextBoxMs1IsoCyanLossScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxMs1IsoCyanLossScore.UseSelectable = true;
            this.metroTextBoxMs1IsoCyanLossScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxMs1IsoCyanLossScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxMs1IsoCyanLossScore.TextChanged += new System.EventHandler(this.MetroTextBoxMs1IsoCyanLossScore_TextChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(130, 283);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(237, 19);
            this.metroLabel8.TabIndex = 1000;
            this.metroLabel8.Text = "Divider for isocyanic loss on -17/-18 ion";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroTextBoxLossDividerIsoScore
            // 
            // 
            // 
            // 
            this.metroTextBoxLossDividerIsoScore.CustomButton.Image = null;
            this.metroTextBoxLossDividerIsoScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxLossDividerIsoScore.CustomButton.Name = "";
            this.metroTextBoxLossDividerIsoScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxLossDividerIsoScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxLossDividerIsoScore.CustomButton.TabIndex = 1;
            this.metroTextBoxLossDividerIsoScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxLossDividerIsoScore.CustomButton.UseSelectable = true;
            this.metroTextBoxLossDividerIsoScore.CustomButton.Visible = false;
            this.metroTextBoxLossDividerIsoScore.Lines = new string[] {
        "2"};
            this.metroTextBoxLossDividerIsoScore.Location = new System.Drawing.Point(73, 279);
            this.metroTextBoxLossDividerIsoScore.MaxLength = 32767;
            this.metroTextBoxLossDividerIsoScore.Name = "metroTextBoxLossDividerIsoScore";
            this.metroTextBoxLossDividerIsoScore.PasswordChar = '\0';
            this.metroTextBoxLossDividerIsoScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxLossDividerIsoScore.SelectedText = "";
            this.metroTextBoxLossDividerIsoScore.SelectionLength = 0;
            this.metroTextBoxLossDividerIsoScore.SelectionStart = 0;
            this.metroTextBoxLossDividerIsoScore.ShortcutsEnabled = true;
            this.metroTextBoxLossDividerIsoScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxLossDividerIsoScore.TabIndex = 7;
            this.metroTextBoxLossDividerIsoScore.Text = "2";
            this.metroTextBoxLossDividerIsoScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxLossDividerIsoScore.UseSelectable = true;
            this.metroTextBoxLossDividerIsoScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxLossDividerIsoScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxLossDividerIsoScore.TextChanged += new System.EventHandler(this.MetroTextBoxLossDividerIsoScore_TextChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(130, 225);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(41, 19);
            this.metroLabel11.TabIndex = 1000;
            this.metroLabel11.Text = "B-ion";
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // metroTextBoxBIsoScore
            // 
            // 
            // 
            // 
            this.metroTextBoxBIsoScore.CustomButton.Image = null;
            this.metroTextBoxBIsoScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxBIsoScore.CustomButton.Name = "";
            this.metroTextBoxBIsoScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxBIsoScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxBIsoScore.CustomButton.TabIndex = 1;
            this.metroTextBoxBIsoScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxBIsoScore.CustomButton.UseSelectable = true;
            this.metroTextBoxBIsoScore.CustomButton.Visible = false;
            this.metroTextBoxBIsoScore.Lines = new string[] {
        "10"};
            this.metroTextBoxBIsoScore.Location = new System.Drawing.Point(73, 221);
            this.metroTextBoxBIsoScore.MaxLength = 32767;
            this.metroTextBoxBIsoScore.Name = "metroTextBoxBIsoScore";
            this.metroTextBoxBIsoScore.PasswordChar = '\0';
            this.metroTextBoxBIsoScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxBIsoScore.SelectedText = "";
            this.metroTextBoxBIsoScore.SelectionLength = 0;
            this.metroTextBoxBIsoScore.SelectionStart = 0;
            this.metroTextBoxBIsoScore.ShortcutsEnabled = true;
            this.metroTextBoxBIsoScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxBIsoScore.TabIndex = 5;
            this.metroTextBoxBIsoScore.Text = "10";
            this.metroTextBoxBIsoScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxBIsoScore.UseSelectable = true;
            this.metroTextBoxBIsoScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxBIsoScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxBIsoScore.TextChanged += new System.EventHandler(this.MetroTextBoxBIsoScore_TextChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(130, 254);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(41, 19);
            this.metroLabel12.TabIndex = 1000;
            this.metroLabel12.Text = "Y-ion";
            this.metroLabel12.UseCustomBackColor = true;
            // 
            // metroTextBoxYIsoScore
            // 
            // 
            // 
            // 
            this.metroTextBoxYIsoScore.CustomButton.Image = null;
            this.metroTextBoxYIsoScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxYIsoScore.CustomButton.Name = "";
            this.metroTextBoxYIsoScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxYIsoScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxYIsoScore.CustomButton.TabIndex = 1;
            this.metroTextBoxYIsoScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxYIsoScore.CustomButton.UseSelectable = true;
            this.metroTextBoxYIsoScore.CustomButton.Visible = false;
            this.metroTextBoxYIsoScore.Lines = new string[] {
        "10"};
            this.metroTextBoxYIsoScore.Location = new System.Drawing.Point(73, 250);
            this.metroTextBoxYIsoScore.MaxLength = 32767;
            this.metroTextBoxYIsoScore.Name = "metroTextBoxYIsoScore";
            this.metroTextBoxYIsoScore.PasswordChar = '\0';
            this.metroTextBoxYIsoScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxYIsoScore.SelectedText = "";
            this.metroTextBoxYIsoScore.SelectionLength = 0;
            this.metroTextBoxYIsoScore.SelectionStart = 0;
            this.metroTextBoxYIsoScore.ShortcutsEnabled = true;
            this.metroTextBoxYIsoScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxYIsoScore.TabIndex = 6;
            this.metroTextBoxYIsoScore.Text = "10";
            this.metroTextBoxYIsoScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxYIsoScore.UseSelectable = true;
            this.metroTextBoxYIsoScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxYIsoScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxYIsoScore.TextChanged += new System.EventHandler(this.MetroTextBoxYIsoScore_TextChanged);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(130, 196);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(42, 19);
            this.metroLabel13.TabIndex = 1000;
            this.metroLabel13.Text = "A-ion";
            this.metroLabel13.UseCustomBackColor = true;
            // 
            // metroTextBoxAIsoScore
            // 
            // 
            // 
            // 
            this.metroTextBoxAIsoScore.CustomButton.Image = null;
            this.metroTextBoxAIsoScore.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.metroTextBoxAIsoScore.CustomButton.Name = "";
            this.metroTextBoxAIsoScore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxAIsoScore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxAIsoScore.CustomButton.TabIndex = 1;
            this.metroTextBoxAIsoScore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxAIsoScore.CustomButton.UseSelectable = true;
            this.metroTextBoxAIsoScore.CustomButton.Visible = false;
            this.metroTextBoxAIsoScore.Lines = new string[] {
        "5"};
            this.metroTextBoxAIsoScore.Location = new System.Drawing.Point(73, 192);
            this.metroTextBoxAIsoScore.MaxLength = 32767;
            this.metroTextBoxAIsoScore.Name = "metroTextBoxAIsoScore";
            this.metroTextBoxAIsoScore.PasswordChar = '\0';
            this.metroTextBoxAIsoScore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxAIsoScore.SelectedText = "";
            this.metroTextBoxAIsoScore.SelectionLength = 0;
            this.metroTextBoxAIsoScore.SelectionStart = 0;
            this.metroTextBoxAIsoScore.ShortcutsEnabled = true;
            this.metroTextBoxAIsoScore.Size = new System.Drawing.Size(51, 23);
            this.metroTextBoxAIsoScore.TabIndex = 4;
            this.metroTextBoxAIsoScore.Text = "5";
            this.metroTextBoxAIsoScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBoxAIsoScore.UseSelectable = true;
            this.metroTextBoxAIsoScore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxAIsoScore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBoxAIsoScore.TextChanged += new System.EventHandler(this.MetroTextBoxAIsoScore_TextChanged);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel14.Location = new System.Drawing.Point(73, 167);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(153, 19);
            this.metroLabel14.TabIndex = 1000;
            this.metroLabel14.Text = "MS2 Isocyanic loss on";
            this.metroLabel14.UseCustomBackColor = true;
            // 
            // AnalAdvancedUC
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroTextBoxLossDividerIsoScore);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroTextBoxBIsoScore);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.metroTextBoxYIsoScore);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroTextBoxAIsoScore);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroTextBoxMs1IsoCyanLossScore);
            this.Controls.Add(this.metroButtonSetDefault);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroTextBoxScoreDividerLoss);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroTextBoxBscore);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroTextBoxYscore);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroTextBoxAscore);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroButtonSave);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBoxCutOffScore);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroToggleInclCutoff);
            this.Name = "AnalAdvancedUC";
            this.Size = new System.Drawing.Size(815, 456);
            this.Load += new System.EventHandler(this.AnalAdvancedUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private MetroFramework.Controls.MetroToggle metroToggleInclCutoff;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxCutOffScore;
        private MetroFramework.Controls.MetroButton metroButtonSave;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox metroTextBoxAscore;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox metroTextBoxBscore;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox metroTextBoxScoreDividerLoss;
        private MetroFramework.Controls.MetroTextBox metroTextBoxYscore;
        private MetroFramework.Controls.MetroButton metroButtonSetDefault;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox metroTextBoxMs1IsoCyanLossScore;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox metroTextBoxLossDividerIsoScore;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox metroTextBoxBIsoScore;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox metroTextBoxYIsoScore;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox metroTextBoxAIsoScore;
        private MetroFramework.Controls.MetroLabel metroLabel14;
    }
}
