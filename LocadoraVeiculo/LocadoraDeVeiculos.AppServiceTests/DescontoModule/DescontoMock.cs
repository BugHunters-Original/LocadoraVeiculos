﻿using FluentAssertions;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocadoraDeVeiculos.AppServiceTests.DescontoModule
{
    [TestClass]
    public class DescontoMock
    {
        public DescontoMock()
        {
        }
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            Mock<Desconto> desconto = new Mock<Desconto>();

            Mock<IDescontoRepository> descontoMock = new();

            desconto.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            DescontoAppService descontoService = new(descontoMock.Object);

            descontoService.RegistrarNovoDesconto(desconto.Object);

            descontoMock.Verify(x => x.Inserir(desconto.Object));
        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            Mock<Desconto> desconto = new Mock<Desconto>();

            Mock<IDescontoRepository> descontoMock = new();

            descontoMock.Setup(x => x.VerificarCodigoExistente("123456789123456789")).Returns(true);

            DescontoAppService descontoService = new(descontoMock.Object);

            var inseriu = descontoService.RegistrarNovoDesconto(desconto.Object);

            inseriu.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            Mock<Desconto> desconto = new Mock<Desconto>();

            Mock<IDescontoRepository> descontoMock = new();

            DescontoAppService descontoService = new(descontoMock.Object);

            desconto.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            descontoService.EditarDesconto(desconto.Object.Id, desconto.Object);

            descontoMock.Verify(x => x.Editar(desconto.Object.Id, desconto.Object));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            Mock<Desconto> desconto = new Mock<Desconto>();

            Mock<IDescontoRepository> descontoMock = new();

            descontoMock.Setup(x => x.VerificarCodigoExistente("123456789123456789")).Returns(true);

            DescontoAppService descontoService = new(descontoMock.Object);

            var editou = descontoService.EditarDesconto(desconto.Object.Id, desconto.Object);

            editou.Should().BeFalse();
        }
    }
}
