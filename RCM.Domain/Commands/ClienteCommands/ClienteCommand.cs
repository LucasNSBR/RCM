using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
