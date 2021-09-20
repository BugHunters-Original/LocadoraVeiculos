using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.AppServiceTests.ParceiroModule
{
    [TestClass]
    public class ParceiroAppServiceTest
    {
        Mock<IParceiroRepository> parceiroDAOMock = new();
        Mock<Parceiro> parceiroMock = new();

        //public ParceiroAppServiceTest(Mock<IParceiroRepository> repo, Mock<Parceiro> parceiroMock)
        //{
        //    parceiroDAOMock = repo;
        //    this.parceiroMock = parceiroMock;

        //}

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
            ParceiroAppService parceiroAppService = new ParceiroAppService(parceiroDAOMock.Object, LogManager.GetLogger("Parceiro"));
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
            ParceiroAppService parceiroAppService = new ParceiroAppService(parceiroDAOMock.Object, LogManager.GetLogger("Parceiro"));
            parceiroAppService.EditarParceiro(1 , novoParceiro);

            //assert
            parceiroDAOMock.Verify(x => x.Editar(1, novoParceiro));

        }
    }
}
