using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class DuplicataRepository : BaseRepository<Duplicata>, IDuplicataRepository
    {
        public DuplicataRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
