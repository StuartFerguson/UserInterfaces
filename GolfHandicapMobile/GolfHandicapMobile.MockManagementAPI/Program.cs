﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using HandicapMobile.MockManagementAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ManagementAPI.Service
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.Title = "Mock API";
 
            BuildWebHost(args).Run();
        }
 
        public static IWebHost BuildWebHost(String[] args)
        {
            String environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
 
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: false)
                .AddJsonFile($"hosting.{environmentName}.json", optional: true)
                .Build();
 
            IWebHost host = new WebHostBuilder().UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>().Build();
 
            return host;
        }
    }
}
