using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.ClienteModule
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            var cliente = new Cliente("", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
        [TestMethod]
        public void DeveValidar_Endereco()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "", "(49)99803-5074", "01190011956", "PF");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Endereço está inválido");
        }
        [TestMethod]
        public void DeveValidar_Telefone()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "", "01190011956", "PF");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Telefone está inválido");
        }
        [TestMethod]
        public void DeveValidar_CPF_CNPJ()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "", "PF");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo CPF/CNPJ está inválido");
        }
        [TestMethod]
        public void DeveValidar_Tipo()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "");

            //action
            var resultadoValidacao = cliente.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo está inválido");
        }
    }
}