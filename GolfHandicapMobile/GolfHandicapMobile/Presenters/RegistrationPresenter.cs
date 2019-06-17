namespace GolfHandicapMobile.Presenters
{
    using System;
    using System.Text;
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
    /// <seealso cref="GolfHandicapMobile.Presenters.IRegistrationPresenter" />
    public class RegistrationPresenter : IRegistrationPresenter
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        /// <summary>
        /// The register page
        /// </summary>
        private readonly IRegistrationPage RegistrationPage;

        /// <summary>
        /// The registration success page
        /// </summary>
        private readonly IRegistrationSuccessPage RegistrationSuccessPage;

        /// <summary>
        /// The register view model
        /// </summary>
        private readonly RegistrationViewModel RegistrationViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPresenter" /> class.
        /// </summary>
        /// <param name="registrationPage">The registration page.</param>
        /// <param name="registerViewModel">The register view model.</param>
        /// <param name="registrationSuccessPage">The registration success page.</param>
        /// <param name="apiClient">The API client.</param>
        public RegistrationPresenter(IRegistrationPage registrationPage,
                                     RegistrationViewModel registerViewModel,
                                     IRegistrationSuccessPage registrationSuccessPage,
                                     IClient apiClient)
        {
            this.RegistrationPage = registrationPage;
            this.RegistrationViewModel = registerViewModel;
            this.RegistrationSuccessPage = registrationSuccessPage;
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
            this.RegistrationPage.RegisterButtonClick += this.RegisterPage_RegisterButtonClick;
            this.RegistrationPage.Init(this.RegistrationViewModel);

            await Shell.Current.Navigation.PushAsync((Page)this.RegistrationPage);
        }

        /// <summary>
        /// Handles the RegisterButtonClick event of the RegisterPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void RegisterPage_RegisterButtonClick(Object sender,
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

                    this.RegistrationSuccessPage.HomeButtonClick += this.RegistrationSuccessPage_HomeButtonClick;
                    this.RegistrationSuccessPage.Init();

                    await Shell.Current.Navigation.PushAsync((Page)this.RegistrationSuccessPage);

                    StringBuilder successMessageBuilder = new StringBuilder();

                    successMessageBuilder.AppendLine("Registration Success");
                    successMessageBuilder.AppendLine(string.Empty);
                    successMessageBuilder
                        .AppendLine("An email has been sent to the address you provided, this will contain your username and password to login to the application.");

                    this.RegistrationSuccessPage.SetRegistrationSuccessMessage(successMessageBuilder.ToString());
                }
            }
            catch(Exception exception)
            {
                this.RegistrationPage.SetRegistrationFailureMessage("Registration Failed");

                CrossToastPopUp.Current.ShowToastError("Registration Failed");
            }
        }

        /// <summary>
        /// Handles the HomeButtonClick event of the RegistrationSuccessPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegistrationSuccessPage_HomeButtonClick(Object sender,
                                                                   EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(false);
        }

        #endregion
    }
}