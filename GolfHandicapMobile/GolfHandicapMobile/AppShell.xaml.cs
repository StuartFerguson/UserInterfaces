namespace GolfHandicapMobile
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Plugin.Toast;
    using Presenters;
    using Unity;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Shell" />
    public partial class AppShell : Shell
    {
        #region Fields

        /// <summary>
        /// My details presenter resolver
        /// </summary>
        private readonly Func<IMyDetailsPresenter> MyDetailsPresenterResolver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell" /> class.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            this.BindingContext = this;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets my details command.
        /// </summary>
        /// <value>
        /// My details command.
        /// </value>
        public ICommand MyDetailsCommand => new Command(async () => await this.NavigateToMyDetails());

        /// <summary>
        /// Gets my memberships command.
        /// </summary>
        /// <value>
        /// My memberships command.
        /// </value>
        public ICommand MyMembershipsCommand => new Command(async () => await this.NavigateToMyMemberships());

        /// <summary>
        /// Gets my tournaments command.
        /// </summary>
        /// <value>
        /// My tournaments command.
        /// </value>
        public ICommand MyTournamentsCommand => new Command(async () => await this.NavigateToMyTournaments());

        #endregion

        #region Methods

        /// <summary>
        /// Handles the OnClicked event of the MenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MenuItem_OnClicked(Object sender,
                                        EventArgs e)
        {
        }

        /// <summary>
        /// Navigates to my details.
        /// </summary>
        /// <returns></returns>
        private async Task NavigateToMyDetails()
        {
            IMyDetailsPresenter myDetailsPresenter = App.Container.Resolve<IMyDetailsPresenter>();
            await myDetailsPresenter.Start();
        }

        /// <summary>
        /// Navigates to my memberships.
        /// </summary>
        /// <returns></returns>
        private async Task NavigateToMyMemberships()
        {
            IMyMembershipsPresenter myMembershipsPresenter = App.Container.Resolve<IMyMembershipsPresenter>();
            await myMembershipsPresenter.Start();
        }

        private async Task NavigateToMyTournaments()
        {
            IMyTournamentsPresenter myTournamentsPresenter = App.Container.Resolve<IMyTournamentsPresenter>();
            await myTournamentsPresenter.Start();
        }

        #endregion
    }
}