using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;

using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;

namespace LocadoraDeVeiculos.IntegrationTests.GrupoVeiculoModule
{
    [TestClass]
    public class GrupoVeiculoIntegrationTests
    {
        GrupoVeiculoDAO grupoVeiculoDAO;
      
        public GrupoVeiculoIntegrationTests()
        {
           
            grupoVeiculoDAO = new GrupoVeiculoDAO();
            LimparBancos();
        }

        private static void LimparBancos()
        {
            Db.Update("DELETE FROM [TBLOCACAO]");
            Db.Update("DELETE FROM [TBTIPOVEICULO]");
            Db.Update("DELETE FROM [TBVEICULOS]");
        }

        [TestMethod]
        public void DeveInserir_GrupoVeiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);

            //action
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //assert
            var grupoVeiculoEncontrado = grupoVeiculoDAO.SelecionarPorId(novoTipoGrupo.Id);
            grupoVeiculoEncontrado.Should().Be(novoTipoGrupo);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_GrupoVeiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            var novoTipoGrupoEditado = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10, 10);

            //action
            grupoVeiculoDAO.Editar(novoTipoGrupo.Id, novoTipoGrupoEditado);

            //assert
            GrupoVeiculo grupoAtualizado = grupoVeiculoDAO.SelecionarPorId(novoTipoGrupo.Id);
            grupoAtualizado.Should().Be(novoTipoGrupoEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_GrupoVeiculo()
        {
            //arrange            
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(novoTipoGrupo);

            //action            
            grupoVeiculoDAO.Excluir(novoTipoGrupo.Id);

            //assert
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.SelecionarPorId(novoTipoGrupo.Id);
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
            GrupoVeiculo grupoEncontrado = grupoVeiculoDAO.SelecionarPorId(novoTipoGrupo.Id);

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
            var contatos = grupoVeiculoDAO.SelecionarTodos();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].NomeTipo.Should().Be("Econômico");
            contatos[1].NomeTipo.Should().Be("Esportivo");
            contatos[2].NomeTipo.Should().Be("Vintage");
            LimparBancos();
        }


    }
}
