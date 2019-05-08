using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Controllers
{
    using System.IO;
    using System.Threading;
    using ManagementAPI.Service.Client;
    using ManagementAPI.Service.DataTransferObjects;
    using Microsoft.AspNetCore.Authentication;
    using Models;
    using Services;
    using Shared.General;

    [Area("GolfClubAdministrator")]
    public class HomeController : Controller
    {
        private readonly IClient ApiClient;

        public HomeController(IClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> ManageGolfClub(CancellationToken cancellationToken)
        {
            IActionResult result = null;

            String accessToken = await this.HttpContext.GetTokenAsync("access_token");

            // Check if the golf club is already created (if not redirect to create page)
            if (await this.ApiClient.IsGolfClubCreated(accessToken, cancellationToken))
            {
                // Redirect to the Edit action as we have found the golf club
                result = this.RedirectToAction(nameof(this.EditGolfClub));
            }
            else
            {
                // We need to redirect to the create action
                result = this.RedirectToAction(nameof(this.CreateGolfClub));
            }

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> CreateGolfClub(CancellationToken cancellationToken)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGolfClub(CreateGolfClubViewModel model, CancellationToken cancellationToken)
        {
            // Validate the model
            if (this.ValidateModel(model))
            {
                String accessToken = await this.HttpContext.GetTokenAsync("access_token");

                // All good with model, call the client to create the golf club
                await this.ApiClient.CreateGolfClub(accessToken, model, cancellationToken);

                // GOlf Club Created, redirect to the Club Details screen
                return this.RedirectToAction(nameof(this.ManageGolfClub));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditGolfClub(CancellationToken cancellationToken)
        {
            String accessToken = await this.HttpContext.GetTokenAsync("access_token");

            UpdateGolfClubViewModel golfClubDetails = await this.ApiClient.GetGolfClub(accessToken, cancellationToken);

            return this.View(golfClubDetails);
        }

        private Boolean ValidateModel(CreateGolfClubViewModel model)
        {
            return this.ModelState.IsValid;
        }
    }
}