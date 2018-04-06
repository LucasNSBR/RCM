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
                                       IRequestHandler<AddBancoCommand, RequestResponse>,
                                       IRequestHandler<UpdateBancoCommand, RequestResponse>,
                                       IRequestHandler<RemoveBancoCommand, RequestResponse>
    {
        public BancoCommandHandler(IMediatorHandler mediator, IBancoRepository baseRepository, IUnitOfWork unitOfWork) : 
                                                                                                base(mediator, baseRepository, unitOfWork)
        {
        }

        public Task<RequestResponse> Handle(AddBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Banco banco = new Banco(command.Nome, command.CodigoCompensacao);
            _baseRepository.Add(banco);

            if (Commit())
                _mediator.Publish(new AddedBancoEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(UpdateBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Banco banco = new Banco(command.Id, command.Nome, command.CodigoCompensacao);
            _baseRepository.Update(banco);

            if (Commit())
                _mediator.Publish(new UpdatedBancoEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(RemoveBancoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Banco banco = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(banco);

            if (Commit())
                _mediator.Publish(new RemovedBancoEvent());

            return Response();
        }
    }
}
