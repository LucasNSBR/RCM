using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Presentation.Web.Areas.Platform.Controllers;
using RCM.Presentation.Web.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class AccountControllerTestClass
    {
        [TestMethod]
        public void RecoverEmailResponse()
        {
            //var mock = new Mock<IBancoApplicationService>();
            //var notifications = new Mock<IDomainNotificationHandler>();
            //mock.Setup(exp => exp.Get()).Returns(GetBancos());

            //var controller = new BancosController(mock.Object, notifications.Object);
            //var result = (controller.Index() as ViewResult).ViewData.Model;
            ////Assert.IsInstanceOfType(controller.Index(), typeof(ViewResult));

            //Assert.AreEqual(2, (result as IEnumerable<BancoViewModel>).Count());

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
                    Nome = "Banco do Brasil"
                },
            }.AsQueryable();
        }

        public void TestAccountSettingsController()
        {
            var mock = new Mock<AccountsController>();
            var notifications = new Mock<IDomainNotificationHandler>();
        }
    }
}
