using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Configurations.TaxaDaLocacaoModule
{
    public class TaxaConfiguration : IEntityTypeConfiguration<TaxaDaLocacao>
    {
        public void Configure(EntityTypeBuilder<TaxaDaLocacao> builder)
        {
            builder.ToTable("TBTaxasServicos");

            builder.HasKey(c => new { c.IdLocacao, c.IdTaxa});

            builder.HasOne(c => c.LocacaoEscolhida).WithMany(c => c.TaxasDaLocacao).HasForeignKey(c => c.IdLocacao).IsRequired();

            builder.HasOne(c => c.TaxaLocacao).WithMany(c => c.TaxasDaLocacao).HasForeignKey(c => c.IdTaxa).IsRequired();
        }
    }
}
