
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.AppServiceTests.GrupoVeiculoModule
{
    [TestClass]
    public class GrupoVeiculoAppServiceTest
    {
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, LogManager.GetLogger("Grupo Veículo"));

            grupoVeiculoService.RegistrarNovoGrupoVeiculo(grupoVeiculo);

            grupoVeiculoMock.Verify(x => x.Inserir(It.IsAny<GrupoVeiculo>()));
           
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);
            GrupoVeiculo grupoVeiculoEditado = new GrupoVeiculo("SUV", 40, 5, 50, 30, 40, 10);

            Mock<IGrupoVeiculoRepository> grupoVeiculoMock = new();

            GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoMock.Object, LogManager.GetLogger("Grupo Veículo"));

            grupoVeiculoService.EditarNovoGrupoVeiculo(grupoVeiculo.Id, grupoVeiculoEditado);

            grupoVeiculoMock.Verify(x => x.Editar(grupoVeiculo.Id, grupoVeiculoEditado));
        }
    }
}
