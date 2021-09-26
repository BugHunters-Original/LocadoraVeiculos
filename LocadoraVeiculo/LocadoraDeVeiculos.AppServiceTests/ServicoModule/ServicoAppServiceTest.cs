using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;

namespace LocadoraDeVeiculos.AppServiceTests.ServicoModule
{
    [TestClass]
    public class ServicoAppServiceTest
    {
        Mock<IServicoRepository> servicoDAOMock = new();
        Mock<Servico> servicoMock = new();
        Logger logger;
        public ServicoAppServiceTest()
        {
            logger = LogManager.IniciarLog();
        }
        [TestMethod]
        public void Deve_Chamar_Inserir()
        {
            //arrange
            Servico novoServico = servicoMock.Object;

            servicoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //actions
            ServicoAppService servicoAppService = new ServicoAppService(servicoDAOMock.Object, logger);
            servicoAppService.InserirServico(novoServico);

            //assert
            servicoDAOMock.Verify(x => x.Inserir(novoServico));

        }

        [TestMethod]
        public void Deve_Chamar_Editar()
        {
            //arrange
            Servico novoServico = servicoMock.Object;

            servicoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "ESTA_VALIDO";
            });

            //actions
            ServicoAppService ServicoAppService = new ServicoAppService(servicoDAOMock.Object, logger);
            ServicoAppService.EditarServico(1, novoServico);

            //assert
            servicoDAOMock.Verify(x => x.Editar(1, novoServico));

        }
    }
}
