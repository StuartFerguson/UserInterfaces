namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
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
    [Area("GolfClubAdministrator")]
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
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        public HomeController(IClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateGolfClub(CancellationToken cancellationToken)
        {
            return this.View();
        }

        /// <summary>
        /// Creates the golf club.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGolfClub(CreateGolfClubViewModel model,
                                                        CancellationToken cancellationToken)
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

        /// <summary>
        /// Edits the golf club.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditGolfClub(CancellationToken cancellationToken)
        {
            String accessToken = await this.HttpContext.GetTokenAsync("access_token");

            UpdateGolfClubViewModel golfClubDetails = await this.ApiClient.GetGolfClub(accessToken, cancellationToken);

            return this.View(golfClubDetails);
        }

        /// <summary>
        /// Gets the measured course list.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMeasuredCourseList(CancellationToken cancellationToken)
        {
            return this.View();
        }

        /// <summary>
        /// Gets the measured course list as json.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetMeasuredCourseListAsJson(CancellationToken cancellationToken)
        {
            Logger.LogDebug("In method GetMeasuredCourseListAsJson");

            // Search Value from (Search box)  
            String searchValue = this.HttpContext.Request.Form["search[value]"].FirstOrDefault();
            Logger.LogDebug($"searchvalue is {searchValue}");

            String accessToken = await this.HttpContext.GetTokenAsync("access_token");
            Logger.LogDebug("got access token");

            List<MeasuredCourseListViewModel> measuredCourseList = await this.ApiClient.GetMeasuredCourses(accessToken, cancellationToken);
            Logger.LogDebug($"course list count is {measuredCourseList.Count}");

            Expression<Func<MeasuredCourseListViewModel, Boolean>> whereClause = m => m.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                      m.TeeColour.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                      m.StandardScratchScore.ToString().Contains(searchValue);
            DataTablesResult<MeasuredCourseListViewModel> dataTableResult = this.GetDataForDataTable(measuredCourseList, whereClause);

            String jsonResult = JsonConvert.SerializeObject(dataTableResult);
            Logger.LogDebug(jsonResult);

            return this.Json(this.GetDataForDataTable(measuredCourseList, whereClause));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersList(CancellationToken cancellationToken)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserListAsJson(CancellationToken cancellationToken)
        {
            Logger.LogDebug("In method GetUserListAsJson");

            // Search Value from (Search box)  
            String searchValue = this.HttpContext.Request.Form["search[value]"].FirstOrDefault();
            Logger.LogDebug($"searchvalue is {searchValue}");

            String accessToken = await this.HttpContext.GetTokenAsync("access_token");
            Logger.LogDebug("got access token");

            List<GetGolfClubUserListViewModel> userList = await this.ApiClient.GetUserList(accessToken, cancellationToken);
            Logger.LogDebug($"user list count is {userList.Count}");

            Expression<Func<GetGolfClubUserListViewModel, Boolean>> whereClause = m => m.PhoneNumber.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                  m.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                  m.UserType.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                  m.FullName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                  m.UserName.Contains(searchValue, StringComparison.OrdinalIgnoreCase);


            DataTablesResult<GetGolfClubUserListViewModel> dataTableResult = this.GetDataForDataTable(userList, whereClause);

            String jsonResult = JsonConvert.SerializeObject(dataTableResult);
            Logger.LogDebug(jsonResult);

            return this.Json(this.GetDataForDataTable(userList, whereClause));
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Manages the golf club.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates new measuredcourse.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> NewMeasuredCourse(CancellationToken cancellationToken)
        {
            MeasuredCourseViewModel viewModel = new MeasuredCourseViewModel();

            return this.View(viewModel);
        }

        /// <summary>
        /// Creates new measuredcourse.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> NewMeasuredCourse(MeasuredCourseViewModel model,
                                                           CancellationToken cancellationToken)
        {
            model.MeasuredCourseId = Guid.NewGuid();
            // Validate the model
            if (this.ValidateModel(model))
            {
                String accessToken = await this.HttpContext.GetTokenAsync("access_token");

                // All good with model, call the client to create the golf club
                await this.ApiClient.CreateMeasuredCourse(accessToken, model, cancellationToken);

                // GOlf Club Created, redirect to the Club Details screen
                return this.RedirectToAction(nameof(this.GetMeasuredCourseList));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
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
        private Boolean ValidateModel(CreateGolfClubViewModel model)
        {
            return this.ModelState.IsValid;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        private Boolean ValidateModel(MeasuredCourseViewModel model)
        {
            return this.ModelState.IsValid;
        }

        private Boolean ValidateModel(CreateGolfClubUserViewModel model)
        {
            return this.ModelState.IsValid;
        }

        [HttpGet]
        public async Task<IActionResult> CreateMatchSecretaryUser(CancellationToken cancellationToken)
        {
            CreateGolfClubUserViewModel model = new CreateGolfClubUserViewModel();

            return this.View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMatchSecretaryUser(CreateGolfClubUserViewModel model, CancellationToken cancellationToken)
        {
            //// Validate the model
            if (this.ValidateModel(model))
            {
                String accessToken = await this.HttpContext.GetTokenAsync("access_token");

                // All good with model, call the client to create the golf club
                await this.ApiClient.CreateMatchSecretary(accessToken, model, cancellationToken);

                // GOlf Club Created, redirect to the Club Details screen
                return this.RedirectToAction(nameof(this.GetUsersList));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="orderByColumn">The order by column.</param>
        /// <param name="orderByDirection">The order by direction.</param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable,
                                                String orderByColumn,
                                                String orderByDirection)
        {
            var gimp = typeof(T).GetProperty(orderByColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (orderByDirection == "asc")
            {
                return enumerable.OrderBy(x => gimp.GetValue(x, null));
            }

            return enumerable.OrderByDescending(x => gimp.GetValue(x, null));
        }

        /// <summary>
        /// Thens the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="orderByColumn">The order by column.</param>
        /// <param name="orderByDirection">The order by direction.</param>
        /// <returns></returns>
        public static IEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> enumerable,
                                               String orderByColumn,
                                               String orderByDirection)
        {
            var gimp = typeof(T).GetProperty(orderByColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (orderByDirection == "asc")
            {
                return enumerable.ThenBy(x => gimp.GetValue(x, null));
            }

            return enumerable.ThenByDescending(x => gimp.GetValue(x, null));
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTablesResult<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the draw.
        /// </summary>
        /// <value>
        /// The draw.
        /// </value>
        [JsonProperty("draw")]
        public Int32 Draw { get; set; }

        /// <summary>
        /// Gets or sets the records filtered.
        /// </summary>
        /// <value>
        /// The records filtered.
        /// </value>
        [JsonProperty("recordsFiltered")]
        public Int32 RecordsFiltered { get; set; }

        /// <summary>
        /// Gets or sets the records total.
        /// </summary>
        /// <value>
        /// The records total.
        /// </value>
        [JsonProperty("recordsTotal")]
        public Int32 RecordsTotal { get; set; }

        #endregion
    }
}