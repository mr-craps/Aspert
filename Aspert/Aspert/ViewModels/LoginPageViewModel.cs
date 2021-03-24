using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLite;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class LoginPageViewModel : ViewModel
    { 
        public ICommand Login { get; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public LoginPageViewModel()
        {
            Login = new Command(async () =>
            {
                if (await Database.IsValid(Usuario, Contraseña))
                    await Application.Current.MainPage.Navigation.PushModalAsync(new WelcomePage(Usuario));
                else
                    await Application.Current.MainPage.DisplayAlert("Contraseña inválida", "La contraseña introducida no coincide con la contraseña registrada. Por favor intente nuevamente.", "Ok");
            });
        }
    }

    public static class Database
    {
        private static readonly Task _creationTask;
        private static readonly SQLiteAsyncConnection Connection
            = new SQLiteAsyncConnection(
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "aspertDB.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

        static Database()
        {
            _creationTask = Connection.CreateTableAsync<LoginTable>();
        }

        public static async Task<bool> IsValid(string usuario, string contraseña)
        {
            if (!_creationTask.IsCompleted)
                await _creationTask;

            if (string.IsNullOrWhiteSpace(usuario))
                return false;

            if (string.IsNullOrWhiteSpace(contraseña))
                return false;

            var usuarios = (await Connection.Table<LoginTable>().ToArrayAsync()).FirstOrDefault(x => x.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase));

            if (usuarios is null)
                return await RegisterAsync(usuario, contraseña) == 1;

            return usuarios.Contraseña.Equals(contraseña);
        }

        public static Task<int> RegisterAsync(string usuario, string contraseña)
        {
            return Connection.InsertAsync(new LoginTable 
            { 
                Usuario = usuario, 
                Contraseña = contraseña 
            });
        }
    }

    public class LoginTable
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
