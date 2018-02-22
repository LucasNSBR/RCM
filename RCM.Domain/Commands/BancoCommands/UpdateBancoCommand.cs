using RCM.Domain.Models;

namespace RCM.Domain.Commands.BancoCommands
{
    public class UpdateBancoCommand : BancoCommand
    {
        public UpdateBancoCommand(Banco banco) : base(banco)
        {
        }
    }
}
