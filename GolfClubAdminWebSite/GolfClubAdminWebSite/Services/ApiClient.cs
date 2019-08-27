namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Security.Claims;
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

        /// <summary>
        /// The model factory
        /// </summary>
        private readonly IModelFactory ModelFactory;

        /// <summary>
        /// The reporting client
        /// </summary>
        private readonly IReportingClient ReportingClient;

        /// <summary>
        /// The tournament client
        /// </summary>
        private readonly ITournamentClient TournamentClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class.
        /// </summary>
        /// <param name="golfClubClient">The golf club client.</param>
        /// <param name="tournamentClient">The tournament client.</param>
        /// <param name="reportingClient">The reporting client.</param>
        /// <param name="modelFactory">The model factory.</param>
        public ApiClient(IGolfClubClient golfClubClient,
                         ITournamentClient tournamentClient,
                         IReportingClient reportingClient,
                         IModelFactory modelFactory)
        {
            this.GolfClubClient = golfClubClient;
            this.TournamentClient = tournamentClient;
            this.ReportingClient = reportingClient;
            this.ModelFactory = modelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cancels the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationReason">The cancellation reason.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CancelTournament(String accessToken,
                                           ClaimsIdentity claimsIdentity,
                                           Guid tournamentId,
                                           String cancellationReason,
                                           CancellationToken cancellationToken)
        {
            CancelTournamentRequest request = new CancelTournamentRequest();
            request.CancellationReason = cancellationReason;

            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
            await this.TournamentClient.CancelTournament(accessToken, golfClubId, tournamentId, request, cancellationToken);
        }

        /// <summary>
        /// Completes the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CompleteTournament(String accessToken,
                                             ClaimsIdentity claimsIdentity,
                                             Guid tournamentId,
                                             CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
            await this.TournamentClient.CompleteTournament(accessToken, golfClubId, tournamentId, cancellationToken);
        }

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CreateGolfClub(String accessToken,
                                         CreateGolfClubViewModel viewModel,
                                         CancellationToken cancellationToken)
        {
            // Translate view model to request
            CreateGolfClubRequest createGolfClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.CreateGolfClub(accessToken, createGolfClubRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the match secretary.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CreateMatchSecretary(String accessToken,
                                               ClaimsIdentity claimsIdentity,
                                               CreateGolfClubUserViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            CreateMatchSecretaryRequest createMatchSecretaryRequest = this.ModelFactory.ConvertFrom(viewModel);

            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            await this.GolfClubClient.CreateMatchSecretary(accessToken, golfClubId, createMatchSecretaryRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the measured course.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CreateMeasuredCourse(String accessToken,
                                               ClaimsIdentity claimsIdentity,
                                               MeasuredCourseViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            AddMeasuredCourseToClubRequest addMeasuredCourseToClubRequest = this.ModelFactory.ConvertFrom(viewModel);

            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            await this.GolfClubClient.AddMeasuredCourseToGolfClub(accessToken, golfClubId, addMeasuredCourseToClubRequest, cancellationToken);
        }

        /// <summary>
        /// Creates the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task CreateTournament(String accessToken,
                                           ClaimsIdentity claimsIdentity,
                                           CreateTournamentViewModel viewModel,
                                           CancellationToken cancellationToken)
        {
            CreateTournamentRequest request = this.ModelFactory.ConvertFrom(viewModel);

            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            await this.TournamentClient.CreateTournament(accessToken, golfClubId, request, cancellationToken);
        }

        /// <summary>
        /// Gets the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<UpdateGolfClubViewModel> GetGolfClub(String accessToken,
                                                               ClaimsIdentity claimsIdentity,
                                                               CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetGolfClubResponse getGolfClubResponse = await this.GolfClubClient.GetSingleGolfClub(accessToken, golfClubId, cancellationToken);

            return this.ModelFactory.ConvertFrom(getGolfClubResponse);
        }

        /// <summary>
        /// Gets the measured courses.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<MeasuredCourseListViewModel>> GetMeasuredCourses(String accessToken,
                                                                                ClaimsIdentity claimsIdentity,
                                                                                CancellationToken cancellationToken)
        {
            List<MeasuredCourseListViewModel> result = new List<MeasuredCourseListViewModel>();
            try
            {
                Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

                GetMeasuredCourseListResponse measuredCoursesResponse = await this.GolfClubClient.GetMeasuredCourses(accessToken, golfClubId, cancellationToken);

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
        /// Gets the members by age category report.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ChartJsPieChartDataViewModel> GetMembersByAgeCategoryReport(String accessToken,
                                                                                                       ClaimsIdentity claimsIdentity,
                                                                                                       CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetNumberOfMembersByAgeCategoryReportResponse getNumberOfMembersByAgeCategoryReportResponse = await this.ReportingClient.GetNumberOfMembersByAgeCategoryReport(accessToken, golfClubId, cancellationToken);

            return this.ModelFactory.ConvertFrom(getNumberOfMembersByAgeCategoryReportResponse);
        }

        /// <summary>
        /// Gets the number of members by handicap category report.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ChartJsPieChartDataViewModel> GetNumberOfMembersByHandicapCategoryReport(String accessToken,
                                                                                                                         ClaimsIdentity claimsIdentity,
                                                                                                                         CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetNumberOfMembersByHandicapCategoryReportResponse getNumberOfMembersByHandicapCategoryReportResponse = await this.ReportingClient.GetNumberOfMembersByHandicapCategoryReport(accessToken, golfClubId, cancellationToken);

            return this.ModelFactory.ConvertFrom(getNumberOfMembersByHandicapCategoryReportResponse);
        }

        /// <summary>
        /// Gets the number of members by time period report.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="timePeriod">The time period.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ChartJsLineChartDataViewModel> GetNumberOfMembersByTimePeriodReport(String accessToken,
                                                                                                             String timePeriod,
                                                                                                             ClaimsIdentity claimsIdentity,
                                                                                                             CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetNumberOfMembersByTimePeriodReportResponse getNumberOfMembersByTimePeriodReportResponse = await this.ReportingClient.GetNumberOfMembersByTimePeriodReport(accessToken, golfClubId, timePeriod, cancellationToken);

            return this.ModelFactory.ConvertFrom(getNumberOfMembersByTimePeriodReportResponse);
        }

        /// <summary>
        /// Gets the number of members report.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<NumberOfMembersReportViewModel> GetNumberOfMembersReport(String accessToken,
                                                                                     ClaimsIdentity claimsIdentity,
                                                                                     CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetNumberOfMembersReportResponse getNumberOfMembersReportResponse = await this.ReportingClient.GetNumberOfMembersReport(accessToken, golfClubId, cancellationToken);

            return this.ModelFactory.ConvertFrom(getNumberOfMembersReportResponse);
        }

        /// <summary>
        /// Gets the tournament list.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<GetTournamentListViewModel>> GetTournamentList(String accessToken,
                                                                              ClaimsIdentity claimsIdentity,
                                                                              CancellationToken cancellationToken)
        {
            List<GetTournamentListViewModel> result = new List<GetTournamentListViewModel>();
            try
            {
                Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
                GetTournamentListResponse tournamentListResponse = await this.TournamentClient.GetTournamentList(accessToken, golfClubId, cancellationToken);

                result = this.ModelFactory.ConvertFrom(tournamentListResponse);
            }
            catch(Exception ex)
            {
                // Look at the inner exception
                if (ex.InnerException is KeyNotFoundException)
                {
                    // Swallow this exception and set the result to false
                    result = new List<GetTournamentListViewModel>();
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
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<GetGolfClubUserListViewModel>> GetUserList(String accessToken,
                                                                          ClaimsIdentity claimsIdentity,
                                                                          CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");

            GetGolfClubUserListResponse userList = await this.GolfClubClient.GetGolfClubUserList(accessToken, golfClubId, cancellationToken);

            List<GetGolfClubUserListViewModel> result = this.ModelFactory.ConvertFrom(userList);

            return result;
        }

        /// <summary>
        /// Determines whether [is golf club created] [the specified access token].
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<Boolean> IsGolfClubCreated(String accessToken,
                                                     ClaimsIdentity claimsIdentity,
                                                     CancellationToken cancellationToken)
        {
            Boolean result = false;

            try
            {
                Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
                await this.GolfClubClient.GetSingleGolfClub(accessToken, golfClubId, cancellationToken);
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
        /// Produces the tournament result.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task ProduceTournamentResult(String accessToken,
                                                  ClaimsIdentity claimsIdentity,
                                                  Guid tournamentId,
                                                  CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
            await this.TournamentClient.ProduceTournamentResult(accessToken, golfClubId, tournamentId, cancellationToken);
        }

        /// <summary>
        /// Registers the golf club administrator.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task RegisterGolfClubAdministrator(RegisterClubAdministratorViewModel viewModel,
                                                        CancellationToken cancellationToken)
        {
            // Translate view model to request
            RegisterClubAdministratorRequest registerRegisterClubAdministratorRequest = this.ModelFactory.ConvertFrom(viewModel);

            await this.GolfClubClient.RegisterGolfClubAdministrator(registerRegisterClubAdministratorRequest, cancellationToken);
        }

        public async Task<List<MemberListViewModel>> GetMemberList(String accessToken,
                                        ClaimsIdentity claimsIdentity,
                                        CancellationToken cancellationToken)
        {
            Guid golfClubId = ApiClient.GetClaimValue<Guid>(claimsIdentity, "GolfClubId");
            List<GetGolfClubMembershipDetailsResponse> membershipList = await this.GolfClubClient.GetGolfClubMembershipList(accessToken, golfClubId, cancellationToken);

            List<MemberListViewModel> result = this.ModelFactory.ConvertFrom(membershipList);

            return result;
        }

        /// <summary>
        /// Gets the claim value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">User {claimsIdentity.Name} does not have Claim [{claimType}]</exception>
        private static T GetClaimValue<T>(ClaimsIdentity claimsIdentity,
                                          String claimType)
        {
            if (!claimsIdentity.HasClaim(x => x.Type == claimType))
            {
                throw new InvalidOperationException($"User {claimsIdentity.Name} does not have Claim [{claimType}]");
            }

            Claim claim = claimsIdentity.Claims.Single(x => x.Type == claimType);
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(claim.Value);
        }

        #endregion
    }
}