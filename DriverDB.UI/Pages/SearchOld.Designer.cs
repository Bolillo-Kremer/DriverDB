
namespace DriverDB.UI
{
    partial class SearchOld
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
            this.OldDrivers = new System.Windows.Forms.ListView();
            this.DriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExpDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DriverNameText = new System.Windows.Forms.TextBox();
            this.drvrNmLbl = new System.Windows.Forms.Label();
            this.SelectImageType = new System.Windows.Forms.ComboBox();
            this.ImageTypeLbl = new System.Windows.Forms.Label();
            this.EndDateLbl = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.StartDateLbl = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.SortByLbl = new System.Windows.Forms.Label();
            this.SelectSortBy = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.FilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // OldDrivers
            // 
            this.OldDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DriverName,
            this.ImageType,
            this.ExpDate,
            this.FilePath});
            this.OldDrivers.HideSelection = false;
            this.OldDrivers.Location = new System.Drawing.Point(348, 12);
            this.OldDrivers.Name = "OldDrivers";
            this.OldDrivers.Size = new System.Drawing.Size(430, 426);
            this.OldDrivers.TabIndex = 0;
            this.OldDrivers.UseCompatibleStateImageBehavior = false;
            this.OldDrivers.View = System.Windows.Forms.View.Details;
            this.OldDrivers.SelectedIndexChanged += new System.EventHandler(this.OldDrivers_SelectedIndexChanged);
            this.OldDrivers.DoubleClick += new System.EventHandler(this.OldDrivers_DoubleClick);
            // 
            // DriverName
            // 
            this.DriverName.Text = "Driver Name";
            this.DriverName.Width = 95;
            // 
            // ImageType
            // 
            this.ImageType.Text = "Image Type";
            this.ImageType.Width = 114;
            // 
            // ExpDate
            // 
            this.ExpDate.Text = "Expiration Date";
            this.ExpDate.Width = 115;
            // 
            // DriverNameText
            // 
            this.DriverNameText.Location = new System.Drawing.Point(84, 15);
            this.DriverNameText.Name = "DriverNameText";
            this.DriverNameText.Size = new System.Drawing.Size(199, 20);
            this.DriverNameText.TabIndex = 1;
            // 
            // drvrNmLbl
            // 
            this.drvrNmLbl.AutoSize = true;
            this.drvrNmLbl.Location = new System.Drawing.Point(12, 18);
            this.drvrNmLbl.Name = "drvrNmLbl";
            this.drvrNmLbl.Size = new System.Drawing.Size(66, 13);
            this.drvrNmLbl.TabIndex = 2;
            this.drvrNmLbl.Text = "Driver Name";
            // 
            // SelectImageType
            // 
            this.SelectImageType.FormattingEnabled = true;
            this.SelectImageType.Items.AddRange(new object[] {
            "All",
            "License",
            "MVR",
            "Medical Card"});
            this.SelectImageType.Location = new System.Drawing.Point(84, 52);
            this.SelectImageType.Name = "SelectImageType";
            this.SelectImageType.Size = new System.Drawing.Size(199, 21);
            this.SelectImageType.TabIndex = 7;
            // 
            // ImageTypeLbl
            // 
            this.ImageTypeLbl.AutoSize = true;
            this.ImageTypeLbl.Location = new System.Drawing.Point(12, 55);
            this.ImageTypeLbl.Name = "ImageTypeLbl";
            this.ImageTypeLbl.Size = new System.Drawing.Size(63, 13);
            this.ImageTypeLbl.TabIndex = 8;
            this.ImageTypeLbl.Text = "Image Type";
            // 
            // EndDateLbl
            // 
            this.EndDateLbl.AutoSize = true;
            this.EndDateLbl.Location = new System.Drawing.Point(12, 132);
            this.EndDateLbl.Name = "EndDateLbl";
            this.EndDateLbl.Size = new System.Drawing.Size(52, 13);
            this.EndDateLbl.TabIndex = 12;
            this.EndDateLbl.Text = "End Date";
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(84, 128);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(199, 20);
            this.EndDate.TabIndex = 11;
            // 
            // StartDateLbl
            // 
            this.StartDateLbl.AutoSize = true;
            this.StartDateLbl.Location = new System.Drawing.Point(12, 95);
            this.StartDateLbl.Name = "StartDateLbl";
            this.StartDateLbl.Size = new System.Drawing.Size(55, 13);
            this.StartDateLbl.TabIndex = 10;
            this.StartDateLbl.Text = "Start Date";
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(84, 91);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(199, 20);
            this.StartDate.TabIndex = 9;
            // 
            // SortByLbl
            // 
            this.SortByLbl.AutoSize = true;
            this.SortByLbl.Location = new System.Drawing.Point(12, 168);
            this.SortByLbl.Name = "SortByLbl";
            this.SortByLbl.Size = new System.Drawing.Size(41, 13);
            this.SortByLbl.TabIndex = 14;
            this.SortByLbl.Text = "Sort By";
            // 
            // SelectSortBy
            // 
            this.SelectSortBy.FormattingEnabled = true;
            this.SelectSortBy.Items.AddRange(new object[] {
            "Expiration Date Ascending",
            "Expiration Date Descending"});
            this.SelectSortBy.Location = new System.Drawing.Point(84, 165);
            this.SelectSortBy.Name = "SelectSortBy";
            this.SelectSortBy.Size = new System.Drawing.Size(199, 21);
            this.SelectSortBy.TabIndex = 13;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(133, 225);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 15;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // FilePath
            // 
            this.FilePath.Text = "File Path";
            this.FilePath.Width = 231;
            // 
            // SearchOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 450);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SortByLbl);
            this.Controls.Add(this.SelectSortBy);
            this.Controls.Add(this.EndDateLbl);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.StartDateLbl);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.ImageTypeLbl);
            this.Controls.Add(this.SelectImageType);
            this.Controls.Add(this.drvrNmLbl);
            this.Controls.Add(this.DriverNameText);
            this.Controls.Add(this.OldDrivers);
            this.Name = "SearchOld";
            this.Text = "Search Old Driver Images";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView OldDrivers;
        private System.Windows.Forms.ColumnHeader DriverName;
        private System.Windows.Forms.ColumnHeader ImageType;
        private System.Windows.Forms.ColumnHeader ExpDate;
        private System.Windows.Forms.TextBox DriverNameText;
        private System.Windows.Forms.Label drvrNmLbl;
        private System.Windows.Forms.ComboBox SelectImageType;
        private System.Windows.Forms.Label ImageTypeLbl;
        private System.Windows.Forms.Label EndDateLbl;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.Label StartDateLbl;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Label SortByLbl;
        private System.Windows.Forms.ComboBox SelectSortBy;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ColumnHeader FilePath;
    }
}