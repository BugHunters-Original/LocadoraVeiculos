using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;
using Serilog;

namespace LocadoraDeVeiculos.AppServiceTests.VeiculoModule
{
    [TestClass]
   
    public class VeiculoAppServiceTests
    {
        Mock<IVeiculoRepository> veiculoDAOMock;
        byte[] imagem;
        GrupoVeiculo grupoVeiculo;
        Mock<Veiculo> veiculoMock;
        
        public VeiculoAppServiceTests()
        {   
            veiculoDAOMock = new();
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);
            veiculoMock = new("Carro", "AAA8888", "12345678912345678", imagem, "vermelho",
                "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoVeiculo);
         
            Infra.LogManager.LogSerilog.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        [TestMethod]
        public void Deve_Chamar_Inserir()
        {
            //arrange
            Veiculo veiculo = veiculoMock.Object;

            veiculoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //actions
            VeiculoAppService veiculoAppService = new VeiculoAppService(veiculoDAOMock.Object);
            veiculoAppService.RegistrarNovoVeiculo(veiculo);

            //assert
            veiculoDAOMock.Verify(x => x.Inserir(veiculo));

        }

        [TestMethod]
        public void Deve_Chamar_Editar()
        {
            //arrange
            Veiculo veiculo = veiculoMock.Object;

            veiculoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });
            //actions
            VeiculoAppService veiculoAppService = new VeiculoAppService(veiculoDAOMock.Object);
            
            veiculoAppService.EditarVeiculo(veiculo);

            //assert
            veiculoDAOMock.Verify(x => x.Editar(veiculo));

        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            Veiculo veiculo = veiculoMock.Object;

            veiculoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "O campo Nome é obrigatório";
            });

            VeiculoAppService veiculoService = new(veiculoDAOMock.Object);

            veiculoService.RegistrarNovoVeiculo(veiculo);

            veiculoDAOMock.Verify(x => x.Inserir(veiculo), Times.Never);
        }
    }
}
