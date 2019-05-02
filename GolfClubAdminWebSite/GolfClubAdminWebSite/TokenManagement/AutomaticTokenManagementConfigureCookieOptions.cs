namespace GolfClubAdminWebSite.TokenManagement.TestClientUserInterface.TokenManagement
{
    using System;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Options.IConfigureNamedOptions{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions}" />
    public class AutomaticTokenManagementConfigureCookieOptions : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        #region Fields

        /// <summary>
        /// The scheme
        /// </summary>
        private readonly AuthenticationScheme Scheme;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomaticTokenManagementConfigureCookieOptions"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public AutomaticTokenManagementConfigureCookieOptions(IAuthenticationSchemeProvider provider)
        {
            this.Scheme = provider.GetDefaultSignInSchemeAsync().GetAwaiter().GetResult();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(CookieAuthenticationOptions options)
        {
        }

        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="name">The name of the options instance being configured.</param>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(String name,
                              CookieAuthenticationOptions options)
        {
            if (name == this.Scheme.Name)
            {
                options.EventsType = typeof(AutomaticTokenManagementCookieEvents);
            }
        }

        #endregion
    }
}