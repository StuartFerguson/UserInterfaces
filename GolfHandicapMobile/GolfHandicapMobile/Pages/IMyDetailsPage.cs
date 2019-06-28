namespace GolfHandicapMobile.Pages
{
    using System;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public interface IMyDetailsPage
    {
        #region Events

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyDetailsViewModel viewModel);

        #endregion
    }
}