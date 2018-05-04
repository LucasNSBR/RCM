using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public abstract class VendaCommand : Command
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public string Detalhes { get; set; }
    }
}
