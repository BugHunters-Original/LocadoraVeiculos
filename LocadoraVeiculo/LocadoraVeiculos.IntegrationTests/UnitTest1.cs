using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocadoraVeiculos.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void D()
        {
            //arrange
            Mock<Desconto> descontoMock = new Mock<Desconto>();

            descontoMock.Setup(x => x.Validar()).Returns(() => { return "ESTA_VALIDO"; });

            Desconto desconto = descontoMock.Object;

            Mock<IDescontoRepository> mock = new Mock<IDescontoRepository>();

            //action
            DescontoAppService sut = new DescontoAppService(mock.Object, LogManager.GetLogger("Desconto"));

            sut.RegistrarNovoDesconto(desconto);


            //assert
            mock.Verify(x => x.Inserir(desconto));
        }

        [TestMethod]
        public void P()
        {
            //arrange
            Mock<Parceiro> parceiroMock = new Mock<Parceiro>();

            parceiroMock.Setup(x => x.Validar()).Returns(() => { return "ESTA_VALIDO"; });

            Parceiro parceiro = parceiroMock.Object;

            Mock<IParceiroRepository> mock = new Mock<IParceiroRepository>();

            //action
            ParceiroAppService sut = new ParceiroAppService(mock.Object, LogManager.GetLogger("Parceiro"));

            sut.RegistrarNovoParceiro(parceiro);


            //assert
            mock.Verify(x => x.Inserir(parceiro));
        }
    }
}
