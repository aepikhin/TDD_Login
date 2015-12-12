using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Clases_Login
{
    public class DBPruebas
    {
        private IList<Usuario> users;
        private IList<Evento> eventos;
        private int numeroIntentosLogin;

        public DBPruebas()
        {
            users = new List<Usuario>();
            eventos = new List<Evento>();
            numeroIntentosLogin = 3;
            inicializarDatos();
        }

        public bool valida(string usuario, string contrasena)
        {
            return users.Any(x => x.UserName == usuario && x.Password == "" + contrasena.GetHashCode() && x.NumeroIntentosLogin > 0);
        }

        public bool creaUsuario(string usuario, string nombre, string apellidos, string contrasena, TipoUsuario tipo)
        {
            if (users.Any(x => x.UserName == usuario))
                return false;
            users.Add(new Usuario(usuario, nombre, apellidos, contrasena, tipo, this.numeroIntentosLogin));
            return true;
        }

        public bool esAdministrador(string usuario)
        {
            return users.Any(x => x.UserName == usuario && x.TipoUsuario == TipoUsuario.ADMINISTRADOR);
        }

        public void cambiaTipo(string usuario, TipoUsuario tipo)
        {
            for(int i = 0; i < users.Count; i++)
                if (users[i].UserName == usuario)
                    users[i].TipoUsuario = tipo;
        }

        public bool cambiaContrasena(string usuario, string contrasenaVieja, string contrasenaNueva)
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].UserName == usuario && users[i].Password == "" + contrasenaVieja.GetHashCode())
                {
                    users[i].Password = contrasenaNueva;
                    return true;
                }
            return false;
        }

        public bool desbloqueaUsuario(string usuario)
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].UserName == usuario && users[i].NumeroIntentosLogin == 0)
                {
                    users[i].NumeroIntentosLogin = this.numeroIntentosLogin;
                    return true;
                }
            return false;
        }

        public IList<Evento> verLog()
        {
            return this.eventos;
        }

        public bool borrarLog()
        {
            if(this.eventos.Count > 0)
            {
                this.eventos[0].borraFichero();
                this.eventos = new List<Evento>();
                return true;
            }
            return false;
        }

        public bool lanzaEvento(string usuario, string seccion, TipoEvento tipo)
        {
            Evento tmp = new Evento(usuario, seccion, tipo, DateTime.Now);
            this.eventos.Add(tmp);
            tmp.grabaFichero();
            return true;
        }

        private void inicializarDatos()
        {
            this.creaUsuario("admin1", "Nombre Admin1", "Apellidos Admin1", "pass1", TipoUsuario.ADMINISTRADOR);
            this.creaUsuario("usuarioBloqueado1", "Nombre Bloq1", "Apellidos Bloq1", "pass1", TipoUsuario.BECARIO);
            for (int i = 0; i < users.Count; i++)
                if (users[i].UserName == "usuarioBloqueado1")
                    users[i].NumeroIntentosLogin = 0;
            this.creaUsuario("usuarioBloqueado2", "Nombre Bloq2", "Apellidos Bloq2", "pass2", TipoUsuario.BECARIO);
            for (int i = 0; i < users.Count; i++)
                if (users[i].UserName == "usuarioBloqueado2")
                    users[i].NumeroIntentosLogin = 0;
            this.lanzaEvento("pepe1", "login_screen", TipoEvento.LOGIN_EXITO);
            this.lanzaEvento("pepe1", "login_screen", TipoEvento.BORRADO_ILEGAL);
            this.lanzaEvento("pepe1", "login_screen", TipoEvento.LOGIN_EXITO);
            this.lanzaEvento("pepe1", "login_screen", TipoEvento.LOGIN_FALLIDO);
            this.lanzaEvento("pepe1", "login_screen", TipoEvento.LOGIN_EXITO);
        }
    }
}