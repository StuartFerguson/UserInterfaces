namespace GolfClubAdminWebSite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using GolfClubAdminWebSite.Bootstrapper;
    using IdentityModel;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using NLog.Extensions.Logging;
    using Shared.Extensions;
    using Shared.General;
    using StructureMap;

    [ExcludeFromCodeCoverage]
    public class Startup
    {
        #region Constructors

        public Startup(IConfiguration configuration,
                       IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                                                                      .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                                                                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true).AddEnvironmentVariables();

            Startup.Configuration = builder.Build();
            Startup.HostingEnvironment = env;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Gets or sets the hosting environment.
        /// </summary>
        /// <value>
        /// The hosting environment.
        /// </value>
        public static IHostingEnvironment HostingEnvironment { get; set; }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            String nlogConfigFilename = "nlog.config";
            if (string.Compare(Startup.HostingEnvironment.EnvironmentName, "Development", true) == 0)
            {
                nlogConfigFilename = $"nlog.{Startup.HostingEnvironment.EnvironmentName}.config";
            }

            loggerFactory.AddConsole();
            loggerFactory.ConfigureNLog(Path.Combine(Startup.HostingEnvironment.ContentRootPath, nlogConfigFilename));
            loggerFactory.AddNLog();

            ILogger logger = loggerFactory.CreateLogger("GolfClubAdminWebsite");

            Logger.Initialise(logger);
            Logger.LogInformation("Hello from Logger.");

            ConfigurationReader.Initialise(Startup.Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.AddRequestLogging();
            app.AddResponseLogging();

            app.UseMvc(routes =>
                       {
                           routes.MapAreaRoute(name:"Account", areaName:"Account", template:"Account/{controller=Home}/{action=Index}/{id?}");
                           routes.MapAreaRoute(name:"GolfClubAdministrator", areaName:"GolfClubAdministrator", template:"GolfClubAdministrator/{controller=Home}/{action=Index}/{id?}");
                           routes.MapAreaRoute(name: "MatchSecretary", areaName: "MatchSecretary", template: "MatchSecretary/{controller=Home}/{action=Index}/{id?}");

                           routes.MapRoute(name:"default", template:"{controller=Home}/{action=Index}/{id?}");
                       });
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Startup.ConfigureMiddlewareServices(services);

            IContainer container = Startup.GetConfiguredContainer(services, Startup.HostingEnvironment);

            return container.GetInstance<IServiceProvider>();
        }

        /// <summary>
        /// Gets the configured container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        /// <returns></returns>
        public static IContainer GetConfiguredContainer(IServiceCollection services,
                                                        IHostingEnvironment hostingEnvironment)
        {
            Container container = new Container();

            container.Configure(config =>
                                {
                                    config.AddRegistry<CommonRegistry>();

                                    //if (HostingEnvironment.IsDevelopment())
                                    //{
                                    //    config.AddRegistry<DevelopmentRegistry>();
                                    //}

                                    config.Populate(services);
                                });

            Startup.Container = container;

            return container;
        }

        private static void ConfigureMiddlewareServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            services.Configure<CookiePolicyOptions>(options =>
                                                    {
                                                        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                                                        options.CheckConsentNeeded = context => true;
                                                        options.MinimumSameSitePolicy = SameSiteMode.None;
                                                    });

            
            services.AddAuthentication(options =>
                                       {
                                           options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                                           options.DefaultChallengeScheme = "oidc";
                                       }).AddCookie(options =>
                                                    {
                                                        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                                                        options.Cookie.Name = "golfclubadminwebsite";
                                                    }).AddOpenIdConnect("oidc",
                                                                        options =>
                                                                        {
                                                                            options.Authority = ConfigurationReader.GetValue("AppSettings", "SecurityService");
                                                                            options.RequireHttpsMetadata = false;

                                                                            options.ClientSecret = ConfigurationReader.GetValue("AppSettings", "ClientSecret");
                                                                            options.ClientId = ConfigurationReader.GetValue("AppSettings", "ClientId");

                                                                            options.ResponseType = "code id_token";

                                                                            options.Scope.Clear();
                                                                            options.Scope.Add("openid");
                                                                            options.Scope.Add("profile");
                                                                            options.Scope.Add("email");
                                                                            options.Scope.Add("offline_access");
                                                                            options.Scope.Add("managementapi");

                                                                            options.ClaimActions.MapAllExcept("iss", "nbf", "exp", "aud", "nonce", "iat", "c_hash");
                                                                            options.GetClaimsFromUserInfoEndpoint = true;
                                                                            options.SaveTokens = true;

                                                                            options.TokenValidationParameters = new TokenValidationParameters
                                                                                                                {
                                                                                                                    NameClaimType = JwtClaimTypes.Name,
                                                                                                                    RoleClaimType = JwtClaimTypes.Role,
                                                                                                                    ValidateIssuer = false
                                                                                                                };
                                                                        });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        #endregion
    }
}