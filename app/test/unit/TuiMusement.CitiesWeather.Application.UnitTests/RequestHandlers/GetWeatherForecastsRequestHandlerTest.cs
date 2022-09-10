using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Application.RequestHandlers;
using TuiMusement.CitiesWeather.Application.Requests;
using TuiMusement.CitiesWeather.Domain.Entities;
using TuiMusement.CitiesWeather.Domain.ValueObjects;
using TuiMusement.CitiesWeather.WeatherServiceClient;
using TuiMusement.CitiesWeather.WeatherServiceClient.Models;

namespace TuiMusement.CitiesWeather.Application.UnitTests.RequestHandlers
{
    public class GetWeatherForecastsRequestHandlerTest
    {
        private GetWeatherForecastRequestHandler? _getCityWeatherRequestHandler;
        private IWeatherServiceClient? _weatherServiceClient;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceClient = Substitute.For<IWeatherServiceClient>();
            _getCityWeatherRequestHandler = new GetWeatherForecastRequestHandler(_weatherServiceClient);
        }

        [Test]
        public async Task Handle_ShouldReturnSuccessfulResponse_IfClientReturnsValidResponse()
        {
            //arrange
            const double cityLatitude = 1;
            const double cityLongitude = -1;
            const int conditionCode = 3;
            const string conditionText = nameof(conditionText);
            const string conditionIcon = nameof(conditionIcon);
            var date = DateTime.Parse("2000-01-01");
            const int cityId = 1;

            
            var weatherDto = new WeatherForecastResponseDto
            {
                Location = new WeatherLocationDto
                {
                    Latitude = cityLatitude,
                    Longitude = cityLongitude
                },
                Forecast = new WeatherForecastInfoDto
                {
                    ForecastDay = new[]
                    {
                        new WeatherForecastDailyInfo
                        {
                            Date = date,
                            Day = new WeatherInfoDto
                            {
                                Condition = new WeatherConditionDto
                                {
                                    Code = conditionCode,
                                    Icon = conditionIcon,
                                    Text = conditionText
                                }
                            }
                        }
                    }
                }
            };
            var weatherResponse =
                new RestEase.Response<WeatherForecastResponseDto>(string.Empty, new HttpResponseMessage(), () => weatherDto);
            _weatherServiceClient!.GetForecastAsync(Arg.Any<string>(), 2).Returns(weatherResponse);
            
            //act
            var request = new GetWeatherForecastsRequest(CityId.From(cityId), Latitude.From(cityLatitude), Longitude.From(cityLongitude));
            var actualResult = await _getCityWeatherRequestHandler!.Handle(request, CancellationToken.None);

            //assert
            actualResult.IsSuccessful.Should().BeTrue();
            actualResult.Exception.Should().BeNull();
            actualResult.Value.Should().HaveCount(1);
            actualResult.Value!.First().Id.CityId.Value.Should().Be(cityId);
            actualResult.Value!.First().Id.Date.Should().Be(date);
            actualResult.Value!.First().ConditionText.Value.Should().Be(conditionText);
            actualResult.Value!.First().ConditionCode.Value.Should().Be(conditionCode);
            actualResult.Value!.First().ConditionIcon.Value.Should().Be(conditionIcon);
        }
        
        [Test]
        public async Task Handle_ShouldReturnFailedResponse_IfServiceThrowsException()
        {
            //arrange
            var expectedException = new Exception();
            _weatherServiceClient!.GetForecastAsync(Arg.Any<string>(), 2).Throws(expectedException);
            
            //act
            var request = new GetWeatherForecastsRequest(CityId.From(0), Latitude.Default, Longitude.Default);
            var actualResult = await _getCityWeatherRequestHandler!
                .Handle(request, CancellationToken.None);
            
            //assert
            actualResult.IsSuccessful.Should().BeFalse();
            actualResult.Value.Should().BeNull();
            actualResult.Exception.Should().Be(expectedException);
        }            
    }
}