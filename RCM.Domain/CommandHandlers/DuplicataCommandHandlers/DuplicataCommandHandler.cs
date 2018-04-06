using MediatR;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
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
                                           IRequestHandler<AddDuplicataCommand, RequestResponse>,
                                           IRequestHandler<UpdateDuplicataCommand, RequestResponse>,
                                           IRequestHandler<RemoveDuplicataCommand, RequestResponse>,
                                           IRequestHandler<PagarDuplicataCommand, RequestResponse>,
                                           IRequestHandler<EstornarDuplicataCommand, RequestResponse>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public DuplicataCommandHandler(IFornecedorRepository fornecedorRepository, IDuplicataRepository duplicataRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                                base(mediator, duplicataRepository, unitOfWork)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<RequestResponse> Handle(AddDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            Duplicata duplicata = new Duplicata(command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.Observacao);
            _baseRepository.Add(duplicata);

            if (Commit())
                _mediator.Publish(new AddedDuplicataEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(UpdateDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            Duplicata duplicata = new Duplicata(command.Id, command.NumeroDocumento, command.DataEmissao, command.DataVencimento, fornecedor, command.Valor, command.Observacao);
            _baseRepository.Update(duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(RemoveDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Duplicata duplicata = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(duplicata);

            if (Commit())
                _mediator.Publish(new RemovedDuplicataEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(PagarDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Duplicata duplicata = _baseRepository.GetById(command.Id);
            Pagamento pagamento = new Pagamento(command.DataPagamento, command.ValorPago);
            duplicata.Pagar(pagamento);
            _baseRepository.Update(duplicata);

            if (Commit()) 
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(EstornarDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Duplicata duplicata = _baseRepository.GetById(command.Id);
            duplicata.EstornarPagamento();
            _baseRepository.Update(duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Response();
        }
    }
}
