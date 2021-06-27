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
                SQLiteDB.UpdateCurrentUser();
            }
        }

        public bool Synchronize
        {
            get => SQLiteDB.Usuario.Sincronizar;
            set
            {
                SetValue(ref value, value);
                SQLiteDB.Usuario.Sincronizar = value;
                SQLiteDB.UpdateCurrentUser();
            }
        }

        public bool Notify
        {
            get => SQLiteDB.Usuario.Notificaciones;
            set
            {
                SetValue(ref value, value);
                SQLiteDB.Usuario.Notificaciones = value;
                SQLiteDB.UpdateCurrentUser();
            }
        }

        public ICommand Logout { get; }
        public ICommand DeleteAccount { get; }
        public ICommand Edit { get; }

        public ConfigurationPageViewModel()
        {
            Logout = new Command(async () =>
            {
                if (await AlertAsync("Cerrar sesión", "¿Deseas cerrar sesión?", "Aceptar", "Cancelar"))
                    Push.Execute(typeof(LoginPage));
            });
            DeleteAccount = new Command(async () =>
            {
                if (await AlertAsync("Borrar cuenta", "¿Deseas BORRAR PERMANENTEMENTE tu cuenta?", "SÍ", "NO"))
                {
                    await SQLiteDB.DeleteAccountAsync();
                    Push.Execute(typeof(LoginPage));
                }
            });
        }
    }
}
