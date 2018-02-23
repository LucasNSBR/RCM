using RCM.Domain.Core.Commands;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public abstract class NotaFiscalCommand : Command
    {
        public NotaFiscal NotaFiscal { get; private set; }

        public NotaFiscalCommand(NotaFiscal notaFiscal) 
        {
            NotaFiscal = notaFiscal;
        }
    }
}
