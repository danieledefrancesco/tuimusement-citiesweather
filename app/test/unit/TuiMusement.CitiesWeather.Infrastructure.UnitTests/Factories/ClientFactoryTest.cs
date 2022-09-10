using System.Net.Http;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Infrastructure.Configurations;
using TuiMusement.CitiesWeather.Infrastructure.Factories;
using TuiMusement.CitiesWeather.CitiesServiceClient;

namespace TuiMusement.CitiesWeather.Infrastructure.UnitTests.Factories
{
    public class ClientFactoryTest
    {
        private ClientFactory<ICitiesServiceClient, CitiesServiceConfiguration>? _clientFactory;
        private CitiesServiceConfiguration? _citiesServiceConfiguration;
        private HttpClient? _httpClient;

        [SetUp]
        public void SetUp()
        {
            _citiesServiceConfiguration = new CitiesServiceConfiguration();
            var options = Substitute.For<IOptions<CitiesServiceConfiguration>>();
            options.Value.Returns(_citiesServiceConfiguration);
            _httpClient = Substitute.For<HttpClient>();
            _clientFactory = new ClientFactory<ICitiesServiceClient, CitiesServiceConfiguration>(_httpClient, options);
        }

        [Test]
        public void Create_ShouldReturnClient()
        {
            //arrange
            _citiesServiceConfiguration!.BaseUrl = "http://baseurl";
            
            //act
            var actualResult = _clientFactory!.Create();
            
            //assert
            actualResult.Should().NotBeNull();
        }
    }
}