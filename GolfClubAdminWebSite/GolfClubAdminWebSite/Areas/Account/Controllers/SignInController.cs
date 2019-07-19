using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubAdminWebSite.Areas.Account.Controllers
{
    using System.Threading;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [Area("Account")]
    public class SignInController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Login(CancellationToken cancellationToken)
        {
            return this.RedirectToAction(nameof(this.LoggedIn));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LoggedIn(CancellationToken cancellationToken)
        {
            // Decide which page we move to now based on the role
            return this.DetermineLoggedInView();
        }

        private IActionResult DetermineLoggedInView()
        {
            IActionResult actionResult = null;

            if (this.User.IsInRole("Club Administrator"))
            {
                actionResult = this.RedirectToAction("Index",
                                                     "Home",
                                                     new
                                                     {
                                                         Area = "GolfClubAdministrator"
                                                     });
            }
            else if (this.User.IsInRole("Match Secretary"))
            {
                actionResult = this.RedirectToAction("Index",
                                                     "Home",
                                                     new
                                                     {
                                                         Area = "MatchSecretary"
                                                     });
            }
            else
            {
                // This should throw some kind of error as not supported
            }

            return actionResult;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task Logout(CancellationToken cancellationToken)
        {
            await this.HttpContext.SignOutAsync("oidc");
            await this.HttpContext.SignOutAsync("Cookies");
        }
    }
}
