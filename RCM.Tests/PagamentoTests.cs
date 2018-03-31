using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCM.Tests
{
    [TestClass]
    public class PagamentoTests
    {
        [TestMethod]
        public void PagamentoIsEmpty()
        {
            Pagamento pagamento = new Pagamento();
            Assert.AreEqual(true, pagamento.IsEmpty());

            Pagamento pagamentoFilled = new Pagamento(DateTime.Now, 100);
            //Assert.AreEqual(true, pagamentoFilled.IsEmpty());
        }
    }
}
