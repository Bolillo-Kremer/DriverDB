using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;

namespace DriverDB.UI
{
    public class Dialogs
    {
        /// <summary>
        /// Gets file or directory
        /// </summary>
        /// <param name="InitialDirectory">The directory to start in</param>
        /// <param name="IsFolderPicker">True if choosing a directory</param>
        /// <returns></returns>
        public static string OpenFile(Form ThisForm, string InitialDirectory = "", bool IsFolderPicker = false)
        {
            string FileName = "";
            CommonOpenFileDialog RootDir = new CommonOpenFileDialog();
            if (InitialDirectory.Length > 0)
            {
                RootDir.InitialDirectory = InitialDirectory;
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
