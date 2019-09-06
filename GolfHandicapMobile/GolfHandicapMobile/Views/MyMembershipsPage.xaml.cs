namespace GolfHandicapMobile.Views
{
    using System;
    using System.Linq;
    using Pages;
    using Plugin.Toast;
    using Syncfusion.ListView.XForms;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IMyMembershipsPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMembershipsPage : ContentPage, IPage, IMyMembershipsPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMembershipsPage"/> class.
        /// </summary>
        public MyMembershipsPage()
        {
            this.InitializeComponent();
            Shell.Current.FlyoutIsPresented = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        public event EventHandler HomeButtonClick;

        /// <summary>
        /// Occurs when [request club membership button click].
        /// </summary>
        public event EventHandler RequestClubMembershipButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MyMembershipsListViewModel viewModel)
        {
            this.BindingContext = viewModel;
            this.HomeButton.Clicked += this.HomeButton_Clicked;
            this.RequestClubMembershipButton.Clicked += this.RequestClubMembershipButton_Clicked;
            this.MembershipsView.SelectionChanged += MembershipsView_SelectionChanged;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the MembershipsView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemSelectionChangedEventArgs"/> instance containing the event data.</param>
        private void MembershipsView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            MembershipViewModel m = (MembershipViewModel)e.AddedItems.First();
            
            // TODO: This will show the membership details
            CrossToastPopUp.Current.ShowToastSuccess($"Item {m.GolfClubName} selected");
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
        /// Handles the Clicked event of the RequestClubMembershipButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RequestClubMembershipButton_Clicked(Object sender,
                                                         EventArgs e)
        {
            this.RequestClubMembershipButtonClick(sender, e);
        }

        #endregion
    }
}