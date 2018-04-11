using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class DuplicataApplicationService : BaseApplicationService<Duplicata, DuplicataViewModel>, IDuplicataApplicationService
    {
        public DuplicataApplicationService(IDuplicataRepository duplicataRepository, IMapper mapper, IMediatorHandler mediator) : base(duplicataRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(DuplicataViewModel viewModel)
        {
            return _mediator.SendCommand(new AddDuplicataCommand(viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override Task<CommandResult> Update(DuplicataViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateDuplicataCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override Task<CommandResult> Remove(DuplicataViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveDuplicataCommand(viewModel.Id));
        }

        public Task<CommandResult> Pagar(DuplicataViewModel viewModel, PagamentoViewModel pagamentoViewModel)
        {
            return _mediator.SendCommand(new PagarDuplicataCommand(viewModel.Id, pagamentoViewModel.DataPagamento, pagamentoViewModel.ValorPago));
        }

        public Task<CommandResult> Estornar(DuplicataViewModel viewModel)
        {
            return _mediator.SendCommand(new EstornarDuplicataCommand(viewModel.Id));
        }
    }
}
