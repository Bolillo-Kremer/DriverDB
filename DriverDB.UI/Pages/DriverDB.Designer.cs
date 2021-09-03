
namespace DriverDB.UI
{
    partial class DriverDB
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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewDriver = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDriver = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchOld = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpiredDrivers = new System.Windows.Forms.ListView();
            this.DriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LicenseExp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MVRExp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MedCardExp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expiredDriversLabel = new System.Windows.Forms.Label();
            this.expWithinLbl = new System.Windows.Forms.Label();
            this.AlmostExpired = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysLbl = new System.Windows.Forms.Label();
            this.SelectExpiredWithin = new System.Windows.Forms.NumericUpDown();
            this.Refresh = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExpiredWithin)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseSettingsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(915, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDriver,
            this.OpenDriver,
            this.SearchOld,
            this.Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NewDriver
            // 
            this.NewDriver.Name = "NewDriver";
            this.NewDriver.Size = new System.Drawing.Size(206, 22);
            this.NewDriver.Text = "New";
            this.NewDriver.Click += new System.EventHandler(this.NewDriver_Click);
            // 
            // OpenDriver
            // 
            this.OpenDriver.Name = "OpenDriver";
            this.OpenDriver.Size = new System.Drawing.Size(206, 22);
            this.OpenDriver.Text = "Open";
            this.OpenDriver.Click += new System.EventHandler(this.OpenDriver_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(206, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // SearchOld
            // 
            this.SearchOld.Name = "SearchOld";
            this.SearchOld.Size = new System.Drawing.Size(206, 22);
            this.SearchOld.Text = "Search Old Driver Images";
            this.SearchOld.Click += new System.EventHandler(this.SearchOld_Click);
            // 
            // databaseSettingsToolStripMenuItem
            // 
            this.databaseSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeRoot,
            this.RefreshDatabase});
            this.databaseSettingsToolStripMenuItem.Name = "databaseSettingsToolStripMenuItem";
            this.databaseSettingsToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.databaseSettingsToolStripMenuItem.Text = "Database Settings";
            // 
            // ChangeRoot
            // 
            this.ChangeRoot.Name = "ChangeRoot";
            this.ChangeRoot.Size = new System.Drawing.Size(217, 22);
            this.ChangeRoot.Text = "Change Database Directory";
            this.ChangeRoot.Click += new System.EventHandler(this.ChangeRoot_Click);
            // 
            // RefreshDatabase
            // 
            this.RefreshDatabase.Name = "RefreshDatabase";
            this.RefreshDatabase.Size = new System.Drawing.Size(217, 22);
            this.RefreshDatabase.Text = "Refresh";
            this.RefreshDatabase.Click += new System.EventHandler(this.RefreshDatabase_Click);
            // 
            // ExpiredDrivers
            // 
            this.ExpiredDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DriverName,
            this.LicenseExp,
            this.MVRExp,
            this.MedCardExp});
            this.ExpiredDrivers.HideSelection = false;
            this.ExpiredDrivers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5});
            this.ExpiredDrivers.Location = new System.Drawing.Point(471, 75);
            this.ExpiredDrivers.Name = "ExpiredDrivers";
            this.ExpiredDrivers.Size = new System.Drawing.Size(431, 466);
            this.ExpiredDrivers.TabIndex = 3;
            this.ExpiredDrivers.UseCompatibleStateImageBehavior = false;
            this.ExpiredDrivers.View = System.Windows.Forms.View.Details;
            this.ExpiredDrivers.DoubleClick += new System.EventHandler(this.ExpiredDrivers_DoubleClick);
            // 
            // DriverName
            // 
            this.DriverName.Text = "Driver Name";
            this.DriverName.Width = 91;
            // 
            // LicenseExp
            // 
            this.LicenseExp.Text = "License Expiration";
            this.LicenseExp.Width = 108;
            // 
            // MVRExp
            // 
            this.MVRExp.Text = "MVR Expiration";
            this.MVRExp.Width = 102;
            // 
            // MedCardExp
            // 
            this.MedCardExp.Text = "Medical-Card Expiration";
            this.MedCardExp.Width = 126;
            // 
            // expiredDriversLabel
            // 
            this.expiredDriversLabel.AutoSize = true;
            this.expiredDriversLabel.Location = new System.Drawing.Point(649, 48);
            this.expiredDriversLabel.Name = "expiredDriversLabel";
            this.expiredDriversLabel.Size = new System.Drawing.Size(78, 13);
            this.expiredDriversLabel.TabIndex = 4;
            this.expiredDriversLabel.Text = "Expired Drivers";
            // 
            // expWithinLbl
            // 
            this.expWithinLbl.AutoSize = true;
            this.expWithinLbl.Location = new System.Drawing.Point(131, 48);
            this.expWithinLbl.Name = "expWithinLbl";
            this.expWithinLbl.Size = new System.Drawing.Size(77, 13);
            this.expWithinLbl.TabIndex = 5;
            this.expWithinLbl.Text = "Expiring Within";
            // 
            // AlmostExpired
            // 
            this.AlmostExpired.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.AlmostExpired.HideSelection = false;
            this.AlmostExpired.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.AlmostExpired.Location = new System.Drawing.Point(12, 75);
            this.AlmostExpired.Name = "AlmostExpired";
            this.AlmostExpired.Size = new System.Drawing.Size(431, 466);
            this.AlmostExpired.TabIndex = 6;
            this.AlmostExpired.UseCompatibleStateImageBehavior = false;
            this.AlmostExpired.View = System.Windows.Forms.View.Details;
            this.AlmostExpired.DoubleClick += new System.EventHandler(this.AlmostExpired_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Driver Name";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "License Expiration";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MVR Expiration";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Medical-Card Expiration";
            this.columnHeader4.Width = 126;
            // 
            // daysLbl
            // 
            this.daysLbl.AutoSize = true;
            this.daysLbl.Location = new System.Drawing.Point(270, 48);
            this.daysLbl.Name = "daysLbl";
            this.daysLbl.Size = new System.Drawing.Size(31, 13);
            this.daysLbl.TabIndex = 7;
            this.daysLbl.Text = "Days";
            // 
            // SelectExpiredWithin
            // 
            this.SelectExpiredWithin.Location = new System.Drawing.Point(214, 46);
            this.SelectExpiredWithin.Name = "SelectExpiredWithin";
            this.SelectExpiredWithin.Size = new System.Drawing.Size(50, 20);
            this.SelectExpiredWithin.TabIndex = 8;
            this.SelectExpiredWithin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SelectExpiredWithin.ValueChanged += new System.EventHandler(this.SelectExpiredWithin_ValueChanged);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(417, 27);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(83, 23);
            this.Refresh.TabIndex = 9;
            this.Refresh.Text = "Refresh Data";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // DriverDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 553);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.SelectExpiredWithin);
            this.Controls.Add(this.daysLbl);
            this.Controls.Add(this.AlmostExpired);
            this.Controls.Add(this.expWithinLbl);
            this.Controls.Add(this.expiredDriversLabel);
            this.Controls.Add(this.ExpiredDrivers);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "DriverDB";
            this.Text = "Driver Database";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExpiredWithin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewDriver;
        private System.Windows.Forms.ToolStripMenuItem OpenDriver;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeRoot;
        private System.Windows.Forms.ListView ExpiredDrivers;
        private System.Windows.Forms.ColumnHeader DriverName;
        private System.Windows.Forms.ColumnHeader LicenseExp;
        private System.Windows.Forms.ColumnHeader MVRExp;
        private System.Windows.Forms.ColumnHeader MedCardExp;
        private System.Windows.Forms.Label expiredDriversLabel;
        private System.Windows.Forms.Label expWithinLbl;
        private System.Windows.Forms.ListView AlmostExpired;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label daysLbl;
        private System.Windows.Forms.NumericUpDown SelectExpiredWithin;
        private System.Windows.Forms.ToolStripMenuItem RefreshDatabase;
        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ToolStripMenuItem SearchOld;
    }
}

