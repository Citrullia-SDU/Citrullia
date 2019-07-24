namespace Citrullia.UserControls
{
    partial class ValFromLoneCit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelEnzyme = new MetroFramework.Controls.MetroLabel();
            this.metroButtonFindCitSpectra = new MetroFramework.Controls.MetroButton();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.metroSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabelProgress = new MetroFramework.Controls.MetroLabel();
            this.metroGridSelectedPeptides = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridSelectedPeptides)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel11.Location = new System.Drawing.Point(272, 21);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(102, 19);
            this.metroLabel11.TabIndex = 33;
            this.metroLabel11.Text = "Search Result:";
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel22.Location = new System.Drawing.Point(21, 137);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(199, 15);
            this.metroLabel22.TabIndex = 88;
            this.metroLabel22.Text = "(From an identical unmodified peptide)";
            this.metroLabel22.UseCustomBackColor = true;
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel20.Location = new System.Drawing.Point(21, 80);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(48, 19);
            this.metroLabel20.TabIndex = 87;
            this.metroLabel20.Text = "Name:";
            this.metroLabel20.UseCustomBackColor = true;
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(125, 80);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(82, 19);
            this.metroLabel21.TabIndex = 86;
            this.metroLabel21.Text = "Citrullination";
            this.metroLabel21.UseCustomBackColor = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Location = new System.Drawing.Point(21, 42);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(102, 19);
            this.metroLabel16.TabIndex = 82;
            this.metroLabel16.Text = "Subject Spectra";
            this.metroLabel16.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(125, 61);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(62, 19);
            this.metroLabel8.TabIndex = 74;
            this.metroLabel8.Text = "Modified";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(21, 61);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(40, 19);
            this.metroLabel7.TabIndex = 73;
            this.metroLabel7.Text = "Type:";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(125, 118);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(64, 19);
            this.metroLabel6.TabIndex = 72;
            this.metroLabel6.Text = "+ 0.9845 ";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(125, 99);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(25, 19);
            this.metroLabel5.TabIndex = 71;
            this.metroLabel5.Text = "[R]";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(21, 118);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(95, 19);
            this.metroLabel4.TabIndex = 70;
            this.metroLabel4.Text = "Mass Change:";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(21, 99);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(59, 19);
            this.metroLabel3.TabIndex = 69;
            this.metroLabel3.Text = "Residue:";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabelEnzyme
            // 
            this.metroLabelEnzyme.AutoSize = true;
            this.metroLabelEnzyme.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelEnzyme.Location = new System.Drawing.Point(21, 21);
            this.metroLabelEnzyme.Name = "metroLabelEnzyme";
            this.metroLabelEnzyme.Size = new System.Drawing.Size(104, 19);
            this.metroLabelEnzyme.TabIndex = 66;
            this.metroLabelEnzyme.Text = "Search Query:";
            this.metroLabelEnzyme.UseCustomBackColor = true;
            // 
            // metroButtonFindCitSpectra
            // 
            this.metroButtonFindCitSpectra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonFindCitSpectra.ForeColor = System.Drawing.Color.White;
            this.metroButtonFindCitSpectra.Highlight = true;
            this.metroButtonFindCitSpectra.Location = new System.Drawing.Point(21, 168);
            this.metroButtonFindCitSpectra.Name = "metroButtonFindCitSpectra";
            this.metroButtonFindCitSpectra.Size = new System.Drawing.Size(75, 38);
            this.metroButtonFindCitSpectra.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonFindCitSpectra.TabIndex = 65;
            this.metroButtonFindCitSpectra.Text = "Find Spectra";
            this.metroButtonFindCitSpectra.UseCustomBackColor = true;
            this.metroButtonFindCitSpectra.UseCustomForeColor = true;
            this.metroButtonFindCitSpectra.UseSelectable = true;
            this.metroButtonFindCitSpectra.Click += new System.EventHandler(this.MetroButtonFindCitSpectra_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // metroSpinner
            // 
            this.metroSpinner.Location = new System.Drawing.Point(782, 3);
            this.metroSpinner.Maximum = 100;
            this.metroSpinner.Name = "metroSpinner";
            this.metroSpinner.Size = new System.Drawing.Size(30, 30);
            this.metroSpinner.Spinning = false;
            this.metroSpinner.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroSpinner.TabIndex = 89;
            this.metroSpinner.UseCustomBackColor = true;
            this.metroSpinner.UseSelectable = true;
            this.metroSpinner.Value = 33;
            this.metroSpinner.Visible = false;
            // 
            // metroLabelProgress
            // 
            this.metroLabelProgress.AutoSize = true;
            this.metroLabelProgress.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabelProgress.Location = new System.Drawing.Point(21, 209);
            this.metroLabelProgress.Name = "metroLabelProgress";
            this.metroLabelProgress.Size = new System.Drawing.Size(10, 15);
            this.metroLabelProgress.TabIndex = 90;
            this.metroLabelProgress.Text = " ";
            this.metroLabelProgress.UseCustomBackColor = true;
            // 
            // metroGridSelectedPeptides
            // 
            this.metroGridSelectedPeptides.AllowUserToAddRows = false;
            this.metroGridSelectedPeptides.AllowUserToDeleteRows = false;
            this.metroGridSelectedPeptides.AllowUserToResizeRows = false;
            this.metroGridSelectedPeptides.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridSelectedPeptides.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridSelectedPeptides.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridSelectedPeptides.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridSelectedPeptides.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridSelectedPeptides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGridSelectedPeptides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column3,
            this.Column2,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridSelectedPeptides.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridSelectedPeptides.EnableHeadersVisualStyles = false;
            this.metroGridSelectedPeptides.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridSelectedPeptides.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridSelectedPeptides.Location = new System.Drawing.Point(272, 43);
            this.metroGridSelectedPeptides.MultiSelect = false;
            this.metroGridSelectedPeptides.Name = "metroGridSelectedPeptides";
            this.metroGridSelectedPeptides.ReadOnly = true;
            this.metroGridSelectedPeptides.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridSelectedPeptides.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridSelectedPeptides.RowHeadersVisible = false;
            this.metroGridSelectedPeptides.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.metroGridSelectedPeptides.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGridSelectedPeptides.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridSelectedPeptides.Size = new System.Drawing.Size(527, 389);
            this.metroGridSelectedPeptides.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroGridSelectedPeptides.TabIndex = 91;
            this.metroGridSelectedPeptides.SelectionChanged += new System.EventHandler(this.MetroGridSelectedPeptides_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Protein:";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 260;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Sequence:";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Score:";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "E-value:";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ScanID:";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Scans:";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 50;
            // 
            // ValFromLoneCit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.metroGridSelectedPeptides);
            this.Controls.Add(this.metroLabelProgress);
            this.Controls.Add(this.metroSpinner);
            this.Controls.Add(this.metroLabel22);
            this.Controls.Add(this.metroLabel20);
            this.Controls.Add(this.metroLabel21);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabelEnzyme);
            this.Controls.Add(this.metroButtonFindCitSpectra);
            this.Controls.Add(this.metroLabel11);
            this.Name = "ValFromLoneCit";
            this.Size = new System.Drawing.Size(815, 456);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridSelectedPeptides)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabelEnzyme;
        private MetroFramework.Controls.MetroButton metroButtonFindCitSpectra;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private MetroFramework.Controls.MetroProgressSpinner metroSpinner;
        private MetroFramework.Controls.MetroLabel metroLabelProgress;
        private MetroFramework.Controls.MetroGrid metroGridSelectedPeptides;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
