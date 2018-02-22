using RCM.Domain.Models;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class UpdateNotaFiscalCommand : NotaFiscalCommand
    {
        public UpdateNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }
    }
}
