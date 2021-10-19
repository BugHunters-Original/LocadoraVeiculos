using Autofac;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using System;

namespace LocadoraDeVeiculos.Infra.Autofac
{
    public class DependencyInjection
    {
        static readonly IContainer container;
        static readonly ContainerBuilder builder = new();
        static DependencyInjection()
        {
            builder.RegisterType<LocacaoContext>().InstancePerLifetimeScope();

            builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().SingleInstance();

            container = builder.Build();
        }        
    }
}
