using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using TuiMusement.CitiesWeather.CitiesServiceClient.Models;

namespace TuiMusement.CitiesWeather.CitiesServiceClient
{
    [Header("Accept", "application/json")]
    public interface ICitiesServiceClient
    {
        [Get("cities")]
        Task<Response<IEnumerable<CityDto>>> GetCitiesAsync();
    }
}