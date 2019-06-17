namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Threading.Tasks;
    using Pages;
    using Plugin.Toast;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Presenters.IHomePagePresenter" />
    public class HomePagePresenter : IHomePagePresenter
    {
        #region Fields

        /// <summary>
        /// The home page
        /// </summary>
        private readonly IHomePage HomePage;

        /// <summary>
        /// The registration presenter resolver
        /// </summary>
        private readonly Func<IRegistrationPresenter> RegistrationPresenterResolver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePagePresenter" /> class.
        /// </summary>
        /// <param name="homePage">The home page.</param>
        /// <param name="registrationPresenterResolver">The registration presenter resolver.</param>
        public HomePagePresenter(IHomePage homePage,
                                 Func<IRegistrationPresenter> registrationPresenterResolver)
        {
            this.HomePage = homePage;
            this.RegistrationPresenterResolver = registrationPresenterResolver;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            this.HomePage.RegisterButtonClick += this.HomePage_OnRegisterButtonClick;
            this.HomePage.SignInButtonClick += this.HomePage_OnSignInButtonClick;

            // TODO: Not sure if this is a hack or not....
            await Shell.Current.Navigation.PushAsync((Page)this.HomePage);
        }

        /// <summary>
        /// Handles the OnRegisterButtonClick event of the HomePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void HomePage_OnRegisterButtonClick(Object sender,
                                                          EventArgs e)
        {
            IRegistrationPresenter registrationPresenter = this.RegistrationPresenterResolver();
            await registrationPresenter.Start();
        }

        /// <summary>
        /// Handles the OnSignInButtonClick event of the HomePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void HomePage_OnSignInButtonClick(Object sender,
                                                  EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastSuccess("Sign In Clicked");
        }

        #endregion
    }
}