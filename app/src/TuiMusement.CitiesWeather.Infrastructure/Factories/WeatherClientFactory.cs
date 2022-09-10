using System.Net.Http;
using Microsoft.Extensions.Options;
using TuiMusement.CitiesWeather.Infrastructure.Configurations;
using TuiMusement.CitiesWeather.WeatherServiceClient;

namespace TuiMusement.CitiesWeather.Infrastructure.Factories
{
    public class WeatherClientFactory: ClientFactory<IWeatherServiceClient, WeatherServiceConfiguration>
    {
        private readonly WeatherServiceConfiguration _configuration;
        
        public WeatherClientFactory(HttpClient httpClient, IOptions<WeatherServiceConfiguration> configuration) : base(httpClient, configuration)
        {
            _configuration = configuration.Value;
        }

        public override IWeatherServiceClient Create()
        {
            var client = base.Create();
            client.Key = _configuration.Key;
            return client;
        }
    }
}