using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class UserClaimEntityTypeConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.ToTable("UserClaims");
        }
    }
}
