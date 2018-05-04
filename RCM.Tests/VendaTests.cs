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

            venda.AdicionarProduto(produto, 0, 0, 1);

            Assert.AreEqual(1, venda.QuantidadeProdutos);
        }

        [TestMethod]
        public void TestProdutoValor()
        {
            Produto produto = GetProdutos().First();
            Venda venda = new Venda(DateTime.Now, "Sem detalhes", GetCliente());
            VendaProduto vendaProduto = new VendaProduto(venda, produto, 78, 0, 1);

            Assert.AreEqual(200, vendaProduto.PrecoFinal);
        }

        [TestMethod]
        public void TestProdutoValorQuantidade()
        {
            Produto produto = GetProdutos().First();
            Venda venda = new Venda(DateTime.Now, "Sem detalhes", GetCliente());
            VendaProduto vendaProduto = new VendaProduto(venda, produto, 0, 0, 2);

            Assert.AreEqual(200, vendaProduto.PrecoFinal);
        }

        [TestMethod]
        public void TestVendaFinalizador()
        {
            Cliente cliente = GetCliente();
            List<Produto> produtos = GetProdutos();

            Venda venda = new Venda(DateTime.Now, "Sem detalhes", cliente);

            venda.AdicionarProduto(produtos.First(), 2, 0, 7);
            venda.AdicionarProduto(produtos.Last(), 2, 0, 1);
            //venda.RemoverProduto(produtos.Last());

            Assert.AreEqual(1, venda.Errors.Count);
        }

        [TestMethod]
        public void TestVendaAddRemove()
        {
            Cliente cliente = GetCliente();
            List<Produto> produtos = GetProdutos();

            Venda venda = new Venda(DateTime.Now, "Sem detalhes", cliente);

            venda.AdicionarProduto(produtos[0], desconto: 0, acrescimo: 0, quantidade: 3);

            //Assert.AreEqual(2, produtos[0].Estoque);
            venda.RemoverProduto(produtos[0]);

            Assert.AreEqual(5, produtos[0].Estoque);
            //Assert.AreEqual("O estoque não tem essa quantidade disponível.", venda.Errors.First().Description);
        }

        public List<Produto> GetProdutos()
        {
            Produto produto = new Produto("Vela Ignicao", ProdutoUnidadeEnum.KIT, 5, 1, 5, 100, new Marca("NGK"));
            Produto produto2 = new Produto("Disco de freio", ProdutoUnidadeEnum.KIT, 5, 4, 2, 140, new Marca("Axios"));

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
