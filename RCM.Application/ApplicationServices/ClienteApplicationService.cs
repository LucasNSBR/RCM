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
            command.AttachContato(viewModel.ContatoCelular, viewModel.ContatoEmail, viewModel.ContatoTelefoneComercial, viewModel.ContatoTelefoneResidencial, viewModel.ContatoObservacao);
            command.AttachEndereco(viewModel.EnderecoNumero, viewModel.EnderecoRua, viewModel.EnderecoBairro, viewModel.EnderecoComplemento, viewModel.EnderecoCidadeId, viewModel.EnderecoCEP);
            command.AttachDocumento(viewModel.DocumentoCadastroNacional, viewModel.DocumentoCadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Update(ClienteViewModel viewModel)
        {
            var command = new UpdateClienteCommand(viewModel.Id, viewModel.Nome, viewModel.Tipo, viewModel.Pontuacao, viewModel.Descricao);
            command.AttachContato(viewModel.ContatoCelular, viewModel.ContatoEmail, viewModel.ContatoTelefoneComercial, viewModel.ContatoTelefoneResidencial, viewModel.ContatoObservacao);
            command.AttachEndereco(viewModel.EnderecoNumero, viewModel.EnderecoRua, viewModel.EnderecoBairro, viewModel.EnderecoComplemento, viewModel.EnderecoCidadeId, viewModel.EnderecoCEP);
            command.AttachDocumento(viewModel.DocumentoCadastroNacional, viewModel.DocumentoCadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Remove(ClienteViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveClienteCommand(viewModel.Id));
        }
    }
}
