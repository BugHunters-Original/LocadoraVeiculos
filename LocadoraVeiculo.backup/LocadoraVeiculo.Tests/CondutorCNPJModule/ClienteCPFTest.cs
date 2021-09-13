using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.CondutorModule
{
    [TestClass]
    public class ClienteCPFTest
    {

        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome está inválido");
        }
        [TestMethod]
        public void DeveValidar_Endereco()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-6789", "", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Endereço está inválido");
        }
        [TestMethod]
        public void DeveValidar_Telefone()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-67899", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Telefone está inválido");
        }
        [TestMethod]
        public void DeveValidar_CPF()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-577",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo CPF está inválido");
        }
        [TestMethod]
        public void DeveValidar_RG()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.7547", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo RG está inválido");
        }
        [TestMethod]
        public void DeveValidar_CNH()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "123456789101", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo CNH está inválido");
        }
        [TestMethod]
        public void DeveValidar_DataCNH()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            var condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2021, 06, 22), "gabas220601@gmail.com", cliente);

            //action
            var resultadoValidacao = condutor.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Data de Validade CNH está inválido");
        }

    }
}
