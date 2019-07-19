namespace GolfClubAdminWebSite.Bootstrapper
{
    using System;
    using Factories;
    using ManagementAPI.Service.Client;
    using Microsoft.Extensions.Configuration;
    using GolfClubAdminWebSite;
    using Services;
    using Shared.General;
    using StructureMap;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StructureMap.Registry" />
    public class CommonRegistry : Registry
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRegistry"/> class.
        /// </summary>
        public CommonRegistry()
        {
            Func<String, String> baseAddressResolver = address => { return Startup.Configuration.GetValue<String>($"AppSettings:{address}"); ; };

            this.For<Func<String, String>>().Use(baseAddressResolver);
            this.For<IGolfClubClient>().Use<GolfClubClient>();
            this.For<IClient>().Use<ApiClient>();
            this.For<IModelFactory>().Use<ModelFactory>();
        }

        #endregion
    }
}