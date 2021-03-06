using FluentAssertions;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.DescontoModule
{
    [TestClass]
    public class DescontoTests
    {
        Parceiro parceiro;
        public DescontoTests()
        {
            parceiro = new Parceiro("Arthur");
        }

        [TestMethod]
        public void DeveValidar_Desconto()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Codigo()
        {
            //arrange
            Desconto desconto = new Desconto("", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Codigo está inválido");
        }

        [TestMethod]
        public void DeveValidar_Valor_Zero()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 0, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ser zero ou negativo");
        }

        [TestMethod]
        public void DeveValidar_Valor_MenorQueZero()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", -11, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ser zero ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PorcentagemMaiorQue100()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 110, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor não pode ter uma porcentagem maior que 100%");
        }

        [TestMethod]
        public void DeveValidar_ValorInteiroMaiorQue100()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 1000, "Inteiro", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Tipo()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo está inválido");
        }

        [TestMethod]
        public void DeveValidar_Validade()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2010, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Data de Validade está inválido");
        }

        [TestMethod]
        public void DeveValidar_Parceiro()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), null, "YouTube", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Parceiro não pode ser nulo");
        }

        [TestMethod]
        public void DeveValidar_Meio()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "", "dimdim", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Meio está inválido");
        }
        [TestMethod]
        public void DeveValidar_ValorMinimo()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "Youtube", "dimdim", 0, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Valor Mínimo não pode ser zero ou negativo");
        }
        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            Desconto desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "Youtube", "", 50, 1);

            //action
            var resultadoValidacao = desconto.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
       
    }
}
