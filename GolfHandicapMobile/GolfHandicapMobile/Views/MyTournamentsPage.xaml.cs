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
    /// <seealso cref="GolfHandicapMobile.Pages.IMyTournamentsPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTournamentsPage : ContentPage, IMyTournamentsPage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTournamentsPage" /> class.
        /// </summary>
        public MyTournamentsPage()
        {
            this.InitializeComponent();
            Shell.Current.FlyoutIsPresented = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [enter tournament score button click].
        /// </summary>
        public event EventHandler EnterTournamentScoreButtonClick;

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        public event EventHandler HomeButtonClick;

        /// <summary>
        /// Occurs when [tournament sign up button click].
        /// </summary>
        public event EventHandler TournamentSignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MyTournamentsViewModel viewModel)
        {
            this.BindingContext = viewModel;
            this.HomeButton.Clicked += this.HomeButton_Clicked;
            this.TournamentSignInButton.Clicked += this.TournamentSignInButton_Clicked;
            this.EnterScoreButton.Clicked += this.EnterScoreButton_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the EnterScoreButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EnterScoreButton_Clicked(Object sender,
                                              EventArgs e)
        {
            this.EnterTournamentScoreButtonClick(sender, e);
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
        /// Handles the Clicked event of the TournamentSignInButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void TournamentSignInButton_Clicked(Object sender,
                                                       EventArgs e)
        {
            this.TournamentSignInButtonClick(sender, e);
        }

        #endregion
    }
}