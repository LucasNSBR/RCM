﻿using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeDevolvido : EstadoCheque
    {
        public string Motivo { get; private set; }
        public override string Estado
        {
            get
            {
                return "Devolvido";
            }
        }

        protected ChequeDevolvido() { }

        public ChequeDevolvido(DateTime dataEvento, string motivo) : base(dataEvento)
        {
            Motivo = motivo;
        }

        public override void Bloquear(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeBloqueado());
        }

        public override void Compensar(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeCompensado(dataEvento));
        }

        public override void Repassar(Cheque cheque, DateTime dataEvento, Cliente cliente)
        {
            cheque.MudarEstado(new ChequeRepassado(dataEvento, cliente));
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