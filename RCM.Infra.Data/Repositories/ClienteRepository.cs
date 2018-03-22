using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
