using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ChequeRepository : BaseRepository<Cheque>, IChequeRepository
    {
        public ChequeRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
