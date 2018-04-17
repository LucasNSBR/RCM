using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ProdutoEvents;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.ProdutoCommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler<Produto>,
                                         IRequestHandler<AddProdutoCommand, CommandResult>,
                                         IRequestHandler<UpdateProdutoCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoCommand, CommandResult>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMarcaRepository _marcaRepository;

        public ProdutoCommandHandler(IMediatorHandler mediator, IProdutoRepository produtoRepository, IMarcaRepository marcaRepository, IUnitOfWork unitOfWork) : 
                                                                                                        base(mediator, unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _marcaRepository = marcaRepository;
        }

        public Task<CommandResult> Handle(AddProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.MarcaId);
            Produto produto = new Produto(command.Nome, command.Aplicacao, command.Quantidade, command.PrecoVenda, marca);
            _produtoRepository.Add(produto);

            if (Commit())
                _mediator.Publish(new AddedProdutoEvent());
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.MarcaId);
            Produto produto = new Produto(command.Id, command.Nome, command.Aplicacao, command.Quantidade, command.PrecoVenda, marca);
            _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Produto produto = _produtoRepository.GetById(command.Id);
            _produtoRepository.Remove(produto);

            if (Commit())
                _mediator.Publish(new RemovedProdutoEvent());

            return Response();
        }
    }
}
