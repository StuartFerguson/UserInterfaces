namespace GolfHandicapMobile.Common
{
    using System;
    using System.Net.Http;
    using GolfClubAdminWebSite.Services;
    using ManagementAPI.Service.Client;
    using Pages;
    using Presenters;
    using Unity;
    using Unity.Injection;
    using Unity.Lifetime;
    using ViewModels;
    using Views;

    /// <summary>
    /// 
    /// </summary>
    public class Bootstrapper
    {
        #region Methods

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Run()
        {
            UnityContainer unityContainer = new UnityContainer();

            String managementAPIUri = string.Empty;
            String securityServiceAPIUri = string.Empty;

            // TODO: Setup configuration
            managementAPIUri = "http://3.9.26.155:9000";
            securityServiceAPIUri = "http://3.9.26.155:9000";

            Configuration configuration = new Configuration
                                          {
                                              ManagementAPI = managementAPIUri,
                                              SecurityServiceAPI = securityServiceAPIUri
                                          };

            unityContainer.RegisterInstance<IConfiguration>(configuration, new SingletonLifetimeManager());

            // Presentation registrations
            unityContainer.RegisterType<IHomePagePresenter, HomePagePresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegistrationPresenter, RegistrationPresenter>(new TransientLifetimeManager());

            // View registrations
            unityContainer.RegisterType<IHomePage, HomePage>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IRegistrationPage, RegistrationPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegistrationSuccessPage, RegistrationSuccessPage>(new TransientLifetimeManager());

            // View model registrations
            unityContainer.RegisterType<RegistrationViewModel>(new TransientLifetimeManager());

            // Other registrations
            unityContainer.RegisterType<IClient, ApiClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IPlayerClient, PlayerClient>(new SingletonLifetimeManager());

            HttpClient httpClient = new HttpClient();
            unityContainer.RegisterInstance(httpClient, new SingletonLifetimeManager());

            unityContainer.RegisterType<Func<String, String>>(new InjectionFactory(c => new Func<String, String>(configSetting =>
                                                                                                                 {
                                                                                                                     IConfiguration config =
                                                                                                                         unityContainer.Resolve<IConfiguration>();

                                                                                                                     if (configSetting == "ManagementAPI")
                                                                                                                     {
                                                                                                                         return config.ManagementAPI;
                                                                                                                     }

                                                                                                                     if (configSetting == "SecurityServiceAPI")
                                                                                                                     {
                                                                                                                         return config.SecurityServiceAPI;
                                                                                                                     }

                                                                                                                     return string.Empty;
                                                                                                                 })));

            return unityContainer;
        }

        #endregion
    }
}