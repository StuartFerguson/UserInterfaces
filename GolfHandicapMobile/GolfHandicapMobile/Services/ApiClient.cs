namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfHandicapMobile.ViewModels;
    using ManagementAPI.Service.Client;
    using ManagementAPI.Service.DataTransferObjects.Requests;
    using ManagementAPI.Service.DataTransferObjects.Responses;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfClubAdminWebSite.Services.IClient" />
    [ExcludeFromCodeCoverage]
    public class ApiClient : IClient
    {
        #region Fields

        /// <summary>
        /// The player client
        /// </summary>
        private readonly IPlayerClient PlayerClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="playerClient">The player client.</param>
        public ApiClient(IPlayerClient playerClient)
        {
            this.PlayerClient = playerClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the player.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task RegisterPlayer(RegistrationViewModel viewModel,
                                         CancellationToken cancellationToken)
        {
            // Translate the view model into the api request
            RegisterPlayerRequest apiRequest = new RegisterPlayerRequest
                                               {
                                                   DateOfBirth = viewModel.DateOfBirth,
                                                   Gender = viewModel.Gender == 0 ? "M" : "F",
                                                   EmailAddress = viewModel.EmailAddress,
                                                   MiddleName = viewModel.MiddleName,
                                                   ExactHandicap = Decimal.Parse(viewModel.ExactHandicap),
                                                   FirstName = viewModel.FirstName,
                                                   LastName = viewModel.LastName
                                               };

            RegisterPlayerResponse apiResponse = await this.PlayerClient.RegisterPlayer(apiRequest, cancellationToken);

            // Set the result in the view model
            viewModel.PlayerId = apiResponse.PlayerId;
        }

        #endregion
    }
}