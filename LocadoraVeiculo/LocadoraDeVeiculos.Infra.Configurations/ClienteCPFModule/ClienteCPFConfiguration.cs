using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.ClienteCPFModule
{
    class ClienteCPFConfiguration : IEntityTypeConfiguration<ClienteCPF>
    {
        public void Configure(EntityTypeBuilder<ClienteCPF> builder)
        {
            builder.ToTable("TBClienteCPF");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Cpf).HasColumnType("VARCHAR(14)").IsRequired();

            builder.Property(e => e.Email).HasColumnType("VARCHAR(250)").IsRequired();

            builder.Property(e => e.Endereco).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(e => e.Telefone).HasColumnType("VARCHAR(15)").IsRequired();

            builder.Property(e => e.Cnh).HasColumnType("VARCHAR(12)").IsRequired();

            builder.Property(e => e.Rg).HasColumnType("VARCHAR(10)").IsRequired();

            builder.HasOne(e => e.Cliente)
                   .WithMany(e => e.Condutores)
                   .HasForeignKey(e => e.IdCliente);
        }

    }
}
