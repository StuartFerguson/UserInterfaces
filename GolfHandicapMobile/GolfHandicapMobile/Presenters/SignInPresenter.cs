namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using GolfClubAdminWebSite.Services;
    using Pages;
    using Plugin.Toast;
    using Services;
    using ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfHandicapMobile.Presenters.ISignInPresenter" />
    public class SignInPresenter : ISignInPresenter
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        /// <summary>
        /// The registration page
        /// </summary>
        private readonly IRegistrationPage RegistrationPage;

        /// <summary>
        /// The registration view model
        /// </summary>
        private readonly RegistrationViewModel RegistrationViewModel;

        /// <summary>
        /// The security service client
        /// </summary>
        private readonly ISecurityServiceClient SecurityServiceClient;

        /// <summary>
        /// The sign in page
        /// </summary>
        private readonly ISignInPage SignInPage;

        /// <summary>
        /// The sign in view model
        /// </summary>
        private readonly SignInViewModel SignInViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPresenter"/> class.
        /// </summary>
        /// <param name="signInPage">The sign in page.</param>
        /// <param name="signInViewModel">The sign in view model.</param>
        /// <param name="registrationPage">The registration page.</param>
        /// <param name="registrationViewModel">The registration view model.</param>
        /// <param name="securityServiceClient">The security service client.</param>
        /// <param name="apiClient">The API client.</param>
        public SignInPresenter(ISignInPage signInPage,
                               SignInViewModel signInViewModel,
                               IRegistrationPage registrationPage,
                               RegistrationViewModel registrationViewModel,
                               ISecurityServiceClient securityServiceClient,
                               IClient apiClient)
        {
            this.SignInPage = signInPage;
            this.SignInViewModel = signInViewModel;
            this.RegistrationPage = registrationPage;
            this.RegistrationViewModel = registrationViewModel;
            this.SecurityServiceClient = securityServiceClient;
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
            this.SignInPage.SignInButtonClick += this.SignInPage_SignInButtonClick;
            this.SignInPage.RegisterButtonClick += this.SignInPage_RegisterButtonClick;
            this.SignInPage.Init(this.SignInViewModel);

            Application.Current.MainPage = new NavigationPage((Page)this.SignInPage);
        }

        /// <summary>
        /// Handles the RegisterButtonClick event of the RegistrationPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegistrationPage_RegisterButtonClick(Object sender,
                                                                EventArgs e)
        {
            try
            {
                await this.ApiClient.RegisterPlayer(this.RegistrationViewModel, CancellationToken.None);

                if (this.RegistrationViewModel.PlayerId == Guid.Empty)
                {
                    this.RegistrationPage.SetRegistrationFailureMessage("Registration Failed");

                    CrossToastPopUp.Current.ShowToastError("Registration Failed");
                }
                else
                {
                    // Move to registration success page
                    CrossToastPopUp.Current.ShowToastSuccess("Registration Successful");

                    // Move back to the Login Page
                    await Application.Current.MainPage.Navigation.PopToRootAsync(true);
                }
            }
            catch(Exception exception)
            {
                this.RegistrationPage.SetRegistrationFailureMessage("Registration Failed");

                CrossToastPopUp.Current.ShowToastError("Registration Failed");
            }
        }

        /// <summary>
        /// Handles the RegisterButtonClick event of the SignInPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SignInPage_RegisterButtonClick(Object sender,
                                                          EventArgs e)
        {
            this.RegistrationPage.RegisterButtonClick += this.RegistrationPage_RegisterButtonClick;
            this.RegistrationPage.Init(this.RegistrationViewModel);

            await Application.Current.MainPage.Navigation.PushAsync((Page)this.RegistrationPage);
        }

        /// <summary>
        /// Handles the SignInButtonClick event of the SignInPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SignInPage_SignInButtonClick(Object sender,
                                                        EventArgs e)
        {
            // TODO: Move from here
            String clientId = "golfhandicap.mobile";
            String clientSecret = "golfhandicap.mobile";

            // Get a token
            String token = await this.SecurityServiceClient.GetPasswordToken(clientId,
                                                                             clientSecret,
                                                                             this.SignInViewModel.EmailAddress,
                                                                             this.SignInViewModel.Password,
                                                                             CancellationToken.None);

            // Store the token
            App.AccessToken = token;

            // Get the users information
            GetUserInfoResponse userInformation = await this.SecurityServiceClient.GetUserInfo(token, CancellationToken.None);

            // TODO: Navigate to the next page (based on user type)
            if (userInformation.RoleName == RoleNames.Player)
            {
                // Store the player id claim
                App.PlayerId = Guid.Parse(userInformation.PlayerId);

                // Go to signed in page
                Application.Current.MainPage = new AppShell();
            }
        }

        #endregion
    }
}