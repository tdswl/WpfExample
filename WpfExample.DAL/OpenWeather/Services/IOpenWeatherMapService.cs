using System.Threading.Tasks;
using WpfExample.DAL.OpenWeather.Models;

namespace WpfExample.DAL.OpenWeather.Services
{
    /// <summary>
    /// Proxy service for openweathermap.org
    /// </summary>
    public interface IOpenWeatherMapService
    {
        Task<WeatherData> GetWeatherByCityId(int cityId, string appId);
    }
}