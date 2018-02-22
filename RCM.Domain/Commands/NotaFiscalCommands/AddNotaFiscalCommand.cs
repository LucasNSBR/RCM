using RCM.Domain.Models;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class AddNotaFiscalCommand : NotaFiscalCommand
    {
        public AddNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }
    }
}
