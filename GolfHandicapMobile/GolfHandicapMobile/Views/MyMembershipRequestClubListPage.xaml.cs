namespace GolfHandicapMobile.ViewModels
{
    using System;
    using Pages;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IMyMembershipRequestClubListPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMembershipRequestClubListPage : ContentPage, IMyMembershipRequestClubListPage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMembershipRequestClubListPage"/> class.
        /// </summary>
        public MyMembershipRequestClubListPage()
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
        /// Occurs when [request membership button click].
        /// </summary>
        public event EventHandler RequestMembershipButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MyMembershipRequestClubListViewModel viewModel)
        {
            this.BindingContext = viewModel;
            
            this.RequestMembershipButton.Clicked += this.RequestMembershipButton_Clicked;
            this.HomeButton.Clicked += this.HomeButton_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the HomeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HomeButton_Clicked(Object sender,
                                        EventArgs e)
        {
            this.HomeButtonClick(sender, e);
        }

        /// <summary>
        /// Handles the Clicked event of the RequestMembershipButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RequestMembershipButton_Clicked(Object sender,
                                                     EventArgs e)
        {
            this.RequestMembershipButtonClick(sender, e);
        }

        #endregion
    }
}