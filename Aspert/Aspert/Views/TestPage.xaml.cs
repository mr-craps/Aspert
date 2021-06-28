using System.Linq;
using Aspert.Database;
using Aspert.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            btnStart.Text = QuestionPageViewModel.Answers.All(x => x == null)
                ? "Empezar Test"
                : $"Reintentar Test (Puntaje anterior: {SQLiteDB.Usuario.ResultadoTest})";
            template.SetDarkIcons();
            base.OnAppearing();
        }
    }
}