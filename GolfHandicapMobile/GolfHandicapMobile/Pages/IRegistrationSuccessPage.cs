namespace GolfHandicapMobile.Pages
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    public interface IRegistrationSuccessPage : IPage
    {
        #region Events

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init();

        /// <summary>
        /// Sets the registration success message.
        /// </summary>
        /// <param name="successMessage">The success message.</param>
        void SetRegistrationSuccessMessage(String successMessage);

        #endregion
    }
}