using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.ProdutoEvents;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.ProdutoCommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler<Produto>,
                                         INotificationHandler<AddProdutoCommand>,
                                         INotificationHandler<UpdateProdutoCommand>,
                                         INotificationHandler<RemoveProdutoCommand>
    {
        public ProdutoCommandHandler(IMediatorHandler mediator, IProdutoRepository produtoRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : base(mediator, produtoRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddProdutoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Produto produto = new Produto(command.Nome, command.Aplicacao, command.Quantidade, command.PrecoVenda);
            _baseRepository.Add(produto);

            if (Commit())
                _mediator.Publish(new AddedProdutoEvent());
            
            return Task.CompletedTask;
        }

        public Task Handle(UpdateProdutoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Produto produto = new Produto(command.Id, command.Nome, command.Aplicacao, command.Quantidade, command.PrecoVenda);
            _baseRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveProdutoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Produto produto = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(produto);

            if (Commit())
                _mediator.Publish(new RemovedProdutoEvent());

            return Task.CompletedTask;
        }
    }
}
