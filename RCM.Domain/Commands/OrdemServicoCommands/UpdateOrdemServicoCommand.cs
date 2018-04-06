using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.OrdemServicoCommandValidators;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Commands.OrdemServicoCommands
{
    public class UpdateOrdemServicoCommand : OrdemServicoCommand
    {
        public UpdateOrdemServicoCommand(Guid id, Guid clienteId, List<Produto> produtos)
        {
            Id = id;
            clienteId = ClienteId;
            Produtos = Produtos;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrdemServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
