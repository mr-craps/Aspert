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
        public ICommand TestPage { get; }
        public ICommand PlayPage { get; }
        public ICommand AboutPage { get; }

        public MenuPageViewModel()
        {
            NewsPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NewsPage()));
            AbcPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new AbcPage()));
            BookPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new BookPage()));
            TestPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new TestPage()));
            PlayPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new PlayPage()));
            AboutPage = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new AboutPage()));
        }
    }
}
