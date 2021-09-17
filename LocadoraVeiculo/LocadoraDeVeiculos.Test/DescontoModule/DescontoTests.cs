using FluentAssertions;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LocadoraDeVeiculos.Test.DescontoModule
{
    [TestClass]
    public class DescontoTests
    {
        ILog log;
        Parceiro parceiro;
        public DescontoTests()
        {
            parceiro = new Parceiro("Arthur");
        }

        [TestMethod]
        public void DeveValidar_Desconto()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Codigo()
        {
            //arrange
            Desconto funcionario = new Desconto("", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Codigo está inválido");
        }

        [TestMethod]
        public void DeveValidar_Valor_Zero()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 0, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ser zero ou negativo");
        }

        [TestMethod]
        public void DeveValidar_Valor_MenorQueZero()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", -11, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ser zero ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PorcentagemMaiorQue100()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 110, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ter uma porcentagem maior que 100%");
        }

        [TestMethod]
        public void DeveValidar_ValorInteiroMaiorQue100()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 1000, "Inteiro", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Tipo()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo está inválido");
        }

        [TestMethod]
        public void DeveValidar_Validade()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2010, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Data de Validade está inválido");
        }

        [TestMethod]
        public void DeveValidar_Parceiro()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), null, "YouTube", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Parceiro não pode ser nulo");
        }

        [TestMethod]
        public void DeveValidar_Meio()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "", "dimdim", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Meio está inválido");
        }
        [TestMethod]
        public void DeveValidar_ValorMinimo()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "Youtube", "dimdim", 0);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor Mínimo não pode ser zero ou negativo");
        }
        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            Desconto funcionario = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "Youtube", "", 50);

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }

        [TestMethod]
        public void DeveValidar_Desconto000000000()
        {
            //arrange
            Mock<Desconto> descontoMock = new Mock<Desconto>();

            descontoMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Desconto desconto = descontoMock.Object;

            Mock<IDescontoRepository> mock = new Mock<IDescontoRepository>();

            //action
            DescontoAppService sut = new DescontoAppService(mock.Object, log);

            sut.RegistrarNovoDesconto(desconto);


            //assert
            mock.Verify(x => x.InserirDesconto(It.IsAny<Desconto>()));
        }
    }
}
