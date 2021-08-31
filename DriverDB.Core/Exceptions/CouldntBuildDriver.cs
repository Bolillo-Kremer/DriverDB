using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverDB.Core.Exceptions
{
    /// <summary>
    /// <see cref="Exception"/> for invalid driver directories
    /// </summary>
    public class CouldntBuildDriver : Exception
    {

        #region Properties

        public string DriverPath = string.Empty;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates new <see cref="CouldntBuildDriver"/>
        /// </summary>
        /// <param name="aDriverPath">The path to the driver that gave an error</param>
        public CouldntBuildDriver(string aDriverPath, Exception InnerException) : base("Couldn't build Driver from " + aDriverPath, InnerException)
        {
            this.DriverPath = System.IO.Path.GetFullPath(aDriverPath);
        }

        /// <summary>
        /// Creates new <see cref="CouldntBuildDriver"/>
        /// </summary>
        /// <param name="aDriverPath">The path to the driver that gave an error</param>
        /// <param name="Message">Error message</param>
        public CouldntBuildDriver(string aDriverPath, string Message, Exception InnerException) : base(Message, InnerException)
        {
            this.DriverPath = System.IO.Path.GetFullPath(aDriverPath);
        }

        #endregion Constructors
    }
}
