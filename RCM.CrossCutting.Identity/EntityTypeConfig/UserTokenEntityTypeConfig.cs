using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class UserTokenEntityTypeConfig : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            builder.ToTable("UserTokens");
        }
    }
}
