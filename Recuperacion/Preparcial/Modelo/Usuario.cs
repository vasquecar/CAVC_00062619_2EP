namespace Preparcial.Modelo
{
    public class Usuario
    {
        public string IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Contrasena { get; set; }

        public bool Admin { get; set; }

        public Usuario(string idUsuario, string nombre, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}
