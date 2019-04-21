namespace GolfClubAdminWebSite.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IClient
    {
        #region Methods

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