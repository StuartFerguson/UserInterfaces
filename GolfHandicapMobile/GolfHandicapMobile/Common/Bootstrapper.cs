namespace GolfHandicapMobile.Common
{
    using System;
    using System.Net.Http;
    using GolfClubAdminWebSite.Services;
    using ManagementAPI.Service.Client;
    using Pages;
    using Presenters;
    using Services;
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
            //AWS
            //managementAPIUri = "http://3.9.26.155:9000";
            //securityServiceAPIUri = "http://3.9.26.155:9000";
            // Dev
            managementAPIUri = "http://192.168.1.132:9000";
            securityServiceAPIUri = "http://192.168.1.132:9000";
            // Local
            //managementAPIUri = "http://192.168.1.67:9000";
            //securityServiceAPIUri = "http://192.168.1.67:9000";

            Configuration configuration = new Configuration
                                          {
                                              ManagementAPI = managementAPIUri,
                                              SecurityServiceAPI = securityServiceAPIUri
                                          };

            unityContainer.RegisterInstance<IConfiguration>(configuration, new SingletonLifetimeManager());

            // Presentation registrations
            unityContainer.RegisterType<ISignInPresenter, SignInPresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyDetailsPresenter, MyDetailsPresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyMembershipsPresenter, MyMembershipsPresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyTournamentsPresenter, MyTournamentsPresenter>(new TransientLifetimeManager());

            // View registrations
            unityContainer.RegisterType<IRegistrationPage, RegistrationPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignInPage, SignInPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyDetailsPage, MyDetailsPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyMembershipsPage, MyMembershipsPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyMembershipRequestClubListPage, MyMembershipRequestClubListPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyTournamentsPage, MyTournamentsPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<IMyTournamentSignInPage, MyTournamentSignInPage>(new TransientLifetimeManager());

            // View model registrations
            unityContainer.RegisterType<RegistrationViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<SignInViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<MyDetailsViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<MyMembershipsListViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<MyMembershipRequestClubListViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<MyTournamentsViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<TournamentSignInViewModel>(new TransientLifetimeManager());

            // Other registrations
            unityContainer.RegisterType<IClient, ApiClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IPlayerClient, PlayerClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IGolfClubClient, GolfClubClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<ITournamentClient, TournamentClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<ISecurityServiceClient, SecurityServiceClient>(new SingletonLifetimeManager());

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