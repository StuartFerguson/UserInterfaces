﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GolfClubAdminWebSite.IntegrationTests.Common
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Ductus.FluentDocker.Builders;
    using Ductus.FluentDocker.Model.Builders;
    using Ductus.FluentDocker.Services;
    using Ductus.FluentDocker.Services.Extensions;
    using Gherkin;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using TechTalk.SpecFlow;

    [Binding]
    public abstract class GenericSteps
    {
        protected ScenarioContext ScenarioContext;
        protected IContainerService ManagementAPIContainer;
        protected IContainerService SubscriptionServiceContainer;
        protected IContainerService EventStoreContainer;
        protected IContainerService SecurityServiceContainer;
        protected IContainerService MessagingServiceContainer;
        protected IContainerService GolfClubAdminUIContainer;

        protected INetworkService TestNetwork;

        protected Int32 ManagementApiPort;
        protected Int32 EventStorePort;
        //protected Int32 SecurityServicePort;
        protected Int32 MessagingServicePort;
        protected Int32 GolfClubAdminUIPort;
        protected Guid SubscriberServiceId;
        

        private String ManagementAPIContainerName;
        private String EventStoreContainerName;
        private String SecurityServiceContainerName;
        private String SubscriptionServiceContainerName;
        private String MessagingServiceContainerName;
        private String GolfClubAdminUIContainerName;

        private String EventStoreConnectionString;
        private String SecurityServiceAddress;
        private String AuthorityAddress;
        private String SubscriptionServiceConnectionString;
        private String ManagementAPISeedingType;
        private String MessagingServiceAddress;
        private String ManagementAPIAddress;

        protected GenericSteps(ScenarioContext scenarioContext)
        {
            this.ScenarioContext = scenarioContext;
        }

        protected async Task RunSystem(String testFolder)
        {
            Logging.Enabled();

            Guid testGuid = Guid.NewGuid();

            // Setup the container names
            this.ManagementAPIContainerName = $"rest{testGuid:N}";
            this.EventStoreContainerName = $"eventstore{testGuid:N}";
            this.SecurityServiceContainerName = $"auth{testGuid:N}";
            this.SubscriberServiceId = testGuid;
            this.SubscriptionServiceContainerName = $"subService{testGuid:N}";
            this.MessagingServiceContainerName = $"messaging{testGuid:N}";
            this.GolfClubAdminUIContainerName = $"golfclubadminui{testGuid:N}";

            this.EventStoreConnectionString = $"EventStoreSettings:ConnectionString=ConnectTo=tcp://admin:changeit@{this.EventStoreContainerName}:1113;VerboseLogging=true;";
            this.SecurityServiceAddress = $"AppSettings:OAuth2SecurityService=http://{this.SecurityServiceContainerName}:5001";
            this.AuthorityAddress = $"SecurityConfiguration:Authority=http://{this.SecurityServiceContainerName}:5001";
            this.SubscriptionServiceConnectionString = $"\"ConnectionStrings:SubscriptionServiceConfigurationContext={Setup.GetConnectionString("SubscriptionServiceConfiguration")}\"";
            this.ManagementAPISeedingType = "SeedingType=IntegrationTest";
            this.MessagingServiceAddress = $"ServiceAddresses:MessagingService=http://{this.MessagingServiceContainerName}:5002";
            this.MessagingServiceAddress = $"ServiceAddresses:MessagingService=http://{this.MessagingServiceContainerName}:5002";
            this.ManagementAPIAddress = $"AppSettings:ManagementAPI=http://{this.ManagementAPIContainerName}:5000";

            this.SetupTestNetwork();
            this.SetupSecurityServiceContainer(testFolder);
            this.SetupManagementAPIContainer(testFolder);
            this.SetupEventStoreContainer(testFolder);
            this.SetupSubscriptionServiceContainer(testFolder);
            this.SetupMessagingService(testFolder);
            this.SetupGolfClubAdminUIContainer(testFolder);

            // Cache the ports
            this.GolfClubAdminUIPort = this.GolfClubAdminUIContainer.ToHostExposedEndpoint("5005/tcp").Port;

            this.SetupSubscriptionServiceConfig();
        }

        private void SetupGolfClubAdminUIContainer(String testFolder)
        {
            this.GolfClubAdminUIContainer = new Builder()
                                          .UseContainer()
                                          .WithName(this.GolfClubAdminUIContainerName)
                                          .WithEnvironment(this.ManagementAPIAddress)
                                          .UseImage("golfclubadminwebsite")
                                          .ExposePort(5005)
                                          .UseNetwork(new List<INetworkService> { this.TestNetwork, Setup.DatabaseServerNetwork }.ToArray())
                                          .Mount($"D:\\temp\\docker\\{testFolder}", "/home", MountType.ReadWrite)
                                          .Build()
                                          .Start().WaitForPort("5005/tcp", 30000);
        }

        protected void StopSystem()
        {
            try
            {
                if (this.GolfClubAdminUIContainer != null)
                {
                    this.GolfClubAdminUIContainer.StopOnDispose = true;
                    this.GolfClubAdminUIContainer.RemoveOnDispose = true;
                    this.GolfClubAdminUIContainer.Dispose();
                }

                if (this.ManagementAPIContainer != null)
                {
                    this.ManagementAPIContainer.StopOnDispose = true;
                    this.ManagementAPIContainer.RemoveOnDispose = true;
                    this.ManagementAPIContainer.Dispose();
                }

                if (this.MessagingServiceContainer != null)
                {
                    this.MessagingServiceContainer.StopOnDispose = true;
                    this.MessagingServiceContainer.RemoveOnDispose = true;
                    this.MessagingServiceContainer.Dispose();
                }

                if (this.EventStoreContainer != null)
                {
                    this.EventStoreContainer.StopOnDispose = true;
                    this.EventStoreContainer.RemoveOnDispose = true;
                    this.EventStoreContainer.Dispose();
                }

                if (this.SecurityServiceContainer != null)
                {
                    this.SecurityServiceContainer.StopOnDispose = true;
                    this.SecurityServiceContainer.RemoveOnDispose = true;
                    this.SecurityServiceContainer.Dispose();
                }

                if (this.SubscriptionServiceContainer != null)
                {
                    this.SubscriptionServiceContainer.StopOnDispose = true;
                    this.SubscriptionServiceContainer.RemoveOnDispose = true;
                    this.SubscriptionServiceContainer.Dispose();
                }

                if (this.TestNetwork != null)
                {
                    this.TestNetwork.Stop();
                    this.TestNetwork.Remove(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected void SetupSubscriptionServiceConfig()
        {
            IPEndPoint mysqlEndpoint = Setup.DatabaseServerContainer.ToHostExposedEndpoint("3306/tcp");

            String server = "127.0.0.1";
            String database = "SubscriptionServiceConfiguration";
            String user = "root";
            String password = "Pa55word";
            String port = mysqlEndpoint.Port.ToString();
            String sslM = "none";

            String connectionString = $"server={server};port={port};user id={user}; password={password}; database={database}; SslMode={sslM}";

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // Insert the subscription service
            SubscriptionServiceHelper.CreateSubscriptionService(connection, this.SubscriberServiceId, "Test Service");

            // Create the Endpoints
            Guid golfClubEndpointId = Guid.NewGuid();
            String golfClubEndpointUrl = $"http://{this.ManagementAPIContainer.Name}:5000/api/DomainEvent/GolfClub";
            SubscriptionServiceHelper.CreateEndpoint(connection, golfClubEndpointId, "Golf Club Read Model", golfClubEndpointUrl);

            Guid golfClubMembershipEndpointId = Guid.NewGuid();
            String golfClubMembershipEndpointUrl = $"http://{this.ManagementAPIContainer.Name}:5000/api/DomainEvent/GolfClubMembership";
            SubscriptionServiceHelper.CreateEndpoint(connection, golfClubMembershipEndpointId, "Golf Club Membership Read Model", golfClubMembershipEndpointUrl);

            Guid tournamentEndpointId = Guid.NewGuid();
            String tournamentEndpointUrl = $"http://{this.ManagementAPIContainer.Name}:5000/api/DomainEvent/Tournament";
            SubscriptionServiceHelper.CreateEndpoint(connection, tournamentEndpointId, "Tournament Read Model", tournamentEndpointUrl);

            Guid handicapCalculatorEndpointId = Guid.NewGuid();
            String handicapCalculatorEndpointUrl = $"http://{this.ManagementAPIContainer.Name}:5000/api/DomainEvent/HandicapCalculator";
            SubscriptionServiceHelper.CreateEndpoint(connection, handicapCalculatorEndpointId, "Handicap Calculator", handicapCalculatorEndpointUrl);

            // Create the Streams
            Guid categoryGolfClubAggregateStream = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionStream(connection, categoryGolfClubAggregateStream, "$ce-GolfClubAggregate");

            Guid categoryGolfClubMembershipAggregateStream = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionStream(connection, categoryGolfClubMembershipAggregateStream, "$ce-GolfClubMembershipAggregate");

            Guid categoryTournamentAggregateStream = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionStream(connection, categoryTournamentAggregateStream, "$ce-TournamentAggregate");

            Guid categoryHandicapCalculationProcessAggregateStream = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionStream(connection, categoryHandicapCalculationProcessAggregateStream, "$ce-HandicapCalculationProcessAggregate");

            // Create the groups
            Guid subscriptionGroupGolfClubAggregateId = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionGroup(connection, subscriptionGroupGolfClubAggregateId, golfClubEndpointId, "GolfClubAggregate", categoryGolfClubAggregateStream);

            Guid subscriptionGroupGolfClubMembershipAggregateId = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionGroup(connection, subscriptionGroupGolfClubMembershipAggregateId, golfClubMembershipEndpointId, "GolfClubMembershipAggregate", categoryGolfClubMembershipAggregateStream);

            Guid subscriptionGroupTournamentAggregateId = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionGroup(connection, subscriptionGroupTournamentAggregateId, tournamentEndpointId, "TournamentAggregate", categoryTournamentAggregateStream);

            Guid subscriptionHandicapCalculationProcessAggregateId = Guid.NewGuid();
            SubscriptionServiceHelper.CreateSubscriptionGroup(connection, subscriptionHandicapCalculationProcessAggregateId, handicapCalculatorEndpointId, "HandicapCalculationProcessAggregate", categoryHandicapCalculationProcessAggregateStream);

            // Add the groups to the Subscription Service
            SubscriptionServiceHelper.AddSubscriptionGroupToSubscriberService(connection, Guid.NewGuid(), subscriptionGroupGolfClubAggregateId, this.SubscriberServiceId);
            SubscriptionServiceHelper.AddSubscriptionGroupToSubscriberService(connection, Guid.NewGuid(), subscriptionGroupGolfClubMembershipAggregateId, this.SubscriberServiceId);
            SubscriptionServiceHelper.AddSubscriptionGroupToSubscriberService(connection, Guid.NewGuid(), subscriptionGroupTournamentAggregateId, this.SubscriberServiceId);
            SubscriptionServiceHelper.AddSubscriptionGroupToSubscriberService(connection, Guid.NewGuid(), subscriptionHandicapCalculationProcessAggregateId, this.SubscriberServiceId);

            connection.Close();
        }

        protected async Task<HttpResponseMessage> MakeHttpPost<T>(String requestUri, T requestObject, String bearerToken = "", String mediaType = "application/json")
        {
            HttpResponseMessage result = null;
            StringContent httpContent = null;
            if (requestObject is String)
            {
                httpContent = new StringContent(requestObject.ToString(), Encoding.UTF8, mediaType);
            }
            else
            {
                String requestSerialised = JsonConvert.SerializeObject(requestObject);
                httpContent = new StringContent(requestSerialised, Encoding.UTF8, mediaType);
            }

            using (HttpClient client = new HttpClient())
            {
                if (!String.IsNullOrEmpty(bearerToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                }

                result = await client.PostAsync(requestUri, httpContent, CancellationToken.None).ConfigureAwait(false);
            }

            return result;
        }

        protected async Task<T> GetResponseObject<T>(HttpResponseMessage responseMessage)
        {
            T result = default(T);

            result = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }
        
        private void SetupTestNetwork()
        {
            // Build a network
            this.TestNetwork = new Builder().UseNetwork($"testnetwork{Guid.NewGuid()}").Build();
        }

        private void SetupSecurityServiceContainer(String testFolder)
        {
            // Security Service Container
            this.SecurityServiceContainer = new Builder()
                .UseContainer()
                .WithName(this.SecurityServiceContainerName)
                .WithEnvironment("SeedingType=IntegrationTest", "ASPNETCORE_ENVIRONMENT=IntegrationTest",
                    $"ServiceOptions:PublicOrigin=http://{this.SecurityServiceContainerName}:5001",
                    $"ServiceOptions:IssuerUrl=http://{this.SecurityServiceContainerName}:5001",
                    this.MessagingServiceAddress)
                .WithCredential("https://www.docker.com", "stuartferguson", "Sc0tland")
                .UseImage("stuartferguson/oauth2securityserviceservice")
                .ExposePort(5001)
                .UseNetwork(this.TestNetwork)
                .Mount($"D:\\temp\\docker\\{testFolder}", "/home", MountType.ReadWrite)
                .Build()
                .Start()
                .WaitForPort("5001/tcp", 30000);
        }

        private void SetupManagementAPIContainer(String testFolder)
        {
            // Management API Container
            this.ManagementAPIContainer = new Builder()
                .UseContainer()
                .WithName(this.ManagementAPIContainerName)
                .WithEnvironment("ASPNETCORE_ENVIRONMENT=IntegrationTest",
                    this.EventStoreConnectionString,
                    this.SecurityServiceAddress,
                    this.ManagementAPISeedingType,
                    this.AuthorityAddress,
                    "EventStoreSettings:START_PROJECTIONS=true",
                    "EventStoreSettings:ContinuousProjectionsFolder=/app/projections/continuous")
                .WithCredential("https://www.docker.com", "stuartferguson", "Sc0tland")
                .UseImage("stuartferguson/managementapi")
                .ExposePort(5000)
                .UseNetwork(new List<INetworkService> { this.TestNetwork, Setup.DatabaseServerNetwork }.ToArray())
                .Mount($"D:\\temp\\docker\\{testFolder}", "/home", MountType.ReadWrite)
                .Build()
                .Start().WaitForPort("5000/tcp", 30000);
        }

        /// <summary>
        /// Setups the messaging service.
        /// </summary>
        /// <param name="testFolder">The test folder.</param>
        private void SetupMessagingService(String testFolder)
        {
            this.MessagingServiceContainer = new Builder()
                                             .UseContainer()
                                             .WithName(this.MessagingServiceContainerName)
                                             .WithEnvironment("ASPNETCORE_ENVIRONMENT=IntegrationTest")
                                             .WithCredential("https://www.docker.com", "stuartferguson", "Sc0tland")
                                             .UseImage("stuartferguson/messagingservice")
                                             .ExposePort(5002)
                                             .UseNetwork(this.TestNetwork)
                                             .Mount($"D:\\temp\\docker\\{testFolder}", "/home", MountType.ReadWrite)
                                             .Build()
                                             .Start()
                                             .WaitForPort("5002/tcp", 30000);
        }

        private void SetupEventStoreContainer(String testFolder)
        {
            // Event Store Container
            this.EventStoreContainer = new Builder()
                .UseContainer()
                .UseImage("eventstore/eventstore:release-5.0.0")
                .ExposePort(2113)
                .ExposePort(1113)
                .WithName(this.EventStoreContainerName)
                .WithEnvironment("EVENTSTORE_RUN_PROJECTIONS=all", "EVENTSTORE_START_STANDARD_PROJECTIONS=true")
                .UseNetwork(this.TestNetwork)
                .Mount($"D:\\temp\\docker\\{testFolder}\\eventstore", "/var/log/eventstore", MountType.ReadWrite)
                .Build()
                .Start().WaitForPort("2113/tcp", 30000);
        }

        private void SetupSubscriptionServiceContainer(String testFolder)
        {
            // Subscriber Service Container
            this.SubscriptionServiceContainer = new Builder()
                .UseContainer()
                .WithName(this.SubscriptionServiceContainerName)
                .WithEnvironment("ASPNETCORE_ENVIRONMENT=Development",
                    this.SubscriptionServiceConnectionString,
                    this.EventStoreConnectionString,
                    "EventStoreSettings:HttpPort=2113",
                    $"ServiceSettings:SubscriptionServiceId={this.SubscriberServiceId}")
                .WithCredential("https://docker.io", "stuartferguson", "Sc0tland")
                .UseImage("stuartferguson/subscriptionservice")
                .UseNetwork(new List<INetworkService> { this.TestNetwork, Setup.DatabaseServerNetwork }.ToArray())
                .Mount($"D:\\temp\\docker\\{testFolder}", "/home", MountType.ReadWrite)
                .Build()
                .Start();
        }
    }
}
