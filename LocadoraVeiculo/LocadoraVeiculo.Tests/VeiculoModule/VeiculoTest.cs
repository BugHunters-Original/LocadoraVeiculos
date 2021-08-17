using FluentAssertions;
using LocadoraVeiculo.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace LocadoraVeiculo.Tests.VeiculoModule
{
    [TestClass]

    public class VeiculoTest
    {
        [TestMethod]
        public void DeveValidar_Veiculo()
        {
            //arrange
            //Veiculo veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", "vermelho", "Ford", 2009, 9, 200, 'M', 90, "Álcool", true, );

            ////action
            //var resultadoValidacao = veiculo.Validar();

            ////assert
            //resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
    }
}
