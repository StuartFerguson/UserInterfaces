namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using Areas.MatchSecretary.Models;
    using Factories;
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
        /// The golf club client
        /// </summary>
        private readonly IGolfClubClient GolfClubClient;

        private readonly ITournamentClient TournamentClient;

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
                         ITournamentClient tournamentClient,
                         IModelFactory modelFactory)
        {
            this.GolfClubClient = golfClubClient;
            this.TournamentClient = tournamentClient;
            this.ModelFactory = modelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task CreateGolfClub(String accessToken,
                                                                 CreateGolfClubViewModel viewModel,
                                                                 CancellationToken cancellationToken)
        {
            // Translate view model to request
            CreateGolfClubRequest createGolfClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.CreateGolfClub(accessToken, createGolfClubRequest, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="viewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CreateMatchSecretary(String accessToken,
                                               CreateGolfClubUserViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            CreateMatchSecretaryRequest createMatchSecretaryRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.CreateMatchSecretary(accessToken, createMatchSecretaryRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the measured course.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task CreateMeasuredCourse(String accessToken,
                                               MeasuredCourseViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            AddMeasuredCourseToClubRequest addMeasuredCourseToClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.AddMeasuredCourseToGolfClub(accessToken, addMeasuredCourseToClubRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task CreateTournament(String accessToken,
                                           CreateTournamentViewModel viewModel,
                                           CancellationToken cancellationToken)
        {

            CreateTournamentRequest request = this.ModelFactory.ConvertFrom(viewModel);

            await this.TournamentClient.CreateTournament(accessToken, request, cancellationToken);

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
        /// Gets the measured courses.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<MeasuredCourseListViewModel>> GetMeasuredCourses(String accessToken,
                                                                                CancellationToken cancellationToken)
        {
            List<MeasuredCourseListViewModel> result = new List<MeasuredCourseListViewModel>();
            try
            {
                GetMeasuredCourseListResponse measuredCoursesResponse = await this.GolfClubClient.GetMeasuredCourses(accessToken, cancellationToken);

                result = this.ModelFactory.ConvertFrom(measuredCoursesResponse);
            }
            catch(Exception ex)
            {
                // Look at the inner exception
                if (ex.InnerException is KeyNotFoundException)
                {
                    // Swallow this exception and set the result to false
                    result = new List<MeasuredCourseListViewModel>();
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<GetGolfClubUserListViewModel>> GetUserList(String accessToken,
                                                                          CancellationToken cancellationToken)
        {
            GetGolfClubUserListResponse userList = await this.GolfClubClient.GetGolfClubUserList(accessToken, cancellationToken);

            return this.ModelFactory.ConvertFrom(userList);
        }

        /// <summary>
        /// Determines whether [is golf club created] [the specified access token].
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<Boolean> IsGolfClubCreated(String accessToken,
                                                     CancellationToken cancellationToken)
        {
            Boolean result = false;

            try
            {
                await this.GolfClubClient.GetSingleGolfClub(accessToken, cancellationToken);
                result = true;
            }
            catch(Exception ex)
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