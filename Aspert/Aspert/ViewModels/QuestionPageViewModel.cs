using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class QuestionPageViewModel : ViewModel
    {
        private static readonly string[] _questions =
{
            "¿Le resulta fácil participar en los juegos con otros niños?",
            "¿Se acerca de una forma espontánea a usted para conversar?",
            "¿Comenzó el niño a hablar antes de cumplir los dos años?",
            "¿Le gustan los deportes?",
            "¿Da el niño importancia al hecho de llevarse bien con otros niños de la misma edad y parecer como ellos?",
            "¿Tiene a entender las cosas que se dicen literalmente?",
            "¿A la edad de tres años, pasaba mucho tiempo jugando imaginativamente juegos de ficción? Por ejemplo, imaginando que era un superhéroe, u organizando una merienda para sus muñecos de peluche?",
            "¿Le gusta hacer las cosas de manera repetida y de la misma forma todo el tiempo?",
            "¿Le resulta fácil interactuar con otros niños?",
            "¿Es capaz de mantener una conversación recíproca?",
            "¿Lee de una forma apropiada para su edad?",
            "¿Tiene los mismos intereses, en general, que los otros niños de su misma edad?",
            "¿Tiene algún interés que le mantenga ocupado durante tanto tiempo que el niño no hace otra cosa?",
            "¿Tiene amigos y no sólo \"conocidos\"?",
            "¿Le trae a menudo cosas en las que está interesado con la intención de mostrárselas?",
            "¿Le gusta bromear?",
            "¿Tiene alguna dificultad para entender las reglas del comportamiento educado?",
            "¿Parece tener una memoria excepcional para los detalles?",
            "¿Es la voz del niño peculiar (demasiado adulta, aplanada y muy monótona)?",
            "¿Es la gente importante para él?",
            "¿Puede vestirse solo?",
            "¿Muestra una buena capacidad para esperar turnos en una conversación?",
            "¿Juega el niño de forma imaginativa con otros niños y participa en juegos sociales de roles?",
            "¿Hace a menudo comentarios que son impertinentes, indiscretos o socialmente inapropiados?",
            "¿Puede contar hasta cincuenta sin saltarse números?",
            "¿Mantiene un contacto visual normal?",
            "¿Muestra algún movimiento repetitivo e inusual?",
            "¿Es su conducta social muy unilateral y siempre acorde a sus propias reglas y condiciones?",
            "¿Utiliza algunas veces los pronombres \"tú\" y \"él/ella\" en lugar de \"yo\"?",
            "¿Prefiere las actividades imaginativas, como los juegos de ficción y los cuentos, en lugar de números o listas de información?",
            "¿En una conversación, confunde algunas veces al interlocutor por no haber explicado el asunto del que está hablando?",
            "¿Puede montar en bicicleta (aunque sea con ruedas estabilizadoras)?",
            "¿Intenta imponer sus rutinas sobre sí mismo o sobre los demás de tal forma que causa problemas?",
            "¿Le importa al niño la opinión que el resto del grupo tenga de él?",
            "¿Dirige a menudo la conversación hacia sus temas de interés en lugar de continuar con lo que la otra persona desea hablar?",
            "¿Utiliza frases inusuales o extrañas?"
        };
        private static int _index;
        private readonly bool[] _answers;

        public ICommand Yes { get; }
        public ICommand No { get; }

        public QuestionPageViewModel()
        {
            _index = 0;
            _answers = new bool[_questions.Length];
            Yes = new Command<Label>(label =>
            {
                if (_index >= _questions.Length)
                    return;

                _answers[_index++] = true;

                if (_index >= _questions.Length)
                    return;

                label.Text = $"{_index + 1}. {_questions[_index]}";
            });
            No = new Command<Label>(label =>
            {
                if (++_index >= _questions.Length)
                    return;

                label.Text = $"{_index + 1}. {_questions[_index]}";
            });
        }
    }
}
