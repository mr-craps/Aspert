using System.Windows.Input;
using Aspert.Database;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class LoginPageViewModel : ViewModel
    { 
        public ICommand Login { get; }
        public ICommand Register { get; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public LoginPageViewModel()
        {
            Login = new Command(async () =>
            {
                if (await SQLiteDB.GetUserAsync(Usuario, Contraseña) is User usuario)
                {
                    SQLiteDB.Usuario = usuario;
                    await Application.Current.MainPage.Navigation.PushModalAsync(new WelcomePage());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Contraseña inválida", "La contraseña introducida no coincide con la contraseña registrada, por favor intente nuevamente. Recuerde que el usuario y contraseña deben tener al menos 4 caracteres y máximo 12 caracteres.", "Ok");
            });
            Register = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
            });
        }
    }
}
