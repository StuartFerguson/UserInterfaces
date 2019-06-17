namespace GolfHandicapMobile
{
    using Common;
    using Presenters;
    using Unity;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        #region Fields

        /// <summary>
        /// Unity container
        /// </summary>
        public static IUnityContainer Container;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            App.Container = Bootstrapper.Run();
            this.MainPage = new AppShell();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override async void OnStart()
        {
            // Handle when your app starts
            IHomePagePresenter homePagePresenter = App.Container.Resolve<IHomePagePresenter>();

            // show the login page
            await homePagePresenter.Start();
        }

        #endregion
    }
}