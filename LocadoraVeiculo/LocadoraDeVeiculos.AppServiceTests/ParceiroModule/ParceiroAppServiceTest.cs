using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.LogManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;
using Serilog;

namespace LocadoraDeVeiculos.AppServiceTests.ParceiroModule
{
    [TestClass]
    public class ParceiroAppServiceTest
    {
        Mock<IParceiroRepository> parceiroDAOMock = new();
        Mock<Parceiro> parceiroMock = new();

        public ParceiroAppServiceTest()
        {           
            Infra.LogManager.Serilogger.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        [TestMethod]
        public void Deve_Chamar_Inserir()
        {
            //arrange 
            Parceiro novoParceiro = parceiroMock.Object;

            parceiroMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //actions
            ParceiroAppService parceiroAppService = new ParceiroAppService(parceiroDAOMock.Object);
            parceiroAppService.RegistrarNovoParceiro(novoParceiro);

            //assert
            parceiroDAOMock.Verify(x => x.Inserir(novoParceiro));

        }

        [TestMethod]
        public void Deve_Chamar_Editar()
        {
            //arrange
            Parceiro novoParceiro = parceiroMock.Object;

            parceiroMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //actions
            ParceiroAppService parceiroAppService = new ParceiroAppService(parceiroDAOMock.Object);
            parceiroAppService.EditarParceiro(novoParceiro);

            //assert
            parceiroDAOMock.Verify(x => x.Editar(novoParceiro));

        }
    }
}
