using RCM.Domain.Models;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>
    {
        public NotaFiscalRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
