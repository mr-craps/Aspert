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
#if !DEBUG
            await Task.Delay(1000);
#endif
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
