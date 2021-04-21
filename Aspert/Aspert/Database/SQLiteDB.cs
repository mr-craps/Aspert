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
        {
            _creationTask = Connection.CreateTableAsync<User>();
        }

        public static Task UpdateCurrentUser()
            => Connection.UpdateAsync(Usuario);

        public static async Task<User> GetUserAsync(string usuario, string contraseña)
        {
            if (!_creationTask.IsCompleted)
                await _creationTask;

            if (string.IsNullOrWhiteSpace(usuario))
                return null;

            if (string.IsNullOrWhiteSpace(contraseña))
                return null;

            var user = (await Connection.Table<User>().ToArrayAsync()).FirstOrDefault(x => x.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase));

            if (user is null)
                return await RegisterAsync(usuario, contraseña);

            if (!user.Contraseña.Equals(contraseña))
                return null;

            return user;
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

        internal static async Task DeleteAccountAsync()
            => await Connection.DeleteAsync<User>(Usuario.Id);
    }
}
