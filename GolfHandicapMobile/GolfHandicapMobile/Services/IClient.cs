namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfHandicapMobile.ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public interface IClient
    {
        #region Methods

        /// <summary>
        /// Gets the golf club list.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetGolfClubList(String passwordToken,
                             Guid playerId,
                             MyMembershipRequestClubListViewModel viewModel,
                             CancellationToken cancellationToken);

        /// <summary>
        /// Gets the next available tournaments for sign in.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetNextAvailableTournamentsForSignIn(String passwordToken,
                                                  Guid playerId,
                                                  MyTournamentsSignInViewModel viewModel,
                                                  CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetPlayer(String accessToken,
                       Guid playerId,
                       MyDetailsViewModel viewModel,
                       CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player memberships.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetPlayerMemberships(String passwordToken,
                                  Guid playerId,
                                  MyMembershipsListViewModel viewModel,
                                  CancellationToken cancellationToken);

        /// <summary>
        /// Gets the signed up tournament.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetSignedUpTournament(String passwordToken,
                                   Guid playerId,
                                   MyTournamentsViewModel viewModel,
                                   CancellationToken cancellationToken);

        /// <summary>
        /// Gets the top player scores.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="numberOfScores">The number of scores.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetTopPlayerScores(String passwordToken,
                                Guid playerId,
                                Int32 numberOfScores,
                                MyTournamentsViewModel viewModel,
                                CancellationToken cancellationToken);

        /// <summary>
        /// Registers the player.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RegisterPlayer(RegistrationViewModel viewModel,
                            CancellationToken cancellationToken);

        /// <summary>
        /// Requests the club membership.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RequestClubMembership(String passwordToken,
                                   Guid playerId,
                                   Guid golfClubId,
                                   CancellationToken cancellationToken);

        /// <summary>
        /// Tournaments the sign in.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task TournamentSignIn(String passwordToken,
                              Guid playerId,
                              Guid tournamentId,
                              CancellationToken cancellationToken);

        #endregion
    }
}