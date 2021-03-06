using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.TaxaServicoModule
{
    [TestClass]
    public class ServicoTest
    {
        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            Servico servico = new Servico("", 12, 1);

            //action
            var resultadoValidacao = servico.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
        [TestMethod]
        public void DeveValidar_Preco()
        {
            //arrange
            Servico servico = new Servico("GPS", 0, 1);

            //action
            var resultadoValidacao = servico.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Preço está inválido");
        }
        [TestMethod]
        public void DeveValidar_Tipo()
        {
            //arrange
            Servico servico = new Servico("GPS", 12, 2);

            //action
            var resultadoValidacao = servico.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo está inválido");
        }
    }
}
