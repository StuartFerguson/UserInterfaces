namespace GolfClubAdminWebSite.Services
{
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