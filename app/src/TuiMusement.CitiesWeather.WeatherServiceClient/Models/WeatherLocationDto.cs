using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.Models
{
    public class WeatherLocationDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "region")] 
        public string Region { get; set; }= string.Empty;
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "tz_id")] 
        public string TimeZoneId { get; set; }= string.Empty;
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
        
    }
}