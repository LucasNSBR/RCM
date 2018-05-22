using MediatR;
using RCM.Domain.Commands.EmpresaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.EmpresaModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.EmpresaCommandHandlers
{
    public class EmpresaCommandHandler : CommandHandler<Empresa>,
                                         IRequestHandler<AddOrUpdateEmpresaCommand, CommandResult>,
                                         IRequestHandler<AttachEmpresaLogoCommand, CommandResult>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public EmpresaCommandHandler(IEmpresaRepository empresaRepository, ICidadeRepository cidadeRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _cidadeRepository = cidadeRepository;
        }

        public Task<CommandResult> Handle(AddOrUpdateEmpresaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cidade cidade = _cidadeRepository.GetById(command.EnderecoCidadeId);
            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoRua, command.EnderecoNumero, command.EnderecoBairro, command.EnderecoComplemento, cidade, command.EnderecoCEP);
            Empresa empresa = new Empresa(command.Id, command.NomeFantasia, command.RazaoSocial, command.Descricao, documento, contato, endereco);

            _empresaRepository.AddOrUpdate(empresa);

            if (Commit())
                RaiseEvents(empresa.Events);

            return Response();
        }

        public Task<CommandResult> Handle(AttachEmpresaLogoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Empresa empresa = _empresaRepository.Get();
            if(empresa == null)
            {
                NotifyCommandError("A empresa não foi encontrada.");
                return Response();
            }

            empresa.AdicionarLogo(command.Logo);
            _empresaRepository.AddOrUpdate(empresa);

            if (Commit())
                RaiseEvents(empresa.Events);

            return Response();
        }
    }
}
