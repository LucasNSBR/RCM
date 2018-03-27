using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCM.Tests
{
    [TestClass]
    public class ProdutoSpecificationTestClass
    {
        [TestMethod]
        public void TestNomeSpecification()
        {
            ProdutoNomeSpecification spec = new ProdutoNomeSpecification("a");
            var appService = new Mock<IProdutoApplicationService>();
            appService.Setup(cfg => cfg.Get(spec.ToExpression())).Returns(GetProdutos());

            Assert.AreEqual(2, appService.Object.Get().Count());
        }

        public IQueryable<ProdutoViewModel> GetProdutos()
        {
            return new List<ProdutoViewModel>()
            {
                new ProdutoViewModel()
                {
                    Nome = "Embreagem GM",
                    Aplicacao = "GM"
                },

                new ProdutoViewModel()
                {
                    Nome = "Sapata Freio Fiat",
                    Aplicacao = "GM"
                },

                new ProdutoViewModel()
                {
                    Nome = "Coxim Embreagem GM",
                    Aplicacao = "GM"
                },
            }.AsQueryable();
        }
    }
}
