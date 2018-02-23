using RCM.Domain.Models;

namespace RCM.Domain.Commands.BancoCommands
{
    public class AddBancoCommand : BancoCommand
    {
        public AddBancoCommand(Banco banco) : base(banco)
        {
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
