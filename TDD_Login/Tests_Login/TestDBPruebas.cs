using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsFalse(db.valida("admin1", "pass1".GetHashCode()));
            Assert.IsFalse(db.valida("admin1", "pass2"));

            Assert.IsTrue(db.valida("admin1", "pass1"));
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
            String userName = "userTest3";
            db.creaUsuario(userName, "Nombre 3", "Apellidos 3", "pass3", TipoUsuario.ADMINISTRADOR);

            //TODO
        }

        [TestMethod()]
        public void TestBorrarLog()
        {
            DBPruebas db = fabrica();
            String userName = "userTest3";
            db.creaUsuario(userName, "Nombre 3", "Apellidos 3", "pass3", TipoUsuario.ADMINISTRADOR);

            //TODO
        }

        [TestMethod()]
        public void TestGrabaEvento()
        {
            DBPruebas db = fabrica();
            String userName = "userTest3";
            db.creaUsuario(userName, "Nombre 3", "Apellidos 3", "pass3", TipoUsuario.ADMINISTRADOR);

            //TODO
        }
    }
    
}
