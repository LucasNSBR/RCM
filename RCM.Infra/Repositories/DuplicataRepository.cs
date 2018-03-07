using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class DuplicataRepository : BaseRepository<Duplicata>, IDuplicataRepository
    {
        public DuplicataRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
