namespace GolfHandicapMobile.Pages
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    public interface IHomePage : IPage
    {
        #region Events

        /// <summary>
        /// Occurs when [register button click].
        /// </summary>
        event EventHandler RegisterButtonClick;

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        event EventHandler SignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init();

        #endregion
    }
}