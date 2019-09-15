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
    /// <seealso cref="GolfHandicapMobile.Pages.IMyTournamentSignInPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTournamentSignInPage : ContentPage, IMyTournamentSignInPage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTournamentSignInPage" /> class.
        /// </summary>
        public MyTournamentSignInPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        public event EventHandler HomeButtonClick;

        /// <summary>
        /// Occurs when [tournament sign in button click].
        /// </summary>
        public event EventHandler TournamentSignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MyTournamentsSignInViewModel viewModel)
        {
            this.BindingContext = viewModel;

            this.HomeButton.Clicked += this.HomeButton_Clicked;
            this.SignInButton.Clicked += this.SignInButton_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the HomeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void HomeButton_Clicked(Object sender,
                                        EventArgs e)
        {
            this.HomeButtonClick(sender, e);
        }

        /// <summary>
        /// Handles the Clicked event of the SignInButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SignInButton_Clicked(Object sender,
                                          EventArgs e)
        {
            this.TournamentSignInButtonClick(sender, e);
        }

        #endregion
    }
}