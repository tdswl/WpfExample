using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using GalaSoft.MvvmLight;
using WpfExample.DAL.OpenWeather.Models;
using WpfExample.DAL.OpenWeather.Services;

namespace WpfExample.UI.OpenWeather.ViewModels
{
    /// <summary>
    /// Base VM for weather
    /// </summary>
    public class OpenWeatherMainViewModel : ViewModelBase, IDisposable
    {
        private readonly HttpClient _client;
        private readonly IOpenWeatherMapService _openWeatherMapService;

        private WeatherData _weatherData;
        /// <inheritdoc cref="WeatherData"/>
        public WeatherData WeatherData
        {
            get { return _weatherData; }
            set { Set(ref _weatherData, value); }
        }
        
        private bool _isBusy;
        /// <summary>
        /// Busy indicator
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(ref _isBusy, value); }
        }
        
        private ICommand _getWeatherDataCommand;
        /// <summary>
        /// Get weather command
        /// </summary>
        public ICommand GetWeatherDataCommand
        {
            get { return _getWeatherDataCommand ?? (_getWeatherDataCommand = new AsyncCommand(GetWeatherData, CanExecuteGetWeatherData)); }
        }

        public OpenWeatherMainViewModel()
        {
             _client = new HttpClient();
             _client.BaseAddress = new Uri("https://samples.openweathermap.org/");
             
            _openWeatherMapService = new OpenWeatherMapService(_client);
        }

        public async Task GetWeatherData()
        {
            IsBusy = true;
            
            WeatherData = await _openWeatherMapService.GetWeatherByCityId(2172797, "b6907d289e10d714a6e88b30761fae22");

            IsBusy = false;
        }
        
        private bool CanExecuteGetWeatherData(object? arg)
        {
            return !IsBusy;
        }
        
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}