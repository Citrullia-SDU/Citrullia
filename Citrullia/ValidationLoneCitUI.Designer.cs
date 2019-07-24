namespace Citrullia
{
    partial class ValidationLoneCitUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationLoneCitUI));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitel = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.metroLabelCitFileName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel27 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelCitRTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelCitEval = new MetroFramework.Controls.MetroLabel();
            this.metroLabelCitSeq = new MetroFramework.Controls.MetroLabel();
            this.metroLabelCitPMass = new MetroFramework.Controls.MetroLabel();
            this.metroLabelCitCharge = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelID = new MetroFramework.Controls.MetroLabel();
            this.metroLabelSpectrumID = new MetroFramework.Controls.MetroLabel();
            this.chartMS2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroButtonZoomResetMS2 = new MetroFramework.Controls.MetroButton();
            this.metroGridCitIons = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroButtonResetZoomMS1 = new MetroFramework.Controls.MetroButton();
            this.chartMS1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroLabelCitMS1RTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonRemoveQuant = new MetroFramework.Controls.MetroButton();
            this.metroButtonAddQuant = new MetroFramework.Controls.MetroButton();
            this.metroButtonSaveMS1Cit = new MetroFramework.Controls.MetroButton();
            this.metroButtonExportDataGrid = new MetroFramework.Controls.MetroButton();
            this.metroButtonSaveMS2 = new MetroFramework.Controls.MetroButton();
            this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
            this.metroLabelCitScore = new MetroFramework.Controls.MetroLabel();
            this.metroLabel30 = new MetroFramework.Controls.MetroLabel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridCitIons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.labelTitel);
            this.panelTop.Controls.Add(this.labelMinimize);
            this.panelTop.Controls.Add(this.labelExit);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1483, 40);
            this.panelTop.TabIndex = 2;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            // 
            // labelTitel
            // 
            this.labelTitel.AutoSize = true;
            this.labelTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labelTitel.Location = new System.Drawing.Point(10, 10);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(449, 25);
            this.labelTitel.TabIndex = 7;
            this.labelTitel.Text = "Spectra Validation - Lonely Citrullinations";
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labelMinimize.Location = new System.Drawing.Point(1429, 10);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(15, 20);
            this.labelMinimize.TabIndex = 4;
            this.labelMinimize.Text = "-";
            this.labelMinimize.Click += new System.EventHandler(this.LabelMinimize_Click);
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labelExit.Location = new System.Drawing.Point(1450, 10);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(21, 20);
            this.labelExit.TabIndex = 1;
            this.labelExit.Text = "X";
            this.labelExit.Click += new System.EventHandler(this.LabelExit_Click);
            // 
            // metroLabelCitFileName
            // 
            this.metroLabelCitFileName.AutoSize = true;
            this.metroLabelCitFileName.Location = new System.Drawing.Point(115, 197);
            this.metroLabelCitFileName.Name = "metroLabelCitFileName";
            this.metroLabelCitFileName.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitFileName.TabIndex = 92;
            this.metroLabelCitFileName.Text = "NaN";
            this.metroLabelCitFileName.UseCustomBackColor = true;
            // 
            // metroLabel27
            // 
            this.metroLabel27.AutoSize = true;
            this.metroLabel27.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel27.Location = new System.Drawing.Point(17, 197);
            this.metroLabel27.Name = "metroLabel27";
            this.metroLabel27.Size = new System.Drawing.Size(72, 19);
            this.metroLabel27.TabIndex = 91;
            this.metroLabel27.Text = "File Name:";
            this.metroLabel27.UseCustomBackColor = true;
            // 
            // metroLabelCitRTime
            // 
            this.metroLabelCitRTime.AutoSize = true;
            this.metroLabelCitRTime.Location = new System.Drawing.Point(115, 178);
            this.metroLabelCitRTime.Name = "metroLabelCitRTime";
            this.metroLabelCitRTime.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitRTime.TabIndex = 90;
            this.metroLabelCitRTime.Text = "NaN";
            this.metroLabelCitRTime.UseCustomBackColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(17, 178);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(104, 19);
            this.metroLabel7.TabIndex = 89;
            this.metroLabel7.Text = "Retention Time:";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // metroLabelCitEval
            // 
            this.metroLabelCitEval.AutoSize = true;
            this.metroLabelCitEval.Location = new System.Drawing.Point(115, 159);
            this.metroLabelCitEval.Name = "metroLabelCitEval";
            this.metroLabelCitEval.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitEval.TabIndex = 88;
            this.metroLabelCitEval.Text = "NaN";
            this.metroLabelCitEval.UseCustomBackColor = true;
            // 
            // metroLabelCitSeq
            // 
            this.metroLabelCitSeq.Location = new System.Drawing.Point(115, 140);
            this.metroLabelCitSeq.Name = "metroLabelCitSeq";
            this.metroLabelCitSeq.Size = new System.Drawing.Size(300, 19);
            this.metroLabelCitSeq.TabIndex = 87;
            this.metroLabelCitSeq.Text = "NaN";
            this.metroLabelCitSeq.UseCustomBackColor = true;
            // 
            // metroLabelCitPMass
            // 
            this.metroLabelCitPMass.AutoSize = true;
            this.metroLabelCitPMass.Location = new System.Drawing.Point(115, 102);
            this.metroLabelCitPMass.Name = "metroLabelCitPMass";
            this.metroLabelCitPMass.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitPMass.TabIndex = 85;
            this.metroLabelCitPMass.Text = "NaN";
            this.metroLabelCitPMass.UseCustomBackColor = true;
            // 
            // metroLabelCitCharge
            // 
            this.metroLabelCitCharge.AutoSize = true;
            this.metroLabelCitCharge.Location = new System.Drawing.Point(115, 121);
            this.metroLabelCitCharge.Name = "metroLabelCitCharge";
            this.metroLabelCitCharge.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitCharge.TabIndex = 84;
            this.metroLabelCitCharge.Text = "NaN";
            this.metroLabelCitCharge.UseCustomBackColor = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(17, 159);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(57, 19);
            this.metroLabel11.TabIndex = 83;
            this.metroLabel11.Text = "E-value:";
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(17, 140);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 19);
            this.metroLabel3.TabIndex = 82;
            this.metroLabel3.Text = "Sequence:";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(17, 121);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(92, 19);
            this.metroLabel5.TabIndex = 80;
            this.metroLabel5.Text = "Charge-state:";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(17, 102);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(88, 19);
            this.metroLabel4.TabIndex = 79;
            this.metroLabel4.Text = "Parent Mass:";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(12, 77);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(191, 25);
            this.metroLabel1.TabIndex = 78;
            this.metroLabel1.Text = "Citrullinated Peptide:";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabelID
            // 
            this.metroLabelID.AutoSize = true;
            this.metroLabelID.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabelID.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabelID.Location = new System.Drawing.Point(131, 43);
            this.metroLabelID.Name = "metroLabelID";
            this.metroLabelID.Size = new System.Drawing.Size(127, 25);
            this.metroLabelID.TabIndex = 77;
            this.metroLabelID.Text = "Spectrum ID....";
            this.metroLabelID.UseCustomBackColor = true;
            // 
            // metroLabelSpectrumID
            // 
            this.metroLabelSpectrumID.AutoSize = true;
            this.metroLabelSpectrumID.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabelSpectrumID.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelSpectrumID.Location = new System.Drawing.Point(12, 43);
            this.metroLabelSpectrumID.Name = "metroLabelSpectrumID";
            this.metroLabelSpectrumID.Size = new System.Drawing.Size(122, 25);
            this.metroLabelSpectrumID.TabIndex = 76;
            this.metroLabelSpectrumID.Text = "Spectrum ID:";
            this.metroLabelSpectrumID.UseCustomBackColor = true;
            // 
            // chartMS2
            // 
            this.chartMS2.BackColor = System.Drawing.Color.Silver;
            this.chartMS2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chartMS2.BackSecondaryColor = System.Drawing.Color.White;
            this.chartMS2.BorderlineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea";
            this.chartMS2.ChartAreas.Add(chartArea1);
            this.chartMS2.Location = new System.Drawing.Point(537, 46);
            this.chartMS2.Name = "chartMS2";
            this.chartMS2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartMS2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray};
            this.chartMS2.Size = new System.Drawing.Size(934, 292);
            this.chartMS2.TabIndex = 93;
            this.chartMS2.Text = "chart1";
            this.chartMS2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartMS2_MouseMove);
            // 
            // metroButtonZoomResetMS2
            // 
            this.metroButtonZoomResetMS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonZoomResetMS2.ForeColor = System.Drawing.Color.White;
            this.metroButtonZoomResetMS2.Highlight = true;
            this.metroButtonZoomResetMS2.Location = new System.Drawing.Point(470, 81);
            this.metroButtonZoomResetMS2.Name = "metroButtonZoomResetMS2";
            this.metroButtonZoomResetMS2.Size = new System.Drawing.Size(75, 21);
            this.metroButtonZoomResetMS2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonZoomResetMS2.TabIndex = 94;
            this.metroButtonZoomResetMS2.Text = "Reset Zoom";
            this.metroButtonZoomResetMS2.UseCustomBackColor = true;
            this.metroButtonZoomResetMS2.UseCustomForeColor = true;
            this.metroButtonZoomResetMS2.UseSelectable = true;
            this.metroButtonZoomResetMS2.Click += new System.EventHandler(this.MetroButtonZoomResetMS2_Click);
            // 
            // metroGridCitIons
            // 
            this.metroGridCitIons.AllowUserToAddRows = false;
            this.metroGridCitIons.AllowUserToDeleteRows = false;
            this.metroGridCitIons.AllowUserToResizeRows = false;
            this.metroGridCitIons.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridCitIons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridCitIons.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridCitIons.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridCitIons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridCitIons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGridCitIons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridCitIons.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridCitIons.EnableHeadersVisualStyles = false;
            this.metroGridCitIons.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridCitIons.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridCitIons.Location = new System.Drawing.Point(17, 260);
            this.metroGridCitIons.Name = "metroGridCitIons";
            this.metroGridCitIons.ReadOnly = true;
            this.metroGridCitIons.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridCitIons.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridCitIons.RowHeadersVisible = false;
            this.metroGridCitIons.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridCitIons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridCitIons.Size = new System.Drawing.Size(498, 345);
            this.metroGridCitIons.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroGridCitIons.TabIndex = 107;
            this.metroGridCitIons.UseStyleColors = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "a";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "b-18";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "b-17";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "b";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Seq.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "y";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "y-17";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 60;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "y-18";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 60;
            // 
            // metroButtonResetZoomMS1
            // 
            this.metroButtonResetZoomMS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonResetZoomMS1.ForeColor = System.Drawing.Color.White;
            this.metroButtonResetZoomMS1.Highlight = true;
            this.metroButtonResetZoomMS1.Location = new System.Drawing.Point(1136, 350);
            this.metroButtonResetZoomMS1.Name = "metroButtonResetZoomMS1";
            this.metroButtonResetZoomMS1.Size = new System.Drawing.Size(75, 21);
            this.metroButtonResetZoomMS1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonResetZoomMS1.TabIndex = 112;
            this.metroButtonResetZoomMS1.Text = "Reset Zoom";
            this.metroButtonResetZoomMS1.UseCustomBackColor = true;
            this.metroButtonResetZoomMS1.UseCustomForeColor = true;
            this.metroButtonResetZoomMS1.UseSelectable = true;
            this.metroButtonResetZoomMS1.Click += new System.EventHandler(this.MetroButtonResetZoomMS1_Click);
            // 
            // chartMS1
            // 
            this.chartMS1.BackColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea";
            this.chartMS1.ChartAreas.Add(chartArea2);
            this.chartMS1.Location = new System.Drawing.Point(537, 385);
            this.chartMS1.Name = "chartMS1";
            this.chartMS1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.chartMS1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Blue};
            this.chartMS1.Size = new System.Drawing.Size(934, 220);
            this.chartMS1.TabIndex = 111;
            this.chartMS1.Text = "chartMS1";
            this.chartMS1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartMS1_MouseMove);
            // 
            // metroLabelCitMS1RTime
            // 
            this.metroLabelCitMS1RTime.AutoSize = true;
            this.metroLabelCitMS1RTime.Location = new System.Drawing.Point(686, 360);
            this.metroLabelCitMS1RTime.Name = "metroLabelCitMS1RTime";
            this.metroLabelCitMS1RTime.Size = new System.Drawing.Size(36, 19);
            this.metroLabelCitMS1RTime.TabIndex = 110;
            this.metroLabelCitMS1RTime.Text = "NaN";
            this.metroLabelCitMS1RTime.UseCustomBackColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(576, 360);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(104, 19);
            this.metroLabel13.TabIndex = 109;
            this.metroLabel13.Text = "Retention Time:";
            this.metroLabel13.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(576, 341);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(192, 19);
            this.metroLabel8.TabIndex = 108;
            this.metroLabel8.Text = "MS1 Scan of Modified Peptide";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroButtonRemoveQuant
            // 
            this.metroButtonRemoveQuant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonRemoveQuant.ForeColor = System.Drawing.Color.White;
            this.metroButtonRemoveQuant.Highlight = true;
            this.metroButtonRemoveQuant.Location = new System.Drawing.Point(470, 152);
            this.metroButtonRemoveQuant.Name = "metroButtonRemoveQuant";
            this.metroButtonRemoveQuant.Size = new System.Drawing.Size(75, 38);
            this.metroButtonRemoveQuant.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonRemoveQuant.TabIndex = 114;
            this.metroButtonRemoveQuant.Text = "Remove";
            this.metroButtonRemoveQuant.UseCustomBackColor = true;
            this.metroButtonRemoveQuant.UseCustomForeColor = true;
            this.metroButtonRemoveQuant.UseSelectable = true;
            this.metroButtonRemoveQuant.Click += new System.EventHandler(this.MetroButtonRemoveQuant_Click);
            // 
            // metroButtonAddQuant
            // 
            this.metroButtonAddQuant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonAddQuant.ForeColor = System.Drawing.Color.White;
            this.metroButtonAddQuant.Highlight = true;
            this.metroButtonAddQuant.Location = new System.Drawing.Point(470, 108);
            this.metroButtonAddQuant.Name = "metroButtonAddQuant";
            this.metroButtonAddQuant.Size = new System.Drawing.Size(75, 38);
            this.metroButtonAddQuant.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonAddQuant.TabIndex = 113;
            this.metroButtonAddQuant.Text = "Add";
            this.metroButtonAddQuant.UseCustomBackColor = true;
            this.metroButtonAddQuant.UseCustomForeColor = true;
            this.metroButtonAddQuant.UseSelectable = true;
            this.metroButtonAddQuant.Click += new System.EventHandler(this.MetroButtonAddQuant_Click);
            // 
            // metroButtonSaveMS1Cit
            // 
            this.metroButtonSaveMS1Cit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonSaveMS1Cit.ForeColor = System.Drawing.Color.White;
            this.metroButtonSaveMS1Cit.Highlight = true;
            this.metroButtonSaveMS1Cit.Location = new System.Drawing.Point(1083, 350);
            this.metroButtonSaveMS1Cit.Name = "metroButtonSaveMS1Cit";
            this.metroButtonSaveMS1Cit.Size = new System.Drawing.Size(47, 21);
            this.metroButtonSaveMS1Cit.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonSaveMS1Cit.TabIndex = 115;
            this.metroButtonSaveMS1Cit.Text = "Save";
            this.metroButtonSaveMS1Cit.UseCustomBackColor = true;
            this.metroButtonSaveMS1Cit.UseCustomForeColor = true;
            this.metroButtonSaveMS1Cit.UseSelectable = true;
            this.metroButtonSaveMS1Cit.Click += new System.EventHandler(this.MetroButtonSaveMS1Cit_Click);
            // 
            // metroButtonExportDataGrid
            // 
            this.metroButtonExportDataGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonExportDataGrid.ForeColor = System.Drawing.Color.White;
            this.metroButtonExportDataGrid.Highlight = true;
            this.metroButtonExportDataGrid.Location = new System.Drawing.Point(468, 233);
            this.metroButtonExportDataGrid.Name = "metroButtonExportDataGrid";
            this.metroButtonExportDataGrid.Size = new System.Drawing.Size(47, 21);
            this.metroButtonExportDataGrid.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonExportDataGrid.TabIndex = 116;
            this.metroButtonExportDataGrid.Text = "Export";
            this.metroButtonExportDataGrid.UseCustomBackColor = true;
            this.metroButtonExportDataGrid.UseCustomForeColor = true;
            this.metroButtonExportDataGrid.UseSelectable = true;
            this.metroButtonExportDataGrid.Click += new System.EventHandler(this.MetroButtonExportDataGrid_Click);
            // 
            // metroButtonSaveMS2
            // 
            this.metroButtonSaveMS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonSaveMS2.ForeColor = System.Drawing.Color.White;
            this.metroButtonSaveMS2.Highlight = true;
            this.metroButtonSaveMS2.Location = new System.Drawing.Point(484, 54);
            this.metroButtonSaveMS2.Name = "metroButtonSaveMS2";
            this.metroButtonSaveMS2.Size = new System.Drawing.Size(47, 21);
            this.metroButtonSaveMS2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonSaveMS2.TabIndex = 117;
            this.metroButtonSaveMS2.Text = "Save";
            this.metroButtonSaveMS2.UseCustomBackColor = true;
            this.metroButtonSaveMS2.UseCustomForeColor = true;
            this.metroButtonSaveMS2.UseSelectable = true;
            this.metroButtonSaveMS2.Click += new System.EventHandler(this.MetroButtonSaveMS2_Click);
            // 
            // backgroundWorkerExport
            // 
            this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerExport_DoWork);
            // 
            // metroLabelCitScore
            // 
            this.metroLabelCitScore.AutoSize = true;
            this.metroLabelCitScore.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelCitScore.Location = new System.Drawing.Point(115, 216);
            this.metroLabelCitScore.Name = "metroLabelCitScore";
            this.metroLabelCitScore.Size = new System.Drawing.Size(39, 19);
            this.metroLabelCitScore.TabIndex = 123;
            this.metroLabelCitScore.Text = "NaN";
            this.metroLabelCitScore.UseCustomBackColor = true;
            // 
            // metroLabel30
            // 
            this.metroLabel30.AutoSize = true;
            this.metroLabel30.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel30.Location = new System.Drawing.Point(20, 216);
            this.metroLabel30.Name = "metroLabel30";
            this.metroLabel30.Size = new System.Drawing.Size(69, 19);
            this.metroLabel30.TabIndex = 122;
            this.metroLabel30.Text = "CitScore:";
            this.metroLabel30.UseCustomBackColor = true;
            // 
            // ValidationLoneCitUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1483, 617);
            this.Controls.Add(this.metroLabelCitScore);
            this.Controls.Add(this.metroLabel30);
            this.Controls.Add(this.metroButtonSaveMS2);
            this.Controls.Add(this.metroButtonExportDataGrid);
            this.Controls.Add(this.metroButtonSaveMS1Cit);
            this.Controls.Add(this.metroButtonRemoveQuant);
            this.Controls.Add(this.metroButtonAddQuant);
            this.Controls.Add(this.metroButtonResetZoomMS1);
            this.Controls.Add(this.chartMS1);
            this.Controls.Add(this.metroLabelCitMS1RTime);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroGridCitIons);
            this.Controls.Add(this.metroButtonZoomResetMS2);
            this.Controls.Add(this.chartMS2);
            this.Controls.Add(this.metroLabelCitFileName);
            this.Controls.Add(this.metroLabel27);
            this.Controls.Add(this.metroLabelCitRTime);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabelCitEval);
            this.Controls.Add(this.metroLabelCitSeq);
            this.Controls.Add(this.metroLabelCitPMass);
            this.Controls.Add(this.metroLabelCitCharge);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelID);
            this.Controls.Add(this.metroLabelSpectrumID);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidationLoneCitUI";
            this.Text = "ValidationUI3";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridCitIons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitel;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.Label labelExit;
        private MetroFramework.Controls.MetroLabel metroLabelCitFileName;
        private MetroFramework.Controls.MetroLabel metroLabel27;
        private MetroFramework.Controls.MetroLabel metroLabelCitRTime;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabelCitEval;
        private MetroFramework.Controls.MetroLabel metroLabelCitSeq;
        private MetroFramework.Controls.MetroLabel metroLabelCitPMass;
        private MetroFramework.Controls.MetroLabel metroLabelCitCharge;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabelID;
        private MetroFramework.Controls.MetroLabel metroLabelSpectrumID;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMS2;
        private MetroFramework.Controls.MetroButton metroButtonZoomResetMS2;
        private MetroFramework.Controls.MetroGrid metroGridCitIons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private MetroFramework.Controls.MetroButton metroButtonResetZoomMS1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMS1;
        private MetroFramework.Controls.MetroLabel metroLabelCitMS1RTime;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroButton metroButtonRemoveQuant;
        private MetroFramework.Controls.MetroButton metroButtonAddQuant;
        private MetroFramework.Controls.MetroButton metroButtonSaveMS1Cit;
        private MetroFramework.Controls.MetroButton metroButtonExportDataGrid;
        private MetroFramework.Controls.MetroButton metroButtonSaveMS2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private MetroFramework.Controls.MetroLabel metroLabelCitScore;
        private MetroFramework.Controls.MetroLabel metroLabel30;
    }
}