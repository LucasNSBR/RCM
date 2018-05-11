using MediatR;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ClienteEvents;
using RCM.Domain.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ClienteCommandHandlers
{
    public class ClienteCommandHandler : CommandHandler<Cliente>,
                                         IRequestHandler<AddClienteCommand, CommandResult>,
                                         IRequestHandler<UpdateClienteCommand, CommandResult>,
                                         IRequestHandler<RemoveClienteCommand, CommandResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IMediatorHandler mediator, IClienteRepository clienteRepository, IUnitOfWork unitOfWork) : 
                                                                                                        base(mediator, unitOfWork)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<CommandResult> Handle(AddClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoNumero, command.EnderecoRua, command.EnderecoBairro, command.EnderecoComplemento, command.EnderecoCEP);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);

            Cliente cliente = new Cliente(command.Nome, command.Tipo, command.Pontuacao, documento, contato, endereco, command.Descricao);

            _clienteRepository.Add(cliente);

            if (Commit())
                _mediator.Publish(new AddedClienteEvent());
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoNumero, command.EnderecoRua, command.EnderecoBairro, command.EnderecoComplemento, command.EnderecoCEP);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Cliente cliente = new Cliente(command.Id, command.Nome, command.Tipo, command.Pontuacao, documento, contato, endereco, command.Descricao);
            _clienteRepository.Update(cliente);

            if (Commit())
                _mediator.Publish(new UpdatedClienteEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.Id);
            _clienteRepository.Remove(cliente);

            if (Commit())
                _mediator.Publish(new RemovedClienteEvent());

            return Response();
        }
    }
}
