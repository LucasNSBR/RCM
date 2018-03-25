using RCM.Domain.Core.Commands;
using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Commands.BancoCommands
{
    public abstract class BancoCommand : Command
    {
        public Banco Banco { get; }

        public BancoCommand(Banco banco) 
        {
            Banco = banco;
        }
    }
}
