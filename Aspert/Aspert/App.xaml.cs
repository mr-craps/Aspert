using Xamarin.Forms;

namespace Aspert
{
    public partial class App : Application
    {
        public App()
        {
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
