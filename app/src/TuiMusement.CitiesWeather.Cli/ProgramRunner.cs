using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TuiMusement.CitiesWeather.Application.Requests;

namespace TuiMusement.CitiesWeather.Cli
{
    public class ProgramRunner
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProgramRunner> _logger;
        private readonly TextWriter _writer;

        public ProgramRunner(IMediator mediator, ILogger<ProgramRunner> logger, TextWriter writer)
        {
            _mediator = mediator;
            _logger = logger;
            _writer = writer;
        }

        public async Task Run()
        {
            var citiesWeatherResponse = await _mediator.Send(new GetCitiesRequest());
            if (!citiesWeatherResponse.IsSuccessful)
            {
                _logger.LogError(citiesWeatherResponse.Exception, "Error while getting cities weather forecasts");
                return;
            }

            foreach (var city in citiesWeatherResponse.Value!)
            {
                await _writer.WriteLineAsync($"Processed city {city.Name} | {string.Join(" - ", city.WeatherForecasts.Select(x => x.ConditionText))}");

            }            
        }
    }
}