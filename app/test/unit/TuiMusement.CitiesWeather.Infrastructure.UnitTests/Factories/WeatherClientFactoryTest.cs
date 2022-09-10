using System.Net.Http;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Infrastructure.Configurations;
using TuiMusement.CitiesWeather.Infrastructure.Factories;

namespace TuiMusement.CitiesWeather.Infrastructure.UnitTests.Factories
{
    public class WeatherClientFactoryTest
    {
        private WeatherClientFactory? _clientFactory;
        private WeatherServiceConfiguration? _weatherServiceConfiguration;
        private HttpClient? _httpClient;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceConfiguration = new WeatherServiceConfiguration();
            var options = Substitute.For<IOptions<WeatherServiceConfiguration>>();
            options.Value.Returns(_weatherServiceConfiguration);
            _httpClient = Substitute.For<HttpClient>();
            _clientFactory = new WeatherClientFactory(_httpClient, options);

        }

        [Test]
        public void Create_ShouldReturnClientWithKey()
        {
            //arrange
            const string key = "key";
            _weatherServiceConfiguration!.BaseUrl = "http://baseurl";
            _weatherServiceConfiguration!.Key = key;
            
            //act
            var actualResult = _clientFactory!.Create();
            
            //assert
            actualResult.Key.Should().Be(key);
        }
    }
}