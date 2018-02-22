using RCM.Domain.Core.Command;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class NotaFiscalCommand : Command
    {
        public NotaFiscal NotaFiscal { get; private set; }

        public NotaFiscalCommand(NotaFiscal notaFiscal)
        {
            NotaFiscal = notaFiscal;
        }
    }
}
