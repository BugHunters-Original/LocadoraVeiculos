using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace LocadoraVeiculo.Tests.ClienteModule
{
    [TestClass]
    public class ControladorClienteTest
    {
        ControladorCliente controlador = null;

        public ControladorClienteTest()
        {
            controlador = new ControladorCliente();
            Db.Update("DELETE FROM [TBCLIENTE]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            //arrange
            var novoCliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");

            //action
            controlador.InserirNovo(novoCliente);

            //assert
            var clienteEncontrado = controlador.SelecionarPorId(novoCliente.Id);
            clienteEncontrado.Should().Be(novoCliente);
        }
        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            controlador.InserirNovo(cliente);

            var novoCliente = new Cliente("Andrey Silva", "Santa Helena", "(49)99803-5074", "01190011956", "PF");

            //action
            controlador.Editar(cliente.Id, novoCliente);

            //assert
            Cliente clienteAtualizado = controlador.SelecionarPorId(cliente.Id);
            clienteAtualizado.Should().Be(novoCliente);
        }
        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            //arrange            
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            controlador.InserirNovo(cliente);

            //action            
            controlador.Excluir(cliente.Id);

            //assert
            Cliente clienteEncontrado = controlador.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            //arrange
            var cliente = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            controlador.InserirNovo(cliente);

            //action
            Cliente clienteEncontrado = controlador.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new Cliente("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "PF");
            controlador.InserirNovo(c1);

            var c2 = new Cliente("Andrey Silva", "Santa Helena", "(49)99803-5074", "01190011956", "PF");
            controlador.InserirNovo(c2);

            var c3 = new Cliente("NDD", "Coral", "(49)99803-5074", "01190011956", "PJ");
            controlador.InserirNovo(c3);

            //action
            var contatos = controlador.SelecionarTodos();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].Nome.Should().Be("Gabriel Marques");
            contatos[1].Nome.Should().Be("Andrey Silva");
            contatos[2].Nome.Should().Be("NDD");
        }
    }
}
