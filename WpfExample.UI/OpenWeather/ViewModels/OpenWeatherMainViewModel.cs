using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfExample.DAL.OpenWeather.Models;
using WpfExample.DAL.OpenWeather.Services;

namespace WpfExample.UI.OpenWeather.ViewModels
{
    /// <summary>
    /// Base VM for weather
    /// </summary>
    public partial class OpenWeatherMainViewModel : ObservableRecipient, IDisposable
    {
        private readonly HttpClient _client;
        private readonly IOpenWeatherMapService _openWeatherMapService;

        [ObservableProperty]
        private WeatherData? _weatherData;
        
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GetWeatherDataCommand))]
        private bool _isBusy;

        public OpenWeatherMainViewModel()
        {
             _client = new HttpClient();
             _client.BaseAddress = new Uri("https://samples.openweathermap.org/");
             
            _openWeatherMapService = new OpenWeatherMapService(_client);
        }

        [RelayCommand(IncludeCancelCommand = true, CanExecute = nameof(CanExecuteGetWeatherData))]
        private async Task GetWeatherDataAsync(CancellationToken token)
        {
            IsBusy = true;
            
            WeatherData = await _openWeatherMapService.GetWeatherByCityId(2172797, "b6907d289e10d714a6e88b30761fae22");

            IsBusy = false;
        }
        
        private bool CanExecuteGetWeatherData()
        {
            return !IsBusy;
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}