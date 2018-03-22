using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.CrossCutting.Identity.Models;

namespace RCM.CrossCutting.Identity.EntityTypeConfig
{
    public class RoleEntityTypeConfig : IEntityTypeConfiguration<RCMIdentityRole>
    {
        public void Configure(EntityTypeBuilder<RCMIdentityRole> builder)
        {
            builder.ToTable("Roles");
        }
    }
}
