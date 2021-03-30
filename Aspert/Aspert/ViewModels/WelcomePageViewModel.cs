using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class WelcomePageViewModel : ViewModel
    {
        public ICommand Ok { get; }

        public WelcomePageViewModel()
        {
            Ok = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
        }
    }
}
