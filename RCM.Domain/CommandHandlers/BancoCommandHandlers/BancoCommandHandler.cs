using MediatR;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.BancoEvents;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.BancoCommandHandlers
{
    public class BancoCommandHandler : CommandHandler<Banco>,
                                       IRequestHandler<AddBancoCommand, CommandResult>,
                                       IRequestHandler<UpdateBancoCommand, CommandResult>,
                                       IRequestHandler<RemoveBancoCommand, CommandResult>
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoCommandHandler(IMediatorHandler mediator, IBancoRepository bancoRepository, IUnitOfWork unitOfWork) : 
                                                                                                base(mediator, unitOfWork)
        {
            _bancoRepository = bancoRepository;
        }

        public Task<CommandResult> Handle(AddBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Banco banco = new Banco(command.Nome, command.CodigoCompensacao);
            _bancoRepository.Add(banco);

            if (Commit())
                _mediator.Publish(new AddedBancoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Banco banco = new Banco(command.Id, command.Nome, command.CodigoCompensacao);
            _bancoRepository.Update(banco);

            if (Commit())
                _mediator.Publish(new UpdatedBancoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.Id);
            _bancoRepository.Remove(banco);

            if (Commit())
                _mediator.Publish(new RemovedBancoEvent());

            return Response();
        }
    }
}
