using System;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Domain.Entities
{
    public record WeatherForecastId(CityId CityId, DateTime Date)
    {
    }
}