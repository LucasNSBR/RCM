using RCM.Domain.UnitOfWork;
using RCM.Infra.Models;

namespace RCM.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RCMDbContext _RCMDbContext;

        public UnitOfWork(RCMDbContext dbContext)
        {
            _RCMDbContext = dbContext;
        }

        public bool Commit()
        {
            if (_RCMDbContext.SaveChanges() > 0)
                return true;

            return false;
        }
    }
}
