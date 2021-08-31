using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace DriverDB.Core
{
    [Serializable]
    ///<summary>
    ///Stores data about driver images
    ///</summary>
    public class DriverImage
    {
        #region Properties

        private string filePath;
        public string FilePath => filePath;

        private DateTime expirationDate;
        public DateTime ExpirationDate => expirationDate;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="DriverImage"/>
        /// </summary>
        /// <param name="aFilePath">The path to the image file</param>
        /// <param name="aExpirationDate">The expiration date</param>
        public DriverImage(string aFilePath, DateTime aExpirationDate)
        {
            if (File.Exists(aFilePath))
            {
                this.filePath = Path.GetFullPath(aFilePath);
            }          
            this.expirationDate = aExpirationDate;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Updates the expiration date of the <see cref="DriverImage"/>
        /// </summary>
        /// <param name="aExpirationDate">New expiration date</param>
        public void UpdateExpirationDate(DateTime aExpirationDate)
        {
            this.expirationDate = aExpirationDate;
        }

        /// <summary>
        /// Checks if this <see cref="DriverImage"/> is expired
        /// </summary>
        /// <returns>True if expired</returns>
        public bool IsExpired()
        {
            return this.expirationDate < DateTime.Now;
        }

        /// <summary>
        /// Checks the number of days until this <see cref="DriverImage"/> expires
        /// </summary>
        /// <returns>the number of days until this <see cref="DriverImage"/> expires</returns>
        public int DaysUntilExpired()
        {
            return (this.expirationDate - DateTime.Now).Days;
        }

        /// <summary>
        /// Saves the image to a given path
        /// </summary>
        /// <param name="SaveDir">The directory to save the image to</param>
        public void SaveImage(string SaveDir)
        {
            if (!Path.GetFullPath(SaveDir).Equals(this.filePath))
            {
                if (File.Exists(SaveDir))
                {
                    File.Delete(SaveDir);
                }
                Image NewImage = Image.FromFile(this.filePath);
                NewImage.Save(SaveDir);
                NewImage.Dispose();
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
