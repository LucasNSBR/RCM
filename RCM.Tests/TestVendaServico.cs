using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ServicoModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Models.VendaModels;
using System;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class TestVendaServico
    {
        [TestMethod]
        public void TestServicos()
        {
            var venda = GetVenda();
            var servico = new Servico(venda, "Mão de Obra", 100);

            venda.AdicionarServico(servico);

            Assert.AreEqual(1, venda.Servicos.Count);
        }

        [TestMethod]
        public void TestQuantidadeItemsVenda()
        {
            var venda = GetVenda();
            var servico = new Servico(venda, "Serviço", 125);

            venda.AdicionarServico(servico);

            Assert.AreEqual(1, venda.QuantidadeItens);
        }

        [TestMethod]
        public void TestRemoveServico()
        {
            var venda = GetVenda();
            var id = Guid.NewGuid();

            var servico = new Servico(id, venda, "Serviço", 125);
            venda.AdicionarServico(servico);

            var servicoFromList = venda.Servicos.FirstOrDefault(s => s.Id == id);

            Assert.AreEqual(125, servicoFromList.PrecoServico);
        }

        public Venda GetVenda()
        {
            Cliente c = new Cliente("Lucas", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Bom, new Documento("", ""), new Contato(), new Endereco("", 100, "", "", new Cidade("", new Estado("", "")), ""));
            var venda = new Venda(DateTime.Now, "", c);

            return venda;
        }
    }
}
