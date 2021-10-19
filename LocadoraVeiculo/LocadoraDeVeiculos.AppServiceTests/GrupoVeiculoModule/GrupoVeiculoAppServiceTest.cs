using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using Serilog.Core;
using Serilog;

namespace LocadoraDeVeiculos.AppServiceTests.GrupoVeiculoModule
{
    
    [TestClass]
    public class GrupoVeiculoAppServiceTest
    {
        public GrupoVeiculoAppServiceTest()
        {
            Infra.Logger.Serilogger.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }
       
        [TestMethod]
        public void Deve_Chamar_Excluir()
        {
            GrupoVeiculo grupoVeiculo = new("SUV", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();
            grupoVeiculoMock.Setup(x => x.Excluir(grupoVeiculo)).Returns(true);


            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object);

            var resultado = grupoVeiculoService.ExcluirGrupoVeiculo(grupoVeiculo);
            resultado.Should().BeTrue();


        }


    

        [TestMethod]
        public void Deve_chamar_inserir()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object);

            grupoVeiculoService.RegistrarNovoGrupoVeiculo(grupoVeiculo);

            grupoVeiculoMock.Verify(x => x.Inserir(It.IsAny<GrupoVeiculo>()));

        }

        [TestMethod]
        public void Não_Deve_inserir()
        {

            Mock<GrupoVeiculo> grupoVeiculo = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            grupoVeiculo.Setup(x => x.Validar()).Returns("O campo Categoria é obrigatório");

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object);

            grupoVeiculoService.RegistrarNovoGrupoVeiculo(grupoVeiculo.Object);

            grupoVeiculoMock.Verify(x => x.Inserir(grupoVeiculo.Object), Times.Never);
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);
            GrupoVeiculo grupoVeiculoEditado = new GrupoVeiculo("SUV", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object);

            grupoVeiculoService.EditarNovoGrupoVeiculo(grupoVeiculoEditado);

            grupoVeiculoMock.Verify(x => x.Editar(grupoVeiculoEditado));
        }

        [TestMethod]
        public void Nao_Deve_editar()
        {
            Mock<GrupoVeiculo> grupoVeiculo = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);
            Mock<GrupoVeiculo> grupoVeiculoEditado = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            grupoVeiculoEditado.Setup(x => x.Validar()).Returns("O campo Categoria é obrigatório");

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object);

            grupoVeiculoService.EditarNovoGrupoVeiculo(grupoVeiculoEditado.Object);

            grupoVeiculoMock.Verify(x => x.Editar(grupoVeiculoEditado.Object), Times.Never);
        }
    }
}
