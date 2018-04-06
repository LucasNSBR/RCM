using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public abstract class FornecedorCommand : Request
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}
