using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        private string[] _questions =
{
            "¿Le resulta fácil participar en los juegos con otros niños?",
            "¿Se acerca de una forma espontánea a usted para conversar?",
            "¿Comenzó el niño a habla antes de cumplir los dos años?",
            "¿Le gustan los deportes?",
            "¿Da el niño importancia al hecho de llevarse bien con otros niños de la misma edad y parecer como ellos?",
            "¿Tiene a entender las cosas que se dicen literalmente?",
            "¿A la edad de tres años, pasaba mucho tiempo jugando imaginativamente juegos de ficción? Por ejemplo, imaginando que era un superhéroe, u organizando una merienda para sus muñecos de peluche?",
            "¿Le gusta hacer las cosas de manera repetida y de la misma forma todo el tiempo?"
                // seguir agregando las otras preguntas -.-
        };

        private int _question;

        public TestPage()
        {
            InitializeComponent();
        }

        private void OnBtnClicked(object sender, System.EventArgs e)
        {
            if (_question == _questions.Length)
                return;

            lbl.Text = _questions[_question++];

            if (_question < _questions.Length)
                btn.Text = "Siguiente";
            else
            {
                btn.Text = "Finalizar tests";
            }
        }
    }
}