using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverDB.Core.Exceptions
{
    class DriverDoesntExist : Exception
    {
        #region Properties

        public string DriverName = string.Empty;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates new <see cref="DriverDoesntExist"/>
        /// </summary>
        /// <param name="aDriverName">The path to the driver that gave an error</param>
        public DriverDoesntExist(string aDriverName) : base($"Couldn't find {aDriverName} in the root direcotry")
        {
            this.DriverName = aDriverName;
        }

        /// <summary>
        /// Creates new <see cref="DriverDoesntExist"/>
        /// </summary>
        /// <param name="aDriverPath">The path to the driver that gave an error</param>
        /// <param name="Message">Error message</param>
        public DriverDoesntExist(string aDriverName, string Message) : base(Message)
        {
            this.DriverName = aDriverName;
        }

        #endregion Constructors
    }
}
