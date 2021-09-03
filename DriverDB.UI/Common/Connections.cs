using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;
using DriverDB.Core;

namespace DriverDB.UI
{
    public class Connections
    {
        #region Properties

        public static CommonFileDialogFilter ImageFilter = new CommonFileDialogFilter("Image Files", "*.png; *.PNG; *.jpg *.JPG *.jpeg *JPEG");

        #endregion Properties

        /// <summary>
        /// Gets file or directory
        /// </summary>
        /// <param name="InitialDirectory">The directory to start in</param>
        /// <param name="IsFolderPicker">True if choosing a directory</param>
        /// <returns></returns>
        public static string OpenFile(Form ThisForm, string InitialDirectory = "", bool IsFolderPicker = false, CommonFileDialogFilter Filter = null)
        {
            string FileName = "";
            CommonOpenFileDialog RootDir = new CommonOpenFileDialog();
            if (InitialDirectory.Length > 0)
            {
                RootDir.InitialDirectory = InitialDirectory;
            }

            if (Filter != null)
            {
                RootDir.Filters.Add(Filter);
            }

            RootDir.IsFolderPicker = IsFolderPicker;
            if (RootDir.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FileName = RootDir.FileName;
            }
            if (ThisForm != null)
            {
                ThisForm.Focus();
            }
            return FileName;
        }
    }
}
