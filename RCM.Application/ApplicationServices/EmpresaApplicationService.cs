using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.EmpresaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public EmpresaApplicationService(IEmpresaRepository empresaRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public EmpresaViewModel Get()
        {
            var model = _empresaRepository.Get();
            return _mapper.Map<EmpresaViewModel>(model);
        }

        public Task<CommandResult> AddOrUpdate(EmpresaViewModel viewModel)
        {
            var command = new AddOrUpdateEmpresaCommand(viewModel.Id, viewModel.RazaoSocial, viewModel.NomeFantasia, viewModel.Descricao);
            command.AttachContato(viewModel.ContatoCelular, viewModel.ContatoEmail, viewModel.ContatoTelefoneComercial, viewModel.ContatoTelefoneResidencial, viewModel.ContatoObservacao);
            command.AttachEndereco(viewModel.EnderecoNumero, viewModel.EnderecoRua, viewModel.EnderecoBairro, viewModel.EnderecoComplemento, viewModel.EnderecoCidadeId, viewModel.EnderecoCEP);
            command.AttachDocumento(viewModel.DocumentoCadastroNacional, viewModel.DocumentoCadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public Task<CommandResult> AttachLogo(byte[] logo)
        {
            return _mediator.SendCommand(new AttachEmpresaLogoCommand(logo));
        }
    }
}
