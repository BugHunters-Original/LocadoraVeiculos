using Autofac;
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
            Builder.RegisterType<OperacoesParceiro>().InstancePerDependency();
            Builder.RegisterType<OperacoesDesconto>().InstancePerDependency();
            Builder.RegisterType<OperacoesCliente>().InstancePerDependency();
            Builder.RegisterType<OperacoesFuncionario>().InstancePerDependency();
            Builder.RegisterType<OperacoesGrupoVeiculo>().InstancePerDependency();
            Builder.RegisterType<OperacoesLocacao>().InstancePerDependency();
            Builder.RegisterType<OperacoesServico>().InstancePerDependency();
            Builder.RegisterType<OperacoesVeiculo>().InstancePerDependency();
        }

        private static void ConfigurarService()
        {
            Builder.RegisterType<ParceiroAppService>().InstancePerDependency();
            Builder.RegisterType<ClienteCNPJAppService>().InstancePerDependency();
            Builder.RegisterType<ClienteCPFAppService>().InstancePerDependency();
            Builder.RegisterType<DescontoAppService>().InstancePerDependency();
            Builder.RegisterType<FuncionarioAppService>().InstancePerDependency();
            Builder.RegisterType<GrupoVeiculoAppService>().InstancePerDependency();
            Builder.RegisterType<LocacaoAppService>().InstancePerDependency();
            Builder.RegisterType<ServicoAppService>().InstancePerDependency();
            Builder.RegisterType<VeiculoAppService>().InstancePerDependency();
        }
        private static void ConfigurarORM()
        {
            Builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().InstancePerDependency();
            Builder.RegisterType<ClienteCNPJDAO>().As<IClienteCNPJRepository>().InstancePerDependency();
            Builder.RegisterType<ClienteCPFDAO>().As<IClienteCPFRepository>().InstancePerDependency();
            Builder.RegisterType<DescontoDAO>().As<IDescontoRepository>().InstancePerDependency();
            Builder.RegisterType<FuncionarioDAO>().As<IFuncionarioRepository>().InstancePerDependency();
            Builder.RegisterType<GrupoVeiculoDAO>().As<IGrupoVeiculoRepository>().InstancePerDependency();
            Builder.RegisterType<LocacaoDAO>().As<ILocacaoRepository>().InstancePerDependency();
            Builder.RegisterType<ServicoDAO>().As<IServicoRepository>().InstancePerDependency();
            Builder.RegisterType<VeiculoDAO>().As<IVeiculoRepository>().InstancePerDependency();
            Builder.RegisterType<TaxaDaLocacaoDAO>().As<ITaxaRepository>().AsSelf().InstancePerDependency();
            Builder.RegisterType<EnviaEmail>().As<IEmail>().InstancePerDependency();
            Builder.RegisterType<MontaPdf>().As<IPDF>().InstancePerDependency();
            Builder.RegisterType<FiltroCliente>().InstancePerDependency();
        }
    }
}
