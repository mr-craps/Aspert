using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class TestPageViewModel : PageViewModel
    {
        public ICommand StartTest { get; }

        public TestPageViewModel()
        {
            StartTest = Push<QuestionPage>();
        }
    }
}
