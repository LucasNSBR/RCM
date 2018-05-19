using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCM.CrossCutting.Identity.Models;

namespace RCM.CrossCutting.Identity.Context
{
    public class RCMIdentityDbContext : IdentityDbContext<RCMIdentityUser, RCMIdentityRole, int>
    {
        public RCMIdentityDbContext(DbContextOptions<RCMIdentityDbContext> options) : base(options)
        {
        }
    }
}
