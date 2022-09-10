using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TuiMusement.CitiesWeather.Application.Requests;
using TuiMusement.CitiesWeather.Domain.Entities;
using TuiMusement.CitiesWeather.Domain.ValueObjects;
using TuiMusement.CitiesWeather.WeatherServiceClient;

namespace TuiMusement.CitiesWeather.Application.RequestHandlers
{
    public class GetWeatherForecastRequestHandler: IRequestHandler<GetWeatherForecastsRequest, Response<IEnumerable<WeatherForecast>>>
    {
        private readonly IWeatherServiceClient _weatherServiceClient;
        private const int ForecastDays = 2;

        public GetWeatherForecastRequestHandler(IWeatherServiceClient weatherServiceClient)
        {
            _weatherServiceClient = weatherServiceClient;
        }
        public async Task<Response<IEnumerable<WeatherForecast>>> Handle(GetWeatherForecastsRequest forecastsRequest, CancellationToken cancellationToken)
        {
            try
            {
                var query = $"{forecastsRequest.Latitude},{forecastsRequest.Longitude}";
                var weatherForecastResponse = await _weatherServiceClient.GetForecastAsync(query, ForecastDays);
                var weatherForecastDto = weatherForecastResponse.GetContent();
                var weatherForecasts = weatherForecastDto.Forecast!.ForecastDay.Select(
                        info => new WeatherForecast(forecastsRequest.CityId, info.Date)
                        {
                            ConditionCode = WeatherConditionCode.From(info.Day!.Condition!.Code),
                            ConditionIcon = WeatherConditionIcon.From(info.Day!.Condition!.Icon),
                            ConditionText = WeatherConditionText.From(info.Day!.Condition!.Text)
                        })
                    .OrderBy(x => x.Id.Date)
                    .ToList();
                return Response<IEnumerable<WeatherForecast>>.NewSuccessfulResponse(weatherForecasts);
            }
            catch (Exception e)
            {
                return Response<IEnumerable<WeatherForecast>>.NewFailedResponse(e);
            }
        }
    }
}