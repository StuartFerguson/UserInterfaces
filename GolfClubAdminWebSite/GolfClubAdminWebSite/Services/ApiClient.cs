namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
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

        /// <summary>
        /// Determines whether [is golf club created] [the specified access token].
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<Boolean> IsGolfClubCreated(String accessToken, CancellationToken cancellationToken)
        {
            Boolean result = false;

            try
            {
                await this.GolfClubClient.GetSingleGolfClub(accessToken, cancellationToken);
                result = true;
            }
            catch (Exception ex)
            {
                // Look at the inner exception
                if (ex.InnerException is KeyNotFoundException)
                {
                    // Swallow this exception and set the result to false
                    result = false;
                }
                else
                {
                    throw;
                }
            }

            return result;

        }

        /// <summary>
        /// Gets the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<UpdateGolfClubViewModel> GetGolfClub(String accessToken,
                                                           CancellationToken cancellationToken)
        {
            GetGolfClubResponse getGolfClubResponse = await this.GolfClubClient.GetSingleGolfClub(accessToken, cancellationToken);

            return this.ModelFactory.ConvertFrom(getGolfClubResponse);
        }

        /// <summary>
        /// Creates the measured course.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task CreateMeasuredCourse(String accessToken, MeasuredCourseViewModel viewModel, CancellationToken cancellationToken)
        {
            AddMeasuredCourseToClubRequest addMeasuredCourseToClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.AddMeasuredCourseToGolfClub(accessToken, addMeasuredCourseToClubRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<CreateGolfClubResponse> CreateGolfClub(String accessToken, CreateGolfClubViewModel viewModel,
                                                                 CancellationToken cancellationToken)
        {
            // Translate view model to request
            CreateGolfClubRequest createGolfClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            return await this.GolfClubClient.CreateGolfClub(accessToken, createGolfClubRequest, cancellationToken);
        }

        #endregion
    }
}