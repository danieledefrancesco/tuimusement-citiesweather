using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.Models
{
    public class WeatherConditionDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
    }
}