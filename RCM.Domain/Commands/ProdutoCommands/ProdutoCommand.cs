﻿using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ProdutoModels;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Command
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public ProdutoUnidadeEnum Unidade { get; set; }
        public string ReferenciaFabricante { get; set; }
        public string ReferenciaOriginal { get; set; }
        public string ReferenciaAuxiliar { get; set; }
        public string ReferenciaUrl { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueIdeal { get; set; }
        public decimal PrecoVenda { get; set; }
        public Guid MarcaId { get; set; }
    }
}
