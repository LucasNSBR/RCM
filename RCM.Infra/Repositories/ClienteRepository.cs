using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
