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
        /// Registers the player.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RegisterPlayer(RegistrationViewModel viewModel,
                            CancellationToken cancellationToken);

        #endregion
    }
}