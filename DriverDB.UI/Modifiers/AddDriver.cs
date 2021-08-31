using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using DriverDB.Core;

namespace DriverDB.UI
{
    public partial class AddDriver : Form
    {
        public Driver Existing = null;
        public AddDriver(Driver aDriver = null)
        {
            InitializeComponent();
            if (aDriver != null)
            {
                Existing = aDriver;
                this.Text = Existing.DriverName;
                DriverNameInput.Text = Existing.DriverName;
                LicenseImageInput.Text = aDriver.License.FilePath;
                MVRImageInput.Text = aDriver.MVR.FilePath;
                MedCardImageInput.Text = aDriver.MedicalCard.FilePath;

                ChooseLicenseExpiration.Value = Existing.License.ExpirationDate;
                ChooseMVRExpiration.Value = Existing.MVR.ExpirationDate;
                ChooseMedCardExpiration.Value = Existing.MedicalCard.ExpirationDate;
            }
        }

        #region Button Clicks

        private void ChooseLicenseImage_Click(object sender, EventArgs e)
        {
            string Dir = Dialogs.OpenFile(this, LicenseImageInput.Text);
            LicenseImageInput.Text = (Dir.Length > 0) ? Dir: LicenseImageInput.Text;
        }

        private void ChooseMVRImage_Click(object sender, EventArgs e)
        {
            string Dir = Dialogs.OpenFile(this, MVRImageInput.Text);
            MVRImageInput.Text = (Dir.Length > 0) ? Dir : MVRImageInput.Text;
        }

        private void ChooseMedCardImage_Click(object sender, EventArgs e)
        {
            string Dir = Dialogs.OpenFile(this, MedCardImageInput.Text);
            MedCardImageInput.Text = (Dir.Length > 0) ? Dir : MedCardImageInput.Text;
        }

        private void SaveDriver_Click(object sender, EventArgs e)
        {
            if (Existing != null)
            {
                Existing.UpdateLicense(LicenseImageInput.Text, ChooseLicenseExpiration.Value);
                Existing.UpdateMVR(MVRImageInput.Text, ChooseMVRExpiration.Value);
                Existing.UpdateMedicalCard(MedCardImageInput.Text, ChooseMedCardExpiration.Value);
                Existing.Save();
            }
            else
            {
                new Driver(DriverNameInput.Text,
                    new DriverImage(LicenseImageInput.Text, ChooseLicenseExpiration.Value),
                    new DriverImage(MVRImageInput.Text, ChooseMVRExpiration.Value),
                    new DriverImage(MedCardImageInput.Text, ChooseMedCardExpiration.Value)).Save();
            }

            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Button Clicks
    }
}
