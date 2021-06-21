using SQLite;

namespace Aspert.Database
{
    public class User 
    {
        private string _nombre;

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre
        {
            get => _nombre ?? Usuario;
            set => _nombre = value ?? Usuario;
        }
        public bool UsarDatos { get; set; } = true;
        public bool Sincronizar { get; set; } = true;
        public bool Notificaciones { get; set; } = true;

        public override string ToString()
            => Nombre;
    }
}
