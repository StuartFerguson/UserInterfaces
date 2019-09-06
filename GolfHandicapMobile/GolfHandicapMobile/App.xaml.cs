namespace GolfHandicapMobile
{
    using System;
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
        /// The access token
        /// </summary>
        public static String AccessToken;

        /// <summary>
        /// Unity container
        /// </summary>
        public static IUnityContainer Container;

        /// <summary>
        /// The player identifier
        /// </summary>
        public static Guid PlayerId;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM2Nzk0QDMxMzcyZTMyMmUzMG81LzgzTS9KaEpOWVYwTXpRZytTY09yYWpiYTkwNDJzZGIzbmRoZUszZWs9");

            this.InitializeComponent();

            App.Container = Bootstrapper.Run();
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
            ISignInPresenter signInPresenter = App.Container.Resolve<ISignInPresenter>();

            // show the login page
            await signInPresenter.Start();
        }

        #endregion
    }
}