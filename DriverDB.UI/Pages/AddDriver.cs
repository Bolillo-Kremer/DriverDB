using System;
using System.Drawing;
using System.Windows.Forms;
using DriverDB.Core;
using System.IO;

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
            else
            {
                ChooseLicenseExpiration.Value = DateTime.Today.AddDays(1);
                ChooseMVRExpiration.Value = DateTime.Today.AddDays(1);
                ChooseMedCardExpiration.Value = DateTime.Today.AddDays(1);
            }

            CheckExpirationDates();
        }

        #region Button Clicks

        private void ChooseLicenseImage_Click(object sender, EventArgs e)
        {
            string Dir = Connections.OpenFile(this, Path.GetDirectoryName(LicenseImageInput.Text));
            LicenseImageInput.Text = (Dir.Length > 0) ? Dir: LicenseImageInput.Text;
        }

        private void ChooseMVRImage_Click(object sender, EventArgs e)
        {
            string Dir = Connections.OpenFile(this, Path.GetDirectoryName(MVRImageInput.Text));
            MVRImageInput.Text = (Dir.Length > 0) ? Dir : MVRImageInput.Text;
        }

        private void ChooseMedCardImage_Click(object sender, EventArgs e)
        {
            string Dir = Connections.OpenFile(this, Path.GetDirectoryName(MedCardImageInput.Text));
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
                    new DriverFile(LicenseImageInput.Text, ChooseLicenseExpiration.Value),
                    new DriverFile(MVRImageInput.Text, ChooseMVRExpiration.Value),
                    new DriverFile(MedCardImageInput.Text, ChooseMedCardExpiration.Value)).Save();
            }

            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Button Clicks

        #region Methods

        private void CheckExpirationDates()
        {
            if (ChooseLicenseExpiration.Value <= DateTime.Now)
            {
                LicenseImageInput.BackColor = Color.FromKnownColor(KnownColor.Red);
                LicenseImageInput.ForeColor = Color.FromKnownColor(KnownColor.White);
            }
            else
            {
                LicenseImageInput.BackColor = Color.FromKnownColor(KnownColor.White);
                LicenseImageInput.ForeColor = Color.FromKnownColor(KnownColor.Black);
            }

            if (ChooseMVRExpiration.Value <= DateTime.Now)
            {
                MVRImageInput.BackColor = Color.FromKnownColor(KnownColor.Red);
                MVRImageInput.ForeColor = Color.FromKnownColor(KnownColor.White);
            }
            else
            {
                MVRImageInput.BackColor = Color.FromKnownColor(KnownColor.White);
                MVRImageInput.ForeColor = Color.FromKnownColor(KnownColor.Black);
            }

            if (ChooseMedCardExpiration.Value <= DateTime.Now)
            {
                MedCardImageInput.BackColor = Color.FromKnownColor(KnownColor.Red);
                MedCardImageInput.ForeColor = Color.FromKnownColor(KnownColor.White);
            }
            else
            {
                MedCardImageInput.BackColor = Color.FromKnownColor(KnownColor.White);
                MedCardImageInput.ForeColor = Color.FromKnownColor(KnownColor.Black);
            }
        }

        #endregion Methods

        #region Selectors

        private void ChooseLicenseExpiration_ValueChanged(object sender, EventArgs e)
        {
            CheckExpirationDates();
        }

        private void ChooseMVRExpiration_ValueChanged(object sender, EventArgs e)
        {
            CheckExpirationDates();
        }

        private void ChooseMedCardExpiration_ValueChanged(object sender, EventArgs e)
        {
            CheckExpirationDates();
        }

        #endregion Selectors
    }
}
