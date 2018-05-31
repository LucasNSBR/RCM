using MediatR;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ProdutoEvents;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ProdutoCommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler<Produto>,
                                         IRequestHandler<AddProdutoCommand, CommandResult>,
                                         IRequestHandler<UpdateProdutoCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoCommand, CommandResult>,
                                         IRequestHandler<AttachProdutoAplicacaoCommand, CommandResult>,
                                         IRequestHandler<AddProdutoAplicacaoCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoAplicacaoCommand, CommandResult>,
                                         IRequestHandler<AttachFornecedorCommand, CommandResult>,
                                         IRequestHandler<RemoveProdutoFornecedorCommand, CommandResult>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IAplicacaoRepository _aplicacaoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository, IMarcaRepository marcaRepository, IAplicacaoRepository aplicacaoRepository, IFornecedorRepository fornecedorRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) :
                                                                                                        base(mediator, unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _marcaRepository = marcaRepository;
            _aplicacaoRepository = aplicacaoRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<CommandResult> Handle(AddProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.MarcaId);
            Produto produto = new Produto(command.Nome, command.Unidade, command.Estoque, command.EstoqueMinimo, command.EstoqueIdeal, command.PrecoVenda, marca);
            produto.AdicionarReferencias(command.ReferenciaFabricante, command.ReferenciaOriginal, command.ReferenciaAuxiliar);

            _produtoRepository.Add(produto);

            if (Commit())
                _mediator.Publish(new AddedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Marca marca = _marcaRepository.GetById(command.MarcaId, loadRelatedData: false);
            Produto produto = new Produto(command.ProdutoId, command.Nome, command.Unidade, command.Estoque, command.EstoqueMinimo, command.EstoqueIdeal, command.PrecoVenda, marca);
            produto.AdicionarReferencias(command.ReferenciaFabricante, command.ReferenciaOriginal, command.ReferenciaAuxiliar);

            _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            _produtoRepository.Remove(produto);

            if (Commit())
                _mediator.Publish(new RemovedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(AttachProdutoAplicacaoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Aplicacao aplicacao = _aplicacaoRepository.GetById(command.AplicacaoId);
            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            produto.AdicionarAplicacao(aplicacao);

            if (NotifyModelErrors(produto.Errors))
                return Response();
            else
                _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(AddProdutoAplicacaoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Carro carro = new Carro(command.MarcaCarroAplicacao, command.ModeloCarroAplicacao, command.AnoCarroAplicacao, command.MotorCarroAplicacao, command.ObservacaoCarroAplicacao);
            Aplicacao aplicacao = new Aplicacao(carro);
            Produto produto = _produtoRepository.GetById(command.ProdutoId);
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
                NotifyCommandErrors(command);
                return Response();
            }

            Aplicacao aplicacao = _aplicacaoRepository.GetById(command.AplicacaoId);
            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            produto.RemoverAplicacao(aplicacao);

            if (NotifyModelErrors(produto.Errors))
                return Response();
            else
                _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(AttachFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            produto.AdicionarFornecedor(fornecedor, command.ReferenciaFornecedor, command.PrecoCusto, command.Disponibilidade);

            if (NotifyModelErrors(produto.Errors))
                return Response();
            else
                _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveProdutoFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorId);
            produto.RemoverFornecedor(fornecedor);

            if (NotifyModelErrors(produto.Errors))
                return Response();
            else
                _produtoRepository.Update(produto);

            if (Commit())
                _mediator.Publish(new UpdatedProdutoEvent());

            return Response();
        }
    }
}

