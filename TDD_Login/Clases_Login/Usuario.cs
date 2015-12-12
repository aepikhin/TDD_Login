namespace Clases_Login
{
    public class Usuario
    {
        private string username;
        private string nombre;
        private string apellidos;
        private string password;
        private TipoUsuario tipoUsuario;
        private int intentosLogin;

        public Usuario(string username, string nombre, string apellidos, string password, TipoUsuario tipoUsuario, int intentosLogin)
        {
            this.username = username;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.password = "" + password.GetHashCode();
            this.tipoUsuario = tipoUsuario;
            this.intentosLogin = intentosLogin;
        }

        public string UserName
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = "" + value.GetHashCode(); }
        }

        public TipoUsuario TipoUsuario
        {
            get { return this.tipoUsuario; }
            set { this.tipoUsuario = value; }
        }

        public int NumeroIntentosLogin
        {
            get { return this.intentosLogin; }
            set { this.intentosLogin = value; }
        }

        public bool Equals(Usuario user)
        {
            return this.UserName == user.UserName;
        }
    }

    public enum TipoUsuario
    {
        ADMINISTRADOR = 1,
        BECARIO = 2
    }
}