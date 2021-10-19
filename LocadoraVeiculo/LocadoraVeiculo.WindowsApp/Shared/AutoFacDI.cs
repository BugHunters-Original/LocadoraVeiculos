﻿using Autofac;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
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
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.InternetServices;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using LocadoraDeVeiculos.Infra.PDFLocacao;
using LocadoraVeiculo.WindowsApp.Features.ClienteFeature;
using LocadoraVeiculo.WindowsApp.Features.DescontoFeature;
using LocadoraVeiculo.WindowsApp.Features.FuncionarioFeature;
using LocadoraVeiculo.WindowsApp.Features.GrupoVeiculoFeature;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature;
using LocadoraVeiculo.WindowsApp.Features.ParceiroFeature;
using LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature;
using LocadoraVeiculo.WindowsApp.Features.VeiculoFeature;
using System;

namespace LocadoraDeVeiculos.WindowsApp.Shared
{
    public class AutoFacDI
    {
        private static ContainerBuilder Builder = new();
        public static IContainer Container;
        
        static AutoFacDI()
        {
            Builder.RegisterType<LocacaoContext>().InstancePerLifetimeScope();

            ConfigurarORM();

            ConfigurarService();

            ConfigurarOperacao();

            Container = Builder.Build();
        }

        private static void ConfigurarOperacao()
        {
            Builder.RegisterType<OperacoesParceiro>().SingleInstance();
            Builder.RegisterType<OperacoesDesconto>().SingleInstance();
            Builder.RegisterType<OperacoesCliente>().SingleInstance();
            Builder.RegisterType<OperacoesFuncionario>().SingleInstance();
            Builder.RegisterType<OperacoesGrupoVeiculo>().SingleInstance();
            Builder.RegisterType<OperacoesLocacao>().SingleInstance();
            Builder.RegisterType<OperacoesServico>().SingleInstance();
            Builder.RegisterType<OperacoesVeiculo>().SingleInstance();
        }

        private static void ConfigurarService()
        {
            Builder.RegisterType<ParceiroAppService>().SingleInstance();
            Builder.RegisterType<ClienteCNPJAppService>().SingleInstance();
            Builder.RegisterType<ClienteCPFAppService>().SingleInstance();
            Builder.RegisterType<DescontoAppService>().SingleInstance();
            Builder.RegisterType<FuncionarioAppService>().SingleInstance();
            Builder.RegisterType<GrupoVeiculoAppService>().SingleInstance();
            Builder.RegisterType<LocacaoAppService>().SingleInstance();
            Builder.RegisterType<ServicoAppService>().SingleInstance();
            Builder.RegisterType<VeiculoAppService>().SingleInstance();
        }
        private static void ConfigurarORM()
        {
            Builder.RegisterType<EnviaEmail>().As<IEmail>().SingleInstance();
            Builder.RegisterType<MontaPdf>().As<IPDF>().SingleInstance();
            Builder.RegisterType<FiltroCliente>().SingleInstance();

            Builder.RegisterType<ServicoDAO>().As<IServicoRepository>().SingleInstance();
            Builder.RegisterType<VeiculoDAO>().As<IVeiculoRepository>().SingleInstance();
            Builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().SingleInstance();
            Builder.RegisterType<ClienteCNPJDAO>().As<IClienteCNPJRepository>().SingleInstance();
            Builder.RegisterType<ClienteCPFDAO>().As<IClienteCPFRepository>().SingleInstance();
            Builder.RegisterType<DescontoDAO>().As<IDescontoRepository>().SingleInstance();
            Builder.RegisterType<FuncionarioDAO>().As<IFuncionarioRepository>().SingleInstance();
            Builder.RegisterType<GrupoVeiculoDAO>().As<IGrupoVeiculoRepository>().SingleInstance();
            Builder.RegisterType<LocacaoDAO>().As<ILocacaoRepository>().SingleInstance();
            Builder.RegisterType<TaxaDaLocacaoDAO>().As<ITaxaRepository>().SingleInstance();
        }
    }
}
