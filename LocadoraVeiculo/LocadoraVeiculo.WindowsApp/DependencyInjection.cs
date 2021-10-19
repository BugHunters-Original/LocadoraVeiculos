using Autofac;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.ParceiroFeature;
using System;

namespace LocadoraDeVeiculos.Infra.DI
{
    public class DependencyInjection
    {
        private static ContainerBuilder Builder = new();
        public static IContainer Container;
        
        static DependencyInjection()
        {
            Builder.RegisterType<LocacaoContext>().InstancePerLifetimeScope();

            ConfigurarORM();

            ConfigurarService();

            ConfigurarOperacao();

            Container = Builder.Build();
        }

        private static void ConfigurarOperacao()
        {
            Builder.RegisterType<OperacoesParceiro>().InstancePerDependency();
        }

        private static void ConfigurarService()
        {
            Builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>().InstancePerDependency();
        }
        private static void ConfigurarORM()
        {
            Builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().InstancePerDependency();
        }
    }
}
