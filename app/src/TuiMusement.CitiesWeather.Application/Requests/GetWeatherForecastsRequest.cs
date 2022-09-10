using System.Collections;
using System.Collections.Generic;
using MediatR;
using TuiMusement.CitiesWeather.Domain.Entities;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Application.Requests
{
    public class GetWeatherForecastsRequest: IRequest<Response<IEnumerable<WeatherForecast>>>
    {
        public GetWeatherForecastsRequest(CityId cityId, Latitude latitude, Longitude longitude)
        {
            CityId = cityId;
            Latitude = latitude;
            Longitude = longitude;
        }

        public CityId CityId { get; }
        public Latitude Latitude { get; }
        public Longitude Longitude { get; }
    }
}