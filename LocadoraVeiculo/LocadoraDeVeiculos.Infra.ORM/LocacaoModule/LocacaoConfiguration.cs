using LocadoraDeVeiculos.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacoes");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cliente).WithMany(x => x.Locacoes).HasForeignKey(x => x.IdCliente);

            builder.HasOne(x => x.Veiculo).WithMany(x => x.Locacoes).HasForeignKey(x => x.IdVeiculo);

            builder.HasOne(x => x.Desconto).WithMany(x => x.Locacoes).HasForeignKey(x => x.IdDesconto);

            builder.HasOne(x => x.Condutor).WithOne(x => x.Locacao).HasForeignKey<Locacao>(x => x.IdCondutor);

            builder.Property(x => x.IdDesconto).HasColumnType("INT");

            builder.Property(x => x.DataRetorno).HasColumnType("DATE").IsRequired();

            builder.Property(x => x.DataSaida).HasColumnType("DATE").IsRequired();

            builder.Property(x => x.TipoLocacao).HasColumnType("VARCHAR(20)").IsRequired();

            builder.Property(x => x.StatusLocacao).HasColumnType("VARCHAR(20)");

            builder.Property(x => x.TipoCliente).HasColumnType("INT").IsRequired();

            builder.Property(x => x.Dias).HasColumnType("INT").IsRequired();

            builder.Property(x => x.PrecoServicos).HasColumnType("FLOAT");

            builder.Property(x => x.PrecoCombustivel).HasColumnType("FLOAT");

            builder.Property(x => x.PrecoPlano).HasColumnType("FLOAT").IsRequired();

            builder.Property(x => x.PrecoTotal).HasColumnType("FLOAT").IsRequired();
        }
    }
}
