using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class ClienteApplicationService : BaseApplicationService<Cliente, ClienteViewModel>, IClienteApplicationService
    {
        public ClienteApplicationService(IClienteRepository clienteRepository, IMapper mapper, IMediatorHandler mediator) : base(clienteRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(ClienteViewModel viewModel)
        {
            var command = new AddClienteCommand(viewModel.Nome, viewModel.Tipo, viewModel.Pontuacao, viewModel.Descricao);
            command.AttachContato(viewModel.Contato.Celular, viewModel.Contato.Email, viewModel.Contato.TelefoneComercial, viewModel.Contato.TelefoneResidencial, viewModel.Contato.Observacao);
            command.AttachEndereco(viewModel.Endereco.Numero, viewModel.Endereco.Rua, viewModel.Endereco.Bairro, viewModel.Endereco.Complemento, viewModel.Endereco.CidadeId, viewModel.Endereco.CEP);
            command.AttachDocumento(viewModel.Documento.CadastroNacional, viewModel.Documento.CadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Update(ClienteViewModel viewModel)
        {
            var command = new UpdateClienteCommand(viewModel.Id, viewModel.Nome, viewModel.Tipo, viewModel.Pontuacao, viewModel.Descricao);
            command.AttachContato(viewModel.Contato.Celular, viewModel.Contato.Email, viewModel.Contato.TelefoneComercial, viewModel.Contato.TelefoneResidencial, viewModel.Contato.Observacao);
            command.AttachEndereco(viewModel.Endereco.Numero, viewModel.Endereco.Rua, viewModel.Endereco.Bairro, viewModel.Endereco.Complemento, viewModel.Endereco.CidadeId, viewModel.Endereco.CEP);
            command.AttachDocumento(viewModel.Documento.CadastroNacional, viewModel.Documento.CadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Remove(ClienteViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveClienteCommand(viewModel.Id));
        }
    }
}
