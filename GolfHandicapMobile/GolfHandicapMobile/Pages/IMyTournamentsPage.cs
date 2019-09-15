using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Pages
{
    using ViewModels;

    public interface IMyTournamentsPage
    {
        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyTournamentsViewModel viewModel);

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        /// <summary>
        /// Occurs when [tournament sign up button click].
        /// </summary>
        event EventHandler TournamentSignInButtonClick;

        /// <summary>
        /// Occurs when [enter tournament score button click].
        /// </summary>
        event EventHandler EnterTournamentScoreButtonClick;
    }
}
