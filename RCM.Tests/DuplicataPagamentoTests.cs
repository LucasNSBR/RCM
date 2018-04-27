using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.FornecedorModels;
using System;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class DuplicataPagamentoTests
    {
        [TestMethod]
        public void TestDuplicataPagamento()
        {
            Fornecedor fornecedor = new Fornecedor("BHZ");
            Duplicata duplicata = new Duplicata("00001-A", DateTime.Now, DateTime.Now.AddDays(30), fornecedor, 100.0m);

            duplicata.EstornarPagamento();

            //Assert.AreEqual(2, duplicata.Errors.Count);
            Assert.AreEqual("Esse título ainda não foi pago.", duplicata.Errors.First().Description);
        }

        [TestMethod]
        public void TestDuplicataEstorno()
        {
            Fornecedor fornecedor = new Fornecedor("BHZ");
            Duplicata duplicata = new Duplicata("00001-A", DateTime.Now, DateTime.Now.AddDays(30), fornecedor, 100.0m);
            Pagamento pagamento = new Pagamento(DateTime.Now, 122);

            duplicata.Pagar(pagamento);
            duplicata.Pagar(pagamento);

            //Assert.AreEqual(1, duplicata.Errors.Count);
            Assert.AreEqual("O pagamento desse título já foi efetuado.", duplicata.Errors.First().Description);
        }
    }
}
