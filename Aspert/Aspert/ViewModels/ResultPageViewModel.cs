using System.Linq;


namespace Aspert.ViewModels
{
    public class ResultPageViewModel : ViewModel
    {
        public int Result => QuestionPageViewModel.Answers.Sum(x => x.GetValueOrDefault() ? 1 : 0);
    }
}
