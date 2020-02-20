namespace WpfExample.DAL.OpenWeather.Consts
{
    /// <summary>
    /// Api urls
    /// </summary>
    public static class ApiUrls
    {
        /// <summary>
        /// Url for get weather by city id
        /// </summary>
        /// <remarks>
        /// {0} - city id
        /// {1} - app id
        /// </remarks>
        public const string GetByCityIdUrl = "data/2.5/weather?id={0}&appid={1}";
    }
}