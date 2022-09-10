using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.CitiesServiceClient.Models
{
    public class CountryDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "iso_code")]
        public string IsoCode { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "country_prefix")]
        public string CountryPrefix { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; } = string.Empty;
    }
}