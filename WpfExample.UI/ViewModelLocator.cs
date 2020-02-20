using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                
            }
            else
            {
                
            }

            SimpleIoc.Default.Register<OpenWeatherMainViewModel>();
        }

        /// <summary>
        /// Main weather VM
        /// </summary>
        public OpenWeatherMainViewModel OpenWeatherMain
        {
            get { return SimpleIoc.Default.GetInstance<OpenWeatherMainViewModel>(); }
        }
    }
}