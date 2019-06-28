namespace GolfHandicapMobile.Pages
{
    using System;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public interface ISignInPage
    {
        #region Events

        /// <summary>
        /// Occurs when [cancel button click].
        /// </summary>
        event EventHandler RegisterButtonClick;

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        event EventHandler SignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(SignInViewModel viewModel);

        /// <summary>
        /// Sets the registration failure message.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        void SetSignInFailureMessage(String failureMessage);

        #endregion
    }
}