using Autofac;
using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.LoginModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.ReciboModule;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using LocadoraDeVeiculos.Infra.PdfManager;

namespace LocadoraDeVeiculos.WebApi.Config.AutoFacConfig
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocacaoContext>().InstancePerLifetimeScope();

            RegistrarORM(builder);

            RegistrarAppService(builder);

            builder.RegisterType<Mapper>().As<IMapper>();
        }

        private static void RegistrarORM(ContainerBuilder builder)
        {
            builder.RegisterType<TaxaDaLocacaoDAO>().As<ITaxaRepository>().AsSelf().InstancePerDependency();
            builder.RegisterType<GrupoVeiculoDAO>().As<IGrupoVeiculoRepository>().InstancePerDependency();
            builder.RegisterType<ClienteCNPJDAO>().As<IClienteCNPJRepository>().InstancePerDependency();
            builder.RegisterType<FuncionarioDAO>().As<IFuncionarioRepository>().AsSelf().InstancePerDependency();
            builder.RegisterType<ClienteCPFDAO>().As<IClienteCPFRepository>().InstancePerDependency();
            builder.RegisterType<ParceiroDAO>().As<IParceiroRepository>().InstancePerDependency();
            builder.RegisterType<DescontoDAO>().As<IDescontoRepository>().InstancePerDependency();
            builder.RegisterType<LocacaoDAO>().As<ILocacaoRepository>().InstancePerDependency();
            builder.RegisterType<ServicoDAO>().As<IServicoRepository>().InstancePerDependency();
            builder.RegisterType<VeiculoDAO>().As<IVeiculoRepository>().InstancePerDependency();
            builder.RegisterType<ReciboDAO>().As<IReciboRepository>().InstancePerDependency();
            builder.RegisterType<LoginDAO>().InstancePerDependency();
            builder.RegisterType<PdfMaker>().InstancePerDependency();
        }
        private static void RegistrarAppService(ContainerBuilder builder)
        {
            builder.RegisterType<GrupoVeiculoAppService>().As<IGrupoVeiculoAppService>().InstancePerDependency();
            builder.RegisterType<FuncionarioAppService>().As<IFuncionarioAppService>().InstancePerDependency();
            builder.RegisterType<ClienteCNPJAppService>().As<IClienteCNPJAppService>().InstancePerDependency();
            builder.RegisterType<ClienteCPFAppService>().As<IClienteCPFAppService>().InstancePerDependency();
            builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>().InstancePerDependency();
            builder.RegisterType<DescontoAppService>().As<IDescontoAppService>().InstancePerDependency();
            builder.RegisterType<LocacaoAppService>().As<ILocacaoAppService>().InstancePerDependency();
            builder.RegisterType<ServicoAppService>().As<IServicoAppService>().InstancePerDependency();
            builder.RegisterType<VeiculoAppService>().As<IVeiculoAppService>().InstancePerDependency();
        }
    }
}
