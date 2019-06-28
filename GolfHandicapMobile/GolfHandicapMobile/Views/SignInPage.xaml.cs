namespace GolfHandicapMobile.Views
{
    using System;
    using Pages;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.ISignInPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage, ISignInPage, IPage
    {
        #region Fields

        /// <summary>
        /// The view model
        /// </summary>
        private SignInViewModel ViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPage"/> class.
        /// </summary>
        public SignInPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [cancel button click].
        /// </summary>
        public event EventHandler RegisterButtonClick;

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        public event EventHandler SignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(SignInViewModel viewModel)
        {
            this.ViewModel = viewModel;

            this.EmailAddress.TextChanged += this.EmailAddress_TextChanged;
            this.EmailAddress.Completed += this.EmailAddress_Completed;

            this.Password.TextChanged += this.Password_TextChanged;
            this.Password.Completed += this.Password_Completed;

            this.SignIn.Clicked += this.SignIn_Clicked;
            this.Register.Clicked += this.Register_Clicked;
        }

        /// <summary>
        /// Sets the registration failure message.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        public void SetSignInFailureMessage(String failureMessage)
        {
            // TODO:
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

            this.EmailAddress.Focus();
        }

        /// <summary>
        /// Handles the Completed event of the EmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EmailAddress_Completed(Object sender,
                                            EventArgs e)
        {
            this.Password.Focus();
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
        /// Handles the Completed event of the Password control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Password_Completed(Object sender,
                                        EventArgs e)
        {
            this.SignIn.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the Password control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void Password_TextChanged(Object sender,
                                          TextChangedEventArgs e)
        {
            this.ViewModel.Password = e.NewTextValue;
        }

        /// <summary>
        /// Handles the Clicked event of the Register control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Register_Clicked(Object sender,
                                      EventArgs e)
        {
            this.RegisterButtonClick(sender, e);
        }

        /// <summary>
        /// Handles the Clicked event of the SignIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SignIn_Clicked(Object sender,
                                    EventArgs e)
        {
            // Validate Inputs
            this.SignInButtonClick(sender, e);
        }

        #endregion
    }
}