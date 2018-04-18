using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class AplicacaoRepository : BaseRepository<Aplicacao>, IAplicacaoRepository
    {
        public AplicacaoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
