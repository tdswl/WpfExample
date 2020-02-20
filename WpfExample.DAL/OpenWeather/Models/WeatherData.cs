using Newtonsoft.Json;

namespace WpfExample.DAL.OpenWeather.Models
{
    /// <summary>
    /// Weather data
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Name of city
        /// </summary>
        [JsonProperty("name")]
        public string CityName { get; set; }
        
        /// <inheritdoc cref="Main"/>
        [JsonProperty("main")]
        public Main Main { get; set; }
    }
}