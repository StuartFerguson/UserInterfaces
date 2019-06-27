namespace GolfHandicapMobile.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityServiceClient
    {
        #region Methods

        /// <summary>
        /// Gets the password token.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<String> GetPasswordToken(String clientId,
                                      String clientSecret,
                                      String userName,
                                      String password,
                                      CancellationToken cancellationToken);

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<GetUserInfoResponse> GetUserInfo(String accessToken,
                                              CancellationToken cancellationToken);

        #endregion
    }
}