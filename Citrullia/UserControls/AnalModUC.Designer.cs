namespace Citrullia.UserControls
{
    partial class AnalModUC
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
            this.metroLabelCrapList = new MetroFramework.Controls.MetroLabel();
            this.metroToggleMonoIso = new MetroFramework.Controls.MetroToggle();
            this.metroListViewVModi = new MetroFramework.Controls.MetroListView();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroListViewFModi = new MetroFramework.Controls.MetroListView();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroListViewRVModi = new MetroFramework.Controls.MetroListView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroToggleAverage = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabelCrapList
            // 
            this.metroLabelCrapList.AutoSize = true;
            this.metroLabelCrapList.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelCrapList.Location = new System.Drawing.Point(21, 84);
            this.metroLabelCrapList.Name = "metroLabelCrapList";
            this.metroLabelCrapList.Size = new System.Drawing.Size(114, 19);
            this.metroLabelCrapList.TabIndex = 4;
            this.metroLabelCrapList.Text = "Fragment Mass:";
            this.metroLabelCrapList.UseCustomBackColor = true;
            // 
            // metroToggleMonoIso
            // 
            this.metroToggleMonoIso.AutoSize = true;
            this.metroToggleMonoIso.Checked = true;
            this.metroToggleMonoIso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggleMonoIso.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggleMonoIso.Location = new System.Drawing.Point(46, 141);
            this.metroToggleMonoIso.Name = "metroToggleMonoIso";
            this.metroToggleMonoIso.Size = new System.Drawing.Size(80, 17);
            this.metroToggleMonoIso.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggleMonoIso.TabIndex = 5;
            this.metroToggleMonoIso.Text = "On";
            this.metroToggleMonoIso.UseCustomBackColor = true;
            this.metroToggleMonoIso.UseSelectable = true;
            this.metroToggleMonoIso.UseStyleColors = true;
            // 
            // metroListViewVModi
            // 
            this.metroListViewVModi.BackColor = System.Drawing.Color.White;
            this.metroListViewVModi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroListViewVModi.CheckBoxes = true;
            this.metroListViewVModi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewVModi.FullRowSelect = true;
            this.metroListViewVModi.Location = new System.Drawing.Point(3, 3);
            this.metroListViewVModi.Name = "metroListViewVModi";
            this.metroListViewVModi.OwnerDraw = true;
            this.metroListViewVModi.Size = new System.Drawing.Size(534, 320);
            this.metroListViewVModi.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroListViewVModi.TabIndex = 24;
            this.metroListViewVModi.UseCompatibleStateImageBehavior = false;
            this.metroListViewVModi.UseSelectable = true;
            this.metroListViewVModi.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.MetroListViewVModi_ItemChecked);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.HotTrack = true;
            this.metroTabControl1.Location = new System.Drawing.Point(202, 43);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(548, 368);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTabControl1.TabIndex = 25;
            this.metroTabControl1.UseCustomBackColor = true;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroListViewVModi);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(540, 323);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Variable Modifications";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroListViewFModi);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(540, 326);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Fixed Modifications";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroListViewFModi
            // 
            this.metroListViewFModi.BackColor = System.Drawing.Color.White;
            this.metroListViewFModi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroListViewFModi.CheckBoxes = true;
            this.metroListViewFModi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewFModi.FullRowSelect = true;
            this.metroListViewFModi.Location = new System.Drawing.Point(3, 3);
            this.metroListViewFModi.Name = "metroListViewFModi";
            this.metroListViewFModi.OwnerDraw = true;
            this.metroListViewFModi.Size = new System.Drawing.Size(534, 320);
            this.metroListViewFModi.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroListViewFModi.TabIndex = 25;
            this.metroListViewFModi.UseCompatibleStateImageBehavior = false;
            this.metroListViewFModi.UseSelectable = true;
            this.metroListViewFModi.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.MetroListViewFModi_ItemChecked);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroListViewRVModi);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(540, 326);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Refinement: Variable Modifications";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroListViewRVModi
            // 
            this.metroListViewRVModi.BackColor = System.Drawing.Color.White;
            this.metroListViewRVModi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroListViewRVModi.CheckBoxes = true;
            this.metroListViewRVModi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewRVModi.FullRowSelect = true;
            this.metroListViewRVModi.Location = new System.Drawing.Point(3, 3);
            this.metroListViewRVModi.Name = "metroListViewRVModi";
            this.metroListViewRVModi.OwnerDraw = true;
            this.metroListViewRVModi.Size = new System.Drawing.Size(534, 320);
            this.metroListViewRVModi.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroListViewRVModi.TabIndex = 25;
            this.metroListViewRVModi.UseCompatibleStateImageBehavior = false;
            this.metroListViewRVModi.UseSelectable = true;
            this.metroListViewRVModi.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.MetroListViewRVModi_ItemChecked);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(46, 119);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(89, 19);
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Monoisotopic";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroToggleAverage
            // 
            this.metroToggleAverage.AutoSize = true;
            this.metroToggleAverage.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggleAverage.Location = new System.Drawing.Point(46, 192);
            this.metroToggleAverage.Name = "metroToggleAverage";
            this.metroToggleAverage.Size = new System.Drawing.Size(80, 17);
            this.metroToggleAverage.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggleAverage.TabIndex = 27;
            this.metroToggleAverage.Text = "Off";
            this.metroToggleAverage.UseCustomBackColor = true;
            this.metroToggleAverage.UseSelectable = true;
            this.metroToggleAverage.UseStyleColors = true;
            this.metroToggleAverage.CheckedChanged += new System.EventHandler(this.MetroToggleAverage_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(46, 170);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 19);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "Average";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // AnalModUC
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroToggleAverage);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroToggleMonoIso);
            this.Controls.Add(this.metroLabelCrapList);
            this.Name = "AnalModUC";
            this.Size = new System.Drawing.Size(815, 456);
            this.Load += new System.EventHandler(this.AnalModUC_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MetroFramework.Controls.MetroLabel metroLabelCrapList;
        private MetroFramework.Controls.MetroToggle metroToggleMonoIso;
        private MetroFramework.Controls.MetroListView metroListViewVModi;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle metroToggleAverage;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroListView metroListViewFModi;
        private MetroFramework.Controls.MetroListView metroListViewRVModi;

        #endregion

        //private MetroFramework.Controls.MetroLabel metroLabel24;
        //private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}
