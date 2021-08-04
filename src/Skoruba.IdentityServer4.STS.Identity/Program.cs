using System;
using System.Collections.Generic;
using System.IO;
using Hills.Extensions.Models;
using Hills.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks.MSSqlServer;
using Skoruba.IdentityServer4.Shared.Configuration.Helpers;

namespace Skoruba.IdentityServer4.STS.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            try
            {
                DockerHelpers.ApplyDockerConfiguration(configuration);

                CreateHostBuilder(args, configuration).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IConfiguration GetConfiguration(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("serilog.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"serilog.{environment}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("deploy.appsettings.json", optional: true, reloadOnChange: true);

            if (isDevelopment)
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }

            var configuration = configurationBuilder.Build();

            configuration.AddAzureKeyVaultConfiguration(configurationBuilder);

            configurationBuilder.AddCommandLine(args);
            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostContext, configApp) =>
                 {
                     var configurationRoot = configApp.Build();

                     configApp.AddJsonFile("serilog.json", optional: true, reloadOnChange: true);

                     var env = hostContext.HostingEnvironment;

                     configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                     configApp.AddJsonFile("deploy.appsettings.json", optional: true, reloadOnChange: true);

                     if (env.IsDevelopment())
                     {
                         configApp.AddUserSecrets<Startup>();
                     }

                     configurationRoot.AddAzureKeyVaultConfiguration(configApp);

                     configApp.AddEnvironmentVariables();
                     configApp.AddCommandLine(args);
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var endpointsConfiguration = configuration.GetSection("EndPoints").Get<List<EndPointConfiguration>>();
                    webBuilder.ConfigureKestrel(endpointsConfiguration);
                    //webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);
                    webBuilder.UseKestrel();
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((hostContext, loggerConfig) =>
                {
                    //var sqlc = new MSSqlServerSinkOptions() { TableName = "Log" };
                    //var co = new ColumnOptions();
                    //co.AdditionalColumns.Add(new SqlColumn("LogEvent", System.Data.SqlDbType.VarChar));

                    loggerConfig
                        .ReadFrom.Configuration(hostContext.Configuration)
                        .WriteTo.MSSqlServer(configuration.GetConnectionString("SerilogDbConnection"), sinkOptionsSection: hostContext.Configuration.GetSection("SerilogSink"))
                        .Enrich.WithProperty("ApplicationName", hostContext.HostingEnvironment.ApplicationName);
                })
            .UseWindowsService();


    }

    
}