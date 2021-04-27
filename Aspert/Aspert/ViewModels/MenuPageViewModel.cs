using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class MenuPageViewModel : ViewModel
    {
        public ICommand Back { get; }
        public ICommand Configuration { get; }

        public MenuPageViewModel()
        {
            Back = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
            Configuration = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new ConfigurationPage()));
        }
    }
}
