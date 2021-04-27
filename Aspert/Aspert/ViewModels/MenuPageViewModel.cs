using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class MenuPageViewModel : ViewModel
    {
        public ICommand Back { get; }
        public ICommand Configuration { get; }
        public ICommand NewsPage { get; }
        public ICommand AbcPage { get; }
        public ICommand BookPage { get; }

        public MenuPageViewModel()
        {
            Back = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
            Configuration = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new ConfigurationPage()));
            NewsPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NewsPage()));
            AbcPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new AbcPage()));
            BookPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new BookPage()));
        }
    }
}
