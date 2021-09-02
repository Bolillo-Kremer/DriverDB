using System;
using System.Windows.Forms;
using DriverDB.Core;

namespace DriverDB.UI
{
    public partial class ChangeRoot : Form
    {
        public ChangeRoot()
        {
            InitializeComponent();
            RootInput.Text = AppData.Root;
        }

        #region Button Clicks

        private void ChooseDirectory_Click(object sender, EventArgs e)
        {
            string Dir = Dialogs.OpenFile(this, RootInput.Text, true);
            RootInput.Text = (Dir.Length > 0) ? Dir : RootInput.Text;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            AppData.Root = RootInput.Text;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Button Clicks
    }
}
