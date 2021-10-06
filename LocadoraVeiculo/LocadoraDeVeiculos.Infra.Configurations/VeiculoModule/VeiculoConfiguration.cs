using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.VeiculoModule
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {

            builder.ToTable("TBVeiculos");

            builder.Property(veiculo => veiculo.CapacidadePessoas).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.CapacidadeTanque).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.Cor).HasColumnType("VARCHAR(64)").IsRequired();

            builder.Property(veiculo => veiculo.DisponibilidadeVeiculo).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.Foto).HasColumnType("image").IsRequired();

            builder.Property(veiculo => veiculo.IdGrupoVeiculo).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.KmInicial).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.Marca).HasColumnType("VARCHAR(64)").IsRequired();

            builder.Property(veiculo => veiculo.Nome).HasColumnType("VARCHAR(64)").IsRequired();

            builder.Property(veiculo => veiculo.NumeroChassi).HasColumnType("VARCHAR(64").IsRequired();

            builder.Property(veiculo => veiculo.NumeroPlaca).HasColumnType("VARCHAR(64)").IsRequired();
                    
            builder.Property(veiculo => veiculo.NumeroPortas).HasColumnType("INT").IsRequired();

            builder.Property(veiculo => veiculo.TamanhoPortaMalas).HasColumnType("CHAR").IsRequired();
                    
            builder.Property(veiculo => veiculo.TipoCombustivel).HasColumnType("VARCHAR(64)").IsRequired();

            builder.HasOne(veiculo => veiculo.GrupoVeiculo)
                   .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdGrupoVeiculo);
                   
                    
            
        }
    }
}
