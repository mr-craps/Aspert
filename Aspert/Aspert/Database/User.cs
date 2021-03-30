namespace Aspert.Database
{
    public class User
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public bool UsarDatos { get; set; } = true;
        public bool Sincronizar { get; set; } = true;
        public bool Notificaciones { get; set; } = true;
    }
}
