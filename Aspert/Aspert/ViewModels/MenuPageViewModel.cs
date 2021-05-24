using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class MenuPageViewModel : PageViewModel
    {
        public ICommand NewsPage { get; }
        public ICommand AbcPage { get; }
        public ICommand BookPage { get; }

        [Obsolete("Recuerda cambiar test -> news")]
        public MenuPageViewModel()
        {
            NewsPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new TestPage()));
            AbcPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new AbcPage()));
            BookPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new BookPage()));
        }
    }
}
