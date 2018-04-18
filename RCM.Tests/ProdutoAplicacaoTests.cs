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
            Aplicacao aplicacao = new Aplicacao(new Carro("Toyota", "Hilux"));
            Assert.AreEqual("Hilux", aplicacao.Carro.Modelo);
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
