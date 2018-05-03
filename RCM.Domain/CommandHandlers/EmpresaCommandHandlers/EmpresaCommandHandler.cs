using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.EmpresaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models;
using RCM.Domain.Models.EmpresaModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.EmpresaCommandHandlers
{
    public class EmpresaCommandHandler : CommandHandler<Empresa>,
                                         IRequestHandler<AddOrUpdateEmpresaCommand, CommandResult>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaCommandHandler(IEmpresaRepository empresaRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _empresaRepository = empresaRepository;
        }

        public Task<CommandResult> Handle(AddOrUpdateEmpresaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Documento documento = new Documento(command.DocumentoCadastroNacional, command.DocumentoCadastroEstadual);
            Contato contato = new Contato(command.ContatoCelular, command.ContatoEmail, command.ContatoTelefoneComercial, command.ContatoTelefoneResidencial, command.ContatoObservacao);
            Endereco endereco = new Endereco(command.EnderecoNumero, command.EnderecoRua, command.EnderecoBairro, command.EnderecoComplemento, command.EnderecoCEP);
            Empresa empresa = new Empresa(command.Id, command.NomeFantasia, command.RazaoSocial, command.Descricao, documento, contato, endereco);

            _empresaRepository.AddOrUpdate(empresa);

            if (Commit())
                empresa.Events.ToList().ForEach(e => _mediator.Publish(e));

            return Response();
        }
    }
}
