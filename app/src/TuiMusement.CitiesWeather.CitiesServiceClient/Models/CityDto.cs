using System;
using Newtonsoft.Json;

namespace TuiMusement.CitiesWeather.CitiesServiceClient.Models
{
    public class CityDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "top")]
        public bool Top { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "content_html")]
        public string ContentHtml { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "meta_description")]
        public string MetaDescription { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "meta_title")]
        public string MetaTitle { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "headline")]
        public string Headline { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "more")]
        public string More { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "more_html")]
        public string MoreHtml { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "country")]
        public CountryDto? Country { get; set; }
        [JsonProperty(PropertyName = "cover_image_url")]
        public string CoverImageUrl { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "activities_count")]
        public int ActivitiesCount { get; set; }
        [JsonProperty(PropertyName = "time_zone")]
        public string TimeZone { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "list_count")]
        public int ListCount { get; set; }
        [JsonProperty(PropertyName = "venue_count")]
        public int VenueCount { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "show_in_popular")]
        public bool ShowInPopular { get; set; }
    }
}