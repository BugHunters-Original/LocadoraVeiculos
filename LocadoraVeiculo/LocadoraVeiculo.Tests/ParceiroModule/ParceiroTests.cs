using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculo.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroTests
    {
        [TestMethod]
        public void DeveValidar_Parceiro()
        {
            Parceiro parceiro = new Parceiro("Luisa S");

            //action
            var resultadoValidacao = parceiro.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {
            Parceiro parceiro = new Parceiro("");

            //action
            var resultadoValidacao = parceiro.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
    }
}
