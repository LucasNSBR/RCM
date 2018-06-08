using MediatR;
using RCM.Domain.Commands.VendaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.VendaEvents;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ServicoModels;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.VendaCommandHandlers
{
    public class VendaCommandHandler : CommandHandler<Venda>,
                                       IRequestHandler<AddVendaCommand, CommandResult>,
                                       IRequestHandler<UpdateVendaCommand, CommandResult>,
                                       IRequestHandler<RemoveVendaCommand, CommandResult>,
                                       IRequestHandler<AttachVendaProdutoCommand, CommandResult>,
                                       IRequestHandler<RemoveVendaProdutoCommand, CommandResult>,
                                       IRequestHandler<AttachVendaServicoCommand, CommandResult>,
                                       IRequestHandler<RemoveVendaServicoCommand, CommandResult>,
                                       IRequestHandler<FinalizarVendaCommand, CommandResult>,
                                       IRequestHandler<PagarParcelaVendaCommand, CommandResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;

        public VendaCommandHandler(IVendaRepository vendaRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
        }

        public Task<CommandResult> Handle(AddVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.ClienteId, loadRelatedData: false);
            Venda venda = new Venda(command.DataVenda, command.Detalhes, cliente);
            _vendaRepository.Add(venda);

            if (Commit())
                _mediator.PublishEvent(new AddedVendaEvent(venda, cliente));

            return Response();
        }

        public Task<CommandResult> Handle(UpdateVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.VendaId, loadRelatedData: false);
            Venda venda = new Venda(command.VendaId, command.DataVenda, command.Detalhes, cliente);

            Venda oldVenda = _vendaRepository.GetById(command.VendaId);
            if(oldVenda.Status == VendaStatusEnum.Fechada)
            {
                NotifyCommandError("Não é possível editar uma venda já finalizada.");
                return Response();
            }

            _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new UpdatedVendaEvent(venda, cliente));

            return Response();
        }

        public Task<CommandResult> Handle(RemoveVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId, loadRelatedData: false);
            _vendaRepository.Remove(venda);

            if (Commit())
                _mediator.PublishEvent(new RemovedVendaEvent(venda));

            return Response();
        }

        public Task<CommandResult> Handle(AttachVendaProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId);
            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            venda.AdicionarProduto(produto, command.Desconto, command.Acrescimo, command.Quantidade);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new AttachedVendaProdutoEvent(venda, produto));

            return Response();
        }

        public Task<CommandResult> Handle(RemoveVendaProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId);
            Produto produto = _produtoRepository.GetById(command.ProdutoId);
            venda.RemoverProduto(produto);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new RemovedVendaProdutoEvent(venda, produto));

            return Response();
        }

        public Task<CommandResult> Handle(AttachVendaServicoCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId);
            Servico servico = new Servico(venda, command.ServicoDetalhes, command.ServicoPreco);
            venda.AdicionarServico(servico);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new AttachedVendaServicoEvent(venda, servico));

            return Response();
        }

        public Task<CommandResult> Handle(RemoveVendaServicoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId);
            Servico servico = venda.Servicos.First(s => s.Id == command.ServicoId);
            venda.RemoverServico(servico);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new RemovedVendaServicoEvent(venda, servico));

            return Response();
        }

        public Task<CommandResult> Handle(FinalizarVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId);
            venda.Finalizar(command.TipoVenda, command.QuantidadeParcelas, command.IntervaloVencimento, command.ValorEntrada);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new CheckedOutVendaEvent(venda));

            return Response();
        }

        public Task<CommandResult> Handle(PagarParcelaVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.VendaId, loadRelatedData: false);
            Parcela parcela = venda.PagarParcela(command.ParcelaId, command.DataPagamento);

            if (NotifyModelErrors(venda.Errors))
                return Response();
            else
                _vendaRepository.Update(venda);

            if (Commit())
                _mediator.PublishEvent(new PaidInstallmentVendaEvent(venda, parcela));

            return Response();
        }
    }
}
