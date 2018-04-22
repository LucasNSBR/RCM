using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Models;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class ProdutoAplicacaoTests
    {
        [TestMethod]
        public void TestProduto()
        {
            var mock = new Mock<IProdutoRepository>();
            mock.Setup(exp => exp.Get()).Returns(GetProdutos());
            var objects = mock.Object.Get();

            Assert.AreEqual(3, objects.Count());
        }

        [TestMethod]
        public void TestAplicacao()
        {
            Marca marca = new Marca("NGK");
            Aplicacao aplicacao = new Aplicacao(new Carro("Toyota", "Hilux"));
            Aplicacao aplicacao2 = new Aplicacao(new Carro("Toyota", "Corolla"));

            Produto produto = new Produto("Vela Ignição Toyota", 12, 122, marca);
            produto.AdicionarAplicacao(aplicacao);
            produto.AdicionarAplicacao(aplicacao2);

            produto.RemoverAplicacao(aplicacao2);

            Assert.AreEqual(1, produto.Aplicacoes.Count);
        }

        [TestMethod]
        public void TestMethod()
        {
            Marca marca = new Marca("NGK");
            Aplicacao aplicacao = new Aplicacao(new Carro("Toyota", "Hilux"));
            Aplicacao aplicacao2 = new Aplicacao(new Carro("Toyota", "Corolla"));
            Produto produto = new Produto("Vela Ignição Toyota", 12, 122, marca);
            Produto produto2 = new Produto("Vela Ignição", 12, 122, marca);

            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao(produto, aplicacao);
            ProdutoAplicacao produtoAplicacao2 = new ProdutoAplicacao(produto, aplicacao);

            Assert.IsTrue(produtoAplicacao.Equals(produtoAplicacao2));
        }

        public IQueryable<Produto> GetProdutos()
        {
            Marca marcaSKF = new Marca("SKF");
            Marca marcaNGK = new Marca("NGK");

            return new List<Produto>()
            {
                new Produto("Rolamento", 2, 122, marcaSKF),
                new Produto("Vela Ignição VW", 3, 81, marcaNGK),
                new Produto("Vela Ignição Honda", 2, 122, marcaNGK),
            }
            .AsQueryable();
        }
    }
}
