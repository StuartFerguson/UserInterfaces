namespace GolfClubAdminWebSite.Areas.MatchSecretary.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfClubAdministrator.Controllers;
    using GolfClubAdministrator.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CodeActions;
    using Models;
    using Newtonsoft.Json;
    using Services;
    using Shared.General;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Area("MatchSecretary")]
    public class HomeController : Controller
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchSecretary.Controllers.HomeController" /> class.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        public HomeController(IClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTournament( CancellationToken cancellationToken)
        {
            CreateTournamentViewModel viewModel = new CreateTournamentViewModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTournament(CreateTournamentViewModel model, CancellationToken cancellationToken)
        {
            // Validate the model
            if (this.ValidateModel(model))
            {
                String accessToken = await this.HttpContext.GetTokenAsync("access_token");

                // All good with model, call the client to create the golf club
                await this.ApiClient.CreateTournament(accessToken, model, cancellationToken);

                // Tournament Created, redirect to the Manage Tournaments screen
                // TODO: Get list of tournaments :|
                return this.RedirectToAction(nameof(this.Index));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        private Boolean ValidateModel(CreateTournamentViewModel model)
        {
            return this.ModelState.IsValid;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasuredCourseListAsJson(CancellationToken cancellationToken)
        {
            Logger.LogDebug("In method GetMeasuredCourseListAsJson");
            
            String accessToken = await this.HttpContext.GetTokenAsync("access_token");
            Logger.LogDebug("got access token");

            List<MeasuredCourseListViewModel> measuredCourseList = await this.ApiClient.GetMeasuredCourses(accessToken, cancellationToken);
            Logger.LogDebug($"course list count is {measuredCourseList.Count}");
            
            return this.Json(measuredCourseList);
        }

        #endregion
    }
}