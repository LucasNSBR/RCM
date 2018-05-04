using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class VendaTests
    {
        [TestMethod]
        public void TestVenda()
        {
            Cliente cliente = GetCliente();
            Produto produto = GetProdutos().First();

            Venda venda = new Venda(DateTime.Now, "Sem detalhes", cliente);

            venda.AdicionarProduto(produto, 0, 0);

            Assert.AreEqual(1, venda.TotalProdutos);
        }

        [TestMethod]
        public void TestProdutoValor()
        {
            Produto produto = GetProdutos().First();
            Venda venda = new Venda(DateTime.Now, "Sem detalhes", GetCliente());
            VendaProduto vendaProduto = new VendaProduto(venda, produto, 78, 0);

            Assert.AreEqual(200, vendaProduto.PrecoFinal);
        }

        [TestMethod]
        public void TestVendaFinalizador()
        {
            Cliente cliente = GetCliente();
            List<Produto> produtos = GetProdutos();

            Venda venda = new Venda(DateTime.Now, "Sem detalhes", cliente);

            venda.AdicionarProduto(produtos.First(), 2, 0);
            venda.AdicionarProduto(produtos.Last(), 2, 0);
            venda.RemoverProduto(produtos.Last());

            venda.Finalizar();

            //Assert.AreEqual(4, venda.Produtos.First().Produto.Estoque);
            //Assert.AreEqual(venda.TotalVenda, venda.Produtos.Sum(pv => pv.PrecoFinal));
            Assert.AreEqual(venda.Status, VendaStatusEnum.Fechada);
        }

        public List<Produto> GetProdutos()
        {
            Produto produto = new Produto("Vela Ignicao", 5, 1, 5, 122, new Marca("NGK"));
            Produto produto2 = new Produto("Disco de freio", 5, 4, 2, 142, new Marca("Axios"));

            return new List<Produto>()
            {
                produto, produto2
            };
        }

        public Cliente GetCliente()
        {
            Documento doc = new Documento();
            Contato cont = new Contato();
            Endereco end = new Endereco(100, "One Microsoft Way", "Redmond");
            Cliente cliente = new Cliente("Lucas Pereira Campos", doc, cont, end);

            return cliente;
        }
    }
}
