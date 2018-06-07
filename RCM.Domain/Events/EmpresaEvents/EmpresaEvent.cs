using RCM.Domain.Core.Events;
using RCM.Domain.Models.EmpresaModels;

namespace RCM.Domain.Events.EmpresaEvents
{
    public abstract class EmpresaEvent : DomainEvent
    {
        public Empresa Empresa { get; private set; }

        public EmpresaEvent(Empresa empresa)
        {
            Empresa = empresa;
            AggregateId = Empresa.Id;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Empresa.RazaoSocial), Empresa.RazaoSocial);
            Args.Add(nameof(Empresa.NomeFantasia), Empresa.NomeFantasia);
            Args.Add(nameof(Empresa.Descricao), Empresa.Descricao);
        }
    }
}
