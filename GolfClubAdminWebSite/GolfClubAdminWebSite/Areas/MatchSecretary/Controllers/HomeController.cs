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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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
        /// Completes the tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> CompleteTournament(Guid tournamentId,
                                                            CancellationToken cancellationToken)
        {
            String accessToken = await this.HttpContext.GetTokenAsync("access_token");

            await this.ApiClient.CompleteTournament(accessToken, tournamentId, cancellationToken);

            return this.Ok();
        }

        /// <summary>
        /// Creates the tournament.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateTournament(CancellationToken cancellationToken)
        {
            CreateTournamentViewModel viewModel = new CreateTournamentViewModel();

            return this.View(viewModel);
        }

        /// <summary>
        /// Creates the tournament.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTournament(CreateTournamentViewModel model,
                                                          CancellationToken cancellationToken)
        {
            // Validate the model
            if (this.ValidateModel(model))
            {
                String accessToken = await this.HttpContext.GetTokenAsync("access_token");

                // All good with model, call the client to create the golf club
                await this.ApiClient.CreateTournament(accessToken, model, cancellationToken);

                // Tournament Created, redirect to the Manage Tournaments screen
                return this.RedirectToAction(nameof(this.GetTournamentList));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        /// <summary>
        /// Gets the measured course list as json.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
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

        [HttpGet]
        public async Task<IActionResult> GetTournamentList(CancellationToken cancellationToken)
        {
            return this.View();
        }

        /// <summary>
        /// Gets the tournament list as json.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetTournamentListAsJson(CancellationToken cancellationToken)
        {
            Logger.LogDebug("In method GetTournamentListAsJson");

            // Search Value from (Search box)  
            String searchValue = this.HttpContext.Request.Form["search[value]"].FirstOrDefault();
            Logger.LogDebug($"searchvalue is {searchValue}");

            String accessToken = await this.HttpContext.GetTokenAsync("access_token");
            Logger.LogDebug("got access token");

            List<GetTournamentListViewModel> tournamentList = await this.ApiClient.GetTournamentList(accessToken, cancellationToken);
            Logger.LogDebug($"tournament list count is {tournamentList.Count}");

            Expression<Func<GetTournamentListViewModel, Boolean>> whereClause = m => m.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                     m.Format.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                     m.PlayerCategory.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                     m.MeasuredCourseName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                     m.MeasuredCourseTeeColour.Contains(searchValue, StringComparison.OrdinalIgnoreCase);

            DataTablesResult<GetTournamentListViewModel> dataTableResult = this.GetDataForDataTable(tournamentList, whereClause);

            String jsonResult = JsonConvert.SerializeObject(dataTableResult);
            Logger.LogDebug(jsonResult);

            return this.Json(this.GetDataForDataTable(tournamentList, whereClause));
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        /// <summary>
        /// Gets the data for data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryData">The query data.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        private DataTablesResult<T> GetDataForDataTable<T>(IEnumerable<T> queryData,
                                                           Expression<Func<T, Boolean>> whereClause = null)
        {
            DataTablesResult<T> result;

            IFormCollection formData = this.HttpContext.Request.Form;

            if (formData == null)
            {
                result = null;
            }
            else
            {
                Logger.LogInformation("got form");
                // Extract the data tables fields
                String draw = formData["draw"].FirstOrDefault();
                Logger.LogInformation($"draw is {draw}");
                // Skiping number of Rows count  
                String start = formData["start"].FirstOrDefault();
                Logger.LogInformation($"start is {start}");
                // Paging Length 10,20  
                String length = formData["length"].FirstOrDefault();
                Logger.LogInformation($"length is {length}");
                // Sort Column Name  
                String sortColumn = formData["columns[" + formData["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                Logger.LogInformation($"sortcol is {sortColumn}");
                // Sort Column Direction ( asc ,desc)  
                String sortColumnDirection = formData["order[0][dir]"].FirstOrDefault();
                Logger.LogInformation($"sortcoldirection is {sortColumnDirection}");
                // Search Value from (Search box)  
                String searchValue = formData["search[value]"].FirstOrDefault();
                Logger.LogInformation($"searchvalue is {searchValue}");
                //Paging Size (10,20,50,100)  
                Int32 pageSize = length != null ? Convert.ToInt32(length) : 0;
                Int32 skip = start != null ? Convert.ToInt32(start) : 0;
                Int32 recordsTotal = 0;

                recordsTotal = queryData.Count();

                // Filtering
                if (whereClause != null)
                {
                    queryData = queryData.AsQueryable().Where(whereClause);
                }

                // Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    queryData = queryData.OrderBy(sortColumn, sortColumnDirection).ToList();
                }

                //Paging   
                queryData = queryData.Skip(skip).Take(pageSize).ToList();
                Logger.LogInformation($"querydata count is {queryData.Count()}");
                // Build the result 
                result = new DataTablesResult<T>
                         {
                             Data = queryData,
                             Draw = int.Parse(draw),
                             RecordsTotal = recordsTotal,
                             RecordsFiltered = queryData.Count()
                         };
            }

            return result;
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

        #endregion
    }
}