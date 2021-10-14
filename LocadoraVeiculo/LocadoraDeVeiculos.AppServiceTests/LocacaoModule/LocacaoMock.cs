using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;
using Serilog;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;

namespace LocadoraDeVeiculos.AppServiceTests.LocacaoModule
{
    [TestClass]
    public class LocacaoMock
    {
        Mock<Locacao> locacaoObj;
        Mock<Veiculo> veiculoObj;
        Mock<GrupoVeiculo> grupoObj;
        Mock<IPDF> pdfRepo;
        Mock<IEmail> emailRepo;
        Mock<IVeiculoRepository> veiculoRepo;
        Mock<IDescontoRepository> descontoRepo;
        Mock<ILocacaoRepository> locacaoRepo;
        Mock<ITaxaRepository> taxaRepo;
        LocacaoAppService locacaoService;
        Veiculo veiculo;
        public LocacaoMock()
        {
            locacaoObj = new();

            pdfRepo = new();

            emailRepo = new();

            veiculoRepo = new();

            descontoRepo = new();

            locacaoRepo = new();

            taxaRepo = new();

            grupoObj = new();

            byte[] imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };

            veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupoObj.Object);


            locacaoService = new(locacaoRepo.Object, emailRepo.Object,
                                 pdfRepo.Object, descontoRepo.Object, veiculoRepo.Object, taxaRepo.Object);

            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        [TestMethod]
        public void Deve_chamar_inserir()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Veiculo a = locacaoObj.Object.Veiculo;

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            emailRepo.Setup(x => x.EnviarEmail(locacaoObj.Object));

            //veiculoObj.Setup(x => x.ToString()).Returns("");

            locacaoObj.Setup(x => x.Veiculo).Returns(veiculo);

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            locacaoRepo.Verify(x => x.Inserir(locacaoObj.Object));
        }
        [TestMethod]
        public void Não_deve_chamar_inserir()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ASIDGBASIDHSAD");

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            emailRepo.Setup(x => x.EnviarEmail(locacaoObj.Object));

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            locacaoRepo.Verify(x => x.Inserir(locacaoObj.Object), Times.Never);
        }
        [TestMethod]
        public void Não_deve_enviar_email()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("sdfsdfds");

            pdfRepo.Setup(x => x.MontarPDF(locacaoObj.Object));

            locacaoService.RegistrarNovaLocacao(locacaoObj.Object);

            emailRepo.Verify(x => x.EnviarEmail(locacaoObj.Object), Times.Never);
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

            locacaoService.ConcluirLocacao(locacaoObj.Object);

            veiculoRepo.Verify(x => x.DevolverVeiculo(It.IsAny<Veiculo>()));
        }
        [TestMethod]
        public void Deve_atualizar_quilometragem()
        {
            locacaoObj.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            locacaoService.ConcluirLocacao(locacaoObj.Object);

            veiculoRepo.Verify(x => x.AtualizarQuilometragem(It.IsAny<Veiculo>()));
        }
    }
}
