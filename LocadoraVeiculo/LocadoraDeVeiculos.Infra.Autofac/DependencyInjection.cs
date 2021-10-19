using Autofac;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using System;
using System.Reflection;

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

            Container = Builder.Build();
        }
        private static void ConfigurarService()
        {
            Builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>().SingleInstance();
        }
        private static void ConfigurarORM()
        {
            Builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().SingleInstance();
        }
    }
}
