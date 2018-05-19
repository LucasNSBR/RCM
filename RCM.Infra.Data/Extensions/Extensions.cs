using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Infra.Data.EntityTypeConfig;

namespace RCM.Infra.Data.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Configure Entity and properties for EstadoCheque and derived types
        /// </summary>
        /// <param name="modelBuilder">This Model Builder object</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureChequeEstado(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoChequeEntityTypeConfig());

            modelBuilder.Entity<ChequeBloqueado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeCompensado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeRepassado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeSustado>().HasBaseType<EstadoCheque>();

            modelBuilder.Entity<ChequeSustado>().Property(m => m.Motivo).HasMaxLength(100).HasColumnName("Motivo");
            modelBuilder.Entity<ChequeDevolvido>().Property(m => m.Motivo).HasMaxLength(100).HasColumnName("Motivo");

            modelBuilder.Entity<ChequeDevolvido>().HasBaseType<EstadoCheque>();

            return modelBuilder;
        }
    }
}
