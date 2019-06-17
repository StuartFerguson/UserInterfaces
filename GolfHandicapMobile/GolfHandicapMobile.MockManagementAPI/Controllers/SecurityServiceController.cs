using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using HandicapMobile.MockAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandicapMobile.MockAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class SecurityServiceController : ControllerBase
    {
        private readonly Func<MockDatabaseDbContext> MockDatabaseDbContextResolver;

        public SecurityServiceController(Func<MockDatabaseDbContext> mockDatabaseDbContextResolver)
        {
            this.MockDatabaseDbContextResolver = mockDatabaseDbContextResolver;
        }

        [Route("connect/token")]
        [HttpPost]
        public async Task<IActionResult> GetToken([FromForm] TokenRequestData request)
        {
            using (var context = this.MockDatabaseDbContextResolver())
            {
                var user = context.RegisteredUsers.SingleOrDefault(u =>
                    u.EmailAddress == request.UserName && u.Password == request.Password);

                if (user != null)
                {
                    var accessToken = new
                    {
                        access_token = $"{request.UserName}|accesstoken",
                        expires_in = 3600,
                        token_type = "Bearer"
                    };

                    return this.Ok(accessToken);
                }
                else
                {
                    return this.BadRequest();
                }
            }
        }

        [Route("connect/userinfo")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo([FromHeader] String authorization)
        {
            if (authorization == null)
            {
                return this.Unauthorized();
            }

            // We have a token
            String tokenValue = authorization.Split(" ")[1];

            // Now get the user name from the token value
            String userName = tokenValue.Split('|')[0];

            using(var context = this.MockDatabaseDbContextResolver())
            {
                var user = context.RegisteredUsers.SingleOrDefault(u => u.EmailAddress == userName);

                if (user == null)
                {
                    return this.BadRequest();
                }

                String userRole = "Player";

                var userInfo = new
                               {
                                   sub = user.UserId,
                                   role = userRole,
                                   name = user.EmailAddress,
                                   email = user.EmailAddress
                               };

                return this.Ok(userInfo);
            }
        }
    }

    public class TokenRequestData
    {
        [FromForm(Name="grant_type")]
        public String GrantType { get; set; }
        [FromForm(Name="username")]
        public String UserName { get; set; }
        [FromForm(Name="client_id")]
        public String ClientId { get; set; }
        [FromForm(Name="password")]
        public String Password { get; set; }
        [FromForm(Name="client_secret")]
        public String ClientSecret { get; set; }
        [FromForm(Name="scope")]
        public String Scope { get; set; }
    }
}