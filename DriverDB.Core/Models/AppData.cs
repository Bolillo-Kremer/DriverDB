using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using DriverDB.Core.Exceptions;

namespace DriverDB.Core
{
    /// <summary>
    /// AppData model for manipulating app settings
    /// </summary>
    public static class AppData
    {
        #region Properties
        private static string DataDirectory { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\DriverDB.Core\Data";
        private static string SettingsDirectory { get; } = $@"{DataDirectory}\AppData.json";

        /// <summary>
        /// The root directory for DriverDB
        /// </summary>
        public static string Root
        {
            get
            {
                return GetSetting<string>("root");
            }
            set
            {
                SetSetting("root", value);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets JSON value from file
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="Path">Path to .json</param>
        /// <param name="Key">The value to get</param>
        /// <returns>A JSON value</returns>
        public static T GetJSONValue<T>(string Path, string Key)
        {
            return JObject.Parse(File.ReadAllText(Path))[Key].Value<T>();
        }

        private static T GetSetting<T>(string Key)
        {
            return GetJSONValue<T>(SettingsDirectory, Key);
        }

        /// <summary>
        /// Sets a value in a JSON string
        /// </summary>
        /// <param name="Path">Path to .json</param>
        /// <param name="Key">The value to change</param>
        /// <param name="Value">The new value</param>
        public static void SetJSONValue(string Path, string Key, string Value)
        {
            JObject JSON = JObject.Parse(File.ReadAllText(Path));
            JSON[Key] = Value;

            using (StreamWriter SettingsStream = File.CreateText(Path))
            {
                new JsonSerializer().Serialize(SettingsStream, JSON);
            }
        }

        private static void SetSetting(string Key, string Value)
        {
            SetJSONValue(SettingsDirectory, Key, Value);
        }

        /// <summary>
        /// Throws error if Root doesn't exist
        /// </summary>
        /// <returns>Root if exists</returns>
        public static string CheckRoot()
        {
            string R = Root;
            if (R == "")
            {
                throw new MissingRootDirectory();
            }
            return R;
        }

        #endregion Methods
    }
}
