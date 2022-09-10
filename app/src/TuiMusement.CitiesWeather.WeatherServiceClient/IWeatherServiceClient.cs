using System.Threading.Tasks;
using RestEase;
using TuiMusement.CitiesWeather.WeatherServiceClient.Models;

namespace TuiMusement.CitiesWeather.WeatherServiceClient
{
    public interface IWeatherServiceClient
    {
        [Query("key")]
        public string Key { get; set; }
        
        [Get("forecast.json")]
        Task<Response<WeatherForecastResponseDto>> GetForecastAsync(
            [Query("q")] string query,
            [Query("days")] int days,
            [Query("aqi")] string aqi = "no",
            [Query("alerts")] string alerts = "no");
    }
}