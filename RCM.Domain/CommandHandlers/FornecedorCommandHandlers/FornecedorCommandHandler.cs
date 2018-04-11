using MediatR;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.FornecedorEvents;
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
        public FornecedorCommandHandler(IMediatorHandler mediator, IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork) :
                                                                                                                base(mediator, fornecedorRepository, unitOfWork)
        {
        }

        public Task<CommandResult> Handle(AddFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Fornecedor fornecedor = new Fornecedor(command.Nome, command.Observacao);
            _baseRepository.Add(fornecedor);
      
            if (Commit())
                _mediator.Publish(new AddedFornecedorEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Fornecedor fornecedor = new Fornecedor(command.Id, command.Nome, command.Observacao);
            _baseRepository.Update(fornecedor);

            if (Commit())
                _mediator.Publish(new UpdatedFornecedorEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Fornecedor fornecedor = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(fornecedor);

            if (Commit())
                _mediator.Publish(new RemovedFornecedorEvent());

            return Response();
        }
    }
}
