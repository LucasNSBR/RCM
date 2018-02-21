using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
