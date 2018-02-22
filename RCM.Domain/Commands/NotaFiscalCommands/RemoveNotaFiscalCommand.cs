using RCM.Domain.Models;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class RemoveNotaFiscalCommand : NotaFiscalCommand
    {
        public RemoveNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }
    }
}
