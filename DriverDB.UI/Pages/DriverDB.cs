using System;
using System.Drawing;
using DriverDB.Core;
using System.Windows.Forms;

namespace DriverDB.UI
{
    public partial class DriverDB : Form
    {
        #region Properties

        private string Root = string.Empty;

        #endregion Properties

        #region Constructors

        public DriverDB()
        {
            InitializeComponent();
            try
            {
                this.Root = AppData.CheckRoot();
            }
            catch
            {
                MessageBox.Show("The directory to the database is empty.\nPlease select \"Database Settings>Change Database Directory\" from the top menu to change it");
                return;
            }

            PopulateExpiredDrivers();
            PopulateAlmostExpired();
        }

        #endregion Constructors

        #region Initiator Methods

        private static ListViewItem CreateListItem(Driver aDriver, int Days = 0, string DateFormat = "MM/dd/yyyy")
        {
            ListViewItem ListItem = new ListViewItem(new[]
            {
                    aDriver.DriverName,
                    aDriver.License.ExpirationDate.ToString(DateFormat),
                    aDriver.MVR.ExpirationDate.ToString(DateFormat),
                    aDriver.MedicalCard.ExpirationDate.ToString(DateFormat)
            });

            if (aDriver.License.ExpirationDate <= DateTime.Today.AddDays(Days + 1))
            {
                ListItem.SubItems[1].BackColor = Color.FromKnownColor(KnownColor.Red);
                ListItem.SubItems[1].ForeColor = Color.FromKnownColor(KnownColor.White);
            }

            if (aDriver.MVR.ExpirationDate <= DateTime.Today.AddDays(Days + 1))
            {
                ListItem.SubItems[2].BackColor = Color.FromKnownColor(KnownColor.Red);
                ListItem.SubItems[2].ForeColor = Color.FromKnownColor(KnownColor.White);
            }

            if (aDriver.MedicalCard.ExpirationDate <= DateTime.Today.AddDays(Days + 1))
            {
                ListItem.SubItems[3].BackColor = Color.FromKnownColor(KnownColor.Red);
                ListItem.SubItems[3].ForeColor = Color.FromKnownColor(KnownColor.White);
            }

            ListItem.UseItemStyleForSubItems = false;

            return ListItem;
        }

        public void PopulateExpiredDrivers()
        {
            ExpiredDrivers.Items.Clear();
            foreach (Driver aDriver in Driver.ExpiredDrivers())
            {
                ExpiredDrivers.Items.Add(CreateListItem(aDriver));
            }
        }

        public void PopulateAlmostExpired()
        {
            AlmostExpired.Items.Clear();
            int SelectedDays = (int)SelectExpiredWithin.Value - 1;
            foreach (Driver aDriver in Driver.ExpiresWithin((int)SelectExpiredWithin.Value - 1))
            {
                AlmostExpired.Items.Add(CreateListItem(aDriver, SelectedDays));
            }
        }

        #endregion Initiator Methods

        #region File Menu Methods

        private void NewDriver_Click(object sender, EventArgs e)
        {
            new AddDriver().Show();
        }

        private void OpenDriver_Click(object sender, EventArgs e)
        {
            string Path = Connections.OpenFile(this, Root, true).Replace(Root + "\\", "");
            if (!(Path == "" || Path == null))
            {
                new AddDriver(Driver.GetExisting(Path, true)).Show();
            }      
        }

        private void SearchOld_Click(object sender, EventArgs e)
        {
            new SearchOld().Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion File Menu Methods

        #region Database Menu Methods

        private void ChangeRoot_Click(object sender, EventArgs e)
        {
            Form ChangeRoot = new ChangeRoot();
            ChangeRoot.Show();
        }

        private void RefreshDatabase_Click(object sender, EventArgs e)
        {
            PopulateExpiredDrivers();
            PopulateAlmostExpired();
        }

        #endregion Database Menu Methods

        #region Selector Methods

        private void SelectExpiredWithin_ValueChanged(object sender, EventArgs e)
        {
            PopulateAlmostExpired();
        }

        private void ExpiredDrivers_DoubleClick(object sender, EventArgs e)
        {
            new AddDriver(Driver.GetExisting(ExpiredDrivers.SelectedItems[0].SubItems[0].Text)).Show();
        }

        private void AlmostExpired_DoubleClick(object sender, EventArgs e)
        {
            new AddDriver(Driver.GetExisting(AlmostExpired.SelectedItems[0].SubItems[0].Text)).Show();
        }

        #endregion Selector Methods

        #region Button Methods

        private void Refresh_Click(object sender, EventArgs e)
        {
            PopulateExpiredDrivers();
            PopulateAlmostExpired();
        }

        #endregion Button Methods
    }
}
