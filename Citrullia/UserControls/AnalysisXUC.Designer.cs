namespace Citrullia.UserControls
{
    partial class AnalysisXUC
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
            this.Run = new System.Windows.Forms.Button();
            this.panelBack = new System.Windows.Forms.Panel();
            this.buttonModifications = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonGeneral = new System.Windows.Forms.Button();
            this.buttonParameters = new System.Windows.Forms.Button();
            this.panelIndicator = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.analParUC1 = new Citrullia.UserControls.AnalParUC();
            this.analOptUC1 = new Citrullia.UserControls.AnalOptUC();
            this.analModUC1 = new Citrullia.UserControls.AnalModUC();
            this.analGenUC1 = new Citrullia.UserControls.AnalGenUC();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.analAdvancedUC1 = new Citrullia.UserControls.AnalAdvancedUC();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.BackColor = System.Drawing.Color.Silver;
            this.Run.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Run.FlatAppearance.BorderSize = 0;
            this.Run.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Run.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run.Location = new System.Drawing.Point(740, 3);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(107, 36);
            this.Run.TabIndex = 0;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = false;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelBack.Location = new System.Drawing.Point(32, 42);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(815, 10);
            this.panelBack.TabIndex = 1;
            // 
            // buttonModifications
            // 
            this.buttonModifications.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonModifications.FlatAppearance.BorderSize = 0;
            this.buttonModifications.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.buttonModifications.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonModifications.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifications.Location = new System.Drawing.Point(360, 3);
            this.buttonModifications.Name = "buttonModifications";
            this.buttonModifications.Size = new System.Drawing.Size(125, 36);
            this.buttonModifications.TabIndex = 4;
            this.buttonModifications.Text = "Modifications";
            this.buttonModifications.UseVisualStyleBackColor = true;
            this.buttonModifications.Click += new System.EventHandler(this.ButtonModifications_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonOptions.FlatAppearance.BorderSize = 0;
            this.buttonOptions.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.buttonOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOptions.Location = new System.Drawing.Point(491, 3);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(125, 36);
            this.buttonOptions.TabIndex = 5;
            this.buttonOptions.Text = "Options";
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.ButtonOptions_Click);
            // 
            // buttonGeneral
            // 
            this.buttonGeneral.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonGeneral.FlatAppearance.BorderSize = 0;
            this.buttonGeneral.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.buttonGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGeneral.Location = new System.Drawing.Point(85, 3);
            this.buttonGeneral.Name = "buttonGeneral";
            this.buttonGeneral.Size = new System.Drawing.Size(125, 36);
            this.buttonGeneral.TabIndex = 6;
            this.buttonGeneral.Text = "General";
            this.buttonGeneral.UseVisualStyleBackColor = true;
            this.buttonGeneral.Click += new System.EventHandler(this.ButtonGeneral_Click);
            // 
            // buttonParameters
            // 
            this.buttonParameters.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonParameters.FlatAppearance.BorderSize = 0;
            this.buttonParameters.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.buttonParameters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonParameters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParameters.Location = new System.Drawing.Point(216, 3);
            this.buttonParameters.Name = "buttonParameters";
            this.buttonParameters.Size = new System.Drawing.Size(125, 36);
            this.buttonParameters.TabIndex = 7;
            this.buttonParameters.Text = "Parameters";
            this.buttonParameters.UseVisualStyleBackColor = true;
            this.buttonParameters.Click += new System.EventHandler(this.ButtonParameters_Click);
            // 
            // panelIndicator
            // 
            this.panelIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(3)))));
            this.panelIndicator.Location = new System.Drawing.Point(85, 42);
            this.panelIndicator.Name = "panelIndicator";
            this.panelIndicator.Size = new System.Drawing.Size(125, 10);
            this.panelIndicator.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.analAdvancedUC1);
            this.panel1.Controls.Add(this.analParUC1);
            this.panel1.Controls.Add(this.analOptUC1);
            this.panel1.Controls.Add(this.analModUC1);
            this.panel1.Controls.Add(this.analGenUC1);
            this.panel1.Location = new System.Drawing.Point(32, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 456);
            this.panel1.TabIndex = 9;
            // 
            // analParUC1
            // 
            this.analParUC1.BackColor = System.Drawing.Color.Silver;
            this.analParUC1.Location = new System.Drawing.Point(0, 0);
            this.analParUC1.Name = "analParUC1";
            this.analParUC1.Size = new System.Drawing.Size(815, 456);
            this.analParUC1.TabIndex = 3;
            // 
            // analOptUC1
            // 
            this.analOptUC1.BackColor = System.Drawing.Color.Silver;
            this.analOptUC1.Location = new System.Drawing.Point(0, 0);
            this.analOptUC1.Name = "analOptUC1";
            this.analOptUC1.Size = new System.Drawing.Size(815, 456);
            this.analOptUC1.TabIndex = 2;
            // 
            // analModUC1
            // 
            this.analModUC1.BackColor = System.Drawing.Color.Silver;
            this.analModUC1.Location = new System.Drawing.Point(0, 0);
            this.analModUC1.Name = "analModUC1";
            this.analModUC1.Size = new System.Drawing.Size(815, 456);
            this.analModUC1.TabIndex = 1;
            // 
            // analGenUC1
            // 
            this.analGenUC1.BackColor = System.Drawing.Color.Silver;
            this.analGenUC1.Location = new System.Drawing.Point(0, 0);
            this.analGenUC1.Name = "analGenUC1";
            this.analGenUC1.Size = new System.Drawing.Size(815, 456);
            this.analGenUC1.TabIndex = 0;
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonAdvanced.FlatAppearance.BorderSize = 0;
            this.buttonAdvanced.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.buttonAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonAdvanced.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdvanced.Location = new System.Drawing.Point(622, 3);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(125, 36);
            this.buttonAdvanced.TabIndex = 10;
            this.buttonAdvanced.Text = "Advanced";
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.ButtonAdvanced_Click);
            // 
            // analAdvancedUC1
            // 
            this.analAdvancedUC1.BackColor = System.Drawing.Color.Silver;
            this.analAdvancedUC1.Location = new System.Drawing.Point(0, 0);
            this.analAdvancedUC1.Name = "analAdvancedUC1";
            this.analAdvancedUC1.Size = new System.Drawing.Size(815, 456);
            this.analAdvancedUC1.TabIndex = 4;
            // 
            // AnalysisXUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.buttonAdvanced);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelIndicator);
            this.Controls.Add(this.buttonParameters);
            this.Controls.Add(this.buttonGeneral);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.buttonModifications);
            this.Controls.Add(this.panelBack);
            this.Controls.Add(this.Run);
            this.Name = "AnalysisXUC";
            this.Size = new System.Drawing.Size(881, 540);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Button buttonModifications;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Button buttonGeneral;
        private System.Windows.Forms.Button buttonParameters;
        private System.Windows.Forms.Panel panelIndicator;
        private System.Windows.Forms.Panel panel1;
        private AnalParUC analParUC1;
        private AnalOptUC analOptUC1;
        private AnalModUC analModUC1;
        private AnalGenUC analGenUC1;
        private System.Windows.Forms.Button buttonAdvanced;
        private AnalAdvancedUC analAdvancedUC1;
    }
}
