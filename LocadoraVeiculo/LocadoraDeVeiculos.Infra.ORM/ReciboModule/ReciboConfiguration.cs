using LocadoraDeVeiculos.Dominio.ReciboModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ReciboModule
{
    public class ReciboConfiguration : IEntityTypeConfiguration<Recibo>
    {
        public void Configure(EntityTypeBuilder<Recibo> builder)
        {
            builder.ToTable("TBRecibos");

            builder.HasKey(c => c.Id);

        }
    }
}
