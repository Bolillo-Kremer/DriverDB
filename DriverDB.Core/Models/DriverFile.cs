using System;
using System.Drawing;
using System.IO;
using DriverDB.Core.Exceptions;

namespace DriverDB.Core
{
    [Serializable]
    ///<summary>
    ///Stores data about driver images
    ///</summary>
    public class DriverFile
    {
        #region Properties

        /// <summary>
        /// The Type of <see cref="DriverFile"/>
        /// </summary>
        public DriverFileType FileType;

        private string filePath;
        /// <summary>
        /// The current path to the Image file
        /// </summary>
        public string FilePath => filePath;

        private DateTime expirationDate;
        /// <summary>
        /// The Expiration date of the image
        /// </summary>
        public DateTime ExpirationDate => expirationDate;

        private string fileExtension;
        /// <summary>
        /// The file extension of the image
        /// </summary>
        public string FileExtension => fileExtension;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="DriverFile"/>
        /// </summary>
        /// <param name="aFilePath">The path to the image file</param>
        /// <param name="aExpirationDate">The expiration date</param>
        public DriverFile(string aFilePath, DateTime aExpirationDate)
        {
            if (File.Exists(aFilePath))
            {
                this.filePath = Path.GetFullPath(aFilePath);
                this.fileExtension = Path.GetExtension(aFilePath);
            }          
            else
            {
                throw new MissingFile(aFilePath);
            }
            this.expirationDate = aExpirationDate;
        }

        /// <summary>
        /// Creates a new <see cref="DriverFile"/>
        /// </summary>
        /// <param name="aFilePath">The path to the image file</param>
        /// <param name="aExpirationDate">The expiration date</param>
        /// <param name="aFileType">The Type of <see cref="DriverFile"/></param>
        public DriverFile(string aFilePath, DateTime aExpirationDate, DriverFileType aFileType)
        {
            if (File.Exists(aFilePath))
            {
                this.filePath = Path.GetFullPath(aFilePath);
                this.fileExtension = Path.GetExtension(aFilePath);
            }
            else
            {
                throw new MissingFile(aFilePath);
            }
            this.expirationDate = aExpirationDate;
            this.FileType = aFileType;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks if this <see cref="DriverFile"/> is expired
        /// </summary>
        /// <returns>True if expired</returns>
        public bool IsExpired()
        {
            return this.expirationDate < DateTime.Now;
        }

        /// <summary>
        /// Checks the number of days until this <see cref="DriverFile"/> expires
        /// </summary>
        /// <returns>the number of days until this <see cref="DriverFile"/> expires</returns>
        public int DaysUntilExpired()
        {
            return (this.expirationDate - DateTime.Now).Days;
        }

        /// <summary>
        /// Saves the image to a given path
        /// </summary>
        /// <param name="SaveDir">The directory to save the image to</param>
        public void SaveToCurrent(string SaveDir)
        {
            if (!Path.GetFullPath(SaveDir).Equals(this.filePath))
            {
                FileStream OldFile = File.OpenRead(this.filePath);
                FileStream NewFile = File.Create(SaveDir);
                OldFile.CopyTo(NewFile);
                OldFile.Dispose();
                NewFile.Dispose();
                this.filePath = SaveDir;
            }
        }

        public void SaveToOld(string SaveDir)
        {
            if (!Path.GetFullPath(SaveDir).Equals(this.filePath))
            {
                FileStream OldFile = File.OpenRead(this.filePath);
                FileStream NewFile = File.Create(SaveDir);
                OldFile.CopyTo(NewFile);
                OldFile.Dispose();
                NewFile.Dispose();
                File.Delete(this.filePath);
                this.filePath = SaveDir;
            }
        }

        #endregion Methods

        #region Overrides

        override
        public string ToString()
        {
            return "{" + $"\"filepath\":\"{this.filePath}\",\"expiration\":\"{this.expirationDate}\"" + "}";
        }

        #endregion Overrides
    }
}
