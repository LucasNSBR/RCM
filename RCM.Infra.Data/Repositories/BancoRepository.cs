using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository
    {
        public BancoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
