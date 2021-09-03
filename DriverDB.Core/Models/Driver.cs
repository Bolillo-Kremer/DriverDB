using System;
using System.IO;
using System.Collections.Generic;
using DriverDB.Core.Exceptions;

namespace DriverDB.Core
{
    /// <summary>
    /// Driver data
    /// </summary>
    [Serializable]
    public class Driver
    {
        #region Properties
        private List<DriverFile> oldDriverImages = new List<DriverFile>();
        /// <summary>
        /// Old driver images
        /// </summary>
        public List<DriverFile> OldDriverImages => oldDriverImages;

        private string driverName { get; set; } = string.Empty;
        /// <summary>
        /// The Drivers name
        /// </summary>
        public string DriverName => driverName;

        private DriverFile licenseOld { get; set; } = null;
        private DriverFile license { get; set; } = null;
        /// <summary>
        /// The drivers license image and expiration date
        /// </summary>
        public DriverFile License => license;

        private DriverFile mvrOld { get; set; } = null;
        private DriverFile mvr { get; set; } = null;
        /// <summary>
        /// The drivers MVR image and expiration date
        /// </summary>
        public DriverFile MVR => mvr;

        private DriverFile medicalCardOld { get; set; } = null;
        private DriverFile medicalCard { get; set; } = null;
        /// <summary>
        /// The drivers medical card image and expiration date
        /// </summary>
        public DriverFile MedicalCard => medicalCard;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Driver"/>
        /// </summary>
        /// <param name="aDriverName">The name of the Driver</param>
        /// <param name="aLicense">The Drivers License</param>
        /// <param name="aMVR">The Drivers MVR</param>
        /// <param name="aMedicalCard">The Drivers Medical Card</param>
        public Driver(string aDriverName, DriverFile aLicense, DriverFile aMVR, DriverFile aMedicalCard)
        {
            this.driverName = aDriverName;
            this.license = aLicense;
            this.license.FileType = DriverFileType.License;
            this.mvr = aMVR;
            this.mvr.FileType = DriverFileType.MVR;
            this.medicalCard = aMedicalCard;
            this.medicalCard.FileType = DriverFileType.MedicalCard;
        }

