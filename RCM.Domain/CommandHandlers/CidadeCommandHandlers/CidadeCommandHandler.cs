using MediatR;
using RCM.Domain.Commands.CidadeCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.CidadeCommandHandlers
{
    public class CidadeCommandHandler : CommandHandler<Cidade>,
                                        IRequestHandler<AddCidadeCommand, CommandResult>,
                                        IRequestHandler<RemoveCidadeCommand, CommandResult>

    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IEstadoRepository _estadoRepository;

        public CidadeCommandHandler(ICidadeRepository cidadeRepository, IEstadoRepository estadoRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                                                        base(mediator, unitOfWork)
        {
            _cidadeRepository = cidadeRepository;
            _estadoRepository = estadoRepository;
        }

        public Task<CommandResult> Handle(AddCidadeCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Estado estado = _estadoRepository.GetById(command.EstadoId);
            Cidade cidade = new Cidade(command.Nome, estado);
            _cidadeRepository.Add(cidade);

            Commit();

            return Response();
        }

        public Task<CommandResult> Handle(RemoveCidadeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.Id);
            _cidadeRepository.Remove(cidade);

            Commit();

            return Response();
        }
    }
}
