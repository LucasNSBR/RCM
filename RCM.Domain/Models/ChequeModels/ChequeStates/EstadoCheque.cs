﻿using RCM.Domain.Models.FornecedorModels;
using System;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public abstract class EstadoCheque 
    {
        public Guid ChequeId { get; private set; }
        public virtual Cheque Cheque { get; private set; }
        public DateTime DataEvento { get; private set; }

        public abstract EstadoChequeEnum Estado { get; }

        protected EstadoCheque() { }

        public EstadoCheque(DateTime dataEvento)
        {
            DataEvento = dataEvento;
        }

        public abstract void Bloquear(Cheque cheque, DateTime dataEvento);
        public abstract void Compensar(Cheque cheque, DateTime dataEvento);
        public abstract void Repassar(Cheque cheque, DateTime dataEvento, Fornecedor fornecedor);
        public abstract void Sustar(Cheque cheque, DateTime dataEvento, string motivo);
        public abstract void Devolver(Cheque cheque, DateTime dataEvento, string motivo);
    }
}