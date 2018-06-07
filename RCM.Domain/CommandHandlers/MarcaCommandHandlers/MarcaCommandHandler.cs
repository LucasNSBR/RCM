using MediatR;
using RCM.Domain.Commands.MarcaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.MarcaEvents;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.MarcaCommandHandlers
{
    public class MarcaCommandHandler : CommandHandler<Marca>,
                                        IRequestHandler<AddMarcaCommand, CommandResult>,
                                        IRequestHandler<UpdateMarcaCommand, CommandResult>,
                                        IRequestHandler<RemoveMarcaCommand, CommandResult>
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaCommandHandler(IMarcaRepository marcaRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _marcaRepository = marcaRepository;
        }

        public Task<CommandResult> Handle(AddMarcaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Marca marca = new Marca(command.Nome, command.Observacao);
            _marcaRepository.Add(marca);

            if (Commit())
                _mediator.PublishEvent(new AddedMarcaEvent(marca));
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateMarcaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Marca marca = new Marca(command.Id, command.Nome, command.Observacao);
            _marcaRepository.Update(marca);

            if (Commit())
                _mediator.PublishEvent(new UpdatedMarcaEvent(marca));

            return Response();
        }

        public Task<CommandResult> Handle(RemoveMarcaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.Id);
            _marcaRepository.Remove(marca);

            if (Commit())
                _mediator.PublishEvent(new RemovedMarcaEvent(marca));

            return Response();
        }
    }
}
