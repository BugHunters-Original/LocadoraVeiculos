using FluentAssertions;
using LocadoraVeiculo.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculo.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroTests
    {
        [TestMethod]
        public void DeveValidar_Parceiro()
        {
            ParceiroDesconto parceiro = new ParceiroDesconto("Luisa S");

            //action
            var resultadoValidacao = parceiro.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {
            ParceiroDesconto parceiro = new ParceiroDesconto("");

            //action
            var resultadoValidacao = parceiro.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
    }
}
