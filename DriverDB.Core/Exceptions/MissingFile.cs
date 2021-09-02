using System;

namespace DriverDB.Core.Exceptions
{
    public class MissingFile : Exception
    {
        #region Properties

        private string fileDirectory { get; set; } = string.Empty;
        public string FileDirectory => fileDirectory;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        public MissingFile(string aFileDirectory) : base($"{aFileDirectory} does not exist")
        {
            this.fileDirectory = aFileDirectory;
        }

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        /// <param name="aFileDirectory">The missing files directory</param>
        /// <param name="Message"></param>
        public MissingFile(string aFileDirectory, string Message) : base(Message)
        {
            this.fileDirectory = aFileDirectory;
        }

        #endregion Constructors
    }
}
