using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculo.Tests.ClienteModule
{
    [TestClass]
    public class ClienteCNPJTest
    {
        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            var cliente = new ClienteCNPJ("", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
        [TestMethod]
        public void DeveValidar_Endereco()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Endereço está inválido");
        }
        [TestMethod]
        public void DeveValidar_Telefone()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Telefone está inválido");
        }
        [TestMethod]
        public void DeveValidar_CNPJ()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "", "gabas220601@gmail.com");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo CNPJ está inválido");
        }
    }
}