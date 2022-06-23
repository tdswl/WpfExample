using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using WpfExample.UI.OpenWeather.ViewModels;

namespace WpfExample.UI
{
    /// <summary>
    /// VM locator
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<OpenWeatherMainViewModel>()
                    .BuildServiceProvider());
        }

        /// <summary>
        /// Main weather VM
        /// </summary>
        public OpenWeatherMainViewModel? OpenWeatherMain => Ioc.Default.GetService<OpenWeatherMainViewModel>();
    }
}