using System;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Domain.Entities
{
    public class WeatherForecast: EntityBase<WeatherForecastId>
    {
        public WeatherForecast(WeatherForecastId id) : base(id)
        {
        }
        public WeatherForecast(CityId cityId, DateTime date) : this(new WeatherForecastId(cityId, date))
        {
        }
        public WeatherConditionText ConditionText { get; set; } = WeatherConditionText.Empty;
        public WeatherConditionIcon ConditionIcon { get; set; } = WeatherConditionIcon.Empty;
        public WeatherConditionCode ConditionCode { get; set; } = WeatherConditionCode.Default;
    }
}