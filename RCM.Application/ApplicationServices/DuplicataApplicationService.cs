using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class DuplicataApplicationService : BaseApplicationService<Duplicata, DuplicataViewModel>, IDuplicataApplicationService
    {
        public DuplicataApplicationService(IDuplicataRepository duplicataRepository, IMapper mapper, IMediatorHandler mediator) : base(duplicataRepository, mapper, mediator)
        {
        }

        public override void Add(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new AddDuplicataCommand(viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override void Update(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateDuplicataCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.Observacao, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor, viewModel.FornecedorId, viewModel.NotaFiscalId));
        }

        public override void Remove(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveDuplicataCommand(viewModel.Id));
        }

        public void Pagar(DuplicataViewModel viewModel, PagamentoViewModel pagamentoViewModel)
        {
            _mediator.SendCommand(new PagarDuplicataCommand(viewModel.Id, pagamentoViewModel.DataPagamento, pagamentoViewModel.ValorPago));
        }

        public void Estornar(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new EstornarDuplicataCommand(viewModel.Id));
        }
    }
}
