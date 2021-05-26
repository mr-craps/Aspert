using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        private readonly string[] _questions =
        {
            "1. ¿Le resulta fácil participar en los juegos con otros niños?",
            "2. ¿Se acerca de una forma espontánea a usted para conversar?",
            "3. ¿Comenzó el niño a hablar antes de cumplir los dos años?",
            "4. ¿Le gustan los deportes?",
            "5. ¿Da el niño importancia al hecho de llevarse bien con otros niños de la misma edad y parecer como ellos?",
            "6. ¿Tiene a entender las cosas que se dicen literalmente?",
            "7. ¿A la edad de tres años, pasaba mucho tiempo jugando imaginativamente juegos de ficción? Por ejemplo, imaginando que era un superhéroe, u organizando una merienda para sus muñecos de peluche?",
            "8. ¿Le gusta hacer las cosas de manera repetida y de la misma forma todo el tiempo?",
            "9. ¿Le gusta hacer las cosas de manera repetida y de la misma forma todo el tiempo?",
            "10. ¿Le resulta fácil interactuar con otros niños?",
            "11. ¿Es capaz de mantener una conversación recíproca?",
            "12. ¿Lee de una forma apropiada para su edad?",
            "13. ¿Tiene los mismos intereses, en general, que los otros niños de su misma edad?",
            "14. ¿Tiene algún interés que le mantenga ocupado durante tanto tiempo que el niño no hace otra cosa?",
            "15. ¿Tiene amigos y no sólo ''conocidos''?",
            "16. ¿Le trae a menudo cosas en las que está interesado con la intención de mostrárselas?",
            "17. ¿Le gusta bromear?",
            "18. ¿Tiene alguna dificultad para entender las reglas del comportamiento educado?",
            "19. ¿Parece tener una memoria excepcional para los detalles?",
            "20. ¿Es la voz del niño peculiar (demasiado adulta, aplanada y muy monótona)?",
            "21. ¿Es la gente importante para él?",
            "22. ¿Puede vestirse solo?",
            "23. ¿Muestra una buena capacidad para esperar turnos en una conversación?",
            "24. ¿Juega el niño de forma imaginativa con otros niños y participa en juegos sociales de roles?",
            "25. ¿Hace a menudo comentarios que son impertinentes, indiscretos o socialmente inapropiados?",
            "26. ¿Puede contar hasta cincuenta sin saltarse números?",
            "27. ¿Mantiene un contacto visual normal?",
            "28. ¿Muestra algún movimiento repetitivo e inusual?",
            "29. ¿Es su conducta social muy unilateral y siempre acorde a sus propias reglas y condiciones?",
            "30. ¿Utiliza algunas veces los pronombres ''tú'' y ''él/ella'' en lugar de ''yo''?",
            "31. ¿Prefiere las actividades imaginativas, como los juegos de ficción y los cuentos, en lugar de números o listas de información?",
            "32. ¿En una conversación, confunde algunas veces al interlocutor por no haber explicado el asunto del que está hablando?",
            "33. ¿Puede montar en bicicleta (aunque sea con ruedas estabilizadoras)?",
            "34. ¿Intenta imponer sus rutinas sobre sí mismo o sobre los demás de tal forma que causa problemas?",
            "35. ¿Le importa al niño la opinión que el resto del grupo tenga de él?",
            "36. ¿Dirige a menudo la conversación hacia sus temas de interés en lugar de continuar con lo que la otra persona desea hablar?",
            "37. ¿Utiliza frases inusuales o extrañas?"
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