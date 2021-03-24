namespace Aspert.ViewModels
{
    public class WelcomePageViewModel : ViewModel
    {
        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set => SetValue(ref _usuario, value);
        }

        public WelcomePageViewModel(string usuario)
        {
            Usuario = usuario;
        }
    }
}
