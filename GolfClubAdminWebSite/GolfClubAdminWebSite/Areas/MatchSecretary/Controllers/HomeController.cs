namespace GolfClubAdminWebSite.Areas.MatchSecretary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

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
        public IActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}