using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.MarcaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

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
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = new Marca(command.Nome, command.Observacao);
            _marcaRepository.Add(marca);

            Commit();
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateMarcaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = new Marca(command.Id, command.Nome, command.Observacao);
            _marcaRepository.Update(marca);

            Commit();

            return Response();
        }

        public Task<CommandResult> Handle(RemoveMarcaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = new Marca(command.Nome, command.Observacao);
            _marcaRepository.Remove(marca);

            Commit();

            return Response();
        }
    }
}
