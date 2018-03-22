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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new RoleClaimEntityTypeConfig());
            //builder.ApplyConfiguration(new RoleEntityTypeConfig());
            //builder.ApplyConfiguration(new UserClaimEntityTypeConfig());
            //builder.ApplyConfiguration(new UserLoginEntityConfig());
            //builder.ApplyConfiguration(new UserRoleEntityTypeConfig());
            //builder.ApplyConfiguration(new UserEntityTypeConfig());
            //builder.ApplyConfiguration(new UserTokenEntityTypeConfig());

            base.OnModelCreating(builder);
        }
    }
}
