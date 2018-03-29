using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
