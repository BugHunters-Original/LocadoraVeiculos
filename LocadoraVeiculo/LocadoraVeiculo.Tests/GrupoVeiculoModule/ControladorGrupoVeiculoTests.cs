using FluentAssertions;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculo.Tests.GrupoVeiculoModule
{
    [TestClass]
    public class ControladorGrupoVeiculoTests
    {
        ControladorGrupoVeiculo controlador = null;

        //public ControladorGrupoVeiculoTests()
        //{
        //    controlador = new ControladorGrupoVeiculo();
        //    Db.Update("DELETE FROM [TBVEICULOS]");
        //    Db.Update("DELETE FROM [TBTIPOVEICULO]");
        //}

        //[TestMethod]
        //public void DeveInserir_GrupoVeiculo()
        //{
        //    //arrange
        //    var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);

        //    //action
        //    controlador.InserirNovo(novoTipoGrupo);

        //    //assert
        //    var clienteEncontrado = controlador.SelecionarPorId(novoTipoGrupo.Id);
        //    clienteEncontrado.Should().Be(novoTipoGrupo);
        //}

        //[TestMethod]
        //public void DeveAtualizar_GrupoVeiculo()
        //{
        //    //arrange
        //    var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(novoTipoGrupo);

        //    var novoTipoGrupoEditado = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10);

        //    //action
        //    controlador.Editar(novoTipoGrupo.Id, novoTipoGrupoEditado);

        //    //assert
        //    GrupoVeiculo grupoAtualizado = controlador.SelecionarPorId(novoTipoGrupo.Id);
        //    grupoAtualizado.Should().Be(novoTipoGrupoEditado);
        //}

        //[TestMethod]
        //public void DeveExcluir_GrupoVeiculo()
        //{
        //    //arrange            
        //    var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(novoTipoGrupo);

        //    //action            
        //    controlador.Excluir(novoTipoGrupo.Id);

        //    //assert
        //    GrupoVeiculo grupoEncontrado = controlador.SelecionarPorId(novoTipoGrupo.Id);
        //    grupoEncontrado.Should().BeNull();
        //}

        //[TestMethod]
        //public void DeveSelecionar_Grupo_PorId()
        //{
        //    //arrange
        //    var novoTipoGrupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(novoTipoGrupo);

        //    //action
        //    GrupoVeiculo grupoEncontrado = controlador.SelecionarPorId(novoTipoGrupo.Id);

        //    //assert
        //    grupoEncontrado.Should().NotBeNull();
        //}
        //[TestMethod]
        //public void DeveSelecionar_Todos()
        //{
        //    //arrange
        //    var g1 = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(g1);

        //    var g2 = new GrupoVeiculo("Esportivo", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(g2);

        //    var g3 = new GrupoVeiculo("Vintage", 10, 10, 10, 10, 10);
        //    controlador.InserirNovo(g3);

        //    //action
        //    var contatos = controlador.SelecionarTodos();

        //    //assert
        //    contatos.Should().HaveCount(3);
        //    contatos[0].categoriaVeiculo.Should().Be("Econômico");
        //    contatos[1].categoriaVeiculo.Should().Be("Esportivo");
        //    contatos[2].categoriaVeiculo.Should().Be("Vintage");
        //}
    }
}
