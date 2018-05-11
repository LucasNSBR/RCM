using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Models;
using RCM.Domain.Models.ClienteModels;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Tests
{
    [TestClass]
    public class ClienteSpecificationTests
    {
        [TestMethod]
        public void TestClienteSpecifications()
        {
            //var nomeSpecification = new ClienteNomeSpecification("lucas");
            //var pontuacaoSpecification = new ClientePontuacaoSpecification(1);
            var tipoSpecification = new ClienteTipoSpecification(0);

            var count = GetClientes()
                .AsQueryable()
                .Where(tipoSpecification.ToExpression())
                .Count();

            Assert.AreEqual(4, count);
        }

        public List<Cliente> GetClientes()
        {
            Documento documento = new Documento();
            Contato contato = new Contato();
            Endereco endereco = new Endereco(100, "Rua", "bairro");

            return new List<Cliente>()
            {
                new Cliente("Lucas", ClienteTipoEnum.PessoaJuridica, ClientePontuacaoEnum.Bom, documento, contato, endereco),
                new Cliente("Leo", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Excelente, documento, contato, endereco),
                new Cliente("Laura", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Mediano, documento, contato, endereco),
                new Cliente("Sabrina", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Mediano, documento, contato, endereco),
                new Cliente("Marcelo", ClienteTipoEnum.PessoaFisica, ClientePontuacaoEnum.Ruim, documento, contato, endereco),
            };
        }
    }
}
