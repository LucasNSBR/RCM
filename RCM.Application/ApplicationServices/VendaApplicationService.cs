using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels.VendaViewModels;
using RCM.Domain.Commands.VendaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class VendaApplicationService : BaseApplicationService<Venda, VendaViewModel>, IVendaApplicationService
    {
        public VendaApplicationService(IVendaRepository vendaRepository, IMapper mapper, IMediatorHandler mediator) : base(vendaRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new AddVendaCommand(viewModel.DataVenda, viewModel.Detalhes, viewModel.ClienteId));
        }

        public override Task<CommandResult> Update(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateVendaCommand(viewModel.Id, viewModel.DataVenda, viewModel.Detalhes, viewModel.ClienteId));
        }

        public override Task<CommandResult> Remove(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveVendaCommand(viewModel.Id));
        }

        public Task<CommandResult> AttachProduto(VendaProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new AttachVendaProdutoCommand(viewModel.VendaId, viewModel.ProdutoId, viewModel.PrecoVenda, viewModel.Desconto, viewModel.Acrescimo, viewModel.Quantidade));
        }

        public Task<CommandResult> RemoveProduto(Guid vendaId, Guid produtoId)
        {
            return _mediator.SendCommand(new RemoveVendaProdutoCommand(vendaId, produtoId));
        }

        public Task<CommandResult> FinalizarVenda(Guid vendaId, CondicaoPagamentoViewModel viewModel)
        {
            return _mediator.SendCommand(new FinalizarVendaCommand(vendaId, viewModel.TipoVenda, viewModel.QuantidadeParcelas, viewModel.IntervaloVencimento, viewModel.ValorEntrada));
        }

        public Task<CommandResult> PagarParcela(Guid vendaId, ParcelaViewModel viewModel)
        {
            return _mediator.SendCommand(new PagarParcelaVendaCommand(vendaId, viewModel.Numero, viewModel.DataPagamento.Value));
        }
    }
}
