using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Login;
using System.Linq;

namespace Tests_Login
{
    [TestClass]
    public class TestDBPruebas
    {
        DBPruebas dbInstancia;

        private DBPruebas fabrica()
        {
            if (dbInstancia == null)
                dbInstancia = new DBPruebas();
            return dbInstancia;
        }

        [TestMethod()]
        public void DBPruebasTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db);
        }

        [TestMethod()]
        public void TestValida()
        {
            DBPruebas db = fabrica();

            Assert.IsTrue(db.valida("admin1", "pass1"));
            Assert.IsFalse(db.valida("admin1", "" + "pass1".GetHashCode()));
            Assert.IsFalse(db.valida("admin1", "pass2"));
            
            Assert.IsFalse(db.valida("admin2", "pass1"));

            Assert.IsFalse(db.valida("usuarioBloqueado1", "pass1"));
        }

        [TestMethod()]
        public void TestCreaUsuario()
        {
            DBPruebas db = fabrica();

            Assert.IsTrue(db.creaUsuario("userTest", "Nombre 1", "Apellidos 1", "pass1", TipoUsuario.ADMINISTRADOR));
            Assert.IsFalse(db.creaUsuario("userTest", "Nombre 2", "Apellidos 2", "pass2", TipoUsuario.BECARIO));
        }

        [TestMethod()]
        public void TestCambiaTipo_TestEsAdministrador()
        {
            DBPruebas db = fabrica();
            String userName = "userTest2";
            db.creaUsuario(userName, "Nombre 2", "Apellidos 2", "pass2", TipoUsuario.ADMINISTRADOR);
            
            Assert.IsTrue(db.esAdministrador(userName));
            db.cambiaTipo(userName, TipoUsuario.BECARIO);
            Assert.IsFalse(db.esAdministrador(userName));
        }

        [TestMethod()]
        public void TestCambiaContrasena()
        {
            DBPruebas db = fabrica();
            String userName = "userTest3";
            db.creaUsuario(userName, "Nombre 3", "Apellidos 3", "pass3", TipoUsuario.ADMINISTRADOR);
            
            Assert.IsTrue(db.cambiaContrasena(userName, "pass3", "passNueva"));
            Assert.IsFalse(db.cambiaContrasena(userName, "pass3", "passNueva"));
        }

        [TestMethod()]
        public void TestDesbloqueaUsuario()
        {
            DBPruebas db = fabrica();
            String userName = "usuarioBloqueado2";
            Assert.IsFalse(db.valida(userName, "pass2"));
            Assert.IsTrue(db.desbloqueaUsuario(userName));
            Assert.IsTrue(db.valida(userName, "pass2"));

            userName = "userTest4";
            db.creaUsuario(userName, "Nombre 4", "Apellidos 4", "pass4", TipoUsuario.ADMINISTRADOR);
            Assert.IsFalse(db.desbloqueaUsuario(userName)); // No está bloqueado, por lo tanto da False.
        }

        [TestMethod()]
        public void TestBorrarLog_VerLog()
        {
            DBPruebas db = fabrica();
            Assert.AreEqual(db.verLog().Count, 5);
            Assert.IsTrue(db.borrarLog());
            Assert.AreEqual(db.verLog().Count, 0);
        }

        [TestMethod()]
        public void TestLanzaEvento()
        {
            DBPruebas db = fabrica();
            String userName = "userTest5";
            db.creaUsuario(userName, "Nombre 5", "Apellidos 5", "pass5", TipoUsuario.ADMINISTRADOR);
            Assert.IsTrue(db.borrarLog());
            Assert.IsTrue(db.lanzaEvento(userName, "login", TipoEvento.LOGIN_EXITO));
            Assert.IsTrue(db.verLog().Any(x => x.TipoEvento == TipoEvento.LOGIN_EXITO));
            Assert.IsTrue(db.verLog().Any(x => x.Username == userName));
            Assert.IsTrue(db.verLog().Any(x => x.Seccion == "login"));
        }
    }
    
}
