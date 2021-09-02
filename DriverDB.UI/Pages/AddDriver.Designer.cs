
namespace DriverDB.UI
{
    partial class AddDriver
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
            this.drvNameLbl = new System.Windows.Forms.Label();
            this.licenseLbl = new System.Windows.Forms.Label();
            this.mvrLbl = new System.Windows.Forms.Label();
            this.medCrdLbl = new System.Windows.Forms.Label();
            this.DriverNameInput = new System.Windows.Forms.TextBox();
            this.LicenseImageInput = new System.Windows.Forms.TextBox();
            this.MVRImageInput = new System.Windows.Forms.TextBox();
            this.MedCardImageInput = new System.Windows.Forms.TextBox();
            this.ChooseLicenseImage = new System.Windows.Forms.Button();
            this.ChooseMVRImage = new System.Windows.Forms.Button();
            this.ChooseMedCardImage = new System.Windows.Forms.Button();
            this.ChooseLicenseExpiration = new System.Windows.Forms.DateTimePicker();
            this.ChooseMVRExpiration = new System.Windows.Forms.DateTimePicker();
            this.ChooseMedCardExpiration = new System.Windows.Forms.DateTimePicker();
            this.SaveDriver = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drvNameLbl
            // 
            this.drvNameLbl.AutoSize = true;
            this.drvNameLbl.Location = new System.Drawing.Point(33, 29);
            this.drvNameLbl.Name = "drvNameLbl";
            this.drvNameLbl.Size = new System.Drawing.Size(69, 13);
            this.drvNameLbl.TabIndex = 0;
            this.drvNameLbl.Text = "Driver Name:";
            // 
            // licenseLbl
            // 
            this.licenseLbl.AutoSize = true;
            this.licenseLbl.Location = new System.Drawing.Point(33, 75);
            this.licenseLbl.Name = "licenseLbl";
            this.licenseLbl.Size = new System.Drawing.Size(47, 13);
            this.licenseLbl.TabIndex = 1;
            this.licenseLbl.Text = "License:";
            // 
            // mvrLbl
            // 
            this.mvrLbl.AutoSize = true;
            this.mvrLbl.Location = new System.Drawing.Point(33, 119);
            this.mvrLbl.Name = "mvrLbl";
            this.mvrLbl.Size = new System.Drawing.Size(34, 13);
            this.mvrLbl.TabIndex = 2;
            this.mvrLbl.Text = "MVR:";
            // 
            // medCrdLbl
            // 
            this.medCrdLbl.AutoSize = true;
            this.medCrdLbl.Location = new System.Drawing.Point(33, 161);
            this.medCrdLbl.Name = "medCrdLbl";
            this.medCrdLbl.Size = new System.Drawing.Size(72, 13);
            this.medCrdLbl.TabIndex = 3;
            this.medCrdLbl.Text = "Medical Card:";
            // 
            // DriverNameInput
            // 
            this.DriverNameInput.Location = new System.Drawing.Point(159, 26);
            this.DriverNameInput.Name = "DriverNameInput";
            this.DriverNameInput.Size = new System.Drawing.Size(289, 20);
            this.DriverNameInput.TabIndex = 4;
            // 
            // LicenseImageInput
            // 
            this.LicenseImageInput.Location = new System.Drawing.Point(159, 72);
            this.LicenseImageInput.Name = "LicenseImageInput";
            this.LicenseImageInput.Size = new System.Drawing.Size(289, 20);
            this.LicenseImageInput.TabIndex = 5;
            // 
            // MVRImageInput
            // 
            this.MVRImageInput.Location = new System.Drawing.Point(159, 116);
            this.MVRImageInput.Name = "MVRImageInput";
            this.MVRImageInput.Size = new System.Drawing.Size(289, 20);
            this.MVRImageInput.TabIndex = 6;
            // 
            // MedCardImageInput
            // 
            this.MedCardImageInput.Location = new System.Drawing.Point(159, 158);
            this.MedCardImageInput.Name = "MedCardImageInput";
            this.MedCardImageInput.Size = new System.Drawing.Size(289, 20);
            this.MedCardImageInput.TabIndex = 7;
            // 
            // ChooseLicenseImage
            // 
            this.ChooseLicenseImage.Location = new System.Drawing.Point(124, 72);
            this.ChooseLicenseImage.Name = "ChooseLicenseImage";
            this.ChooseLicenseImage.Size = new System.Drawing.Size(29, 20);
            this.ChooseLicenseImage.TabIndex = 8;
            this.ChooseLicenseImage.Text = "...";
            this.ChooseLicenseImage.UseVisualStyleBackColor = true;
            this.ChooseLicenseImage.Click += new System.EventHandler(this.ChooseLicenseImage_Click);
            // 
            // ChooseMVRImage
            // 
            this.ChooseMVRImage.Location = new System.Drawing.Point(124, 116);
            this.ChooseMVRImage.Name = "ChooseMVRImage";
            this.ChooseMVRImage.Size = new System.Drawing.Size(29, 20);
            this.ChooseMVRImage.TabIndex = 10;
            this.ChooseMVRImage.Text = "...";
            this.ChooseMVRImage.UseVisualStyleBackColor = true;
            this.ChooseMVRImage.Click += new System.EventHandler(this.ChooseMVRImage_Click);
            // 
            // ChooseMedCardImage
            // 
            this.ChooseMedCardImage.Location = new System.Drawing.Point(124, 158);
            this.ChooseMedCardImage.Name = "ChooseMedCardImage";
            this.ChooseMedCardImage.Size = new System.Drawing.Size(29, 20);
            this.ChooseMedCardImage.TabIndex = 11;
            this.ChooseMedCardImage.Text = "...";
            this.ChooseMedCardImage.UseVisualStyleBackColor = true;
            this.ChooseMedCardImage.Click += new System.EventHandler(this.ChooseMedCardImage_Click);
            // 
            // ChooseLicenseExpiration
            // 
            this.ChooseLicenseExpiration.Location = new System.Drawing.Point(454, 72);
            this.ChooseLicenseExpiration.Name = "ChooseLicenseExpiration";
            this.ChooseLicenseExpiration.Size = new System.Drawing.Size(200, 20);
            this.ChooseLicenseExpiration.TabIndex = 12;
            this.ChooseLicenseExpiration.ValueChanged += new System.EventHandler(this.ChooseLicenseExpiration_ValueChanged);
            // 
            // ChooseMVRExpiration
            // 
            this.ChooseMVRExpiration.Location = new System.Drawing.Point(454, 116);
            this.ChooseMVRExpiration.Name = "ChooseMVRExpiration";
            this.ChooseMVRExpiration.Size = new System.Drawing.Size(200, 20);
            this.ChooseMVRExpiration.TabIndex = 13;
            this.ChooseMVRExpiration.ValueChanged += new System.EventHandler(this.ChooseMVRExpiration_ValueChanged);
            // 
            // ChooseMedCardExpiration
            // 
            this.ChooseMedCardExpiration.Location = new System.Drawing.Point(454, 158);
            this.ChooseMedCardExpiration.Name = "ChooseMedCardExpiration";
            this.ChooseMedCardExpiration.Size = new System.Drawing.Size(200, 20);
            this.ChooseMedCardExpiration.TabIndex = 14;
            this.ChooseMedCardExpiration.ValueChanged += new System.EventHandler(this.ChooseMedCardExpiration_ValueChanged);
            // 
            // SaveDriver
            // 
            this.SaveDriver.Location = new System.Drawing.Point(243, 212);
            this.SaveDriver.Name = "SaveDriver";
            this.SaveDriver.Size = new System.Drawing.Size(75, 23);
            this.SaveDriver.TabIndex = 16;
            this.SaveDriver.Text = "Save";
            this.SaveDriver.UseVisualStyleBackColor = true;
            this.SaveDriver.Click += new System.EventHandler(this.SaveDriver_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(339, 212);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // AddDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 260);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SaveDriver);
            this.Controls.Add(this.ChooseMedCardExpiration);
            this.Controls.Add(this.ChooseMVRExpiration);
            this.Controls.Add(this.ChooseLicenseExpiration);
            this.Controls.Add(this.ChooseMedCardImage);
            this.Controls.Add(this.ChooseMVRImage);
            this.Controls.Add(this.ChooseLicenseImage);
            this.Controls.Add(this.MedCardImageInput);
            this.Controls.Add(this.MVRImageInput);
            this.Controls.Add(this.LicenseImageInput);
            this.Controls.Add(this.DriverNameInput);
            this.Controls.Add(this.medCrdLbl);
            this.Controls.Add(this.mvrLbl);
            this.Controls.Add(this.licenseLbl);
            this.Controls.Add(this.drvNameLbl);
            this.Name = "AddDriver";
            this.Text = "New Driver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label drvNameLbl;
        private System.Windows.Forms.Label licenseLbl;
        private System.Windows.Forms.Label mvrLbl;
        private System.Windows.Forms.Label medCrdLbl;
        private System.Windows.Forms.TextBox DriverNameInput;
        private System.Windows.Forms.TextBox LicenseImageInput;
        private System.Windows.Forms.TextBox MVRImageInput;
        private System.Windows.Forms.TextBox MedCardImageInput;
        private System.Windows.Forms.Button ChooseLicenseImage;
        private System.Windows.Forms.Button ChooseMVRImage;
        private System.Windows.Forms.Button ChooseMedCardImage;
        private System.Windows.Forms.DateTimePicker ChooseLicenseExpiration;
        private System.Windows.Forms.DateTimePicker ChooseMVRExpiration;
        private System.Windows.Forms.DateTimePicker ChooseMedCardExpiration;
        private System.Windows.Forms.Button SaveDriver;
        private System.Windows.Forms.Button Cancel;
    }
}