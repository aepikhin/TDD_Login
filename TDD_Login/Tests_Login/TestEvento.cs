using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Login;

namespace Tests_Login
{
    [TestClass]
    public class TestEvento
    {
        Evento eventoInstancia;
        DateTime fecha;

        private Evento fabrica()
        {
            if (eventoInstancia == null)
                fecha = DateTime.Today;
                eventoInstancia = new Evento("user1", "login", TipoEvento.LOGIN_EXITO, fecha);
            return eventoInstancia;
        }

        [TestMethod()]
        public void EventoTest()
        {
            Evento evento = fabrica();
            Assert.IsNotNull(evento);
        }

        [TestMethod]
        public void TestUsername()
        {
            Evento evento = fabrica();
            Assert.AreEqual(evento.Username, "user1");
            Assert.AreNotEqual(evento.Username, "user2");
        }

        [TestMethod]
        public void TestSeccion()
        {
            Evento evento = fabrica();
            Assert.AreEqual(evento.Seccion, "login");
            Assert.AreNotEqual(evento.Seccion, "login2");
        }

        [TestMethod]
        public void TestTipoEvento()
        {
            Evento evento = fabrica();
            Assert.AreEqual(evento.TipoEvento, TipoEvento.LOGIN_EXITO);
            Assert.AreNotEqual(evento.TipoEvento, TipoEvento.LOGIN_FALLIDO);
        }

        [TestMethod]
        public void TestFecha()
        {
            Evento evento = fabrica();
            Assert.AreEqual(evento.Fecha, fecha);
            Assert.AreNotEqual(evento.Fecha, fecha.AddDays(-3));
        }

        [TestMethod()]
        public void TestGrabaFichero()
        {
            Evento evento = fabrica();
            Assert.IsTrue(evento.grabaFichero());
        }

        [TestMethod()]
        public void TestBorraFichero()
        {
            Evento evento = fabrica();
            Assert.IsTrue(evento.borraFichero());
        }

        [TestMethod()]
        public void TestEquals()
        {// Fechas no detalladas con hora.
            Evento evento = fabrica();
            Evento evento2 = new Evento("user2", "table", TipoEvento.BORRADO, fecha);
            Evento evento3 = new Evento("user2", "table", TipoEvento.BORRADO, fecha.AddDays(-3));
            Assert.IsTrue(evento.Equals(evento2));
            Assert.IsFalse(evento.Equals(evento3));
        }
    }
}
