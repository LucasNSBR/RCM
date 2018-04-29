using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Tests
{
    [TestClass]
    public class ContatoEmptyTests
    {
        [TestMethod]
        public void ClienteContatoEmpty()
        {
            Contato contato = new Contato();
            Cliente cliente = new Cliente("Lucas", contato);

            Assert.AreEqual(true, cliente.Contato.IsEmpty);
        }

        [TestMethod]
        public void TestContatoEmpty()
        {
            Contato contato = new Contato();
            Assert.AreEqual(true, contato.IsEmpty);
        }

        [TestMethod]
        public void TestContatoNotEmpty()
        {
            Contato contato = new Contato("(37) 0000-0000");
            Assert.AreEqual(false, contato.IsEmpty);
        }
    }
}
