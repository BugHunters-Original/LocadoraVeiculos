using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using Serilog.Core;
using LocadoraDeVeiculos.Infra.Log;

namespace LocadoraDeVeiculos.AppServiceTests.GrupoVeiculoModule
{
    //Testar: se existir um veicuo associado ao grupo, ele nao pode ser excluído
    [TestClass]
    public class GrupoVeiculoAppServiceTest
    {
        Logger logger;
        public GrupoVeiculoAppServiceTest()
        {
            logger = LogManager.IniciarLog();
        }
        [TestMethod]
        public void Deve_Chamar_Excluir()
        {
            GrupoVeiculo grupoVeiculo = new("SUV", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();
            grupoVeiculoMock.Setup(x => x.Excluir(grupoVeiculo.Id)).Returns(true);


            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            var resultado = grupoVeiculoService.ExcluirGrupoVeiculo(grupoVeiculo);
            resultado.sucesso.Should().BeTrue();


        }


        public void Deve_Chamar_Mensagem()
        {
            GrupoVeiculo grupoVeiculo = new("SUV", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();
            grupoVeiculoMock.Setup(x => x.Excluir(grupoVeiculo.Id)).Returns(false);


            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            var resultado = grupoVeiculoService.ExcluirGrupoVeiculo(grupoVeiculo);
            resultado.sucesso.Should().BeFalse();
            resultado.mensagem.Should().Be("Erro ao tentar excluir um grupo de veículos. Verifique se esse registro nao tem um veículo relacionado a ele");

        }

        [TestMethod]
        public void Deve_chamar_inserir()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            grupoVeiculoService.RegistrarNovoGrupoVeiculo(grupoVeiculo);

            grupoVeiculoMock.Verify(x => x.Inserir(It.IsAny<GrupoVeiculo>()));

        }

        [TestMethod]
        public void Não_Deve_inserir()
        {

            Mock<GrupoVeiculo> grupoVeiculo = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            grupoVeiculo.Setup(x => x.Validar()).Returns("O campo Categoria é obrigatório");

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            grupoVeiculoService.RegistrarNovoGrupoVeiculo(grupoVeiculo.Object);

            grupoVeiculoMock.Verify(x => x.Inserir(grupoVeiculo.Object), Times.Never);
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);
            GrupoVeiculo grupoVeiculoEditado = new GrupoVeiculo("SUV", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            grupoVeiculoService.EditarNovoGrupoVeiculo(grupoVeiculo.Id, grupoVeiculoEditado);

            grupoVeiculoMock.Verify(x => x.Editar(grupoVeiculo.Id, grupoVeiculoEditado));
        }

        [TestMethod]
        public void Nao_Deve_editar()
        {
            Mock<GrupoVeiculo> grupoVeiculo = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);
            Mock<GrupoVeiculo> grupoVeiculoEditado = new("Econômico", 40m, 5m, 50m, 30m, 40m, 10m);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            grupoVeiculoEditado.Setup(x => x.Validar()).Returns("O campo Categoria é obrigatório");

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, logger);

            grupoVeiculoService.EditarNovoGrupoVeiculo(grupoVeiculo.Object.Id, grupoVeiculoEditado.Object);

            grupoVeiculoMock.Verify(x => x.Editar(grupoVeiculo.Object.Id, grupoVeiculoEditado.Object), Times.Never);
        }
    }
}
