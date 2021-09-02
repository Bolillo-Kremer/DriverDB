using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverDB.Core;
using System.Diagnostics;

namespace DriverDB.UI
{
    public partial class SearchOld : Form
    {
        #region Constructors

        public SearchOld()
        {
            InitializeComponent();
            SelectImageType.SelectedItem = "All";
            SelectSortBy.SelectedItem = "Expiration Date Ascending";
        }

        #endregion Constructors

        #region Methods

        private void RefreshData()
        {
            OldDrivers.Items.Clear();
            try
            {
                Driver SelectedDriver = Driver.GetExisting(DriverNameText.Text);

                foreach(DriverImage OldImage in SortTable(SelectedDriver.OldDriverImages))
                {
                    if (OldImage.ExpirationDate >= StartDate.Value && OldImage.ExpirationDate <= EndDate.Value)
                    {
                        ListViewItem ListItem = new ListViewItem(new[]
{
                                    SelectedDriver.DriverName,
                                    OldImage.DriverImageType.ToString(),
                                    OldImage.ExpirationDate.ToString("MM/dd/yyyy"),
                                    OldImage.FilePath
                        });

                        if (SelectImageType.SelectedItem.ToString() == "All")
                        {
                            OldDrivers.Items.Add(ListItem);
                        }
                        else if (OldImage.DriverImageType.ToString() == SelectImageType.SelectedItem.ToString().Replace(" ", ""))
                        {
                            OldDrivers.Items.Add(ListItem);
                        }
                    }
                }
            }
            catch 
            { }
        }

        private List<DriverImage> SortTable(List<DriverImage> DriverImages)
        {
            List<DriverImage> Sorted = new List<DriverImage>();

            while (DriverImages.Count != 0)
            {
                DriverImage Compared = DriverImages.First();

                foreach (DriverImage aDriverImage in DriverImages)
                {
                    switch (SelectSortBy.SelectedItem.ToString())
                    {
                        case "Expiration Date Ascending":
                            Compared = (aDriverImage.ExpirationDate < Compared.ExpirationDate) ? aDriverImage : Compared;
                            break;
                        case "Expiration Date Descending":
                            Compared = (aDriverImage.ExpirationDate > Compared.ExpirationDate) ? aDriverImage : Compared;
                            break;
                    }
                }

                Sorted.Add(Compared);
                DriverImages.Remove(Compared);
            }

            return Sorted;
        }

        #endregion Methods

        #region Event Methods

        private void Search_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void OldDrivers_DoubleClick(object sendr, EventArgs e)
        {
            using (Process FileOpener = new Process())
            {
                FileOpener.StartInfo.FileName = "explorer";
                FileOpener.StartInfo.Arguments = $"\"{OldDrivers.SelectedItems[0].SubItems[3].Text}\"";
                FileOpener.Start();
            }             
        }
        #endregion Event Methods

        private void OldDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
