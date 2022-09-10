using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Application.RequestHandlers;
using TuiMusement.CitiesWeather.Application.Requests;
using TuiMusement.CitiesWeather.CitiesServiceClient;
using TuiMusement.CitiesWeather.CitiesServiceClient.Models;
using TuiMusement.CitiesWeather.Domain.Entities;

namespace TuiMusement.CitiesWeather.Application.UnitTests.RequestHandlers
{
    public class GetCitiesRequestHandlerTest
    {
        private ICitiesServiceClient? _citiesServiceClient;
        private GetCitiesRequestHandler? _getCitiesRequestHandler;
        private IMapper? _mapper;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _citiesServiceClient = Substitute.For<ICitiesServiceClient>();
            _mapper = Substitute.For<IMapper>();
            _mediator = Substitute.For<IMediator>();
            _getCitiesRequestHandler = new GetCitiesRequestHandler(_citiesServiceClient, _mapper, _mediator);
        }

        [Test]
        public async Task Handle_ShouldReturnSuccessfulResponse_IfServiceReturnsAValidResponse()
        {
            //arrange
            var cityDto = new CityDto();
            var cityId = CityId.From(0);
            var city = new City(cityId);
            var date = DateTime.Parse("2020-01-01");
            var citiesDto = new List<CityDto>
            {
                cityDto
            };
            var serviceResponse =
                new RestEase.Response<IEnumerable<CityDto>>(string.Empty, new HttpResponseMessage(), () => citiesDto);
            _citiesServiceClient!.GetCitiesAsync().Returns(serviceResponse);
            _mapper!.Map<City>(cityDto).Returns(city);

            var weatherForecast = new WeatherForecast(cityId, date);
            var weatherForecasts = new List<WeatherForecast>()
            {
                weatherForecast
            };
            var getWeatherForecastsResponse =
                Response<IEnumerable<WeatherForecast>>.NewSuccessfulResponse(weatherForecasts);
            _mediator.Send(Arg.Any<GetWeatherForecastsRequest>()).Returns(getWeatherForecastsResponse);

            //act
            var actualResult = await _getCitiesRequestHandler!.Handle(new GetCitiesRequest(), CancellationToken.None);
            
            //assert
            actualResult.IsSuccessful.Should().BeTrue();
            actualResult.Value.Should().HaveCount(1);
            actualResult.Value!.First().Should().Be(city);
            actualResult.Value!.First().WeatherForecasts.Should().HaveCount(1);
            actualResult.Value!.First().WeatherForecasts.First().Should().Be(weatherForecast);
            actualResult.Exception.Should().BeNull();
        }
        
        [Test]
        public async Task Handle_ShouldReturnFailedResponse_IfServiceThrowsException()
        {
            //arrange
            var expectedException = new Exception();
            _citiesServiceClient!.GetCitiesAsync().Throws(expectedException);
            
            //act
            var actualResult = await _getCitiesRequestHandler!.Handle(new GetCitiesRequest(), CancellationToken.None);
            
            //assert
            actualResult.IsSuccessful.Should().BeFalse();
            actualResult.Value.Should().BeNull();
            actualResult.Exception.Should().Be(expectedException);
        }
        
        [Test]
        public async Task Handle_ShouldReturnFailedResponse_IfMediatorReturnsFailedResponse()
        {
            //arrange
            var expectedException = new Exception();
            var cityDto = new CityDto();
            var cityId = CityId.From(0);
            var city = new City(cityId);
            var citiesDto = new List<CityDto>
            {
                cityDto
            };
            var serviceResponse =
                new RestEase.Response<IEnumerable<CityDto>>(string.Empty, new HttpResponseMessage(), () => citiesDto);
            _citiesServiceClient!.GetCitiesAsync().Returns(serviceResponse);
            _mapper!.Map<City>(cityDto).Returns(city);
            var getWeatherForecastsResponse =
                Response<IEnumerable<WeatherForecast>>.NewFailedResponse(expectedException);
            _mediator.Send(Arg.Any<GetWeatherForecastsRequest>()).Returns(getWeatherForecastsResponse);
            //act
            var actualResult = await _getCitiesRequestHandler!.Handle(new GetCitiesRequest(), CancellationToken.None);
            
            //assert
            actualResult.IsSuccessful.Should().BeFalse();
            actualResult.Value.Should().BeNull();
            actualResult.Exception.Should().Be(expectedException);
        }
    }
}