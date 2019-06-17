namespace GolfHandicapMobile.Views
{
    using System;
    using System.Globalization;
    using Pages;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IRegistrationPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage, IRegistrationPage, IPage
    {
        #region Fields

        /// <summary>
        /// The view model
        /// </summary>
        private RegistrationViewModel ViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPage"/> class.
        /// </summary>
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [register button click].
        /// </summary>
        public event EventHandler RegisterButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegistrationViewModel viewModel)
        {
            this.ViewModel = viewModel;
            this.FirstName.TextChanged += this.FirstName_TextChanged;
            this.FirstName.Completed += this.FirstName_OnCompleted;

            this.LastName.TextChanged += this.LastName_TextChanged;
            this.LastName.Completed += this.LastName_OnCompleted;

            this.Gender.SelectedIndexChanged += this.Gender_OnSelectedIndexChanged;

            this.DateOfBirth.Completed += this.DateOfBirth_OnCompleted;

            this.ExactHandicap.TextChanged += this.ExactHandicap_TextChanged;
            this.ExactHandicap.Completed += this.ExactHandicap_OnCompleted;

            this.EmailAddress.TextChanged += this.EmailAddress_TextChanged;
            this.EmailAddress.Completed += this.EmailAddress_OnCompleted;

            this.Register.Clicked += this.Register_Clicked;
        }

        /// <summary>
        /// Sets the registration failure message.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        public void SetRegistrationFailureMessage(String failureMessage)
        {
            this.RegistrationStatus.IsVisible = true;
            this.RegistrationStatus.Text = failureMessage;
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.FirstName.Focus();
        }

        /// <summary>
        /// Handles the OnCompleted event of the Age control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DateOfBirth_OnCompleted(Object sender,
                                     EventArgs e)
        {
            this.ExactHandicap.Focus();
        }
        
        /// <summary>
        /// Handles the OnCompleted event of the EmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EmailAddress_OnCompleted(Object sender,
                                              EventArgs e)
        {
            // TODO: This is not working for some reason :'(
            this.Register.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the EmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void EmailAddress_TextChanged(Object sender,
                                              TextChangedEventArgs e)
        {
            this.ViewModel.EmailAddress = e.NewTextValue;
        }

        /// <summary>
        /// Handles the OnCompleted event of the ExactHandicap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExactHandicap_OnCompleted(Object sender,
                                               EventArgs e)
        {
            this.EmailAddress.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the ExactHandicap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void ExactHandicap_TextChanged(Object sender,
                                               TextChangedEventArgs e)
        {
            this.ViewModel.ExactHandicap = decimal.Parse(e.NewTextValue);
        }

        /// <summary>
        /// Handles the OnCompleted event of the FirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FirstName_OnCompleted(Object sender,
                                           EventArgs e)
        {
            this.LastName.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the FirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void FirstName_TextChanged(Object sender,
                                           TextChangedEventArgs e)
        {
            this.ViewModel.FirstName = e.NewTextValue;
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged event of the Gender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Gender_OnSelectedIndexChanged(Object sender,
                                                   EventArgs e)
        {
            this.ViewModel.Gender = this.Gender.SelectedIndex;

            this.DateOfBirth.Focus();
        }

        /// <summary>
        /// Handles the OnCompleted event of the LastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LastName_OnCompleted(Object sender,
                                          EventArgs e)
        {
            this.Gender.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the LastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void LastName_TextChanged(Object sender,
                                          TextChangedEventArgs e)
        {
            this.ViewModel.LastName = e.NewTextValue;
        }

        /// <summary>
        /// Handles the Clicked event of the Register control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Register_Clicked(Object sender,
                                      EventArgs e)
        {
            //await this.DisplayErrorAlert("An unexpected error occured. Please contact support.");
            // TODO: Validation here

            // Validate a valid date has been entered
            if (!DateTime.TryParseExact(this.DateOfBirth.Text, "dd-MM-yy", null, DateTimeStyles.None, out DateTime dateCodePickerDate))
            {
                // TODO: Handle the error
                //await this.DisplayErrorWithSoundAlert("Please enter a valid Date.");

                //this.DateCodeDateEntry.Focus();
                //return;
            }

            this.ViewModel.DateOfBirth = new DateTime(dateCodePickerDate.Year,
                                             dateCodePickerDate.Month,
                                             dateCodePickerDate.Day,
                                             dateCodePickerDate.Hour,
                                             dateCodePickerDate.Minute,
                                             dateCodePickerDate.Second,
                                             DateTimeKind.Unspecified);

            this.RegisterButtonClick(sender, e);
        }

        #endregion
    }
}