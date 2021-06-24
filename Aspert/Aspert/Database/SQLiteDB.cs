using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Aspert.Database
{
    public static class SQLiteDB
    {
        private static readonly Task _creationTask;
        private static readonly SQLiteAsyncConnection Connection
            = new SQLiteAsyncConnection(
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "aspertDB.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

        public static User Usuario { get; set; }

        static SQLiteDB()
            => _creationTask = Connection.CreateTableAsync<User>();

        public static Task UpdateCurrentUser()
            => Connection.UpdateAsync(Usuario);

        public static async Task<User> GetUserAsync(string usuario, string contraseña)
        {
            if (!_creationTask.IsCompleted)
                await _creationTask;

#if DEBUG
            if (string.IsNullOrWhiteSpace(usuario) && string.IsNullOrWhiteSpace(contraseña))
                return new User
                {
                    Usuario = "Admin",
                    Contraseña = "admin",
                    Nombre = "Admin"
                };
#endif

            if (string.IsNullOrWhiteSpace(usuario))
                return null;

            if (string.IsNullOrWhiteSpace(contraseña))
                return null;

            if (usuario.Length < 4 || usuario.Length > 12 || contraseña.Length < 4 || contraseña.Length > 12)
                return null;

            return (await Connection.Table<User>().ToArrayAsync()).FirstOrDefault(x => x.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase) && x.Contraseña.Equals(contraseña));
        }

        public static async Task<User> RegisterAsync(string usuario, string contraseña)
        {
            var user = new User
            {
                Usuario = usuario,
                Contraseña = contraseña,
                Nombre = usuario
            };

            await Connection.InsertAsync(user);
            return user;
        }

        internal static Task DeleteAccountAsync()
            => Connection.DeleteAsync<User>(Usuario.Id);
    }
}
