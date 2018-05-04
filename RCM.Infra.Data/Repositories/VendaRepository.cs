using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
