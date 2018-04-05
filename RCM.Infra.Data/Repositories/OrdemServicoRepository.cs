using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
