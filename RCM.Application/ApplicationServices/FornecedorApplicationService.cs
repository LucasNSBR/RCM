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
            var command = new AddFornecedorCommand(viewModel.Nome, viewModel.Tipo, viewModel.Observacao);
            command.AttachContato(viewModel.Contato.Celular, viewModel.Contato.Email, viewModel.Contato.TelefoneComercial, viewModel.Contato.TelefoneResidencial, viewModel.Contato.Observacao);
            command.AttachEndereco(viewModel.Endereco.Numero, viewModel.Endereco.Rua, viewModel.Endereco.Bairro, viewModel.Endereco.Complemento, viewModel.Endereco.CEP);
            command.AttachDocumento(viewModel.Documento.CadastroNacional, viewModel.Documento.CadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Update(FornecedorViewModel viewModel)
        {
            var command = new UpdateFornecedorCommand(viewModel.Id, viewModel.Nome, viewModel.Tipo, viewModel.Observacao);
            command.AttachContato(viewModel.Contato.Celular, viewModel.Contato.Email, viewModel.Contato.TelefoneComercial, viewModel.Contato.TelefoneResidencial, viewModel.Contato.Observacao);
            command.AttachEndereco(viewModel.Endereco.Numero, viewModel.Endereco.Rua, viewModel.Endereco.Bairro, viewModel.Endereco.Complemento, viewModel.Endereco.CEP);
            command.AttachDocumento(viewModel.Documento.CadastroNacional, viewModel.Documento.CadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public override Task<CommandResult> Remove(FornecedorViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveFornecedorCommand(viewModel.Id));
        }
    }
}
