using Aspert.Database;

namespace Aspert.ViewModels
{
    public class ResultPageViewModel : ViewModel
    {
        public int Result
        {
            get
            {
                SQLiteDB.Usuario.ResultadoTest = QuestionPageViewModel.Points;
                SQLiteDB.UpdateCurrentUser();
                return QuestionPageViewModel.Points;
            }
        }
    }
}
