using LocadoraDeVeiculos.Dominio.ServicoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.ServicoModule
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("TBTaxasServicos");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(e => e.Preco).HasColumnType("FLOAT").IsRequired();

            builder.Property(e => e.TipoCalculo).HasColumnType("INT").IsRequired();
        }
    }
}
