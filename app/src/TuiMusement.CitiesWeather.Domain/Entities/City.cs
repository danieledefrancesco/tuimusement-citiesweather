using System.Collections;
using System.Collections.Generic;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Domain.Entities
{
    public class City : EntityBase<CityId>
    {
        public City(CityId id) : base(id)
        {
        }
        public CityName Name { get; set; } = CityName.Empty;
        
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }

        public Latitude Latitude { get; set; } = Latitude.Default;
        public Longitude Longitude { get; set; } = Longitude.Default;
    }
}