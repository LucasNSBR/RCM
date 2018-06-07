using RCM.Domain.Models.EmpresaModels;

namespace RCM.Domain.Events.EmpresaEvents
{
    public class AttachedEmpresaLogoEvent : EmpresaEvent
    {
        public AttachedEmpresaLogoEvent(Empresa empresa) : base(empresa)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Empresa.Logo), "Changed logo");
        }
    }
}
