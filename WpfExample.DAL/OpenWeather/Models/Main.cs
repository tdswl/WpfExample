using Newtonsoft.Json;

namespace WpfExample.DAL.OpenWeather.Models
{
    /// <summary>
    /// Main temperature data
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Temperature
        /// </summary>
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}