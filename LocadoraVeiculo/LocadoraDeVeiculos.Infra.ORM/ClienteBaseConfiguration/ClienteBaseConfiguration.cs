using LocadoraDeVeiculos.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ClienteBaseConfiguration
{
    public class ClienteBaseConfiguration : IEntityTypeConfiguration<ClienteBase>
    {
        public void Configure(EntityTypeBuilder<ClienteBase> builder)
        {
            builder.ToTable("TBClienteBase");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Email).HasColumnType("VARCHAR(250)").IsRequired();

            builder.Property(e => e.Endereco).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(e => e.Telefone).HasColumnType("VARCHAR(15)").IsRequired();
        }
    }
}
