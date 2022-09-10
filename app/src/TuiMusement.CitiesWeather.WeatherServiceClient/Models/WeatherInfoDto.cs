using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.Models
{
    public class WeatherInfoDto
    {
        [JsonProperty(PropertyName = "condition")]
        public WeatherConditionDto? Condition { get; set; }
    }
}