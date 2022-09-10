using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.Models
{
    public class WeatherForecastResponseDto
    {
        [JsonProperty(PropertyName = "location")]
        public WeatherLocationDto? Location { get; set; }
        [JsonProperty(PropertyName = "forecast")]
        public WeatherForecastInfoDto? Forecast { get; set; }
    }
}