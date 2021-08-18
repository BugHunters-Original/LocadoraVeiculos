using FluentAssertions;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Tests.VeiculoModule
{
    [TestClass]
    public class ControladorVeiculoTest
    {
        ControladorGrupoVeiculo controladorGrupo = null;
        ControladorVeiculo controlador = null;

        public ControladorVeiculoTest()
        {
            controladorGrupo = new ControladorGrupoVeiculo();
            controlador = new ControladorVeiculo();
            Db.Update("DELETE FROM [TBVEICULOS]");
            Db.Update("DELETE FROM [TBTIPOVEICULO]");
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(novoTipoGrupo);
            var novoVeiculo = new Veiculo("uno","1234567","12345678901234567",);
            //action
            

            //assert
            var clienteEncontrado = controladorGrupo.SelecionarPorId(novoTipoGrupo.Id);
            clienteEncontrado.Should().Be(novoTipoGrupo);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoVeiculo()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(novoTipoGrupo);

            var novoTipoGrupoEditado = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10);

            //action
            controladorGrupo.Editar(novoTipoGrupo.Id, novoTipoGrupoEditado);

            //assert
            GrupoVeiculo grupoAtualizado = controladorGrupo.SelecionarPorId(novoTipoGrupo.Id);
            grupoAtualizado.Should().Be(novoTipoGrupoEditado);
        }

        [TestMethod]
        public void DeveExcluir_GrupoVeiculo()
        {
            //arrange            
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(novoTipoGrupo);

            //action            
            controladorGrupo.Excluir(novoTipoGrupo.Id);

            //assert
            GrupoVeiculo grupoEncontrado = controladorGrupo.SelecionarPorId(novoTipoGrupo.Id);
            grupoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Grupo_PorId()
        {
            //arrange
            var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(novoTipoGrupo);

            //action
            GrupoVeiculo grupoEncontrado = controladorGrupo.SelecionarPorId(novoTipoGrupo.Id);

            //assert
            grupoEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var g1 = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(g1);

            var g2 = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(g2);

            var g3 = new GrupoVeiculo("Vintage", 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(g3);

            //action
            var contatos = controladorGrupo.SelecionarTodos();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].categoriaVeiculo.Should().Be("Econômico");
            contatos[1].categoriaVeiculo.Should().Be("Esportivo");
            contatos[2].categoriaVeiculo.Should().Be("Vintage");
        }
    }
}
