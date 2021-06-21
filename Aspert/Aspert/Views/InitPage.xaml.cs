using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aspert
{
    public partial class InitPage : ContentPage
    {
        public InitPage()
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
