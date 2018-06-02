using MediatR;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ClienteEvents;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ValueObjects;
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
        private readonly ICidadeRepository _cidadeRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository, ICidadeRepository cidadeRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                        base(mediator, unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _cidadeRepository = cidadeRepository;
        }

        public Task<CommandResult> Handle(AddClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.EnderecoCidadeId);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoRua, command.EnderecoNumero, command.EnderecoBairro, command.EnderecoComplemento, cidade, command.EnderecoCEP);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Cliente cliente = new Cliente(command.Nome, command.Tipo, command.Pontuacao, documento, contato, endereco, command.Descricao);

            _clienteRepository.Add(cliente);

            if (Commit())
                _mediator.PublishEvent(new AddedClienteEvent(cliente));
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.EnderecoCidadeId);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoRua, command.EnderecoNumero, command.EnderecoBairro, command.EnderecoComplemento, cidade, command.EnderecoCEP);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Cliente cliente = new Cliente(command.Id, command.Nome, command.Tipo, command.Pontuacao, documento, contato, endereco, command.Descricao);

            _clienteRepository.Update(cliente);

            if (Commit())
                _mediator.PublishEvent(new UpdatedClienteEvent(cliente));

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
                _mediator.PublishEvent(new RemovedClienteEvent(cliente));

            return Response();
        }
    }
}
