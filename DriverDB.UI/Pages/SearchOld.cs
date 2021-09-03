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
            StartDate.Value = DateTime.Today.AddMonths(-1);
            EndDate.Value = DateTime.Today.AddDays(5);
        }

        #endregion Constructors

        #region Methods

        private void PopulateData()
        {
            OldDrivers.Items.Clear();
            Driver SelectedDriver = Driver.GetExisting(DriverNameText.Text);

            if (SelectedDriver != null)
            {
                foreach (DriverFile OldImage in SortTable(SelectedDriver.OldDriverImages))
                {
                    if (OldImage.ExpirationDate >= StartDate.Value && OldImage.ExpirationDate <= EndDate.Value)
                    {
                        ListViewItem ListItem = new ListViewItem(new[]
                        {
                                    SelectedDriver.DriverName,
                                    OldImage.FileType.ToString(),
                                    OldImage.ExpirationDate.ToString("MM/dd/yyyy"),
                                    OldImage.FilePath
                            });

                        if (SelectImageType.SelectedItem.ToString() == "All")
                        {
                            OldDrivers.Items.Add(ListItem);
                        }
                        else if (OldImage.FileType.ToString() == SelectImageType.SelectedItem.ToString().Replace(" ", ""))
                        {
                            OldDrivers.Items.Add(ListItem);
                        }
                    }
                }
            }
        }

        private List<DriverFile> SortTable(List<DriverFile> DriverImages)
        {
            List<DriverFile> Sorted = new List<DriverFile>();

            while (DriverImages.Count != 0)
            {
                DriverFile Compared = DriverImages.First();

                foreach (DriverFile aDriverImage in DriverImages)
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

        private void OldDrivers_DoubleClick(object sendr, EventArgs e)
        {
            using (Process FileOpener = new Process())
            {
                FileOpener.StartInfo.FileName = "explorer";
                FileOpener.StartInfo.Arguments = $"\"{OldDrivers.SelectedItems[0].SubItems[3].Text}\"";
                FileOpener.Start();
            }             
        }

        private void DriverNameText_TextChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void SelectImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void EndDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void SelectSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        #endregion Event Methods
    }
}
