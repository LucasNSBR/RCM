using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Tests
{
    [TestClass]
    public class ProdutoFornecedorTests
    {
        [TestMethod]
        public void TestAddFornecedor()
        {
            Marca marca = new Marca("NGK");
            Fornecedor fornecedor = new Fornecedor("BHZ");
            Produto produto = new Produto("Vela Ignição Toyota", 2, 4, 6, 122, marca);

            produto.AdicionarFornecedor(fornecedor, 129, ProdutoDisponibilidadeEnum.Alta);
            produto.AdicionarFornecedor(fornecedor, 129, ProdutoDisponibilidadeEnum.Alta);

            Assert.AreEqual(1, produto.Errors.Count);
            //Assert.AreEqual(1, produto.Fornecedores.Count);
        }
    }
}
