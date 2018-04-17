using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
