using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfExample.DAL.OpenWeather.Consts;
using WpfExample.DAL.OpenWeather.Models;

namespace WpfExample.DAL.OpenWeather.Services
{
    /// <inheritdoc cref="IOpenWeatherMapService"/>
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly HttpClient _client;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="client"><see cref="HttpClient"/></param>
        public OpenWeatherMapService(HttpClient client)
        {
            _client = client;
        }
        
        /// <inheritdoc cref="IOpenWeatherMapService.GetWeatherByCityId"/>
        public async Task<WeatherData> GetWeatherByCityId(int cityId, string appId)
        {
            WeatherData weatherData = null;
            
            var response = await _client.GetAsync(string.Format(ApiUrls.GetByCityIdUrl, cityId.ToString(), appId));
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonData);
            }

            return weatherData;
        }
    }
}