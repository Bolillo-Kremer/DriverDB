using System;

namespace DriverDB.Core.Exceptions
{
    public class NullDriverFile : Exception
    {
        #region Constructors

        /// <summary>
        /// Creates new <see cref="NullDriverFile"/>
        /// </summary>
        public NullDriverFile() : base("Cannot update Driver with null DriverImage")
        { }

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        /// <param name="Message"></param>
        public NullDriverFile(string Message) : base(Message)
        { }

        #endregion Constructors
    }
}
