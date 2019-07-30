namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using Areas.MatchSecretary.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IClient
    {
        #region Methods

        /// <summary>
        /// Cancels the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationReason">The cancellation reason.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CancelTournament(String accessToken,
                              Guid tournamentId,
                              String cancellationReason,
                              CancellationToken cancellationToken);

        /// <summary>
        /// Produces the tournament result.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task ProduceTournamentResult(String accessToken,
                              Guid tournamentId,
                              CancellationToken cancellationToken);

        /// <summary>
        /// Completes the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CompleteTournament(String accessToken,
                                Guid tournamentId,
                                CancellationToken cancellationToken);

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CreateGolfClub(String accessToken,
                            CreateGolfClubViewModel viewModel,
                            CancellationToken cancellationToken);

        /// <summary>
        /// Creates the match secretary.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CreateMatchSecretary(String accessToken,
                                  CreateGolfClubUserViewModel viewModel,
                                  CancellationToken cancellationToken);

        /// <summary>
        /// Creates the measured course.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CreateMeasuredCourse(String accessToken,
                                  MeasuredCourseViewModel viewModel,
                                  CancellationToken cancellationToken);

        /// <summary>
        /// Creates the tournament.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CreateTournament(String accessToken,
                              CreateTournamentViewModel viewModel,
                              CancellationToken cancellationToken);

        /// <summary>
        /// Gets the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UpdateGolfClubViewModel> GetGolfClub(String accessToken,
                                                  CancellationToken cancellationToken);

        /// <summary>
        /// Gets the measured courses.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<MeasuredCourseListViewModel>> GetMeasuredCourses(String accessToken,
                                                                   CancellationToken cancellationToken);

        /// <summary>
        /// Gets the tournament list.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<GetTournamentListViewModel>> GetTournamentList(String accessToken,
                                                                 CancellationToken cancellationToken);

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<GetGolfClubUserListViewModel>> GetUserList(String accessToken,
                                                             CancellationToken cancellationToken);

        /// <summary>
        /// Determines whether [is golf club created] [the specified access token].
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Boolean> IsGolfClubCreated(String accessToken,
                                        CancellationToken cancellationToken);

        /// <summary>
        /// Registers the golf club administrator.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RegisterGolfClubAdministrator(RegisterClubAdministratorViewModel viewModel,
                                           CancellationToken cancellationToken);

        #endregion
    }
}