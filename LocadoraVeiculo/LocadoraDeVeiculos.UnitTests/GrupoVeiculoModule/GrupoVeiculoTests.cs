using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraDeVeiculos.UnitTests.GrupoVeiculoModule
{
    [TestClass]
    public class GrupoVeiculoTests
    {
        [TestMethod]
        public void DeveValidar_GrupoVeiculo()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("Econômico", 40, 5, 50, 30, 40, 10);

            //action
            var resultadoValidacao = grupoVeiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveRetornar_ErroSemNome()
        {
            GrupoVeiculo grupoVeiculo = new GrupoVeiculo("", 40, 5, 50, 30, 40, 10);

            //action
            var resultadoValidacao = grupoVeiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Categoria é obrigatório");
        }
    }
}
