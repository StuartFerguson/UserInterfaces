namespace GolfHandicapMobile.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ClientProxyBase;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ClientProxyBase.ClientProxyBase" />
    /// <seealso cref="GolfHandicapMobile.Services.ISecurityServiceClient" />
    public class SecurityServiceClient : ClientProxyBase, ISecurityServiceClient
    {
        #region Fields

        /// <summary>
        /// The base address
        /// </summary>
        private readonly String BaseAddress;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityServiceClient" /> class.
        /// </summary>
        /// <param name="baseAddressResolver">The base address resolver.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public SecurityServiceClient(Func<String, String> baseAddressResolver,
                                     HttpClient httpClient) : base(httpClient)
        {
            this.BaseAddress = baseAddressResolver("SecurityServiceAPI");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Access token not found in response</exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<String> GetPasswordToken(String clientId,
                                                   String clientSecret,
                                                   String userName,
                                                   String password,
                                                   CancellationToken cancellationToken)
        {
            String requestUri = $"{this.BaseAddress}/connect/token";

            try
            {
                String request =
                    $"grant_type=password&client_id={clientId}&client_secret={clientSecret}&username={userName}&password={password}&scope=openid profile managementapi";

                StringContent httpContent = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");

                // Make the Http Call here
                HttpResponseMessage httpResponse = await this.HttpClient.PostAsync(requestUri, httpContent, cancellationToken);

                // Process the response
                String content = await this.HandleResponse(httpResponse, cancellationToken);

                // Get the object from the response
                JObject jsonObject = JObject.Parse(content);

                // Rip the token out the response
                if (!jsonObject.TryGetValue("access_token", StringComparison.InvariantCultureIgnoreCase, out JToken token))
                {
                    throw new Exception("Access token not found in response");
                }

                // Get the token as string
                String accessToken = token.Value<String>();

                return accessToken;
            }
            catch(Exception ex)
            {
                // An exception has occurred, add some additional information to the message
                Exception exception = new Exception($"Error getting password token for user name {userName}.", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<GetUserInfoResponse> GetUserInfo(String accessToken,
                                                           CancellationToken cancellationToken)
        {
            GetUserInfoResponse response = null;
            String requestUri = $"{this.BaseAddress}/connect/userinfo";

            try
            {
                this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Make the Http Call here
                HttpResponseMessage httpResponse = await this.HttpClient.GetAsync(requestUri, cancellationToken);

                // Process the response
                String content = await this.HandleResponse(httpResponse, cancellationToken);

                // Deserialise the response
                response = JsonConvert.DeserializeObject<GetUserInfoResponse>(content);
            }
            catch(Exception ex)
            {
                // An exception has occurred, add some additional information to the message
                Exception exception = new Exception("Error getting users info.", ex);

                throw exception;
            }

            return response;
        }

        #endregion
    }
}