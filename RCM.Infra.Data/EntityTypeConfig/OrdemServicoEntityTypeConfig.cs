using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.OrdemServicoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class OrdemServicoEntityTypeConfig : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder
                .HasKey(os => os.Id);
        }
    }
}
