using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class FornecedorApplicationService : BaseApplicationService<Fornecedor, FornecedorViewModel>, IFornecedorApplicationService
    {
        public FornecedorApplicationService(IFornecedorRepository fornecedorRepository, IMapper mapper, IMediatorHandler mediator) : base(fornecedorRepository, mapper, mediator)
        {
        }

        public override Task<RequestResponse> Add(FornecedorViewModel viewModel)
        {
            return _mediator.SendRequest(new AddFornecedorCommand(viewModel.Nome, viewModel.Observacao));
        }

        public override Task<RequestResponse> Update(FornecedorViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateFornecedorCommand(viewModel.Id, viewModel.Nome, viewModel.Observacao));
        }

        public override Task<RequestResponse> Remove(FornecedorViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveFornecedorCommand(viewModel.Id));
        }
    }
}
