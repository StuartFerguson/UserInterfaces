namespace GolfClubAdminWebSite.Areas.Account.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Area("Account")]
    public class RegistrationController : Controller
    {
        #region Fields

        /// <summary>
        /// The API client
        /// </summary>
        private readonly IClient ApiClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationController"/> class.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        public RegistrationController(IClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the specified return URL.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, String returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterClubAdministratorViewModel model,
                                                  CancellationToken cancellationToken,
                                                  String returnUrl = null)
        {
            // Validate the model
            if (this.ValidateModel(model))
            {
                // All good with model, call the security client to register the user
                await this.ApiClient.RegisterGolfClubAdministrator(model, cancellationToken);

                // Club Administrator registered, redirect to a Login Screen
                return this.RedirectToAction(nameof(this.Registered));
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);            
        }

        /// <summary>
        /// Registereds the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Registered(CancellationToken cancellationToken)
        {
            return this.View();
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        private Boolean ValidateModel(RegisterClubAdministratorViewModel model)
        {
            return this.ModelState.IsValid;
        }

        #endregion
    }
}