using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Context
{
    public class LocacaoContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<ClienteCPF> ClientesCPF { get; set; }
        public DbSet<ClienteCNPJ> ClientesCNPJ { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Desconto> Descontos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<TaxaDaLocacao> TaxasDaLocacao { get; set; }
        public DbSet<GrupoVeiculo> GruposVeiculo { get; set; }

        private static readonly ILoggerFactory SeriLog = LoggerFactory.Create(builder =>
        {
            builder.
                AddFilter((category, logLevel) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && logLevel == LogLevel.Debug).
                AddDebug().
                AddSerilog(Serilogger.Logger, dispose: true);
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(SeriLog)
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocadoraVeiculos;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocacaoContext).Assembly);

            var memoryStreamConverter = new ValueConverter<MemoryStream, byte[]>(
                        p => p.ToArray(),
                        p => p.ToMemoryStream());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(MemoryStream))
                        property.SetValueConverter(memoryStreamConverter);
                }
            }
        }

    }

}

