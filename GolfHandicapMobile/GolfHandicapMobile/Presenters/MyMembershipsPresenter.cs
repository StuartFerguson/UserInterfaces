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
    /// <seealso cref="GolfHandicapMobile.Presenters.IMyMembershipsPresenter" />
    public class MyMembershipsPresenter : IMyMembershipsPresenter
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        /// <summary>
        /// The membership request club list page
        /// </summary>
        private readonly IMyMembershipRequestClubListPage MembershipRequestClubListPage;

        /// <summary>
        /// My membership request club ListView model
        /// </summary>
        private readonly MyMembershipRequestClubListViewModel MyMembershipRequestClubListViewModel;

        /// <summary>
        /// My memberships ListView model
        /// </summary>
        private readonly MyMembershipsListViewModel MyMembershipsListViewModel;

        /// <summary>
        /// My memberships page
        /// </summary>
        private readonly IMyMembershipsPage MyMembershipsPage;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMembershipsPresenter"/> class.
        /// </summary>
        /// <param name="myMembershipsPage">My memberships page.</param>
        /// <param name="membershipRequestClubListPage">The membership request club list page.</param>
        /// <param name="myMembershipsListViewModel">My memberships ListView model.</param>
        /// <param name="myMembershipRequestClubListViewModel">My membership request club ListView model.</param>
        /// <param name="apiClient">The API client.</param>
        public MyMembershipsPresenter(IMyMembershipsPage myMembershipsPage,
                                      IMyMembershipRequestClubListPage membershipRequestClubListPage,
                                      MyMembershipsListViewModel myMembershipsListViewModel,
                                      MyMembershipRequestClubListViewModel myMembershipRequestClubListViewModel,
                                      IClient apiClient)
        {
            this.MyMembershipsPage = myMembershipsPage;
            this.MembershipRequestClubListPage = membershipRequestClubListPage;
            this.MyMembershipsListViewModel = myMembershipsListViewModel;
            this.MyMembershipRequestClubListViewModel = myMembershipRequestClubListViewModel;
            this.ApiClient = apiClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            // Get the players membership details
            await this.ApiClient.GetPlayerMemberships(App.AccessToken, this.MyMembershipsListViewModel, CancellationToken.None);

            this.MyMembershipsPage.HomeButtonClick += this.MyMembershipsPage_HomeButtonClick;
            this.MyMembershipsPage.RequestClubMembershipButtonClick += this.MyMembershipsPage_RequestClubMembershipButtonClick;
            this.MyMembershipsPage.Init(this.MyMembershipsListViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.MyMembershipsPage);
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the MembershipRequestClubListPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MembershipRequestClubListPage_HomeButtonClick(Object sender,
                                                                         EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the RequestMembershipButtonClick event of the MembershipRequestClubListPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MembershipRequestClubListPage_RequestMembershipButtonClick(Object sender,
                                                                                      EventArgs e)
        {
            await this.ApiClient.RequestClubMembership(App.AccessToken, this.MyMembershipRequestClubListViewModel.SelectedGolfClub.GolfClubId, CancellationToken.None);

            CrossToastPopUp.Current.ShowToastSuccess($"Membership Requested for Golf Club {this.MyMembershipRequestClubListViewModel.SelectedGolfClub.GolfClubName}");

            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the MyMembershipsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MyMembershipsPage_HomeButtonClick(Object sender,
                                                             EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        /// <summary>
        /// Handles the RequestClubMembershipButtonClick event of the MyMembershipsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MyMembershipsPage_RequestClubMembershipButtonClick(Object sender,
                                                                              EventArgs e)
        {
            // Show the request membership club list
            this.MembershipRequestClubListPage.RequestMembershipButtonClick += this.MembershipRequestClubListPage_RequestMembershipButtonClick;
            this.MembershipRequestClubListPage.HomeButtonClick += this.MembershipRequestClubListPage_HomeButtonClick;

            // Get the Club List
            await this.ApiClient.GetGolfClubList(App.AccessToken, this.MyMembershipRequestClubListViewModel, CancellationToken.None);

            this.MembershipRequestClubListPage.Init(this.MyMembershipRequestClubListViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.MembershipRequestClubListPage);
        }

        #endregion
    }
}