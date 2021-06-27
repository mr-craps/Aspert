using System.Linq;
using Aspert.Database;

namespace Aspert.ViewModels
{
    public class ResultPageViewModel : ViewModel
    {
        public int Result
        {
            get
            {
                SQLiteDB.Usuario.ResultadoTest = QuestionPageViewModel.Answers.Sum(x => x.GetValueOrDefault() ? 1 : 0);
                SQLiteDB.UpdateCurrentUser();
                return SQLiteDB.Usuario.ResultadoTest;
            }
        }
    }
}
