using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.CidadeCommands
{
    public abstract class CidadeCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid EstadoId { get; set; }
    }
}
