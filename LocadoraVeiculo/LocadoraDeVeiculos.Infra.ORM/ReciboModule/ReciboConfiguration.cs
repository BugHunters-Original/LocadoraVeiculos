using LocadoraDeVeiculos.Dominio.ReciboModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ReciboModule
{
    public class ReciboConfiguration : IEntityTypeConfiguration<Recibo>
    {
        public void Configure(EntityTypeBuilder<Recibo> builder)
        {
            builder.ToTable("TBRecibos");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Locacao);

            builder.Property(c => c.Pdf);

            builder.Property(c => c.Status);
        }
    }
}
