using Autofac;
using Autofac.Extensions.DependencyInjection;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.EmailManager;
using LocadoraDeVeiculos.Infra.ORM.ReciboModule;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LocadoraDeVeiculos.Infra.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
                {
                    builder.RegisterType<LocacaoContext>().InstancePerLifetimeScope();

                    builder.RegisterType<ReciboDAO>().As<IReciboRepository>().InstancePerDependency();
                })
                .ConfigureLogging(configure =>
                {
                    configure.AddSerilog();
                })
                .ConfigureServices((hostContext, builder) =>
                {
                    builder.AddHostedService<EmailWorker>();
                })
                .UseWindowsService();
    }
}
