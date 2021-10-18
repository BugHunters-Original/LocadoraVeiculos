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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConfigureLog())
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocadoraVeiculos;Integrated Security=True");
        }
        private static ILoggerFactory ConfigureLog()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, logLevel) => category == DbLoggerCategory.Database.Command.Name && logLevel == LogLevel.Debug);
                builder.AddSerilog();
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocacaoContext).Assembly);
        }
    }
}
