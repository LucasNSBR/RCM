using RCM.Domain.Models;

namespace RCM.Domain.Commands.BancoCommands
{
    public class RemoveBancoCommand : BancoCommand
    {
        public RemoveBancoCommand(Banco banco) : base(banco)
        {
        }
    }
}
