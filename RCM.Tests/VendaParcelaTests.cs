using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class VendaParcelaTests
    {
        //[TestMethod]
        //public void TestParcela()
        //{
        //    var cliente = GetCliente();

        //    var parcelas = new List<Parcela>();
        //    parcelas.Add(new Parcela(1, DateTime.Now.AddDays(7), 1500));
        //    parcelas.Add(new Parcela(2, DateTime.Now.AddDays(7).AddDays(7), 1500));
        //    parcelas.Add(new Parcela(3, DateTime.Now.AddDays(7).AddDays(7).AddDays(7), 1500));

        //    var venda = new Venda(DateTime.Now, "Sem detalhes", cliente);
        //    //venda.AdicionarParcelas(parcelas);
        //    Assert.AreEqual(3, venda.Parcelamento.Count);
        //}

        //[TestMethod]
        //public void TestConfiguraParcelas()
        //{
        //    var cliente = GetCliente();
        //    var venda = new Venda(DateTime.Now, "Sem detalhes", cliente);

        //    var list = venda.CriarParcelas(4, 30, 1000);

        //    Assert.AreEqual(DateTime.Now.AddDays(30).Date, list.First().DataVencimento.Date);
        //}


        public Cliente GetCliente()
        {
            var documento = new Documento("22513155", "1515551");
            var contato = new Contato();
            var endereco = new Endereco("Rua A", 122, "Central", "", new Cidade("SP", new Estado("SP", "São Paulo")), "3511511");

            return new Cliente("Lucas", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Bom, documento, contato, endereco);
        }
    }
}
