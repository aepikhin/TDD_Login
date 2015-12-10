using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_Login
{
    [TestClass]
    public class TestUsuario
    {
        [TestMethod]
        public void TestMethod1()
        {
            Usuario user = new Usuario("user1", "Nombre 1", "Apellidos 1", "pass1", TipoUsuario.ADMINISTRADOR);

            Assert.IsTrue(user.Nombre, "Nombre 1");
            Assert.IsFalse(user.Nombre, "Nombre 2");
        }
    }
}
