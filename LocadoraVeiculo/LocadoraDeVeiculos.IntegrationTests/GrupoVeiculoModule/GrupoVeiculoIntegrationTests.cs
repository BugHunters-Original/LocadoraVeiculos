using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;
using Serilog;

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
            
            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBancos()
        {
            var Loca = context.Locacoes;
            context.Locacoes.RemoveRange(Loca);

            var GrupoV = context.GruposVeiculo;
            context.GruposVeiculo.RemoveRange(GrupoV);

            var Veic = context.Veiculos;
            context.Veiculos.RemoveRange(Veic);
        }

        [TestMethod]
        public void DeveInserir_GrupoVeiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);

            //action
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //assert
            var grupoVeiculoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoVeiculoEncontrado.Should().Be(novoTipoGrupo);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_GrupoVeiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action
            novoTipoGrupo.NomeTipo = "Esportivo";
            grupoVeiculoDAO.Editar(novoTipoGrupo);

            //assert
            GrupoVeiculo grupoAtualizado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoAtualizado.NomeTipo.Should().Be("Esportivo");
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_GrupoVeiculo()
        {
            //arrange            
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action            
            grupoVeiculoDAO.Excluir(novoTipoGrupo);

            //assert
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);
            grupoEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Grupo_PorId()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.GetById(novoTipoGrupo.Id);

            //assert
            grupoEncontrado.Should().NotBeNull();
            LimparBancos();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
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
            LimparBancos();
        }


    }
}
