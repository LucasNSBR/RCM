using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Specifications;
using RCM.Presentation.Web.Areas.Platform.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class BancoSpecificationTests
    {
        [TestMethod]
        public void TestBancoSpecification()
        {
            var mock = new Mock<IBancoApplicationService>();
            var notifications = new Mock<IDomainNotificationHandler>();
            var spec = new BancoNomeSpecification("banco");

            // mock.Setup(exp => exp.Get(spec.ToExpression())).Returns(GetBancos());
            
            var controller = new BancosController(mock.Object, notifications.Object);
            var result = (controller.Index() as ViewResult).ViewData.Model;

            Assert.AreEqual(2, (result as IEnumerable<BancoViewModel>).Count());

        }

        public IQueryable<BancoViewModel> GetBancos()
        {
            return new List<BancoViewModel>()
            {
                new BancoViewModel
                {
                    Id = 1,
                    CodigoCompensacao = 241,
                    Nome = "Banco Itaú"
                },
                new BancoViewModel
                {
                    Id = 2,
                    CodigoCompensacao = 241,
                    Nome = "Banco Bradesco"
                },
                new BancoViewModel
                {
                    Id = 3,
                    CodigoCompensacao = 241,
                    Nome = "JP Morgan Chase"
                },
            }.AsQueryable();
        }
    }
}
