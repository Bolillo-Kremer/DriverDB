using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using DriverDB.Core;

namespace DriverDB.Test
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void TestDriverImage()
        {
            DriverImage TestDriverImage = new DriverImage(Environment.CurrentDirectory + @"\TestDirectory\Driver Name\License.png", new DateTime(2021, 12, 12));
            Assert.AreEqual(TestDriverImage.ToString(), "{\"filepath\":\"C:\\Users\\dwuzjk2\\Desktop\\Projects\\DriverDB\\DriverDB.Test\\bin\\Debug\\TestDirectory\\Driver Name\\License.png\",\"expiration\":\"12/12/2021 12:00:00 AM\"}");
        }

        [TestMethod]
        public void SaveDriverTest()
        {
            string dir = @"C:\Users\dwuzjk2\Desktop\Projects\DriverDB\DriverDB.Test\bin\Debug\TestDirectory\Driver Name\License.png";
            Driver Zach = new Driver("Jeff Kremer", new DriverImage(dir, new DateTime(12, 12, 12)), new DriverImage(dir, new DateTime(12, 12, 12)), new DriverImage(dir, new DateTime(12, 12, 12)));
            Zach.Save();

            Assert.AreEqual(Zach.ToString(), Driver.GetExisting("Zach Kremer").ToString());
        }
        
        [TestMethod]
        public void GetAllDriversTest()
        {
            foreach(Driver aDriver in Driver.AllDrivers())
            {
                Assert.IsNotNull(aDriver.License);
                Assert.IsNotNull(aDriver.MVR);
                Assert.IsNotNull(aDriver.MedicalCard);
            }
        }
    }
}
