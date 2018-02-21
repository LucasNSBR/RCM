using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class ChequeRepository : BaseRepository<Cheque>, IChequeRepository
    {
        public ChequeRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
