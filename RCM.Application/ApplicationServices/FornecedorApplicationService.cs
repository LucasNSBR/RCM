using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class FornecedorApplicationService : BaseApplicationService<Fornecedor, FornecedorViewModel>, IFornecedorApplicationService
    {
        public FornecedorApplicationService(IFornecedorRepository fornecedorRepository, IMapper mapper, IMediatorHandler mediator) : base(fornecedorRepository, mapper, mediator)
        {
        }

        public override void Add(FornecedorViewModel viewModel)
        {
            base.Add(viewModel);
        }

        public override void Update(FornecedorViewModel viewModel)
        {
            base.Update(viewModel);
        }

        public override void Remove(FornecedorViewModel viewModel)
        {
            base.Remove(viewModel);
        }
    }
}
