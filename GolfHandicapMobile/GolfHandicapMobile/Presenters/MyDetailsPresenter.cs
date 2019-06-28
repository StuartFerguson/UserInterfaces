namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfClubAdminWebSite.Services;
    using Pages;
    using ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Presenters.IMyDetailsPresenter" />
    public class MyDetailsPresenter : IMyDetailsPresenter
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        /// <summary>
        /// My details page
        /// </summary>
        private readonly IMyDetailsPage MyDetailsPage;

        /// <summary>
        /// My details view model
        /// </summary>
        private readonly MyDetailsViewModel MyDetailsViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDetailsPresenter"/> class.
        /// </summary>
        /// <param name="myDetailsPage">My details page.</param>
        /// <param name="myDetailsViewModel">My details view model.</param>
        /// <param name="apiClient">The API client.</param>
        public MyDetailsPresenter(IMyDetailsPage myDetailsPage,
                                  MyDetailsViewModel myDetailsViewModel,
                                  IClient apiClient)
        {
            this.MyDetailsPage = myDetailsPage;
            this.MyDetailsViewModel = myDetailsViewModel;
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
            // Get the players details
            await this.ApiClient.GetPlayer(App.AccessToken, this.MyDetailsViewModel, CancellationToken.None);

            this.MyDetailsPage.HomeButtonClick += this.MyDetailsPage_HomeButtonClick;
            this.MyDetailsPage.Init(this.MyDetailsViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.MyDetailsPage);
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the MyDetailsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MyDetailsPage_HomeButtonClick(Object sender,
                                                   EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        #endregion
    }
}