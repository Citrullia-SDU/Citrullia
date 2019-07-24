namespace Citrullia
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.p1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitel = new System.Windows.Forms.Label();
            this.indicatorP = new System.Windows.Forms.Panel();
            this.ms1ValB = new System.Windows.Forms.Button();
            this.homeB = new System.Windows.Forms.Button();
            this.citValB = new System.Windows.Forms.Button();
            this.analysisB = new System.Windows.Forms.Button();
            this.exitL = new System.Windows.Forms.Label();
            this.labMini = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.pCenter = new System.Windows.Forms.Panel();
            this.analysisXUC1 = new Citrullia.UserControls.AnalysisXUC();
            this.mS1Val1 = new Citrullia.UserControls.MS1Val();
            this.startUC1 = new Citrullia.UserControls.StartUC();
            this.citValUC1 = new Citrullia.UserControls.CitValUC();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.p2.SuspendLayout();
            this.pCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.p1.Controls.Add(this.pictureBox1);
            this.p1.Controls.Add(this.labelTitel);
            this.p1.Controls.Add(this.indicatorP);
            this.p1.Controls.Add(this.ms1ValB);
            this.p1.Controls.Add(this.homeB);
            this.p1.Controls.Add(this.citValB);
            this.p1.Controls.Add(this.analysisB);
            this.p1.Dock = System.Windows.Forms.DockStyle.Left;
            this.p1.Location = new System.Drawing.Point(0, 0);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(192, 611);
            this.p1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitel
            // 
            this.labelTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labelTitel.Location = new System.Drawing.Point(0, 577);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(192, 25);
            this.labelTitel.TabIndex = 6;
            this.labelTitel.Text = "Home";
            this.labelTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // indicatorP
            // 
            this.indicatorP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.indicatorP.Location = new System.Drawing.Point(0, 140);
            this.indicatorP.Name = "indicatorP";
            this.indicatorP.Size = new System.Drawing.Size(10, 69);
            this.indicatorP.TabIndex = 2;
            // 
            // ms1ValB
            // 
            this.ms1ValB.FlatAppearance.BorderSize = 0;
            this.ms1ValB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ms1ValB.ForeColor = System.Drawing.Color.White;
            this.ms1ValB.Location = new System.Drawing.Point(0, 347);
            this.ms1ValB.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ms1ValB.Name = "ms1ValB";
            this.ms1ValB.Size = new System.Drawing.Size(192, 69);
            this.ms1ValB.TabIndex = 9;
            this.ms1ValB.Text = "Finishing";
            this.ms1ValB.UseVisualStyleBackColor = true;
            this.ms1ValB.Click += new System.EventHandler(this.Ms1ValB_Click);
            // 
            // homeB
            // 
            this.homeB.FlatAppearance.BorderSize = 0;
            this.homeB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeB.ForeColor = System.Drawing.Color.White;
            this.homeB.Location = new System.Drawing.Point(0, 140);
            this.homeB.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.homeB.Name = "homeB";
            this.homeB.Size = new System.Drawing.Size(192, 69);
            this.homeB.TabIndex = 6;
            this.homeB.Text = "Home";
            this.homeB.UseVisualStyleBackColor = true;
            this.homeB.Click += new System.EventHandler(this.HomeB_Click);
            // 
            // citValB
            // 
            this.citValB.FlatAppearance.BorderSize = 0;
            this.citValB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.citValB.ForeColor = System.Drawing.Color.White;
            this.citValB.Location = new System.Drawing.Point(0, 278);
            this.citValB.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.citValB.Name = "citValB";
            this.citValB.Size = new System.Drawing.Size(192, 69);
            this.citValB.TabIndex = 7;
            this.citValB.Text = "Validation";
            this.citValB.UseVisualStyleBackColor = true;
            this.citValB.Click += new System.EventHandler(this.CitValB_Click);
            // 
            // analysisB
            // 
            this.analysisB.FlatAppearance.BorderSize = 0;
            this.analysisB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analysisB.ForeColor = System.Drawing.Color.White;
            this.analysisB.Location = new System.Drawing.Point(0, 209);
            this.analysisB.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.analysisB.Name = "analysisB";
            this.analysisB.Size = new System.Drawing.Size(192, 69);
            this.analysisB.TabIndex = 8;
            this.analysisB.Text = "Analysis";
            this.analysisB.UseVisualStyleBackColor = true;
            this.analysisB.Click += new System.EventHandler(this.AnalysisB_Click);
            // 
            // exitL
            // 
            this.exitL.AutoSize = true;
            this.exitL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.exitL.Location = new System.Drawing.Point(848, 9);
            this.exitL.Name = "exitL";
            this.exitL.Size = new System.Drawing.Size(21, 20);
            this.exitL.TabIndex = 0;
            this.exitL.Text = "X";
            this.exitL.Click += new System.EventHandler(this.ExitL_Click);
            // 
            // labMini
            // 
            this.labMini.AutoSize = true;
            this.labMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.labMini.Location = new System.Drawing.Point(827, 9);
            this.labMini.Name = "labMini";
            this.labMini.Size = new System.Drawing.Size(15, 20);
            this.labMini.TabIndex = 3;
            this.labMini.Text = "-";
            this.labMini.Click += new System.EventHandler(this.LabMini_Click);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.p2.Controls.Add(this.labMini);
            this.p2.Controls.Add(this.exitL);
            this.p2.Dock = System.Windows.Forms.DockStyle.Top;
            this.p2.Location = new System.Drawing.Point(192, 0);
            this.p2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(881, 39);
            this.p2.TabIndex = 4;
            this.p2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.P2_MouseDown);
            // 
            // pCenter
            // 
            this.pCenter.BackColor = System.Drawing.Color.Silver;
            this.pCenter.Controls.Add(this.analysisXUC1);
            this.pCenter.Controls.Add(this.mS1Val1);
            this.pCenter.Controls.Add(this.startUC1);
            this.pCenter.Controls.Add(this.citValUC1);
            this.pCenter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pCenter.Location = new System.Drawing.Point(192, 39);
            this.pCenter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pCenter.Name = "pCenter";
            this.pCenter.Size = new System.Drawing.Size(881, 572);
            this.pCenter.TabIndex = 5;
            this.pCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCenter_MouseDown);
            // 
            // analysisXUC1
            // 
            this.analysisXUC1.BackColor = System.Drawing.Color.Silver;
            this.analysisXUC1.Location = new System.Drawing.Point(0, 0);
            this.analysisXUC1.Name = "analysisXUC1";
            this.analysisXUC1.Size = new System.Drawing.Size(881, 540);
            this.analysisXUC1.TabIndex = 10;
            // 
            // mS1Val1
            // 
            this.mS1Val1.BackColor = System.Drawing.Color.Silver;
            this.mS1Val1.Location = new System.Drawing.Point(0, 0);
            this.mS1Val1.Name = "mS1Val1";
            this.mS1Val1.Size = new System.Drawing.Size(881, 540);
            this.mS1Val1.TabIndex = 10;
            // 
            // startUC1
            // 
            this.startUC1.BackColor = System.Drawing.Color.Silver;
            this.startUC1.Location = new System.Drawing.Point(0, 0);
            this.startUC1.Name = "startUC1";
            this.startUC1.Size = new System.Drawing.Size(881, 537);
            this.startUC1.TabIndex = 1;
            // 
            // citValUC1
            // 
            this.citValUC1.BackColor = System.Drawing.Color.Silver;
            this.citValUC1.Location = new System.Drawing.Point(0, 0);
            this.citValUC1.Name = "citValUC1";
            this.citValUC1.Size = new System.Drawing.Size(881, 540);
            this.citValUC1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1073, 611);
            this.Controls.Add(this.pCenter);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.p1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.p2.ResumeLayout(false);
            this.p2.PerformLayout();
            this.pCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label exitL;
        private System.Windows.Forms.Label labMini;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.Panel pCenter;
        private System.Windows.Forms.Button ms1ValB;
        private System.Windows.Forms.Button analysisB;
        private System.Windows.Forms.Button citValB;
        private System.Windows.Forms.Button homeB;
        //private LiveCharts.WinForms.CartesianChart chart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControls.CitValUC citValUC1;
        private System.Windows.Forms.Label labelTitel;
        private UserControls.StartUC startUC1;
        private System.Windows.Forms.Panel indicatorP;
        private UserControls.MS1Val mS1Val1;
        private UserControls.AnalysisXUC analysisXUC1;
    }
}

