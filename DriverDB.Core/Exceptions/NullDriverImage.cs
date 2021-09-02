using System;

namespace DriverDB.Core.Exceptions
{
    public class NullDriverImage : Exception
    {
        #region Constructors

        /// <summary>
        /// Creates new <see cref="NullDriverImage"/>
        /// </summary>
        public NullDriverImage() : base("Cannot update Driver with null DriverImage")
        { }

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        /// <param name="Message"></param>
        public NullDriverImage(string Message) : base(Message)
        { }

        #endregion Constructors
    }
}
