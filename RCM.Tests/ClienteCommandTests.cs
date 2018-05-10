using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Models;

namespace RCM.Tests
{
    [TestClass]
    public class ClienteCommandTests
    {
        [TestMethod]
        public void TestClienteCommandValidator()
        {
            var command = new AddClienteCommand("John Doe", Domain.Models.ClienteModels.ClientePontuacaoEnum.Bom, "Sem descrição");
            var contato = new Contato("37 0000-0000");

            command.AttachContato(contato.Celular, contato.Email, contato.TelefoneComercial, contato.TelefoneResidencial, contato.Observacao);

            Assert.AreEqual(true, command.IsValid());
        }
    }
}
