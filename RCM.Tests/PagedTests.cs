using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models.BancoModels;
using RCM.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using RCM.Presentation.Web.Extensions;

namespace RCM.Tests
{
    [TestClass]
    public class PagedTests
    {
        [TestMethod]
        public void TestPageMethod()
        {
            IEnumerable<Banco> bancos = new List<Banco>()
            {
                new Banco("Bradesco", 124),
                new Banco("Banco do Brasil", 124),
                new Banco("Safra", 124),
                new Banco("Sicredi", 124),
                new Banco("Intermedium", 124),
                new Banco("Itau", 124),
                new Banco("Sicoob", 124),
                new Banco("Caixa", 124),

            };

            var list = bancos.AsQueryable().ToPagedList(2, 3);
            Assert.AreEqual("Sicredi", list.List.First().Nome);
        }
    }
}
