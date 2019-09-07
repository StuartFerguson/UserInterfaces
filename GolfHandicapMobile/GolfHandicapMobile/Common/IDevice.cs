﻿namespace GolfHandicapMobile.Common
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface IDevice
    {
        #region Methods

        /// <summary>
        /// Clears the instabug user data.
        /// </summary>
        void ClearInstabugUserData();

        /// <summary>
        /// Sets the instabug user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        void SetInstabugUserData(String userData);

        /// <summary>
        /// Sets the instabug user details.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="emailAddress">The email address.</param>
        void SetInstabugUserDetails(String userName,
                                    String emailAddress);

        #endregion
    }
}