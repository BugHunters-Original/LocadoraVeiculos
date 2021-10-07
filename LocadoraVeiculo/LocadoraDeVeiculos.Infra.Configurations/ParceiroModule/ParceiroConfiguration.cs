using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.ParceiroModule
{
    public class ParceiroConfiguration : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("TBParceiros");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Nome).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
