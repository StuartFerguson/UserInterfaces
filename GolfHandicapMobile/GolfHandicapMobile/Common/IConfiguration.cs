namespace GolfHandicapMobile.Common
{
    using System;

    public interface IConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets or sets the management API.
        /// </summary>
        /// <value>
        /// The management API.
        /// </value>
        String ManagementAPI { get; set; }

        /// <summary>
        /// Gets or sets the security service API.
        /// </summary>
        /// <value>
        /// The security service API.
        /// </value>
        String SecurityServiceAPI { get; set; }

        #endregion
    }
}