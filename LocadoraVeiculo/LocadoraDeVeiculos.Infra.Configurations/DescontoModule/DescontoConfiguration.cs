using LocadoraDeVeiculos.Dominio.DescontoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Configurations.DescontoModule
{
    public class DescontoConfiguration : IEntityTypeConfiguration<Desconto>
    {
        public void Configure(EntityTypeBuilder<Desconto> builder)
        {
            builder.ToTable("TBDescontos");

            builder.HasKey(desconto => desconto.Id);

            builder.Property(desconto => desconto.Codigo).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(desconto => desconto.Valor).HasColumnType("FLOAT").IsRequired();

            builder.Property(desconto => desconto.Tipo).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(desconto => desconto.Validade).HasColumnType("DATE").IsRequired();

            builder.Property(desconto => desconto.Meio).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(desconto => desconto.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(desconto => desconto.ValorMinimo).HasColumnType("FLOAT").IsRequired();

            builder.Property(desconto => desconto.Usos).HasColumnType("INT").IsRequired();

            builder.HasOne(desconto => desconto.Parceiro)
                .WithMany(desconto => desconto.Descontos)
                .HasForeignKey(desconto => desconto.IdParceiro);
        }
    }
}
