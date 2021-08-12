using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.CondutorModule
{
    [TestClass]
    public class ControladorClienteCPFTest
    {
        ControladorClienteCNPJ ctrlCliente = null;
        ControladorClienteCPF ctrlCondutor = null;

        public ControladorClienteCPFTest()
        {
            ctrlCliente = new ControladorClienteCNPJ();
            ctrlCondutor = new ControladorClienteCPF();
            Db.Update("DELETE FROM [TBCLIENTECPF]");
            Db.Update("DELETE FROM [TBCLIENTECNPJ]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            //arrange
            var novoClienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61");

            ctrlCliente.InserirNovo(novoClienteCNPJ);


            //action

            var novoClienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), novoClienteCNPJ);

            ctrlCondutor.InserirNovo(novoClienteCPF);

            //assert
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(novoClienteCPF.Id);
            condutorEncontrado.Should().Be(novoClienteCPF);
        }

        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61");

            ctrlCliente.InserirNovo(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), clienteCNPJ);

            ctrlCondutor.InserirNovo(clienteCPF);

            //action
            var novoClienteCPF = new ClienteCPF("Juca", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), clienteCNPJ);

            ctrlCondutor.Editar(clienteCPF.Id, novoClienteCPF);

            //assert
            var clienteCPFEncontrado = ctrlCondutor.SelecionarPorId(clienteCPF.Id);
            clienteCPFEncontrado.Should().Be(novoClienteCPF);
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956");

            ctrlCliente.InserirNovo(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), clienteCNPJ);

            ctrlCondutor.InserirNovo(clienteCPF);

            //action
            ctrlCondutor.Excluir(clienteCPF.Id);

            //assert
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(clienteCPF.Id);
            condutorEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956");

            ctrlCliente.InserirNovo(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), clienteCNPJ);

            ctrlCondutor.InserirNovo(clienteCPF);

            //action
            var clienteCPFEncontrado = ctrlCondutor.SelecionarPorId(clienteCPF.Id);

            //assert
            clienteCPFEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var ct1 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956");
            ctrlCliente.InserirNovo(ct1);

            var cd1 = new ClienteCPF("Andrey Silva", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), ct1);

            ctrlCondutor.InserirNovo(cd1);

            var ct2 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956");
            ctrlCliente.InserirNovo(ct2);

            var cd2 = new ClienteCPF("Gabriel Marques", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), ct2);

            ctrlCondutor.InserirNovo(cd2);

            var ct3 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956");
            ctrlCliente.InserirNovo(ct3);

            var cd3 = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), ct3);

            ctrlCondutor.InserirNovo(cd3);
            //action
            var clientesCPF = ctrlCondutor.SelecionarTodos();

            //assert
            clientesCPF.Should().HaveCount(3);
            clientesCPF[0].Nome.Should().Be("Andrey Silva");
            clientesCPF[1].Nome.Should().Be("Gabriel Marques");
            clientesCPF[2].Nome.Should().Be("Pedro");
        }
    }
}