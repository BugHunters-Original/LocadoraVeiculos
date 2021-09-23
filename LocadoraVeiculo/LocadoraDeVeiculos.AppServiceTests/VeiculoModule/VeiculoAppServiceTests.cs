using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            VeiculoAppService veiculoAppService = new VeiculoAppService(veiculoDAOMock.Object, LogManager.GetLogger("Veiculo"));
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
            VeiculoAppService veiculoAppService = new VeiculoAppService(veiculoDAOMock.Object, LogManager.GetLogger("Veiculo"));
            
            veiculoAppService.EditarVeiculo(1, veiculo);

            //assert
            veiculoDAOMock.Verify(x => x.Editar(1, veiculo));

        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            Veiculo veiculo = veiculoMock.Object;

            veiculoMock.Setup(x => x.Validar()).Returns(() =>
            {
                return "O campo Nome é obrigatório";
            });

            VeiculoAppService veiculoService = new(veiculoDAOMock.Object, LogManager.GetLogger("Veiculo"));

            veiculoService.RegistrarNovoVeiculo(veiculo);

            veiculoDAOMock.Verify(x => x.Inserir(veiculo), Times.Never);
        }
    }
}
