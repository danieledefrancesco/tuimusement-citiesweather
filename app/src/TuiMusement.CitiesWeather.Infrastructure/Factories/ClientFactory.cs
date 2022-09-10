using System;
using System.Collections;
using System.Net.Http;
using Microsoft.Extensions.Options;
using TuiMusement.CitiesWeather.CitiesServiceClient;
using TuiMusement.CitiesWeather.Infrastructure.Configurations;

namespace TuiMusement.CitiesWeather.Infrastructure.Factories
{
    public class ClientFactory<TClient, TConfig>: IClientFactory<TClient> where TConfig : class, IBaseUrlConfig
    {
        private readonly HttpClient _httpClient;
        private readonly TConfig _configuration;

        public ClientFactory(HttpClient httpClient, IOptions<TConfig> configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration.Value;
        }

        public virtual TClient Create()
        {
            _httpClient.BaseAddress = new Uri(_configuration.BaseUrl);
            return new RestEase.RestClient(_httpClient).For<TClient>();
        }
    }
}