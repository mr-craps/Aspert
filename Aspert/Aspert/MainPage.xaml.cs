using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aspert
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(1000);
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
