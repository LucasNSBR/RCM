using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.BancoCommands
{
    public abstract class BancoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodigoCompensacao { get; set; }
    }
}
