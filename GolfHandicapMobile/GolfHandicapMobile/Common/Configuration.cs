namespace GolfHandicapMobile.Common
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Common.IConfiguration" />
    public class Configuration : IConfiguration
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        [JsonConstructor]
        public Configuration()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the management API.
        /// </summary>
        /// <value>
        /// The management API.
        /// </value>
        public String ManagementAPI { get; set; }

        /// <summary>
        /// Gets or sets the security service API.
        /// </summary>
        /// <value>
        /// The security service API.
        /// </value>
        public String SecurityServiceAPI { get; set; }

        #endregion
    }
}