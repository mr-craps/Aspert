using System.Windows.Input;
using Aspert.Database;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class ConfigurationPageViewModel : ViewModel
    {
        public bool UseData
        {
            get => SQLiteDB.Usuario.UsarDatos;
            set
            {
                SetValue(ref value, value);
                SQLiteDB.Usuario.UsarDatos = value;
                SQLiteDB.UpdateCurrentUser().RunSynchronously();
            }
        }

        public bool Synchronize
        {
            get => SQLiteDB.Usuario.Sincronizar;
            set
            {
                SetValue(ref value, value);
                SQLiteDB.Usuario.Sincronizar = value;
                SQLiteDB.UpdateCurrentUser().RunSynchronously();
            }
        }

        public bool Notify
        {
            get => SQLiteDB.Usuario.Notificaciones;
            set
            {
                SetValue(ref value, value);
                SQLiteDB.Usuario.Notificaciones = value;
                SQLiteDB.UpdateCurrentUser().RunSynchronously();
            }
        }

        public ICommand Menu { get; }
       // public ICommand Back { get; }
        public ICommand Logout { get; }
        public ICommand DeleteAccount { get; }

        public ConfigurationPageViewModel()
        {
            Menu = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage()));
            // Back = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage()));
            Logout = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Cerrar sesión", "¿Deseas cerrar sesión?", "Aceptar", "Cancelar"))
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                }
            });
            DeleteAccount = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Borrar cuenta", "¿Deseas BORRAR PERMANENTEMENTE tu cuenta?", "SÍ", "NO!!!"))
                {
                    await SQLiteDB.DeleteAccountAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                }
            });
        }
    }
}
