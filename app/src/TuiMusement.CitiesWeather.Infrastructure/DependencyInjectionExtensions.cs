using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using TuiMusement.CitiesWeather.CitiesServiceClient;
using TuiMusement.CitiesWeather.Infrastructure.Configurations;
using TuiMusement.CitiesWeather.Infrastructure.Factories;
using TuiMusement.CitiesWeather.WeatherServiceClient;

namespace TuiMusement.CitiesWeather.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
            IConfiguration configuration) => services
            .AddClientFactory<WeatherClientFactory, IWeatherServiceClient, WeatherServiceConfiguration>(
                configuration.GetSection("WeatherService"))
            .AddClientFactory<ClientFactory<ICitiesServiceClient, CitiesServiceConfiguration>, ICitiesServiceClient, CitiesServiceConfiguration>(
                configuration.GetSection("CitiesService"));

        private static IServiceCollection AddClientFactory<TFactory, TClient, TConfig>(this IServiceCollection services,
            IConfiguration configuration)
        where TFactory: class, IClientFactory<TClient>
        where TClient: class
        where TConfig: class
        {
            services.AddHttpClient<TFactory>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());
            services.AddScoped(sp => sp.GetRequiredService<TFactory>().Create());
            services.Configure<TConfig>(configuration.Bind);
            return services;
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => (int)msg.StatusCode > 399)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                    retryAttempt)));
        }
    }
}