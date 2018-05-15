using MediatR;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.FornecedorEvents;
using RCM.Domain.Models;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.FornecedorCommandHandlers
{
    public class FornecedorCommandHandler : CommandHandler<Fornecedor>,
                                            IRequestHandler<AddFornecedorCommand, CommandResult>,
                                            IRequestHandler<UpdateFornecedorCommand, CommandResult>,
                                            IRequestHandler<RemoveFornecedorCommand, CommandResult>
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public FornecedorCommandHandler(IMediatorHandler mediator, IFornecedorRepository fornecedorRepository, ICidadeRepository cidadeRepository, IUnitOfWork unitOfWork) :
                                                                                                                base(mediator, unitOfWork)
        {
            _fornecedorRepository = fornecedorRepository;
            _cidadeRepository = cidadeRepository;
        }

        public Task<CommandResult> Handle(AddFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.EnderecoCidadeId);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoNumero, command.EnderecoRua, command.EnderecoBairro, command.EnderecoComplemento, cidade, command.EnderecoCEP);
            Fornecedor fornecedor = new Fornecedor(command.Nome, command.Tipo, documento, contato, endereco, command.Observacao);

            _fornecedorRepository.Add(fornecedor);
      
            if (Commit())
                _mediator.Publish(new AddedFornecedorEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.EnderecoCidadeId);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoNumero, command.EnderecoRua, command.EnderecoBairro, command.EnderecoComplemento, cidade, command.EnderecoCEP);
            Fornecedor fornecedor = new Fornecedor(command.Id, command.Nome, command.Tipo, documento, contato, endereco, command.Observacao);

            _fornecedorRepository.Update(fornecedor);

            if (Commit())
                _mediator.Publish(new UpdatedFornecedorEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.Id);
            _fornecedorRepository.Remove(fornecedor);

            if (Commit())
                _mediator.Publish(new RemovedFornecedorEvent());

            return Response();
        }
    }
}
