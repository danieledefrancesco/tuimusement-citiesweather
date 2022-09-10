using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TuiMusement.CitiesWeather.Application;
using TuiMusement.CitiesWeather.Infrastructure;

namespace TuiMusement.CitiesWeather.Cli
{
    public class ServicesConfigurationRoot
    {
        public static IServiceProvider ServiceProvider { get; } = BuildServiceProvider();

        public static IServiceProvider BuildServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("applicationSettings.json")
                .AddEnvironmentVariables()
                .Build();
            var services = new ServiceCollection();
            services
                .AddScoped<ProgramRunner>()
                .AddSingleton(Console.Out)
                .AddApplicationLayer()
                .AddInfrastructureLayer(configuration)
                .AddLogging(options => options.AddConsole())
                .Configure<LoggerFilterOptions>(configuration.GetSection("Logging")) ;
            return services.BuildServiceProvider();
        }
    }
}