using RCM.Domain.Models;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class AddClienteCommand : ClienteCommand
    {
        public AddClienteCommand(Cliente cliente) : base(cliente)
        {
        }
    }
}
