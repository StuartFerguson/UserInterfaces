using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Presenters
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using GolfClubAdminWebSite.Services;
    using Pages;
    using Plugin.Toast;
    using Services;
    using ViewModels;
    using Xamarin.Forms;

    public interface ISignInPresenter : IPresenter
    {
    }

    public class SignInPresenter : ISignInPresenter
    {
        private readonly ISignInPage SignInPage;

        private readonly SignInViewModel SignInViewModel;

        private readonly IRegistrationPage RegistrationPage;

        private readonly RegistrationViewModel RegistrationViewModel;

        private readonly ISecurityServiceClient SecurityServiceClient;

        private readonly IClient ApiClient;

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

        public async Task Start()
        {
            this.SignInPage.SignInButtonClick += this.SignInPage_SignInButtonClick;
            this.SignInPage.RegisterButtonClick += this.SignInPage_RegisterButtonClick;
            this.SignInPage.Init(this.SignInViewModel);

            Application.Current.MainPage = new NavigationPage((Page)this.SignInPage);
        }

        private async void SignInPage_RegisterButtonClick(object sender, EventArgs e)
        {
            this.RegistrationPage.RegisterButtonClick += this.RegistrationPage_RegisterButtonClick;
            this.RegistrationPage.Init(this.RegistrationViewModel);

            await Application.Current.MainPage.Navigation.PushAsync((Page)this.RegistrationPage);
        }

        private async void RegistrationPage_RegisterButtonClick(object sender, EventArgs e)
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
            catch (Exception exception)
            {
                this.RegistrationPage.SetRegistrationFailureMessage("Registration Failed");

                CrossToastPopUp.Current.ShowToastError("Registration Failed");
            }
        }

        private async void SignInPage_SignInButtonClick(object sender, EventArgs e)
        {
            // TODO: Move from here
            String clientId = "golfhandicap.mobile";
            String clientSecret = "golfhandicap.mobile";

            // Get a token
            String token = await this.SecurityServiceClient.GetPasswordToken(clientId, clientSecret,
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
            else
            {
                // TODO: Error
            }
        }
    }
}
