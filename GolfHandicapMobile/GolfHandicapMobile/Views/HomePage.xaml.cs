namespace GolfHandicapMobile.Views
{
    using System;
    using Pages;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IHomePage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage, IHomePage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [register button click].
        /// </summary>
        public event EventHandler RegisterButtonClick;

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        public event EventHandler SignInButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        /// Handles the OnClicked event of the RegisterButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegisterButton_OnClicked(Object sender,
                                                    EventArgs e)
        {
            this.RegisterButtonClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Handles the OnClicked event of the SignInButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SignInButton_OnClicked(Object sender,
                                            EventArgs e)
        {
            this.SignInButtonClick?.Invoke(sender, e);
        }

        #endregion
    }
}