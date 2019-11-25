namespace Citrullia.UserControls
{
    partial class StartUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUC));
            this.metroButtonLoadMGX = new MetroFramework.Controls.MetroButton();
            this.metroLabelSequenceFile = new MetroFramework.Controls.MetroLabel();
            this.metroLabelLoadedMGXFiles = new MetroFramework.Controls.MetroLabel();
            this.labelTitel = new System.Windows.Forms.Label();
            this.metroLoadingSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.backgroundWorkerMGX = new System.ComponentModel.BackgroundWorker();
            this.textBoxIntro = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroLabelLoadedResultFiles = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonLoadResult = new MetroFramework.Controls.MetroButton();
            this.backgroundWorkerResult = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButtonLoadMGX
            // 
            this.metroButtonLoadMGX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonLoadMGX.ForeColor = System.Drawing.Color.White;
            this.metroButtonLoadMGX.Highlight = true;
            this.metroButtonLoadMGX.Location = new System.Drawing.Point(481, 102);
            this.metroButtonLoadMGX.Name = "metroButtonLoadMGX";
            this.metroButtonLoadMGX.Size = new System.Drawing.Size(75, 38);
            this.metroButtonLoadMGX.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonLoadMGX.TabIndex = 2;
            this.metroButtonLoadMGX.Text = "Load";
            this.metroButtonLoadMGX.UseCustomBackColor = true;
            this.metroButtonLoadMGX.UseCustomForeColor = true;
            this.metroButtonLoadMGX.UseSelectable = true;
            this.metroButtonLoadMGX.Click += new System.EventHandler(this.MetroButtonLoad_Click);
            // 
            // metroLabelSequenceFile
            // 
            this.metroLabelSequenceFile.AutoSize = true;
            this.metroLabelSequenceFile.Location = new System.Drawing.Point(562, 111);
            this.metroLabelSequenceFile.Name = "metroLabelSequenceFile";
            this.metroLabelSequenceFile.Size = new System.Drawing.Size(115, 19);
            this.metroLabelSequenceFile.TabIndex = 11;
            this.metroLabelSequenceFile.Text = "Input Files (.MGX) ";
            this.metroLabelSequenceFile.UseCustomBackColor = true;
            // 
            // metroLabelLoadedMGXFiles
            // 
            this.metroLabelLoadedMGXFiles.AutoSize = true;
            this.metroLabelLoadedMGXFiles.Location = new System.Drawing.Point(481, 143);
            this.metroLabelLoadedMGXFiles.Name = "metroLabelLoadedMGXFiles";
            this.metroLabelLoadedMGXFiles.Size = new System.Drawing.Size(163, 19);
            this.metroLabelLoadedMGXFiles.TabIndex = 12;
            this.metroLabelLoadedMGXFiles.Text = "No files has been loaded...";
            this.metroLabelLoadedMGXFiles.UseCustomBackColor = true;
            // 
            // labelTitel
            // 
            this.labelTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitel.ForeColor = System.Drawing.Color.Black;
            this.labelTitel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitel.Location = new System.Drawing.Point(285, 28);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(296, 25);
            this.labelTitel.TabIndex = 15;
            this.labelTitel.Text = "Welcome to Citrullia";
            this.labelTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLoadingSpinner
            // 
            this.metroLoadingSpinner.Location = new System.Drawing.Point(828, 3);
            this.metroLoadingSpinner.Maximum = 100;
            this.metroLoadingSpinner.Name = "metroLoadingSpinner";
            this.metroLoadingSpinner.Size = new System.Drawing.Size(50, 50);
            this.metroLoadingSpinner.Spinning = false;
            this.metroLoadingSpinner.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLoadingSpinner.TabIndex = 16;
            this.metroLoadingSpinner.UseCustomBackColor = true;
            this.metroLoadingSpinner.UseSelectable = true;
            this.metroLoadingSpinner.Value = 33;
            this.metroLoadingSpinner.Visible = false;
            // 
            // backgroundWorkerMGX
            // 
            this.backgroundWorkerMGX.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerMGX_DoWork);
            this.backgroundWorkerMGX.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerMGX_RunWorkerCompleted);
            // 
            // textBoxIntro
            // 
            this.textBoxIntro.BackColor = System.Drawing.Color.Silver;
            this.textBoxIntro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIntro.Font = new System.Drawing.Font("Segoe UI Light", 10.5F);
            this.textBoxIntro.Location = new System.Drawing.Point(63, 74);
            this.textBoxIntro.Multiline = true;
            this.textBoxIntro.Name = "textBoxIntro";
            this.textBoxIntro.ReadOnly = true;
            this.textBoxIntro.Size = new System.Drawing.Size(362, 402);
            this.textBoxIntro.TabIndex = 18;
            this.textBoxIntro.Text = resources.GetString("textBoxIntro.Text");
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Silver;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Light", 10.5F);
            this.textBox1.Location = new System.Drawing.Point(481, 74);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 22);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "New experiments:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(696, 403);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Silver;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Light", 10.5F);
            this.textBox2.Location = new System.Drawing.Point(481, 194);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "Open results:";
            // 
            // metroLabelLoadedResultFiles
            // 
            this.metroLabelLoadedResultFiles.AutoSize = true;
            this.metroLabelLoadedResultFiles.Location = new System.Drawing.Point(481, 263);
            this.metroLabelLoadedResultFiles.Name = "metroLabelLoadedResultFiles";
            this.metroLabelLoadedResultFiles.Size = new System.Drawing.Size(163, 19);
            this.metroLabelLoadedResultFiles.TabIndex = 23;
            this.metroLabelLoadedResultFiles.Text = "No files has been loaded...";
            this.metroLabelLoadedResultFiles.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(562, 231);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(116, 19);
            this.metroLabel2.TabIndex = 22;
            this.metroLabel2.Text = "Result Files (.CRX) ";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroButtonLoadResult
            // 
            this.metroButtonLoadResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.metroButtonLoadResult.ForeColor = System.Drawing.Color.White;
            this.metroButtonLoadResult.Highlight = true;
            this.metroButtonLoadResult.Location = new System.Drawing.Point(481, 222);
            this.metroButtonLoadResult.Name = "metroButtonLoadResult";
            this.metroButtonLoadResult.Size = new System.Drawing.Size(75, 38);
            this.metroButtonLoadResult.Style = MetroFramework.MetroColorStyle.White;
            this.metroButtonLoadResult.TabIndex = 21;
            this.metroButtonLoadResult.Text = "Load";
            this.metroButtonLoadResult.UseCustomBackColor = true;
            this.metroButtonLoadResult.UseCustomForeColor = true;
            this.metroButtonLoadResult.UseSelectable = true;
            this.metroButtonLoadResult.Click += new System.EventHandler(this.MetroButtonLoadResult_Click);
            // 
            // backgroundWorkerResult
            // 
            this.backgroundWorkerResult.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerResult_DoWork);
            this.backgroundWorkerResult.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerResult_RunWorkerCompleted);
            // 
            // StartUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.metroLabelLoadedResultFiles);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButtonLoadResult);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxIntro);
            this.Controls.Add(this.metroLoadingSpinner);
            this.Controls.Add(this.labelTitel);
            this.Controls.Add(this.metroLabelLoadedMGXFiles);
            this.Controls.Add(this.metroLabelSequenceFile);
            this.Controls.Add(this.metroButtonLoadMGX);
            this.Name = "StartUC";
            this.Size = new System.Drawing.Size(881, 540);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButtonLoadMGX;
        private MetroFramework.Controls.MetroLabel metroLabelSequenceFile;
        private MetroFramework.Controls.MetroLabel metroLabelLoadedMGXFiles;
        private System.Windows.Forms.Label labelTitel;
        private MetroFramework.Controls.MetroProgressSpinner metroLoadingSpinner;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMGX;
        private System.Windows.Forms.TextBox textBoxIntro;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroLabel metroLabelLoadedResultFiles;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButtonLoadResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerResult;
    }
}
