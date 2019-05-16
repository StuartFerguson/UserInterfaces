namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using ManagementAPI.Service.DataTransferObjects;

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
        
        /// <summary>
        /// Determines whether [is golf club created] [the specified access token].
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Boolean> IsGolfClubCreated(String accessToken,
                                        CancellationToken cancellationToken);

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<CreateGolfClubResponse> CreateGolfClub(String accessToken, 
                                                    CreateGolfClubViewModel viewModel,
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
        /// Creates the measured course.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CreateMeasuredCourse(String accessToken, MeasuredCourseViewModel viewModel, CancellationToken cancellationToken);

        #endregion
    }
}