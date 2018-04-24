using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Application.ViewModels;
using RCM.Presentation.Web.Extensions;
using RCM.Presentation.Web.ViewModels;
using System.Collections.Generic;

namespace RCM.Tests
{
    [TestClass]
    public class DuplicataIndexViewModelTest
    {
        [TestMethod]
        public void TestDuplicataIndexMethodValorTotalResultados()
        {
            DuplicataIndexViewModel vm = new DuplicataIndexViewModel()
            {
                Duplicatas = GetDuplicatas().ToPagedList()
            };

            Assert.AreEqual(300.48m, vm.ValorTotalResultados);
        }

        [TestMethod]
        public void TestDuplicataIndexMethodTotalResultados()
        {
            DuplicataIndexViewModel vm = new DuplicataIndexViewModel()
            {
                Duplicatas = GetDuplicatas().ToPagedList()
            };

            Assert.AreEqual(3, vm.TotalResultados);
        }

        public List<DuplicataViewModel> GetDuplicatas()
        {
            return new List<DuplicataViewModel>
            {
                new DuplicataViewModel { Valor = 100 },
                new DuplicataViewModel { Valor = 100.48m },
                new DuplicataViewModel { Valor = 100 },
            };

        }
    }
}
