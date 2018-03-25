using RCM.Domain.Core.Commands;
using RCM.Domain.Models.NotaFiscalModels;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public abstract class NotaFiscalCommand : Command
    {
        public NotaFiscal NotaFiscal { get; }

        public NotaFiscalCommand(NotaFiscal notaFiscal) 
        {
            NotaFiscal = notaFiscal;
        }
    }
}
