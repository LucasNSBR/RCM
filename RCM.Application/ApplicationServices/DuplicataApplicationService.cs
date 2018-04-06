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

        public override Task<RequestResponse> Add(DuplicataViewModel viewModel)
        {
            return _mediator.SendRequest(new AddDuplicataCommand(viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override Task<RequestResponse> Update(DuplicataViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateDuplicataCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override Task<RequestResponse> Remove(DuplicataViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveDuplicataCommand(viewModel.Id));
        }

        public Task<RequestResponse> Pagar(DuplicataViewModel viewModel, PagamentoViewModel pagamentoViewModel)
        {
            return _mediator.SendRequest(new PagarDuplicataCommand(viewModel.Id, pagamentoViewModel.DataPagamento, pagamentoViewModel.ValorPago));
        }

        public Task<RequestResponse> Estornar(DuplicataViewModel viewModel)
        {
            return _mediator.SendRequest(new EstornarDuplicataCommand(viewModel.Id));
        }
    }
}