        private Driver(string aDriverName)
        {
            string Root = AppData.CheckRoot();
            try
            {
                if (Directory.Exists(Root + $@"\{aDriverName}") && aDriverName != "")
                {
                    this.driverName = aDriverName;
                    FileInfo[] DriverFiles = new DirectoryInfo(Root + $@"\{aDriverName}").GetFiles();

                    if (DriverFiles.Length == 3)
                    {
                        foreach (FileInfo aDriverFile in DriverFiles)
                        {
                            string[] Parts = aDriverFile.Name.Split('-');
                            string DateString = $"{Parts[1]}/{Parts[2]}/{Parts[3].Split('.')[0]}";
                            DateTime ExpDate = DateTime.Parse(DateString);

                            switch (Parts[0])
                            {
                                case "License":
                                    this.license = new DriverFile(aDriverFile.FullName, ExpDate, DriverFileType.License);
                                    break;
                                case "MVR":
                                    this.mvr = new DriverFile(aDriverFile.FullName, ExpDate, DriverFileType.MVR);
                                    break;
                                case "MedicalCard":
                                    this.medicalCard = new DriverFile(aDriverFile.FullName, ExpDate, DriverFileType.MedicalCard);
                                    break;
                            }
                        }

                        foreach (FileInfo OldFile in Directory.CreateDirectory(Root + $@"\{aDriverName}\Old").GetFiles())
                        {
                            string[] Parts = OldFile.Name.Split('-');
                            string DateString = $"{Parts[1]}/{Parts[2]}/{Parts[3].Split('.')[0]}";
                            DateTime OldDate = DateTime.Parse(DateString);
                            oldDriverImages.Add(new DriverFile(OldFile.FullName, OldDate, (DriverFileType)Enum.Parse(typeof(DriverFileType), Parts[0])));
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid driver folder");
                    }

                }
                else
                {
                    throw new DriverDoesntExist(aDriverName);
                }

            }
            catch (Exception e)
            {
                throw new CouldntBuildDriver(aDriverName, e);
            } 
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets an existing <see cref="Driver"/> from the root directory
        /// </summary>
        /// <param name="aDriverName"></param>
        /// <returns></returns>
        public static Driver GetExisting(string aDriverName, Driver[] Drivers)
        {
            Driver Selected = null;
            foreach (Driver aDriver in Drivers)
            {
                if (aDriver.DriverName == aDriverName)
                {
                    Selected = aDriver;
                    break;
                }
            }
            return Selected;
        }

        public static Driver GetExisting(string aDriverName, bool ThrowError = false)
        {
            Driver Selected = null;
            try
            {
                Selected = new Driver(aDriverName);
            }
            catch (Exception e)
            {
                if (ThrowError)
                {
                    throw e;
                }
            }
            return Selected;
        }

        /// <summary>
        /// Gets all existing <see cref="Driver"/>'s from the root directory
        /// </summary>
        /// <returns>An array of all <see cref="Driver"/>'s</returns>
        public static Driver[] AllDrivers()
        {
            List<Driver> DriverData = new List<Driver>();
            string Root = AppData.CheckRoot();

            foreach (string aDriver in Directory.GetDirectories(Root))
            {
                try
                {
                    DriverData.Add(Driver.GetExisting(aDriver.Replace(Root + "\\", "")));
                }
                catch
                { }
            }

            return DriverData.ToArray();
        }

        /// <summary>
        /// Gets all <see cref="Driver"/>'s with any expired <see cref="DriverFile"/>'s
        /// </summary>
        /// <returns>An array of expired <see cref="Driver"/>'s</returns>
        public static Driver[] ExpiredDrivers(Driver[] Drivers = null)
        {
            List<Driver> ExpiredDrivers = new List<Driver>();

            foreach (Driver aDriver in Drivers == null ? Driver.AllDrivers() : Drivers)
            {
                if (aDriver.IsExpired())
                {
                    ExpiredDrivers.Add(aDriver);
                }
            }

            return ExpiredDrivers.ToArray();
        }

        /// <summary>
        /// Gets all <see cref="Driver"/>'s that will expire within a given amount of days
        /// </summary>
        /// <param name="Days">The number of days ahead to check for</param>
        /// <returns>An array of <see cref="Driver"/>'s</returns>
        public static Driver[] ExpiresWithin(int Days, Driver[] Drivers = null)
        {
            List<Driver> AlmostExpired = new List<Driver>();

            foreach (Driver aDriver in Drivers == null ? Driver.AllDrivers() : Drivers)
            {
                if (!aDriver.IsExpired())
                {
                    if (aDriver.DaysUntilExpired() <= Days)
                    {
                        AlmostExpired.Add(aDriver);
                    }
                }
            }

            return AlmostExpired.ToArray();
        }

        /// <summary>
        /// Updates Drivers License
        /// </summary>
        /// <param name="aLicense">The Drivers License</param>
        public void UpdateLicense(DriverFile aLicense)
        {         
            if (aLicense != null && aLicense.ToString() != this.license.ToString())
            {
                this.licenseOld = this.license;
                this.license = aLicense;
                this.license.FileType = DriverFileType.License;
            }
        }

        /// <summary>
        /// Updates Drivers License
        /// </summary>
        /// <param name="ImagePath">Path to License image</param>
        /// <param name="aExpirationDate">License expiration date</param>
        public void UpdateLicense(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateLicense(new DriverFile(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Updates Drivers MVR
        /// </summary>
        /// <param name="aMVR">Drivers MVR</param>
        public void UpdateMVR(DriverFile aMVR)
        {         
            if (aMVR != null && aMVR.ToString() != this.mvr.ToString())
            {
                this.mvrOld = this.mvr;
                this.mvr = aMVR;
                this.mvr.FileType = DriverFileType.MVR;
            }
        }

        /// <summary>
        /// Updates Drivers MVR
        /// </summary>
        /// <param name="ImagePath">Path to MVR image</param>
        /// <param name="aExpirationDate">MVR Expiration date</param>
        public void UpdateMVR(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateMVR(new DriverFile(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Updates Drivers Medical Card
        /// </summary>
        /// <param name="aMedicalCard">Drivers Medical Card</param>
        public void UpdateMedicalCard(DriverFile aMedicalCard)
        {
            if (aMedicalCard != null && aMedicalCard.ToString() != this.MedicalCard.ToString())
            {
                this.medicalCardOld = this.medicalCard;
                this.medicalCard = aMedicalCard;
                this.medicalCard.FileType = DriverFileType.MedicalCard;
            }       
        }

        /// <summary>
        /// Updates Drivers Medical Card
        /// </summary>
        /// <param name="ImagePath">Path to Medical Card image</param>
        /// <param name="aExpirationDate">Medical Card Expiration Date</param>
        public void UpdateMedicalCard(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateMedicalCard(new DriverFile(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Checks if any <see cref="DriverFile"/>'s are expired
        /// </summary>
        /// <returns>True if any <see cref="DriverFile"/>'s are expired</returns>
        public bool IsExpired()
        {
            return (this.license.IsExpired() || this.mvr.IsExpired() || this.medicalCard.IsExpired());
        }

        /// <summary>
        /// Gets the number of days until any of the driver properties expire
        /// </summary>
        /// <returns>The number of days until <see cref="Driver"/> expiration</returns>
        public int DaysUntilExpired()
        {     
            if (!this.IsExpired())
            {
                int ExpiredIn = this.license.DaysUntilExpired();
                ExpiredIn = (this.mvr.DaysUntilExpired() < ExpiredIn) ? this.mvr.DaysUntilExpired() : ExpiredIn;
                ExpiredIn = (this.medicalCard.DaysUntilExpired() < ExpiredIn) ? this.medicalCard.DaysUntilExpired() : ExpiredIn;
                return ExpiredIn;
            }
            return 0;
        }

        /// <summary>
        /// Saves this <see cref="Driver"/> to the root directory
        /// </summary>
        public void Save()
        {
            string Root = AppData.CheckRoot();

            string DriverDirectory = Directory.CreateDirectory(Root + $@"\{this.DriverName}").FullName;
            Directory.CreateDirectory(DriverDirectory + @"\Old");

            this.license.SaveToCurrent(DriverDirectory + $@"\License-{this.license.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.license.FileExtension}");
            this.mvr.SaveToCurrent(DriverDirectory + $@"\MVR-{this.mvr.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.mvr.FileExtension}");
            this.medicalCard.SaveToCurrent(DriverDirectory + $@"\MedicalCard-{this.medicalCard.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.medicalCard.FileExtension}");

            if (this.licenseOld != null)
            {
                this.licenseOld.SaveToOld(DriverDirectory + $@"\Old\License-{this.licenseOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.licenseOld.FileExtension}");
                this.oldDriverImages.Add(this.licenseOld);
            }

            if (this.mvrOld != null)
            {
                this.mvrOld.SaveToOld(DriverDirectory + $@"\Old\MVR-{this.mvrOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.mvrOld.FileExtension}");
                this.oldDriverImages.Add(this.mvrOld);
            }

            if (this.medicalCardOld != null)
            {
                this.medicalCardOld.SaveToOld(DriverDirectory + $@"\Old\MedicalCard-{this.medicalCardOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.medicalCardOld.FileExtension}");
                this.oldDriverImages.Add(this.medicalCardOld);
            }
        }

        /// <summary>
        /// Deletes this <see cref="Driver"/> from the database
        /// </summary>
        public void Delete()
        {
            string Root = AppData.CheckRoot();
            Directory.Delete(Root + $@"\{this.DriverName}");
        }

        /// <summary>
        /// Converts this <see cref="Driver"/> to an object
        /// </summary>
        /// <returns>An object with property data</returns>
        public object ToObject()
        {
            return new
            {
                LicenseExpiration = this.license.ExpirationDate.ToString(),
                LicenseExtension = this.license.FileExtension,
                MVRExpiration = this.mvr.ExpirationDate.ToString(),
                MVRExtension = this.mvr.FileExtension,
                MedicalCardExpiration = this.medicalCard.ExpirationDate.ToString(),
                MedicalCardExtension = this.medicalCard.FileExtension
            };
        }

        #endregion Methods

        #region Overrides

        override
        public string ToString()
        {
            return this.ToObject().ToString();
        }

        #endregion Overrides
    }
}
