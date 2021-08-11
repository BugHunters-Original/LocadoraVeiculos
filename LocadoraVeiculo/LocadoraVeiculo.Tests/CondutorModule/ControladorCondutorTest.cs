using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.CondutorModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.CondutorModule
{
    [TestClass]
    public class ControladorCondutorTest
    {
        ControladorCliente ctrlCliente = null;
        ControladorCondutor ctrlCondutor = null;

        public ControladorCondutorTest()
        {
            ctrlCliente = new ControladorCliente();
            ctrlCondutor = new ControladorCondutor();
            Db.Update("DELETE FROM [TBCONDUTOR]");
            Db.Update("DELETE FROM [TBCLIENTE]");
        }

        [TestMethod]
        public void DeveInserir_Condutor()
        {   
            //arrange
            var novoCliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            ctrlCliente.InserirNovo(novoCliente);


            //action

            var novoCondutor = new Condutor("Pedro", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), novoCliente);

            ctrlCondutor.InserirNovo(novoCondutor);

            //assert
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(novoCondutor.Id);
            condutorEncontrado.Should().Be(novoCondutor);
        }

        [TestMethod]
        public void DeveAtualizar_Condutor()
        {   
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            ctrlCliente.InserirNovo(cliente);

            var condutor = new Condutor("Pedro", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), cliente);

            ctrlCondutor.InserirNovo(condutor);

            //action
            var novoCondutor = new Condutor("Juca", "(49)99803-1234", "coral", "12345678911",
                                "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), cliente);

            ctrlCondutor.Editar(condutor.Id, novoCondutor);

            //assert
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(novoCondutor);
        }

        [TestMethod]
        public void DeveExcluir_Condutor()
        {   
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            ctrlCliente.InserirNovo(cliente);

            var condutor = new Condutor("Pedro", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), cliente);

            ctrlCondutor.InserirNovo(condutor);

            //action
            ctrlCondutor.Excluir(condutor.Id);

            //assert
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Condutor_PorId()
        {   
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            ctrlCliente.InserirNovo(cliente);

            var condutor = new Condutor("Pedro", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), cliente);

            ctrlCondutor.InserirNovo(condutor);

            //action
            var condutorEncontrado = ctrlCondutor.SelecionarPorId(condutor.Id);

            //assert
            condutorEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var ct1 = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            ctrlCliente.InserirNovo(ct1);

            var cd1 = new Condutor("Andrey Silva", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), ct1);

            ctrlCondutor.InserirNovo(cd1);

            var ct2 = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            ctrlCliente.InserirNovo(ct2);

            var cd2 = new Condutor("Gabriel Marques", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), ct2);

            ctrlCondutor.InserirNovo(cd2);

            var ct3 = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            ctrlCliente.InserirNovo(ct3);

            var cd3 = new Condutor("Pedro", "(49)99803-1234", "coral", "12345678911",
                                            "64654654654", "CNHHHHHH", new DateTime(2022, 06, 22), ct3);

            ctrlCondutor.InserirNovo(cd3);
            //action
            var condutores = ctrlCondutor.SelecionarTodos();

            //assert
            condutores.Should().HaveCount(3);
            condutores[0].Nome.Should().Be("Andrey Silva");
            condutores[1].Nome.Should().Be("Gabriel Marques");
            condutores[2].Nome.Should().Be("Pedro");
        }
    }
}
