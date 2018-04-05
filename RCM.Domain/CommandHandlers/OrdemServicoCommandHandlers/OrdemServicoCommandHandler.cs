using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.OrdemServicoCommandHandlers
{
    public class OrdemServicoCommandHandler : CommandHandler<OrdemServico>,
                                              IRequestHandler<AddOrdemServicoCommand, string>,
                                              IRequestHandler<UpdateOrdemServicoCommand, string>
    {
        private readonly IClienteRepository _clienteRepository;

        public OrdemServicoCommandHandler(IOrdemServicoRepository baseRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : base(mediator, baseRepository, unitOfWork, domainNotificationHandler)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<string> Handle(AddOrdemServicoCommand message, CancellationToken cancellationToken)
        {
            var cliente = _clienteRepository.GetById(message.ClienteId);
            if (cliente == null)
                return Task.FromResult("Erradissímo");

            var ordemServico = new OrdemServico(cliente, message.Produtos);
            _baseRepository.Add(ordemServico);

            if (Commit())
                return Task.FromResult("Deu certo");

            return Task.FromResult("Deu merda");
        }

        public Task<string> Handle(UpdateOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
