using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.VendaModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class VendaEntityTypeConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder
                .HasKey(v => v.Id);
        }
    }
}
