using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.Models
{
    public class WeatherForecastInfoDto
    {
        [JsonProperty(PropertyName = "forecastday")]
        public IEnumerable<WeatherForecastDailyInfo> ForecastDay { get; set; } = Enumerable.Empty<WeatherForecastDailyInfo>();
    }
}