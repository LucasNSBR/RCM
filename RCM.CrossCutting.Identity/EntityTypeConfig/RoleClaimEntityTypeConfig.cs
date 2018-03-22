using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class RoleClaimEntityTypeConfig : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            builder.ToTable("RoleClaims");
        }
    }
}
