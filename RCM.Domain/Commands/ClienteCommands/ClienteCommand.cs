using RCM.Domain.Core.Command;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.ClienteCommands
{
    public abstract class ClienteCommand : Command
    {
        public Cliente Cliente { get; private set; }

        public ClienteCommand(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
