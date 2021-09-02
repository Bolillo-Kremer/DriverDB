
namespace DriverDB.UI
{
    partial class ChangeRoot
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
            this.RootLabel = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RootInput = new System.Windows.Forms.TextBox();
            this.ChooseDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RootLabel
            // 
            this.RootLabel.AutoSize = true;
            this.RootLabel.Location = new System.Drawing.Point(23, 31);
            this.RootLabel.Name = "RootLabel";
            this.RootLabel.Size = new System.Drawing.Size(98, 13);
            this.RootLabel.TabIndex = 0;
            this.RootLabel.Text = "Database Directory";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(113, 70);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(203, 70);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(84, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RootInput
            // 
            this.RootInput.Location = new System.Drawing.Point(162, 27);
            this.RootInput.Name = "RootInput";
            this.RootInput.Size = new System.Drawing.Size(222, 20);
            this.RootInput.TabIndex = 3;
            // 
            // ChooseDirectory
            // 
            this.ChooseDirectory.Location = new System.Drawing.Point(127, 27);
            this.ChooseDirectory.Name = "ChooseDirectory";
            this.ChooseDirectory.Size = new System.Drawing.Size(29, 20);
            this.ChooseDirectory.TabIndex = 4;
            this.ChooseDirectory.Text = "...";
            this.ChooseDirectory.UseVisualStyleBackColor = true;
            this.ChooseDirectory.Click += new System.EventHandler(this.ChooseDirectory_Click);
            // 
            // ChangeRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 115);
            this.Controls.Add(this.ChooseDirectory);
            this.Controls.Add(this.RootInput);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.RootLabel);
            this.Name = "ChangeRoot";
            this.Text = "Change Database Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RootLabel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox RootInput;
        private System.Windows.Forms.Button ChooseDirectory;
    }
}