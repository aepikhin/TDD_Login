using System;
using System.IO;

namespace Clases_Login
{
    public class Evento
    {
        private DateTime fecha;
        private TipoEvento tipoEvento;
        private string username;
        private string seccion;
        private string path = @"ServerLog.log";

        public Evento(string username, string seccion, TipoEvento tipoEvento, DateTime fecha)
        {
            this.username = username;
            this.seccion = seccion;
            this.tipoEvento = tipoEvento;
            this.fecha = fecha;
        }

        public string Username
        {
            get { return this.username; }
        }

        public string Seccion
        {
            get { return this.seccion; }
        }

        public TipoEvento TipoEvento
        {
            get { return this.tipoEvento; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
        }

        public bool grabaFichero()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(this.Fecha + " - " + this.Username + " - " + this.Seccion + " - " + this.TipoEvento + "\n");
                tw.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(this.Fecha + " - " + this.Username + " - " + this.Seccion + " - " + this.TipoEvento + "\n");
                tw.Close();
            }
            return true;
        }

        public bool borraFichero()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public bool Equals(Evento evento)
        {
            return this.Fecha == evento.Fecha;
        }
    }

    public enum TipoEvento
    {
        LOGIN_EXITO = 1,
        LOGIN_FALLIDO = 2,
        BORRADO = 3,
        BORRADO_ILEGAL = 4,
        LOGOUT = 5
    }
}