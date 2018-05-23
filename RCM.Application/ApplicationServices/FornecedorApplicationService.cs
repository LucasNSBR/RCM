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

        public override Task<CommandResult> Add(FornecedorViewModel viewModel)
        {
            var command = new AddFornecedorCommand(viewModel.Nome, viewModel.Tipo, viewModel.Descricao);
            command.AttachContato(viewModel.ContatoCelular, viewModel.ContatoEmail, viewModel.ContatoTelefoneComercial, viewModel.ContatoTelefoneResidencial, viewModel.ContatoObservacao);
            command.AttachEndereco(viewModel.EnderecoNumero, viewModel.EnderecoRua, viewModel.EnderecoBairro, viewModel.EnderecoComplemento, viewModel.EnderecoCidadeId, viewModel.EnderecoCEP);
            command.AttachDocumento(viewModel.DocumentoCadastroNacional, viewModel.DocumentoCadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Update(FornecedorViewModel viewModel)
        {
            var command = new UpdateFornecedorCommand(viewModel.Id, viewModel.Nome, viewModel.Tipo, viewModel.Descricao);
            command.AttachContato(viewModel.ContatoCelular, viewModel.ContatoEmail, viewModel.ContatoTelefoneComercial, viewModel.ContatoTelefoneResidencial, viewModel.ContatoObservacao);
            command.AttachEndereco(viewModel.EnderecoNumero, viewModel.EnderecoRua, viewModel.EnderecoBairro, viewModel.EnderecoComplemento, viewModel.EnderecoCidadeId, viewModel.EnderecoCEP);
            command.AttachDocumento(viewModel.DocumentoCadastroNacional, viewModel.DocumentoCadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Remove(FornecedorViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveFornecedorCommand(viewModel.Id));
        }
    }
}
