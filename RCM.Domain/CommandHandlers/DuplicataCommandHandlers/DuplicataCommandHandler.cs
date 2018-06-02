using MediatR;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Constants;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.DuplicataEvents;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.DuplicataCommandHandlers
{
    public class DuplicataCommandHandler : CommandHandler<Duplicata>,
                                           IRequestHandler<AddDuplicataCommand, CommandResult>,
                                           IRequestHandler<UpdateDuplicataCommand, CommandResult>,
                                           IRequestHandler<RemoveDuplicataCommand, CommandResult>,
                                           IRequestHandler<PagarDuplicataCommand, CommandResult>,
                                           IRequestHandler<EstornarDuplicataCommand, CommandResult>
    {
        private readonly IDuplicataRepository _duplicataRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public DuplicataCommandHandler(IDuplicataRepository duplicataRepository, IFornecedorRepository fornecedorRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                                base(mediator, unitOfWork)
        {
            _duplicataRepository = duplicataRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<CommandResult> Handle(AddDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            if (_duplicataRepository.CheckNumeroDocumentoExists(command.NumeroDocumento, command.FornecedorId, command.Id))
            {
                NotifyCommandError(RequestErrorsMessageConstants.DuplicataAlreadyExists);
                return Response();
            }

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId, loadRelatedData: false);
            Duplicata duplicata = new Duplicata(command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.NotaFiscalId, command.Observacao);
            _duplicataRepository.Add(duplicata);

            if (Commit())
                _mediator.PublishEvent(new AddedDuplicataEvent(duplicata));

            return Response();
        }

        public Task<CommandResult> Handle(UpdateDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            if (_duplicataRepository.CheckNumeroDocumentoExists(command.NumeroDocumento, command.FornecedorId, command.Id))
            {
                NotifyCommandError(RequestErrorsMessageConstants.DuplicataAlreadyExists);
                return Response();
            }

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId, loadRelatedData: false);
            Duplicata duplicata = new Duplicata(command.Id, command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.NotaFiscalId, command.Observacao);
            _duplicataRepository.Update(duplicata);

            if (Commit())
                _mediator.PublishEvent(new UpdatedDuplicataEvent(duplicata));

            return Response();
        }

        public Task<CommandResult> Handle(RemoveDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Duplicata duplicata = _duplicataRepository.GetById(command.Id);
            _duplicataRepository.Remove(duplicata);

            if (Commit())
                _mediator.PublishEvent(new RemovedDuplicataEvent(duplicata));

            return Response();
        }

        public Task<CommandResult> Handle(PagarDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Duplicata duplicata = _duplicataRepository.GetById(command.Id);
            Pagamento pagamento = new Pagamento(command.DataPagamento, command.ValorPago);
            duplicata.Pagar(pagamento);

            _duplicataRepository.Update(duplicata);

            if (Commit()) 
                _mediator.PublishEvent(new UpdatedDuplicataEvent(duplicata));

            return Response();
        }

        public Task<CommandResult> Handle(EstornarDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Duplicata duplicata = _duplicataRepository.GetById(command.Id);
            duplicata.EstornarPagamento();
            _duplicataRepository.Update(duplicata);

            if (Commit())
                _mediator.PublishEvent(new UpdatedDuplicataEvent(duplicata));

            return Response();
        }
    }
}
