using RCM.Domain.Models;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Cliente cliente) : base(cliente)
        {
        }
    }
}
