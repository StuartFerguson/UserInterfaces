namespace GolfClubAdminWebSite.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;
    using Factories;
    using ManagementAPI.Service.Client;
    using ManagementAPI.Service.DataTransferObjects;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfClubAdminWebSite.Services.IClient" />
    public class ApiClient : IClient
    {
        #region Fields

        /// <summary>
        /// The golf club client
        /// </summary>
        private readonly IGolfClubClient GolfClubClient;

        /// <summary>
        /// The model factory
        /// </summary>
        private readonly IModelFactory ModelFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="golfClubClient">The golf club client.</param>
        /// <param name="modelFactory">The model factory.</param>
        public ApiClient(IGolfClubClient golfClubClient,
                         IModelFactory modelFactory)
        {
            this.GolfClubClient = golfClubClient;
            this.ModelFactory = modelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the golf club administrator.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task RegisterGolfClubAdministrator(RegisterClubAdministratorViewModel viewModel,
                                                        CancellationToken cancellationToken)
        {
            // Translate view model to request
            RegisterClubAdministratorRequest registerRegisterClubAdministratorRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.RegisterGolfClubAdministrator(registerRegisterClubAdministratorRequest, cancellationToken);
        }

        #endregion
    }
}