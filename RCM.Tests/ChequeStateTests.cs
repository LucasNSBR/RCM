using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Tests
{
    [TestClass]
    public class ChequeStateTests
    {
        [TestMethod]
        public void SetBloqueado()
        {
            Banco banco = new Banco("Itaú", 412);
            Cliente cliente = new Cliente("Lucas Pereira Campos");

            Cheque cheque = new Cheque(banco, "4117", "256-9", "000065", cliente, DateTime.Now, DateTime.Now.AddMonths(10), 1200);

            Assert.AreEqual("Bloqueado", cheque.EstadoCheque.Estado);
        }

        [TestMethod]
        public void SetSustado()
        {
            Banco banco = new Banco("Itaú", 412);
            Cliente cliente = new Cliente("Lucas Pereira Campos");

            Cheque cheque = new Cheque(banco, "4117", "256-9", "000065", cliente, DateTime.Now, DateTime.Now.AddMonths(10), 1200);
            cheque.Sustar(DateTime.Now, "Motivo 12");

            Assert.AreEqual("Sustado", cheque.EstadoCheque.Estado);
        }

        [TestMethod]
        public void SetRepassado()
        {
            Banco banco = new Banco("Itaú", 412);
            Cliente cliente = new Cliente("Lucas Pereira Campos");
            Cliente clienteRepassado = new Cliente("Otacilio Rocha Campos");

            Cheque cheque = new Cheque(banco, "4117", "256-9", "000065", cliente, DateTime.Now, DateTime.Now.AddMonths(10), 1200);
            cheque.Repassar(DateTime.Now, clienteRepassado);

            Assert.AreEqual("Repassado", cheque.EstadoCheque.Estado);
        }
    }
}
