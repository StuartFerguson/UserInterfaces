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
    /// <seealso cref="GolfHandicapMobile.Pages.IMyDetailsPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDetailsPage : ContentPage, IMyDetailsPage, IPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDetailsPage"/> class.
        /// </summary>
        public MyDetailsPage()
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

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MyDetailsViewModel viewModel)
        {
            this.BindingContext = viewModel;
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

        #endregion
    }
}