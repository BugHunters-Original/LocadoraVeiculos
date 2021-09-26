using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;

namespace LocadoraDeVeiculos.AppServiceTests.LocacaoModule
{
    [TestClass]
    public class LocacaoMock
    {
        Mock<Locacao> locacaoObj;
        Mock<IPDF> pdfRepo;
        Mock<IEmail> emailRepo;
        Mock<IVeiculoRepository> veiculoRepo;
        Mock<IDescontoRepository> descontoRepo;
        Mock<ILocacaoRepository> locacaoRepo;
        LocacaoAppService locacaoService;
        Logger logger;
        public LocacaoMock()
        {
            locacaoObj = new();

            pdfRepo = new();

            emailRepo = new();

            veiculoRepo = new();

            descontoRepo = new();

            locacaoRepo = new();

            logger = LogManager.IniciarLog();

            locacaoService = new(locacaoRepo.Object, logger, emailRepo.Object,
                                 pdfRepo.Object, descontoRepo.Object, veiculoRepo.Object);
        }

        [TestMethod]
        public void Deve_chamar_inserir()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            emailRepo.Setup(x => x.EnviarEmail(locacaoObj.Object, logger));

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            locacaoRepo.Verify(x => x.Inserir(locacaoObj.Object));
        }
        [TestMethod]
        public void Não_deve_chamar_inserir()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ASIDGBASIDHSAD");

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            emailRepo.Setup(x => x.EnviarEmail(locacaoObj.Object, logger));

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            locacaoRepo.Verify(x => x.Inserir(locacaoObj.Object), Times.Never);
        }
        [TestMethod]
        public void Não_deve_enviar_email()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("sdfsdfds");

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            emailRepo.Verify(x => x.EnviarEmail(locacaoObj.Object, logger), Times.Never);
        }
        [TestMethod]
        public void Não_deve_montar_pdf()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("sdfsdfds");

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            pdfRepo.Verify(x => x.MontarPDF(locacaoObj.Object), Times.Never);
        }
        [TestMethod]
        public void Deve_devolver_veiculo()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            locacaoService.ConcluirLocacao(0, locacaoObj.Object);

            veiculoRepo.Verify(x => x.DevolverVeiculo(It.IsAny<Veiculo>()));
        }
        [TestMethod]
        public void Deve_atualizar_quilometragem()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            locacaoService.ConcluirLocacao(0, locacaoObj.Object);

            veiculoRepo.Verify(x => x.AtualizarQuilometragem(It.IsAny<Veiculo>()));
        }
    }
}
