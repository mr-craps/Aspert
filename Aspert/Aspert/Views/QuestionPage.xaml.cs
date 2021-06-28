using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            template.SetDarkIcons();
            base.OnAppearing();
        }
    }
}