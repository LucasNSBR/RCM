using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string ReferenciaFabricante { get; set; }
        public string ReferenciaOriginal { get; set; }
        public string ReferenciaAuxiliar { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueIdeal { get; set; }
        public decimal PrecoVenda { get; set; }
        public Guid MarcaId { get; set; }
    }
}
