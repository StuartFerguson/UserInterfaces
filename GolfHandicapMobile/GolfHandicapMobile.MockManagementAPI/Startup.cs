using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HandicapMobile.MockAPI.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace HandicapMobile.MockManagementAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder =
                new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true)
                    .AddEnvironmentVariables();
 
            Startup.Configuration = builder.Build();
        }

        public static IConfiguration Configuration { get; private set; }

        public static IContainer Container { get; private set; }

        public static IContainer GetConfiguredContainer(IServiceCollection services)
        {
            var container = new Container();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            String migrationsAssembly = typeof(MockDatabaseDbContext).GetTypeInfo().Assembly.GetName().Name;
            
            String connectionString = Startup.Configuration.GetConnectionString(nameof(MockDatabaseDbContext));
            services.AddDbContext<MockDatabaseDbContext>(builder =>
                    builder.UseMySql(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddTransient<MockDatabaseDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Mock API", Version = "v1" });
            });

            container.Configure(config =>
            {
                config.Populate(services);
            });
            
            Startup.Container = container;

            return container;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            IContainer container = GetConfiguredContainer(services);
            
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mock API v1");
            });

            this.InitialiseDatabase(app).Wait();
        }

        private async Task InitialiseDatabase(IApplicationBuilder app)
        {
            using(IServiceScope scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                MockDatabaseDbContext mockDatabase = scope.ServiceProvider.GetRequiredService<MockDatabaseDbContext>();
                
                try
                {
                    if (mockDatabase.Database.IsMySql())
                    {
                        mockDatabase.Database.Migrate();
                    }
                
                   // mockDatabase.SaveChanges();
                
                }
                catch (Exception ex)
                {
                    var connString = mockDatabase.Database.GetDbConnection().ConnectionString;

                    Exception newException = new Exception($"Connection String [{connString}]", ex);
                    throw newException;
                }            
            }
        }
    }
}
