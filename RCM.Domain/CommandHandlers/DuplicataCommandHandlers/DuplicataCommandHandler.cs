using MediatR;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.DuplicataEvents;
using RCM.Domain.Models;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.DuplicataCommandHandlers
{
    public class DuplicataCommandHandler : CommandHandler<Duplicata>,
                                           INotificationHandler<AddDuplicataCommand>,
                                           INotificationHandler<UpdateDuplicataCommand>,
                                           INotificationHandler<RemoveDuplicataCommand>,
                                           INotificationHandler<PagarDuplicataCommand>,
                                           INotificationHandler<EstornarDuplicataCommand>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public DuplicataCommandHandler(IFornecedorRepository fornecedorRepository, IDuplicataRepository duplicataRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                base(mediator, duplicataRepository, unitOfWork, domainNotificationHandler)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Task Handle(AddDuplicataCommand command, CancellationToken cancellationToken)
        {            
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            Duplicata duplicata = new Duplicata(command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.Observacao);
            _baseRepository.Add(duplicata);

            if (Commit())
                _mediator.Publish(new AddedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            Duplicata duplicata = new Duplicata(command.Id, command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.Observacao);
            _baseRepository.Update(duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Duplicata duplicata = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(duplicata);

            if (Commit())
                _mediator.Publish(new RemovedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(PagarDuplicataCommand command, CancellationToken cancellationToken)
        {
            Duplicata duplicata = _baseRepository.GetById(command.Id);
            Pagamento pagamento = new Pagamento(command.DataPagamento, command.ValorPago);
            
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            duplicata.Pagar(pagamento);
            _baseRepository.Update(duplicata);

            if (Commit()) 
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(EstornarDuplicataCommand command, CancellationToken cancellationToken)
        {
            Duplicata duplicata = _baseRepository.GetById(command.Id);
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            duplicata.EstornarPagamento();
            _baseRepository.Update(duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }
    }
}
