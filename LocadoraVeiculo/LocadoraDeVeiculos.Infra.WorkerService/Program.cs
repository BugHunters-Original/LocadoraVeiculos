using Autofac;
using Autofac.Extensions.DependencyInjection;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.ORM.ReciboModule;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using LocadoraDeVeiculos.Infra.Logger;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
                    configure.
                        AddFilter((category, logLevel) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && logLevel == LogLevel.Debug).
                        AddDebug().
                        AddSerilog(Serilogger.Logger, dispose: true);
                })
                .ConfigureServices((hostContext, builder) =>
                {
                    builder.AddHostedService<EmailWorker>();
                })
                .UseWindowsService();
    }
}
