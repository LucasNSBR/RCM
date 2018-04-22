using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Constants;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ProdutoEvents;
using RCM.Domain.Models;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.ProdutoCommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler<Produto>,
                                         IRequestHandler<AddProdutoCommand, CommandResult>,
                                         IRequestHandler<UpdateProdutoCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoCommand, CommandResult>,
                                         IRequestHandler<AttachProdutoAplicacaoCommand, CommandResult>,
                                         IRequestHandler<AddProdutoAplicacaoCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoAplicacaoCommand, CommandResult>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IAplicacaoRepository _aplicacaoRepository;

        public ProdutoCommandHandler(IMediatorHandler mediator, IProdutoRepository produtoRepository, IMarcaRepository marcaRepository, IAplicacaoRepository aplicacaoRepository, IUnitOfWork unitOfWork) :
                                                                                                        base(mediator, unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _marcaRepository = marcaRepository;
            _aplicacaoRepository = aplicacaoRepository;
        }

        public Task<CommandResult> Handle(AddProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.MarcaId);
            Produto produto = new Produto(command.Nome, command.Quantidade, command.PrecoVenda, marca);
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
            Produto produto = new Produto(command.Id, command.Nome, command.Quantidade, command.PrecoVenda, marca);
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

        public Task<CommandResult> Handle(AttachProdutoAplicacaoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Aplicacao aplicacao = _aplicacaoRepository.GetById(command.AplicacaoId);
            Produto produto = _produtoRepository.GetById(command.Id);

            produto.AdicionarAplicacao(aplicacao);
            if (produto.Errors.Any())
            {
                _commandResponse.AddError(new CommandError(produto.Errors.First()));
                return Response();
            }

            _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(AddProdutoAplicacaoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Carro carro = new Carro(command.MarcaAplicacao, command.ModeloAplicacao, command.AnoAplicacao, command.MotorAplicacao, command.ObservacaoAplicacao);
            Aplicacao aplicacao = new Aplicacao(carro);
            Produto produto = _produtoRepository.GetById(command.Id);

            produto.AdicionarAplicacao(aplicacao);
            _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveProdutoAplicacaoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Aplicacao aplicacao = _aplicacaoRepository.GetById(command.AplicacaoId);
            Produto produto = _produtoRepository.GetById(command.Id);

            produto.RemoverAplicacao(aplicacao);
            _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }
    }
}
