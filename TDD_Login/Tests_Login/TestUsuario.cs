using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_Login
{
    [TestClass]
    public class TestUsuario
    {
        Usuario userInstancia;

        private Usuario fabrica()
        {
            if (userInstancia == null)
                userInstancia = new Usuario("user1", "Nombre 1", "Apellidos 1", "pass1", TipoUsuario.ADMINISTRADOR, 3);
            return userInstancia;
        }

        [TestMethod()]
        public void UserTest()
        {
            Usuario user = fabrica();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestNombre()
        {
            Usuario user = fabrica();
            Assert.AreEqual(user.Nombre, "Nombre 1");
            Assert.AreNotEqual(user.Nombre, "Nombre 2");
            user.Nombre = "Nombre 2";
            Assert.AreEqual(user.Nombre, "Nombre 2");
            Assert.AreNotEqual(user.Nombre, "Nombre 1");
        }

        [TestMethod]
        public void TestApellidos()
        {
            Usuario user = fabrica();
            Assert.AreEqual(user.Apellidos, "Apellidos 1");
            Assert.AreNotEqual(user.Apellidos, "Apellidos 2");
            user.Apellidos = "Apellidos 2";
            Assert.AreEqual(user.Apellidos, "Apellidos 2");
            Assert.AreNotEqual(user.Apellidos, "Apellidos 1");
        }

        [TestMethod]
        public void TestUsername()
        {
            Usuario user = fabrica();
            Assert.AreEqual(user.UserName, "user1");
            Assert.AreNotEqual(user.UserName, "user2");
        }

        [TestMethod]
        public void TestPassword()
        {
            Usuario user = fabrica();
            Assert.AreNotEqual(user.Password, "pass1");
            Assert.AreEqual(user.Password, "pass1".GetHashCode());
            Assert.AreNotEqual(user.Password, "pass2".GetHashCode());
        }

        [TestMethod]
        public void TestTipoUsuario()
        {
            Usuario user = fabrica();
            Assert.AreEqual(user.TipoUsuario, TipoUsuario.ADMINISTRADOR);
            Assert.AreNotEqual(user.TipoUsuario, TipoUsuario.BECARIO);
            user.TipoUsuario = TipoUsuario.BECARIO;
            Assert.AreEqual(user.TipoUsuario, TipoUsuario.BECARIO);
            Assert.AreNotEqual(user.TipoUsuario, TipoUsuario.ADMINISTRADOR);
        }

        [TestMethod]
        public void TestNumeroIntentosLogin()
        {
            Usuario user = fabrica();
            Assert.AreEqual(user.NumeroIntentosLogin, 3);
            Assert.AreNotEqual(user.NumeroIntentosLogin, 5);
            user.NumeroIntentosLogin = 5;
            Assert.AreEqual(user.NumeroIntentosLogin, 5);
            Assert.AreNotEqual(user.NumeroIntentosLogin, 3);
        }

        [TestMethod()]
        public void TestEquals()
        {
            Usuario user = fabrica();
            Usuario user2 = new Usuario("user66", "Nombre 1", "Apellidos 1", "pass1", TipoUsuario.ADMINISTRADOR, 3);
            Usuario user3 = new Usuario("user1", "Nombre 66", "Apellidos 66", "pass66", TipoUsuario.BECARIO, 5);
            Assert.IsTrue(user.Equals(user3));
            Assert.IsFalse(user.Equals(user2));
        }
    }
}
