using RCM.Domain.Models.EmpresaModels;

namespace RCM.Domain.Repositories
{
    public interface IEmpresaRepository
    {
        Empresa Get();
        void AddOrUpdate(Empresa empresa);
    }
}
