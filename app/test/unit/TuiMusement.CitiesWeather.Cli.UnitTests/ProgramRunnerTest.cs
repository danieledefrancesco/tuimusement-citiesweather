using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Application.Requests;
using TuiMusement.CitiesWeather.Domain.Entities;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Cli.UnitTests
{
    public class ProgramRunnerTest
    {
        private ProgramRunner? _programRunner;
        private IMediator? _mediator;
        private ILogger<ProgramRunner>? _logger;
        private TextWriter? _textWriter;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _logger = Substitute.For<ILogger<ProgramRunner>>();
            _textWriter = Substitute.For<TextWriter>();
            _programRunner = new ProgramRunner(_mediator, _logger, _textWriter);
        }

        [Test]
        public async Task Run_ShouldPrintResults_IfMediatorReturnsASuccessfulResponse()
        {
            //arrange
            const int conditionCode = 3;
            const string conditionText1 = nameof(conditionText1);
            const string conditionText2 = nameof(conditionText2);
            const string conditionIcon = nameof(conditionIcon);
            const string cityName = nameof(cityName);
            const int cityId = 1;
            var date1 = DateTime.Parse("2000-01-01");
            var date2 = DateTime.Parse("2000-01-02");

            var city = new City(CityId.From(cityId))
            {
                Name = CityName.From(cityName),
                WeatherForecasts = new[]
                {
                    new WeatherForecast(CityId.From(cityId), date1)
                    {
                        ConditionCode = WeatherConditionCode.From(conditionCode),
                        ConditionIcon = WeatherConditionIcon.From(conditionIcon),
                        ConditionText = WeatherConditionText.From(conditionText1)
                    },
                    new WeatherForecast(CityId.From(cityId), date2)
                    {
                        ConditionCode = WeatherConditionCode.From(conditionCode),
                        ConditionIcon = WeatherConditionIcon.From(conditionIcon),
                        ConditionText = WeatherConditionText.From(conditionText2)
                    }
                }
            };
            var getCityResponse = Response<IEnumerable<City>>.NewSuccessfulResponse(new[] { city });
            _mediator!.Send(Arg.Any<GetCitiesRequest>()).Returns(getCityResponse);
            
            //act
            await _programRunner!.Run();
            
            //assert
            await _textWriter!.Received(1).WriteLineAsync($"Processed city {cityName} | {conditionText1} - {conditionText2}");
        }
        
        [Test]
        public async Task Run_ShouldLogError_IfMediatorReturnsAFailedResponse()
        {
            //arrange
            var exception = new Exception();
            var getCityResponse = Response<IEnumerable<City>>.NewFailedResponse(exception);
            _mediator!.Send(Arg.Any<GetCitiesRequest>()).Returns(getCityResponse);
            
            //act
            await _programRunner!.Run();
            
            //assert
            _logger.ReceivedCalls().Should().HaveCount(1);
        }
    }
}