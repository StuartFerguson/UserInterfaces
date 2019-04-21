using System;
using System.Collections.Generic;
using System.Text;

namespace GolfClubAdminWebSite.Tests.BootstrapperTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Moq;
    using Shared.EventStore;
    using StructureMap;
    using Xunit;

    public class BootstrapperTests
    {
        [Fact]
        public void VerifyBootstrapperIsValid_Development()
        {
            ServiceCollection servicesCollection = new ServiceCollection();
            Mock<IHostingEnvironment> hostingEnvironment = new Mock<IHostingEnvironment>();
            hostingEnvironment.Setup(he => he.EnvironmentName).Returns("Development");

            Startup.Configuration = this.SetupMemoryConfiguration();
            Startup.HostingEnvironment = hostingEnvironment.Object;

            IContainer container = Startup.GetConfiguredContainer(servicesCollection, hostingEnvironment.Object);

            this.AddTestRegistrations(container);

            container.AssertConfigurationIsValid();
        }

        [Fact]
        public void VerifyBootstrapperIsValid_Production()
        {
            ServiceCollection servicesCollection = new ServiceCollection();
            Mock<IHostingEnvironment> hostingEnvironment = new Mock<IHostingEnvironment>();
            hostingEnvironment.Setup(he => he.EnvironmentName).Returns("Production");

            Startup.Configuration = this.SetupMemoryConfiguration();
            Startup.HostingEnvironment = hostingEnvironment.Object;

            IContainer container = Startup.GetConfiguredContainer(servicesCollection, hostingEnvironment.Object);

            this.AddTestRegistrations(container);

            container.AssertConfigurationIsValid();
        }

        private IConfigurationRoot SetupMemoryConfiguration()
        {
            Dictionary<String, String> configuration = new Dictionary<String, String>();

            IConfigurationBuilder builder = new ConfigurationBuilder();

            configuration.Add("AppSettings:ManagementAPI", "http://3.9.26.155:5000");

            builder.AddInMemoryCollection(configuration);

            return builder.Build();
        }

        private void AddTestRegistrations(IContainer container)
        {
        }
    }
}
