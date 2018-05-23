using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.EmpresaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DbSet<Empresa> _dbSet;

        public EmpresaRepository(RCMDbContext dbContext)
        {
            _dbSet = dbContext.Empresa;
        }

        public Empresa Get()
        {
            return _dbSet
                .AsNoTracking()
                .Include(e => e.Endereco)
                .ThenInclude(en => en.Cidade)
                .FirstOrDefault();
        }

        public void AddOrUpdate(Empresa empresa)
        {
            var model = Get();

            if (Get() != null)
            {
                model = empresa;
                _dbSet.Update(model);
            }
            else
                _dbSet.Add(empresa);
        }
    }
}
