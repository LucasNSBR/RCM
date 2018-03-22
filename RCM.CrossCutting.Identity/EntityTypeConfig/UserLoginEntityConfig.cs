using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class UserLoginEntityConfig : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            builder.ToTable("UserLogins");
        }
    }
}
