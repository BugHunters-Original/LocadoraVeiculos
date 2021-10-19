using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;
using Serilog;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

namespace LocadoraDeVeiculos.IntegrationTests.GrupoVeiculoModule
{
    [TestClass]
    public class GrupoVeiculoIntegrationTests
    {
        GrupoVeiculoDAO grupoVeiculoDAO;
        static LocacaoContext context = null;

        public GrupoVeiculoIntegrationTests()
        {
            context = new();
            grupoVeiculoDAO = new GrupoVeiculoDAO(context);
            LimparBancos();

            Infra.Logger.Serilogger.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBancos()
        {
            context.Locacoes.Clear();

            context.GruposVeiculo.Clear();

            context.Veiculos.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        [TestMethod]
        public void DeveInserir_GrupoVeiculo()
        {
            LimparBancos();
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);

            //action
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //assert
            var grupoVeiculoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoVeiculoEncontrado.Should().Be(novoTipoGrupo);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoVeiculo()
        {
            LimparBancos();
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action
            novoTipoGrupo.NomeTipo = "Esportivo";
            grupoVeiculoDAO.Editar(novoTipoGrupo);

            //assert
            GrupoVeiculo grupoAtualizado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoAtualizado.NomeTipo.Should().Be("Esportivo");
        }

        [TestMethod]
        public void DeveExcluir_GrupoVeiculo()
        {
            LimparBancos();
            //arrange            
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action            
            grupoVeiculoDAO.Excluir(novoTipoGrupo);

            //assert
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Grupo_PorId()
        {
            LimparBancos();
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);

            //assert
            grupoEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            LimparBancos();
            //arrange
            var g1 = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(g1);

            var g2 = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(g2);

            var g3 = new GrupoVeiculo("Vintage", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(g3);

            //action
            var contatos = grupoVeiculoDAO.GetAll();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].NomeTipo.Should().Be("Econômico");
            contatos[1].NomeTipo.Should().Be("Esportivo");
            contatos[2].NomeTipo.Should().Be("Vintage");
        }


    }
}
