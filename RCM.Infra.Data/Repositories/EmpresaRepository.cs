using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.EmpresaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository, IDisposable
    {
        private readonly RCMDbContext _dbContext;

        public EmpresaRepository(RCMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Empresa Get()
        {
            return _dbContext.Empresa.AsNoTracking().FirstOrDefault();
        }

        public void AddOrUpdate(Empresa empresa)
        {
            var model = Get();

            if (Get() != null)
            {
                model = empresa;
                _dbContext.Update(model);
            }
            else
                _dbContext.Add(empresa);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(_dbContext);
        }
    }
}
