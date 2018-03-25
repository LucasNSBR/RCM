using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
