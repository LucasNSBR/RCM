﻿using RCM.Domain.Models.FornecedorModels;
using System;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeSustado : EstadoCheque
    {
        public string Motivo { get; private set; }
        public override EstadoChequeEnum Estado
        {
            get
            {
                return EstadoChequeEnum.Sustado;
            }
        }

        protected ChequeSustado() { }

        public ChequeSustado(DateTime dataEvento, string motivo) : base(dataEvento)
        {
            Motivo = motivo;
        }

        public override void Bloquear(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeBloqueado(dataEvento));
        }

        public override void Compensar(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeCompensado(dataEvento));
        }

        public override void Repassar(Cheque cheque, DateTime dataEvento, Fornecedor fornecedor)
        {
            cheque.MudarEstado(new ChequeRepassado(dataEvento, fornecedor));
        }

        public override void Sustar(Cheque cheque, DateTime dataEvento, string motivo)
        {
            cheque.MudarEstado(new ChequeSustado(dataEvento, motivo));
        }

        public override void Devolver(Cheque cheque, DateTime dataEvento, string motivo)
        {
            cheque.MudarEstado(new ChequeDevolvido(dataEvento, motivo));
        }
    }
}
