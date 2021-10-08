using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.GrupoVeiculoModule
{
    public class GrupoVeiculoConfigurations : IEntityTypeConfiguration<GrupoVeiculo>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculo> builder)
        {
           
            builder.ToTable("TBTiposVeiculo");

            builder.HasKey(grupoveiculo => grupoveiculo.Id);
            

            builder.Property(grupoveiculo => grupoveiculo.NomeTipo).HasColumnType("VARCHAR(64)").IsRequired();

            builder.Property(grupoveiculo => grupoveiculo.ValorDiarioPControlado).HasColumnType("DECIMAL").IsRequired();

            builder.Property(grupoveiculo => grupoveiculo.ValorDiarioPDiario).HasColumnType("DECIMAL").IsRequired();

            builder.Property(grupoveiculo => grupoveiculo.ValorDiarioPLivre).HasColumnType("DECIMAL").IsRequired();

            builder.Property(grupoveiculo => grupoveiculo.ValorKmRodadoPControlado).HasColumnType("DECIMAL").IsRequired();

            builder.Property(grupoveiculo => grupoveiculo.ValorKmRodadoPDiario).HasColumnType("DECIMAL").IsRequired();




        }
    }
}
