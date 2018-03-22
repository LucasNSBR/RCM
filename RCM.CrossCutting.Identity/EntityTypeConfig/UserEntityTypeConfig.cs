using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.CrossCutting.Identity.Models;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class UserEntityTypeConfig : IEntityTypeConfiguration<RCMIdentityUser>
    {
        public void Configure(EntityTypeBuilder<RCMIdentityUser> builder)
        {
            builder.ToTable("Users");
        }
    }
}
