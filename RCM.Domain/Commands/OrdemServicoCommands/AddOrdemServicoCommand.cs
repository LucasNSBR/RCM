using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.OrdemServicoCommandValidators;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Commands.OrdemServicoCommands
{
    public class AddOrdemServicoCommand : OrdemServicoCommand
    {
        public AddOrdemServicoCommand(Guid clienteId, List<Produto> produtos)
        {
            ClienteId = clienteId;
            Produtos = produtos;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddOrdemServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
