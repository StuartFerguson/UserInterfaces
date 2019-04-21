namespace GolfClubAdminWebSite.IntegrationTests.Common
{
    using System;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Threading;
    using Ductus.FluentDocker.Builders;
    using Ductus.FluentDocker.Services;
    using Ductus.FluentDocker.Services.Extensions;
    using MySql.Data.MySqlClient;
    using Shouldly;
    using TechTalk.SpecFlow;

    /// <summary>
    /// 
    /// </summary>
    [Binding]
    public class Setup
    {
        #region Fields

        /// <summary>
        /// The database server container
        /// </summary>
        public static IContainerService DatabaseServerContainer;

        /// <summary>
        /// The database server network
        /// </summary>
        public static INetworkService DatabaseServerNetwork;

        /// <summary>
        /// The database connection string with no database
        /// </summary>
        private static String DbConnectionStringWithNoDatabase;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns></returns>
        public static String GetConnectionString(String databaseName)
        {
            return $"{Setup.DbConnectionStringWithNoDatabase} database={databaseName};";
        }

        /// <summary>
        /// Globals the setup.
        /// </summary>
        [BeforeTestRun]
        protected static void GlobalSetup()
        {
            ShouldlyConfiguration.DefaultTaskTimeout = TimeSpan.FromMinutes(1);

            // Setup a network for the DB Server
            Setup.DatabaseServerNetwork = new Builder().UseNetwork("sharednetwork").ReuseIfExist().Build();

            // Start the Database Server here
            Setup.DbConnectionStringWithNoDatabase = Setup.StartMySqlContainerWithOpenConnection();
        }

        /// <summary>
        /// Globals the tear down.
        /// </summary>
        [AfterTestRun]
        protected static void GlobalTearDown()
        {
        }

        /// <summary>
        /// Starts my SQL container with open connection.
        /// </summary>
        /// <returns></returns>
        private static String StartMySqlContainerWithOpenConnection()
        {
            String containerName = "shareddatabasemysql";
            Setup.DatabaseServerContainer = new Builder().UseContainer().WithName(containerName).WithCredential("https://docker.io", "stuartferguson", "Sc0tland")
                                                         .UseImage("stuartferguson/subscriptionservicedatabasemysql")
                                                         .WithEnvironment("MYSQL_ROOT_PASSWORD=Pa55word", "MYSQL_ROOT_HOST=%").ExposePort(3306)
                                                         .UseNetwork(Setup.DatabaseServerNetwork).KeepContainer().KeepRunning().ReuseIfExists().Build().Start()
                                                         .WaitForPort("3306/tcp", 30000);

            IPEndPoint mysqlEndpoint = Setup.DatabaseServerContainer.ToHostExposedEndpoint("3306/tcp");

            // Try opening a connection
            Int32 maxRetries = 10;
            Int32 counter = 1;

            String server = "127.0.0.1";
            String database = "SubscriptionServiceConfiguration";
            String user = "root";
            String password = "Pa55word";
            String port = mysqlEndpoint.Port.ToString();
            String sslM = "none";

            String connectionString = $"server={server};port={port};user id={user}; password={password}; database={database}; SslMode={sslM}";

            MySqlConnection connection = new MySqlConnection(connectionString);

            using(StreamWriter sw = new StreamWriter("C:\\Temp\\testlog.log", true))
            {
                while (counter <= maxRetries)
                {
                    try
                    {
                        sw.WriteLine($"Attempt {counter}");
                        sw.WriteLine(DateTime.Now);

                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT * FROM EndPoints";
                        command.ExecuteNonQuery();

                        sw.WriteLine("Connection Opened");

                        connection.Close();

                        break;
                    }
                    catch(MySqlException ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }

                        sw.WriteLine(ex);
                        Thread.Sleep(20000);
                    }
                    finally
                    {
                        counter++;
                    }
                }
            }

            return $"server={containerName};user id={user}; password={password};";
        }

        #endregion
    }
}