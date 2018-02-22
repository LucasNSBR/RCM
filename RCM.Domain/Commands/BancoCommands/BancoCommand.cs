using RCM.Domain.Core.Command;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.BancoCommands
{
    public class BancoCommand : Command
    {
        public Banco Banco { get; private set; }

        public BancoCommand(Banco banco)
        {
            Banco = banco;
        }
    }
}
