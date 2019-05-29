using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Controllers
{
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using ManagementAPI.Service.Client;
    using ManagementAPI.Service.DataTransferObjects;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Models;
    using Newtonsoft.Json;
    using NLog.Layouts;
    using Remotion.Linq.Clauses;
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

        private Boolean ValidateModel(MeasuredCourseViewModel model)
        {
            return this.ModelState.IsValid;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasuredCourseList(CancellationToken cancellationToken)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> GetMeasuredCourseListAsJson(CancellationToken cancellationToken)
        {
            Logger.LogInformation("In method GetMeasuredCourseListAsJson");
            // Search Value from (Search box)  
            String searchValue = HttpContext.Request.Form["search[value]"].FirstOrDefault();
            Logger.LogInformation($"searchvalue is {searchValue}");
            String accessToken = await this.HttpContext.GetTokenAsync("access_token");
            Logger.LogInformation($"got access token");
            List<MeasuredCourseListViewModel> measuredCourseList = await this.ApiClient.GetMeasuredCourses(accessToken, cancellationToken);
            Logger.LogInformation($"course list count is {measuredCourseList.Count}");
            Expression<Func<MeasuredCourseListViewModel, Boolean>> whereClause = m => m.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                      m.TeeColour.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                                                      m.StandardScratchScore.ToString().Contains(searchValue);
            var gimp = this.GetDataForDataTable(measuredCourseList, whereClause);
            Logger.LogInformation($"gimp count is {gimp.Data.Count()}");
            String jsonResult = JsonConvert.SerializeObject(gimp);
            Logger.LogInformation(jsonResult);
            return this.Json(this.GetDataForDataTable(measuredCourseList, whereClause));
        }

        [HttpGet]
        public async Task<IActionResult> NewMeasuredCourse(CancellationToken cancellationToken)
        {
            MeasuredCourseViewModel viewModel = new MeasuredCourseViewModel();
            
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewMeasuredCourse(MeasuredCourseViewModel model, CancellationToken cancellationToken)
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

        private DataTablesResult<T> GetDataForDataTable<T>(IEnumerable<T> queryData,
                                                           Expression<Func<T, Boolean>> whereClause = null)
        {
            DataTablesResult<T> result;
            
            IFormCollection formData = HttpContext.Request.Form;

            if (formData == null)
            {
                result = null;
            }
            else
            {
                Logger.LogInformation($"got form");
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
                if (!(String.IsNullOrEmpty(sortColumn) && String.IsNullOrEmpty(sortColumnDirection)))
                {
                    queryData = queryData.OrderBy(sortColumn ,sortColumnDirection).ToList();
                }

                //Paging   
                queryData = queryData.Skip(skip).Take(pageSize).ToList();
                Logger.LogInformation($"querydata count is {queryData.Count()}");
                // Build the result 
                result = new DataTablesResult<T>
                         {
                             Data = queryData,
                             Draw = Int32.Parse(draw),
                             RecordsTotal = recordsTotal,
                             RecordsFiltered = queryData.Count()
                         };
            }
            return result;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable,
                                         String orderByColumn,
                                         String orderByDirection)
        {
            var gimp = typeof(T).GetProperty(orderByColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (orderByDirection == "asc")
            {
                return enumerable.OrderBy(x => gimp.GetValue(x, null));
            }
            else
            {
                return enumerable.OrderByDescending(x => gimp.GetValue(x, null));
            }
        }

        public static IEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> enumerable,
                                                String orderByColumn,
                                                String orderByDirection)
        {
            var gimp = typeof(T).GetProperty(orderByColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (orderByDirection == "asc")
            {
                return enumerable.ThenBy(x => gimp.GetValue(x, null));
            }
            else
            {
                return enumerable.ThenByDescending(x => gimp.GetValue(x, null));
            }
        }
    }

    public class DataTablesResult<T>
    {
        [JsonProperty("draw")]
        public Int32 Draw { get; set; }
        [JsonProperty("recordsFiltered")]
        public Int32 RecordsFiltered { get; set; }
        [JsonProperty("recordsTotal")]
        public Int32 RecordsTotal { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}