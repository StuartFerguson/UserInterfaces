namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using GolfClubAdminWebSite.Services;
    using Pages;
    using ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Presenters.IMyTournamentsPresenter" />
    public class MyTournamentsPresenter : IMyTournamentsPresenter
    {
        private readonly MyTournamentsViewModel MyTournamentsViewModel;

        private readonly IMyTournamentsPage MyTournamentsPage;

        private readonly IClient ApiClient;

        public MyTournamentsPresenter(MyTournamentsViewModel myTournamentsViewModel,
                                      IMyTournamentsPage myTournamentsPage,
                                      IClient apiClient)
        {
            this.MyTournamentsViewModel = myTournamentsViewModel;
            this.MyTournamentsPage = myTournamentsPage;
            this.ApiClient = apiClient;
        }

        public async Task Start()
        {
            // Get the players membership details
            //await this.ApiClient.GetPlayerMemberships(App.AccessToken, this.MyMembershipsListViewModel, CancellationToken.None);

            //this.MyMembershipsPage.HomeButtonClick += this.MyMembershipsPage_HomeButtonClick;
            //this.MyMembershipsPage.RequestClubMembershipButtonClick += this.MyMembershipsPage_RequestClubMembershipButtonClick;

            this.MyTournamentsViewModel.TournamentScores = new ObservableCollection<TournamentScoreViewModel>();
            this.MyTournamentsViewModel.TournamentScores.Add(new TournamentScoreViewModel
                                                             {
                                                                 CSS = 72,
                                                                 CourseName = "Crieff Golf Club",
                                                                 GrossScore = 82,
                                                                 NetScore = 75,
                                                                 PlayingHandicap = 7,
                                                                 TournamentDate = new DateTime(2019, 7, 28),
                                                                 TournamentName = "Morton Burnett Open"
                                                             });
            this.MyTournamentsViewModel.SignedUpTournament = new SignedUpTournamentViewModel
                                                             {
                                                                 TournamentName = "Thornton Open"
                                                             };

            this.MyTournamentsPage.Init(this.MyTournamentsViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.MyTournamentsPage);
        }
    }
}