namespace GolfClubAdminWebSite.IntegrationTests.Common
{
    using System;
    using Newtonsoft.Json;

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public String AccessToken { get; set; }
    }
}