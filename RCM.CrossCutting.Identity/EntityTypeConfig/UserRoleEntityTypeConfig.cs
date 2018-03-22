using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class UserRoleEntityTypeConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.ToTable("UserRoles");
        }
    }
}
