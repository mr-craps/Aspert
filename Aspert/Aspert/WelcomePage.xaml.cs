using Aspert.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage(string usuario)
        {
            InitializeComponent();
            BindingContext = new WelcomePageViewModel(usuario);
        }
    }
}