using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;

namespace LocadoraDeVeiculos.AppServiceTests.ParceiroModule
{
    [TestClass]
    public class ParceiroAppServiceTest
    {
        Mock<IParceiroRepository> parceiroDAOMock = new();
        Mock<Parceiro> parceiroMock = new();

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
            parceiroAppService.EditarParceiro(1 , novoParceiro);

            //assert
            parceiroDAOMock.Verify(x => x.Editar(1, novoParceiro));

        }
    }
}
