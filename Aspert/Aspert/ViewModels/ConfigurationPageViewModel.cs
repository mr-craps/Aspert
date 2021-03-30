using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class ConfigurationPageViewModel : ViewModel
    {
        public ICommand Menu { get; }
        public ICommand Back { get; }

        public ConfigurationPageViewModel()
        {
            Menu = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage()));
            Back = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
        }
    }
}
