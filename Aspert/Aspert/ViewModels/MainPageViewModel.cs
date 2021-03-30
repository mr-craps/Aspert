using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        public ICommand Configuration { get; }
        public ICommand Menu { get; }


        public MainPageViewModel()
        {
            Configuration = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new ConfigurationPage()));
            Menu = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage()));
        }
    }
}
