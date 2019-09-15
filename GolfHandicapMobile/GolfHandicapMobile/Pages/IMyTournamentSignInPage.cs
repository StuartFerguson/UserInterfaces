namespace GolfHandicapMobile.Pages
{
    using System;
    using ViewModels;

    public interface IMyTournamentSignInPage
    {
        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyTournamentsSignInViewModel viewModel);

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        event EventHandler TournamentSignInButtonClick;
    }
}