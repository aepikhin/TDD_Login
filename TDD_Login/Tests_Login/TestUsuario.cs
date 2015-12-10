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
            Assert.IsTrue(user.Nombre, "Nombre 1");
            Assert.IsFalse(user.Nombre, "Nombre 2");
            user.Nombre = "Nombre 2";
            Assert.IsTrue(user.Nombre, "Nombre 2");
            Assert.IsFalse(user.Nombre, "Nombre 1");
        }

        [TestMethod]
        public void TestApellidos()
        {
            Usuario user = fabrica();
            Assert.IsTrue(user.Apellidos, "Apellidos 1");
            Assert.IsFalse(user.Apellidos, "Apellidos 2");
            user.Apellidos = "Apellidos 2";
            Assert.IsTrue(user.Apellidos, "Apellidos 2");
            Assert.IsFalse(user.Apellidos, "Apellidos 1");
        }

        [TestMethod]
        public void TestUsername()
        {
            Usuario user = fabrica();
            Assert.IsTrue(user.UserName, "user1");
            Assert.IsFalse(user.UserName, "user2");
        }

        [TestMethod]
        public void TestPassword()
        {
            Usuario user = fabrica();
            Assert.IsFalse(user.Password, "pass1");
            Assert.IsTrue(user.Password, "pass1".GetHashCode());
            Assert.IsFalse(user.Password, "pass2".GetHashCode());
        }

        [TestMethod]
        public void TestTipoUsuario()
        {
            Usuario user = fabrica();
            Assert.IsTrue(user.TipoUsuario, TipoUsuario.ADMINISTRADOR);
            Assert.IsFalse(user.TipoUsuario, TipoUsuario.BECARIO);
            user.TipoUsuario = TipoUsuario.BECARIO;
            Assert.IsTrue(user.TipoUsuario, TipoUsuario.BECARIO);
            Assert.IsFalse(user.TipoUsuario, TipoUsuario.ADMINISTRADOR);
        }

        [TestMethod]
        public void TestNumeroIntentosLogin()
        {
            Usuario user = fabrica();
            Assert.IsTrue(user.NumeroIntentosLogin, 3);
            Assert.IsFalse(user.NumeroIntentosLogin, 5);
            user.NumeroIntentosLogin = 5;
            Assert.IsTrue(user.NumeroIntentosLogin, 5);
            Assert.IsFalse(user.NumeroIntentosLogin, 3);
        }
    }
}
