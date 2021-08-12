using FluentAssertions;
using LocadoraVeiculo.CombustivelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.CombustivelModule
{
    [TestClass]
    public class CombustivelTests
    {
        [TestMethod]
        public void DeveValidar_Combustivel()
        {
            Combustivel combustivel = new Combustivel(10, 10, 10);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nulos()
        {
            Combustivel combustivel = new Combustivel(10, null, 10);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo preço diesel é obrigatório ou deve ser maior que 0");
        }

        [TestMethod]
        public void DeveValidar_Zeros()
        {
            Combustivel combustivel = new Combustivel(0, 10, 10);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo preço gasolina é obrigatório ou deve ser maior que 0");
        }
    }
}
