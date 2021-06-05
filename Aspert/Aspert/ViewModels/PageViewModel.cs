using System.Windows.Input;

namespace Aspert.ViewModels
{
    public class PageViewModel : ViewModel
    {
        public ICommand Main { get; }
        public ICommand Back { get; }
        public ICommand Configuration { get; }

        public PageViewModel()
        {
            Main = Push<MainPage>();
            Back = Push<MenuPage>();
            Configuration = Push<ConfigurationPage>();
        }
    }
}
