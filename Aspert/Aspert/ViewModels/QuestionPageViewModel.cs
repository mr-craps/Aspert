using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class QuestionPageViewModel : ViewModel
    {
        private static readonly List<(string Question, bool? Value)> _questions = new List<(string, bool?)>()
        {
            ("¿Le resulta fácil participar en los juegos con otros niños?", false),
            ("¿Se acerca de una forma espontánea a usted para conversar?", false),
            ("¿Comenzó el niño a hablar antes de cumplir los dos años?", null),
            ("¿Le gustan los deportes?", null),
            ("¿Da el niño importancia al hecho de llevarse bien con otros niños de la misma edad y parecer como ellos?", false),
            ("¿Tiene a entender las cosas que se dicen literalmente?", true),
            ("¿A la edad de tres años, pasaba mucho tiempo jugando imaginativamente juegos de ficción? Por ejemplo, imaginando que era un superhéroe), u organizando una merienda para sus muñecos de peluche?", true),
            ("¿Tiende a entender las cosas que se dicen literalmente?", false),
            ("¿Le gusta hacer las cosas de manera repetida y de la misma forma todo el tiempo?", true),
            ("¿Le resulta fácil interactuar con otros niños?", false),
            ("¿Es capaz de mantener una conversación recíproca?", false),
            ("¿Lee de una forma apropiada para su edad?", null),
            ("¿Tiene los mismos intereses, en general), que los otros niños de su misma edad?", false),
            ("¿Tiene algún interés que le mantenga ocupado durante tanto tiempo que el niño no hace otra cosa?", true),
            ("¿Tiene amigos y no sólo \"conocidos\"?", false),
            ("¿Le trae a menudo cosas en las que está interesado con la intención de mostrárselas?", false),
            ("¿Le gusta bromear?", false),
            ("¿Tiene alguna dificultad para entender las reglas del comportamiento educado?", true),
            ("¿Parece tener una memoria excepcional para los detalles?", true),
            ("¿Es la voz del niño peculiar (demasiado adulta, aplanada y muy monótona)?", true),
            ("¿Es la gente importante para él?", false),
            ("¿Puede vestirse solo?", null),
            ("¿Muestra una buena capacidad para esperar turnos en una conversación?", false),
            ("¿Juega el niño de forma imaginativa con otros niños y participa en juegos sociales de roles?", false),
            ("¿Hace a menudo comentarios que son impertinentes, indiscretos o socialmente inapropiados?", true),
            ("¿Puede contar hasta cincuenta sin saltarse números?", null),
            ("¿Mantiene un contacto visual normal?", false),
            ("¿Muestra algún movimiento repetitivo e inusual?", true),
            ("¿Es su conducta social muy unilateral y siempre acorde a sus propias reglas y condiciones?", true),
            ("¿Utiliza algunas veces los pronombres \"tú\" y \"él/ella\" en lugar de \"yo\"?", true),
            ("¿Prefiere las actividades imaginativas, como los juegos de ficción y los cuentos, en lugar de números o listas de información?", false),
            ("¿En una conversación, confunde algunas veces al interlocutor por no haber explicado el asunto del que está hablando?", true),
            ("¿Puede montar en bicicleta (aunque sea con ruedas estabilizadoras)?", null),
            ("¿Intenta imponer sus rutinas sobre sí mismo o sobre los demás de tal forma que causa problemas?", true),
            ("¿Le importa al niño la opinión que el resto del grupo tenga de él?", false),
            ("¿Dirige a menudo la conversación hacia sus temas de interés en lugar de continuar con lo que la otra persona desea hablar?", true),
            ("¿Utiliza frases inusuales o extrañas?", true)
        };
        private static int _index;
        public static bool?[] Answers = new bool?[37];

        public ICommand Yes { get; }
        public ICommand No { get; }

        public QuestionPageViewModel()
        {
            _index = 0;
            Yes = new Command<Label>(label =>
            {
                if (_index >= _questions.Count)
                {
                    Push.Execute(typeof(ResultsPage));
                    return;
                }
          
                var (question, value) = _questions[_index];

                if (value != null)
                    Answers[_index++] = value;

                if (_index >= _questions.Count)
                    return;

                label.Text = $"{_index + 1}. {question}";
            });
            No = new Command<Label>(label =>
            {
                if (_index >= _questions.Count)
                {
                    Push.Execute(typeof(ResultsPage));
                    return;
                }

                var (question, value) = _questions[_index];

                if (value != null)
                    Answers[_index++] = !value;

                if (_index >= _questions.Count)
                    return;

                label.Text = $"{_index + 1}. {question}";
            });
        }
    }
}
