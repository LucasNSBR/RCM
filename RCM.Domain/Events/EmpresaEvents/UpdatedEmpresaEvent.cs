using RCM.Domain.Models.EmpresaModels;

namespace RCM.Domain.Events.EmpresaEvents
{
    public class UpdatedEmpresaEvent : EmpresaEvent
    {
        public UpdatedEmpresaEvent(Empresa empresa) : base(empresa)
        {
        }
    }
}
