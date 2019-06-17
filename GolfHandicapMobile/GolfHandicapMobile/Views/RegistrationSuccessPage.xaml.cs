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
    /// <seealso cref="GolfHandicapMobile.Pages.IRegistrationSuccessPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationSuccessPage : ContentPage, IRegistrationSuccessPage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationSuccessPage"/> class.
        /// </summary>
        public RegistrationSuccessPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        public event EventHandler HomeButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
            this.Home.Clicked += this.Home_OnClicked;
        }

        /// <summary>
        /// Sets the registration success message.
        /// </summary>
        /// <param name="successMessage">The success message.</param>
        public void SetRegistrationSuccessMessage(String successMessage)
        {
            this.RegistrationStatus.Text = successMessage;
        }

        /// <summary>
        /// Handles the OnClicked event of the Home control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Home_OnClicked(Object sender,
                                    EventArgs e)
        {
            this.HomeButtonClick(sender, e);
        }

        #endregion
    }
}