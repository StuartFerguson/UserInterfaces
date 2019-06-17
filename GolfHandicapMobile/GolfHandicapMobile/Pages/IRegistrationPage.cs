namespace GolfHandicapMobile.Pages
{
    using System;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    public interface IRegistrationPage : IPage
    {
        #region Events

        /// <summary>
        /// Occurs when [register button click].
        /// </summary>
        event EventHandler RegisterButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(RegistrationViewModel viewModel);

        /// <summary>
        /// Sets the registration failure message.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        void SetRegistrationFailureMessage(String failureMessage);

        #endregion
    }
}