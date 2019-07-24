namespace Citrullia
{
    partial class SpectrumWriterUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectrumWriterUI));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitel = new System.Windows.Forms.Label();
            this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
            this.chartMS2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.labelTitel);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1089, 40);
            this.panelTop.TabIndex = 1;
            // 
            // labelTitel
            // 
            this.labelTitel.AutoSize = true;
            this.labelTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labelTitel.Location = new System.Drawing.Point(10, 10);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(149, 25);
            this.labelTitel.TabIndex = 7;
            this.labelTitel.Text = "Write images";
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
            this.chartMS2.Location = new System.Drawing.Point(15, 46);
            this.chartMS2.Name = "chartMS2";
            this.chartMS2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartMS2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray};
            this.chartMS2.Size = new System.Drawing.Size(970, 400);
            this.chartMS2.TabIndex = 80;
            this.chartMS2.Text = "chart1";
            // 
            // ChartWriterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1088, 484);
            this.Controls.Add(this.chartMS2);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartWriterUI";
            this.Text = "ValidationUI2";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMS2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMS2;
    }
}