using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void TestListaDePaquetes()
        {
            Correo c1 = new Correo();

            Assert.AreNotEqual(c1.Paquetes, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestPaquetesIguales()
        {
            Correo c1 = new Correo();
            Paquete p1 = new Paquete("direccion", "123-123-1234");
            Paquete p2 = new Paquete("direccion", "123-123-1234");

            c1 += p1;
            c1 += p2;

            Assert.AreEqual(p1.TrackingID, p2.TrackingID);
        }
    }
}
