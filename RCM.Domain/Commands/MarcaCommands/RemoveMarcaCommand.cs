using System;

namespace RCM.Domain.Commands.MarcaCommands
{
    public class RemoveMarcaCommand : MarcaCommand
    {
        public RemoveMarcaCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
