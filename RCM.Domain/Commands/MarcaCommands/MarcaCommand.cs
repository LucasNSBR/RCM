using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.MarcaCommands
{
    public abstract class MarcaCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}
