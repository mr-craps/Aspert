using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class WelcomePageViewModel : ViewModel
    {
        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set => SetValue(ref _usuario, value);
        }

        public ICommand Ok { get; }

        public WelcomePageViewModel(string usuario)
        {
            Usuario = usuario;
            //Ok = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage()));
        }
    }
}
