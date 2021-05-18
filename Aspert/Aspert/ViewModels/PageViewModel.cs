using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class PageViewModel : ViewModel
    {
        public ICommand Back { get; }
        public ICommand Configuration { get; }

        public PageViewModel()
        {
            Back = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
            Configuration = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new ConfigurationPage()));
        }
    }
}
