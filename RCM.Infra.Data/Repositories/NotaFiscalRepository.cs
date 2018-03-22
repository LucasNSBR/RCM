using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
