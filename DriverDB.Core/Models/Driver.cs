using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
        private List<DriverImage> oldDriverImages = new List<DriverImage>();
        /// <summary>
        /// Old driver images
        /// </summary>
        public List<DriverImage> OldDriverImages => oldDriverImages;

        private string driverName { get; set; } = string.Empty;
        /// <summary>
        /// The Drivers name
        /// </summary>
        public string DriverName => driverName;

        private DriverImage licenseOld { get; set; } = null;
        private DriverImage license { get; set; } = null;
        /// <summary>
        /// The drivers license image and expiration date
        /// </summary>
        public DriverImage License => license;

        private DriverImage mvrOld { get; set; } = null;
        private DriverImage mvr { get; set; } = null;
        /// <summary>
        /// The drivers MVR image and expiration date
        /// </summary>
        public DriverImage MVR => mvr;

        private DriverImage medicalCardOld { get; set; } = null;
        private DriverImage medicalCard { get; set; } = null;
        /// <summary>
        /// The drivers medical card image and expiration date
        /// </summary>
        public DriverImage MedicalCard => medicalCard;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Driver"/>
        /// </summary>
        /// <param name="aDriverName">The name of the Driver</param>
        /// <param name="aLicense">The Drivers License</param>
        /// <param name="aMVR">The Drivers MVR</param>
        /// <param name="aMedicalCard">The Drivers Medical Card</param>
        public Driver(string aDriverName, DriverImage aLicense, DriverImage aMVR, DriverImage aMedicalCard)
        {
            this.driverName = aDriverName;
            this.license = aLicense;
            this.license.DriverImageType = ImageType.License;
            this.mvr = aMVR;
            this.mvr.DriverImageType = ImageType.MVR;
            this.medicalCard = aMedicalCard;
            this.medicalCard.DriverImageType = ImageType.MedicalCard;
        }

        private Driver(string aDriverName)
        {
            string Root = AppData.CheckRoot();
            try
            {
                if (Directory.Exists(Root + $@"\{aDriverName}"))
                {
                    JObject DriverData = JObject.Parse(File.ReadAllText(Root + $@"\{aDriverName}\data\DriverData.json"));

                    this.driverName = aDriverName;
                    this.license = new DriverImage(Root + $@"\{aDriverName}\License{DriverData["LicenseExtension"]}", DriverData["LicenseExpiration"].Value<DateTime>());
                    this.mvr = new DriverImage(Root + $@"\{aDriverName}\MVR{DriverData["MVRExtension"]}", DriverData["MVRExpiration"].Value<DateTime>());
                    this.medicalCard = new DriverImage(Root + $@"\{aDriverName}\MedicalCard{DriverData["MedicalCardExtension"]}", DriverData["MedicalCardExpiration"].Value<DateTime>());

                    foreach (FileInfo aFile in Directory.CreateDirectory(Root + $@"\{aDriverName}\Old").GetFiles())
                    {
                        string[] Parts = aFile.Name.Split('-');
                        string DateString = $"{Parts[1]}/{Parts[2]}/{Parts[3].Split('.')[0]}";
                        DateTime OldDate = DateTime.Parse(DateString);
                        oldDriverImages.Add(new DriverImage(aFile.FullName, OldDate, (ImageType)Enum.Parse(typeof(ImageType), Parts[0])));
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
        public static Driver GetExisting(string aDriverName)
        {
            return new Driver(aDriverName);
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
        /// Gets all <see cref="Driver"/>'s with any expired <see cref="DriverImage"/>'s
        /// </summary>
        /// <returns>An array of expired <see cref="Driver"/>'s</returns>
        public static Driver[] ExpiredDrivers()
        {
            List<Driver> ExpiredDrivers = new List<Driver>();

            foreach (Driver aDriver in Driver.AllDrivers())
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
        public static Driver[] ExpiresWithin(int Days)
        {
            List<Driver> AlmostExpired = new List<Driver>();

            foreach (Driver aDriver in Driver.AllDrivers())
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
        public void UpdateLicense(DriverImage aLicense)
        {         
            if (aLicense != null)
            {
                this.licenseOld = this.license;
                this.license = aLicense;
                this.license.DriverImageType = ImageType.License;
            }
            else
            {
                throw new NullDriverImage();
            }
        }

        /// <summary>
        /// Updates Drivers License
        /// </summary>
        /// <param name="ImagePath">Path to License image</param>
        /// <param name="aExpirationDate">License expiration date</param>
        public void UpdateLicense(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateLicense(new DriverImage(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Updates Drivers MVR
        /// </summary>
        /// <param name="aMVR">Drivers MVR</param>
        public void UpdateMVR(DriverImage aMVR)
        {         
            if (aMVR != null)
            {
                this.mvrOld = this.mvr;
                this.mvr = aMVR;
                this.mvr.DriverImageType = ImageType.MVR;
            }          
            else
            {
                throw new NullDriverImage();
            }
        }

        /// <summary>
        /// Updates Drivers MVR
        /// </summary>
        /// <param name="ImagePath">Path to MVR image</param>
        /// <param name="aExpirationDate">MVR Expiration date</param>
        public void UpdateMVR(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateMVR(new DriverImage(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Updates Drivers Medical Card
        /// </summary>
        /// <param name="aMedicalCard">Drivers Medical Card</param>
        public void UpdateMedicalCard(DriverImage aMedicalCard)
        {
            if (aMedicalCard != null)
            {
                this.medicalCardOld = this.medicalCard;
                this.medicalCard = aMedicalCard;
                this.medicalCard.DriverImageType = ImageType.MedicalCard;
            }
            else
            {
                throw new NullDriverImage();
            }
            
        }

        /// <summary>
        /// Updates Drivers Medical Card
        /// </summary>
        /// <param name="ImagePath">Path to Medical Card image</param>
        /// <param name="aExpirationDate">Medical Card Expiration Date</param>
        public void UpdateMedicalCard(string ImagePath, DateTime aExpirationDate)
        {
            this.UpdateMedicalCard(new DriverImage(ImagePath, aExpirationDate));
        }

        /// <summary>
        /// Checks if any <see cref="DriverImage"/>'s are expired
        /// </summary>
        /// <returns>True if any <see cref="DriverImage"/>'s are expired</returns>
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
            Directory.CreateDirectory(DriverDirectory + @"\data").Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            Directory.CreateDirectory(DriverDirectory + @"\Old");

            using (StreamWriter SettingsStream = File.CreateText(DriverDirectory + @"\data\DriverData.json"))
            {
                new JsonSerializer().Serialize(SettingsStream, JObject.FromObject(this.ToObject()));
            }

            if (this.licenseOld != null)
            {
                this.licenseOld.SaveImage(DriverDirectory + $@"\Old\License-{this.licenseOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.licenseOld.FileExtension}");
                this.oldDriverImages.Add(this.licenseOld);
            }

            if (this.mvrOld != null)
            {
                this.mvrOld.SaveImage(DriverDirectory + $@"\Old\MVR-{this.mvrOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.mvrOld.FileExtension}");
                this.oldDriverImages.Add(this.mvrOld);
            }

            if (this.medicalCardOld != null)
            {
                this.medicalCardOld.SaveImage(DriverDirectory + $@"\Old\MedicalCard-{this.medicalCardOld.ExpirationDate.ToString("MM'-'dd'-'yyyy")}{this.medicalCardOld.FileExtension}");
                this.oldDriverImages.Add(this.medicalCardOld);
            }

            this.license.SaveImage(DriverDirectory + $@"\License{this.license.FileExtension}");
            this.mvr.SaveImage(DriverDirectory + $@"\MVR{this.mvr.FileExtension}");
            this.medicalCard.SaveImage(DriverDirectory + $@"\MedicalCard{this.medicalCard.FileExtension}");
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
