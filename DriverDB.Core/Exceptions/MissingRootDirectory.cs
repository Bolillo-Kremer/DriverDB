using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverDB.Core.Exceptions
{
    /// <summary>
    /// <see cref="Exception"/> for missing root directory
    /// </summary>
    public class MissingRootDirectory: Exception
    {
        #region Constructors

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        public MissingRootDirectory() : base("DriverDB is missing a root directory")
        { }

        /// <summary>
        /// Creates new <see cref="MissingRootDirectory"/>
        /// </summary>
        /// <param name="Message"></param>
        public MissingRootDirectory(string Message): base (Message)
        { }

        #endregion Constructors
    }
}
