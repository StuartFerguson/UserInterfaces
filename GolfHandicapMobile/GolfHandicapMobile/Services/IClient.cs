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
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetGolfClubList(String passwordToken,
                             MyMembershipRequestClubListViewModel viewModel,
                             CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetPlayer(String accessToken,
                       MyDetailsViewModel viewModel,
                       CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player memberships.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task GetPlayerMemberships(String passwordToken,
                                  MyMembershipsListViewModel viewModel,
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
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RequestClubMembership(String passwordToken,
                                   Guid golfClubId,
                                   CancellationToken cancellationToken);

        Task GetTopPlayerScores(String passwordToken,
                                Guid playerId,
                                MyTournamentsViewModel viewModel,
                                CancellationToken cancellationToken);
        
        #endregion
    }
}