using MediatR;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.OrdemServico;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.OrdemServicoCommandHandlers
{
    public class OrdemServicoCommandHandler : CommandHandler<OrdemServico>,
                                              IRequestHandler<AddOrdemServicoCommand, RequestResponse>,
                                              IRequestHandler<UpdateOrdemServicoCommand, RequestResponse>,
                                              IRequestHandler<RemoveOrdemServicoCommand, RequestResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public OrdemServicoCommandHandler(IOrdemServicoRepository baseRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) :
                                                                                                                                                    base(mediator, baseRepository, unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _commandResponse = new RequestResponse();
        }

        public Task<RequestResponse> Handle(AddOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyRequestErrors(request);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(request.ClienteId);
            if (cliente == null)
            {
                _commandResponse.AddError(new RequestError("Erro de repositório", "Cliente não encontrado"));
                return Response();
            }

            OrdemServico ordemServico = new OrdemServico(cliente, request.Produtos);
            _baseRepository.Add(ordemServico);

            if (Commit())
                _mediator.Publish(new AddedOrdemServicoEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(UpdateOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            var cliente = _clienteRepository.GetById(request.ClienteId);

            if (cliente == null)
            {
                _commandResponse.AddError(new RequestError("Erro de repositório", "Cliente não encontrado"));
                return Task.FromResult(_commandResponse);
            }

            var ordemServico = new OrdemServico(cliente, request.Produtos);
            _baseRepository.Update(ordemServico);

            if (Commit())
                _mediator.Publish(new UpdatedOrdemServicoEvent());

            return Response();
        }

        public Task<RequestResponse> Handle(RemoveOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyRequestErrors(request);
                return Response();
            }

            OrdemServico ordemServico = _baseRepository.GetById(request.Id);

            _baseRepository.Remove(ordemServico);

            if (Commit())
                _mediator.Publish(new RemovedOrdemServicoEvent());

            return Response();
        }
    }
}
