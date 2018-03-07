using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
