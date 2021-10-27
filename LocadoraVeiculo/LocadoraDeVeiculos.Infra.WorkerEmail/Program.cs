using Autofac;
using Autofac.Extensions.DependencyInjection;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Serilog;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.InternetServices;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;

namespace LocadoraDeVeiculos.Infra.WorkerEmail
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

                    builder.RegisterType<LocacaoDAO>().As<ILocacaoRepository>().InstancePerDependency();

                    builder.RegisterType<EnviaEmail>().As<IEmail>().InstancePerDependency();
                })
                .ConfigureLogging(configure =>
                {
                    configure.AddSerilog();
                })
                .ConfigureServices((hostContext, builder) =>
                {
                    builder.AddHostedService<Worker>();
                })
                .UseWindowsService();
    }
}
