using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    public partial class App : Application
    {
        public App()
        {
            UserAppTheme = OSAppTheme.Light;
            InitializeComponent();
            MainPage = new InitPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
