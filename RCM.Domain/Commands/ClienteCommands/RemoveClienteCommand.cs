using RCM.Domain.Models;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Cliente cliente) : base(cliente)
        {
        }
    }
}
