namespace Citrullia.UserControls
{
    partial class AnalGenUC
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
            this.metroBtnLoadSeqFile = new MetroFramework.Controls.MetroButton();
            this.metroToggleSearchCrapList = new MetroFramework.Controls.MetroToggle();
            this.metroLabelCrapList = new MetroFramework.Controls.MetroLabel();
            this.metroToggleRefine = new MetroFramework.Controls.MetroToggle();
            this.metroLabelRefinement = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxEnzyme = new MetroFramework.Controls.MetroComboBox();
            this.metroLabelEnzyme = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxThreads = new MetroFramework.Controls.MetroComboBox();
            this.metroLabelThreads = new MetroFramework.Controls.MetroLabel();
            this.metroLabelSequenceFile = new MetroFramework.Controls.MetroLabel();
            this.metroLabelSelectedFile = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxFiles = new MetroFramework.Controls.MetroTextBox();
            this.metroLabelInputFile = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroBtnLoadSeqFile
            // 
            this.metroBtnLoadSeqFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroBtnLoadSeqFile.ForeColor = System.Drawing.Color.White;
            this.metroBtnLoadSeqFile.Highlight = true;
            this.metroBtnLoadSeqFile.Location = new System.Drawing.Point(437, 80);
            this.metroBtnLoadSeqFile.Name = "metroBtnLoadSeqFile";
            this.metroBtnLoadSeqFile.Size = new System.Drawing.Size(75, 38);
            this.metroBtnLoadSeqFile.Style = MetroFramework.MetroColorStyle.White;
            this.metroBtnLoadSeqFile.TabIndex = 1;
            this.metroBtnLoadSeqFile.Text = "Select";
            this.metroBtnLoadSeqFile.UseCustomBackColor = true;
            this.metroBtnLoadSeqFile.UseCustomForeColor = true;
            this.metroBtnLoadSeqFile.UseSelectable = true;
            this.metroBtnLoadSeqFile.Click += new System.EventHandler(this.MetroBtnLoadSeqFile_Click);
            // 
            // metroToggleSearchCrapList
            // 
            this.metroToggleSearchCrapList.AutoSize = true;
            this.metroToggleSearchCrapList.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggleSearchCrapList.Location = new System.Drawing.Point(81, 141);
            this.metroToggleSearchCrapList.Name = "metroToggleSearchCrapList";
            this.metroToggleSearchCrapList.Size = new System.Drawing.Size(80, 17);
            this.metroToggleSearchCrapList.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggleSearchCrapList.TabIndex = 2;
            this.metroToggleSearchCrapList.Text = "Off";
            this.metroToggleSearchCrapList.UseCustomBackColor = true;
            this.metroToggleSearchCrapList.UseSelectable = true;
            this.metroToggleSearchCrapList.UseStyleColors = true;
            this.metroToggleSearchCrapList.CheckedChanged += new System.EventHandler(this.MetroToggleSearchCrapList_CheckedChanged);
            // 
            // metroLabelCrapList
            // 
            this.metroLabelCrapList.AutoSize = true;
            this.metroLabelCrapList.Location = new System.Drawing.Point(167, 139);
            this.metroLabelCrapList.Name = "metroLabelCrapList";
            this.metroLabelCrapList.Size = new System.Drawing.Size(100, 19);
            this.metroLabelCrapList.TabIndex = 3;
            this.metroLabelCrapList.Text = "Search crap List";
            this.metroLabelCrapList.UseCustomBackColor = true;
            // 
            // metroToggleRefine
            // 
            this.metroToggleRefine.AutoSize = true;
            this.metroToggleRefine.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggleRefine.Location = new System.Drawing.Point(81, 189);
            this.metroToggleRefine.Name = "metroToggleRefine";
            this.metroToggleRefine.Size = new System.Drawing.Size(80, 17);
            this.metroToggleRefine.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggleRefine.TabIndex = 4;
            this.metroToggleRefine.Text = "Off";
            this.metroToggleRefine.UseCustomBackColor = true;
            this.metroToggleRefine.UseSelectable = true;
            this.metroToggleRefine.UseStyleColors = true;
            this.metroToggleRefine.CheckedChanged += new System.EventHandler(this.MetroToggleRefine_CheckedChanged);
            // 
            // metroLabelRefinement
            // 
            this.metroLabelRefinement.AutoSize = true;
            this.metroLabelRefinement.Location = new System.Drawing.Point(167, 187);
            this.metroLabelRefinement.Name = "metroLabelRefinement";
            this.metroLabelRefinement.Size = new System.Drawing.Size(75, 19);
            this.metroLabelRefinement.TabIndex = 5;
            this.metroLabelRefinement.Text = "Refinement";
            this.metroLabelRefinement.UseCustomBackColor = true;
            // 
            // metroComboBoxEnzyme
            // 
            this.metroComboBoxEnzyme.FormattingEnabled = true;
            this.metroComboBoxEnzyme.ItemHeight = 23;
            this.metroComboBoxEnzyme.Location = new System.Drawing.Point(81, 80);
            this.metroComboBoxEnzyme.Name = "metroComboBoxEnzyme";
            this.metroComboBoxEnzyme.Size = new System.Drawing.Size(186, 29);
            this.metroComboBoxEnzyme.TabIndex = 6;
            this.metroComboBoxEnzyme.UseSelectable = true;
            this.metroComboBoxEnzyme.SelectedIndexChanged += new System.EventHandler(this.MetroComboBoxEnzyme_SelectedIndexChanged);
            // 
            // metroLabelEnzyme
            // 
            this.metroLabelEnzyme.AutoSize = true;
            this.metroLabelEnzyme.Location = new System.Drawing.Point(81, 58);
            this.metroLabelEnzyme.Name = "metroLabelEnzyme";
            this.metroLabelEnzyme.Size = new System.Drawing.Size(112, 19);
            this.metroLabelEnzyme.TabIndex = 7;
            this.metroLabelEnzyme.Text = "Digestion Enzyme";
            this.metroLabelEnzyme.UseCustomBackColor = true;
            // 
            // metroComboBoxThreads
            // 
            this.metroComboBoxThreads.FormattingEnabled = true;
            this.metroComboBoxThreads.ItemHeight = 23;
            this.metroComboBoxThreads.Location = new System.Drawing.Point(81, 257);
            this.metroComboBoxThreads.Name = "metroComboBoxThreads";
            this.metroComboBoxThreads.Size = new System.Drawing.Size(186, 29);
            this.metroComboBoxThreads.TabIndex = 8;
            this.metroComboBoxThreads.UseSelectable = true;
            this.metroComboBoxThreads.SelectedIndexChanged += new System.EventHandler(this.MetroComboBoxThreads_SelectedIndexChanged);
            // 
            // metroLabelThreads
            // 
            this.metroLabelThreads.AutoSize = true;
            this.metroLabelThreads.Location = new System.Drawing.Point(81, 235);
            this.metroLabelThreads.Name = "metroLabelThreads";
            this.metroLabelThreads.Size = new System.Drawing.Size(86, 19);
            this.metroLabelThreads.TabIndex = 9;
            this.metroLabelThreads.Text = "Threads used";
            this.metroLabelThreads.UseCustomBackColor = true;
            // 
            // metroLabelSequenceFile
            // 
            this.metroLabelSequenceFile.AutoSize = true;
            this.metroLabelSequenceFile.Location = new System.Drawing.Point(437, 58);
            this.metroLabelSequenceFile.Name = "metroLabelSequenceFile";
            this.metroLabelSequenceFile.Size = new System.Drawing.Size(89, 19);
            this.metroLabelSequenceFile.TabIndex = 10;
            this.metroLabelSequenceFile.Text = "Sequence File";
            this.metroLabelSequenceFile.UseCustomBackColor = true;
            // 
            // metroLabelSelectedFile
            // 
            this.metroLabelSelectedFile.AutoSize = true;
            this.metroLabelSelectedFile.Location = new System.Drawing.Point(518, 90);
            this.metroLabelSelectedFile.Name = "metroLabelSelectedFile";
            this.metroLabelSelectedFile.Size = new System.Drawing.Size(166, 19);
            this.metroLabelSelectedFile.TabIndex = 11;
            this.metroLabelSelectedFile.Text = "No sequence file selected...";
            this.metroLabelSelectedFile.UseCustomBackColor = true;
            // 
            // metroTextBoxFiles
            // 
            // 
            // 
            // 
            this.metroTextBoxFiles.CustomButton.Image = null;
            this.metroTextBoxFiles.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.metroTextBoxFiles.CustomButton.Name = "";
            this.metroTextBoxFiles.CustomButton.Size = new System.Drawing.Size(127, 127);
            this.metroTextBoxFiles.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxFiles.CustomButton.TabIndex = 1;
            this.metroTextBoxFiles.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxFiles.CustomButton.UseSelectable = true;
            this.metroTextBoxFiles.CustomButton.Visible = false;
            this.metroTextBoxFiles.Lines = new string[] {
        "Input files loaded for analysis..."};
            this.metroTextBoxFiles.Location = new System.Drawing.Point(437, 157);
            this.metroTextBoxFiles.MaxLength = 32767;
            this.metroTextBoxFiles.Multiline = true;
            this.metroTextBoxFiles.Name = "metroTextBoxFiles";
            this.metroTextBoxFiles.PasswordChar = '\0';
            this.metroTextBoxFiles.ReadOnly = true;
            this.metroTextBoxFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxFiles.SelectedText = "";
            this.metroTextBoxFiles.SelectionLength = 0;
            this.metroTextBoxFiles.SelectionStart = 0;
            this.metroTextBoxFiles.ShortcutsEnabled = true;
            this.metroTextBoxFiles.Size = new System.Drawing.Size(247, 129);
            this.metroTextBoxFiles.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTextBoxFiles.TabIndex = 12;
            this.metroTextBoxFiles.Text = "Input files loaded for analysis...";
            this.metroTextBoxFiles.UseSelectable = true;
            this.metroTextBoxFiles.UseStyleColors = true;
            this.metroTextBoxFiles.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxFiles.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabelInputFile
            // 
            this.metroLabelInputFile.AutoSize = true;
            this.metroLabelInputFile.Location = new System.Drawing.Point(437, 135);
            this.metroLabelInputFile.Name = "metroLabelInputFile";
            this.metroLabelInputFile.Size = new System.Drawing.Size(111, 19);
            this.metroLabelInputFile.TabIndex = 13;
            this.metroLabelInputFile.Text = "Input Files (.MGX)";
            this.metroLabelInputFile.UseCustomBackColor = true;
            // 
            // AnalGenUC
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.metroLabelInputFile);
            this.Controls.Add(this.metroTextBoxFiles);
            this.Controls.Add(this.metroLabelSelectedFile);
            this.Controls.Add(this.metroLabelSequenceFile);
            this.Controls.Add(this.metroLabelThreads);
            this.Controls.Add(this.metroComboBoxThreads);
            this.Controls.Add(this.metroLabelEnzyme);
            this.Controls.Add(this.metroComboBoxEnzyme);
            this.Controls.Add(this.metroLabelRefinement);
            this.Controls.Add(this.metroToggleRefine);
            this.Controls.Add(this.metroLabelCrapList);
            this.Controls.Add(this.metroToggleSearchCrapList);
            this.Controls.Add(this.metroBtnLoadSeqFile);
            this.Name = "AnalGenUC";
            this.Size = new System.Drawing.Size(815, 456);
            this.Load += new System.EventHandler(this.AnalGenUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroBtnLoadSeqFile;
        private MetroFramework.Controls.MetroToggle metroToggleSearchCrapList;
        private MetroFramework.Controls.MetroLabel metroLabelCrapList;
        private MetroFramework.Controls.MetroToggle metroToggleRefine;
        private MetroFramework.Controls.MetroLabel metroLabelRefinement;
        private MetroFramework.Controls.MetroComboBox metroComboBoxEnzyme;
        private MetroFramework.Controls.MetroLabel metroLabelEnzyme;
        private MetroFramework.Controls.MetroComboBox metroComboBoxThreads;
        private MetroFramework.Controls.MetroLabel metroLabelThreads;
        private MetroFramework.Controls.MetroLabel metroLabelSequenceFile;
        private MetroFramework.Controls.MetroLabel metroLabelSelectedFile;
        private MetroFramework.Controls.MetroTextBox metroTextBoxFiles;
        private MetroFramework.Controls.MetroLabel metroLabelInputFile;
    }
}
