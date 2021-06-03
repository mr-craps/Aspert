using System.Windows.Input;

namespace Aspert.ViewModels
{
    public class PlayPageViewModel : PageViewModel
    {
        public ICommand StartGame { get; }

        public PlayPageViewModel()
        {
            StartGame = Push<GamePage>();
        }
    }
}
