using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;

namespace RCM.Tests
{
    [TestClass]
    public class ContatoEmptyTests
    {
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
