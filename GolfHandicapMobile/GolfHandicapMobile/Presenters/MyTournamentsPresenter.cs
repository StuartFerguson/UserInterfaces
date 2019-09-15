namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfClubAdminWebSite.Services;
    using Pages;
    using Plugin.Toast;
    using ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Presenters.IMyTournamentsPresenter" />
    public class MyTournamentsPresenter : IMyTournamentsPresenter
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        /// <summary>
        /// The sign up for tournament page
        /// </summary>
        private readonly IMyTournamentSignInPage MyTournamentSignInPage;

        /// <summary>
        /// My tournaments page
        /// </summary>
        private readonly IMyTournamentsPage MyTournamentsPage;

        /// <summary>
        /// My tournaments sign up for tournament view model
        /// </summary>
        private readonly MyTournamentsSignInViewModel MyTournamentsSignInViewModel;

        /// <summary>
        /// My tournaments view model
        /// </summary>
        private readonly MyTournamentsViewModel MyTournamentsViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTournamentsPresenter" /> class.
        /// </summary>
        /// <param name="myTournamentsPage">My tournaments page.</param>
        /// <param name="myTournamentSignInPage">My tournament sign in page.</param>
        /// <param name="myTournamentsViewModel">My tournaments view model.</param>
        /// <param name="myTournamentsSignInViewModel">My tournaments sign in view model.</param>
        /// <param name="apiClient">The API client.</param>
        public MyTournamentsPresenter(IMyTournamentsPage myTournamentsPage,
                                      IMyTournamentSignInPage myTournamentSignInPage,
                                      MyTournamentsViewModel myTournamentsViewModel,
                                      MyTournamentsSignInViewModel myTournamentsSignInViewModel,
                                      IClient apiClient)
        {
            this.MyTournamentsViewModel = myTournamentsViewModel;
            this.MyTournamentsSignInViewModel = myTournamentsSignInViewModel;
            this.MyTournamentsPage = myTournamentsPage;
            this.MyTournamentSignInPage = myTournamentSignInPage;
            this.ApiClient = apiClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public async Task Start()
        {
            await this.ApiClient.GetTopPlayerScores(App.AccessToken, App.PlayerId, 10, this.MyTournamentsViewModel, CancellationToken.None);
            await this.ApiClient.GetSignedUpTournament(App.AccessToken, App.PlayerId, this.MyTournamentsViewModel, CancellationToken.None);

            this.MyTournamentsPage.HomeButtonClick += this.MyTournamentsPage_HomeButtonClick;
            this.MyTournamentsPage.TournamentSignInButtonClick += this.MyTournamentsPage_TournamentSignInButtonClick;
            this.MyTournamentsPage.EnterTournamentScoreButtonClick += this.MyTournamentsPage_EnterTournamentScoreButtonClick;

            this.MyTournamentsPage.Init(this.MyTournamentsViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.MyTournamentsPage);
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the MyTournamentSignInPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void MyTournamentSignInPage_HomeButtonClick(Object sender,
                                                                  EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the TournamentSignInButtonClick event of the MyTournamentSignInPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void MyTournamentSignInPage_TournamentSignInButtonClick(Object sender,
                                                                        EventArgs e)
        {
            await this.ApiClient.TournamentSignIn(App.AccessToken, App.PlayerId, this.MyTournamentsSignInViewModel.SelectedTournament.TournamentId, CancellationToken.None);

            CrossToastPopUp.Current.ShowToastSuccess($"Signed In for Tournament {this.MyTournamentsSignInViewModel.SelectedTournament.TournamentName}");

            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the EnterTournamentScoreButtonClick event of the MyTournamentsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MyTournamentsPage_EnterTournamentScoreButtonClick(Object sender,
                                                                       EventArgs e)
        {
            // TODO:
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the MyTournamentsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void MyTournamentsPage_HomeButtonClick(Object sender,
                                                             EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the TournamentSignInButtonClick event of the MyTournamentsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void MyTournamentsPage_TournamentSignInButtonClick(Object sender,
                                                                         EventArgs e)
        {
            // Get the available tournaments
            await this.ApiClient.GetNextAvailableTournamentsForSignIn(App.AccessToken, App.PlayerId, this.MyTournamentsSignInViewModel, CancellationToken.None);

            this.MyTournamentSignInPage.HomeButtonClick += this.MyTournamentSignInPage_HomeButtonClick;
            this.MyTournamentSignInPage.TournamentSignInButtonClick += this.MyTournamentSignInPage_TournamentSignInButtonClick;

            this.MyTournamentSignInPage.Init(this.MyTournamentsSignInViewModel);
            await Shell.Current.Navigation.PushAsync((Page)this.MyTournamentSignInPage);
        }

        #endregion
    }
}