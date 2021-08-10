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
            Db.Update("DELE FROM [TBCLIENTE]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            //arrange
            var novoCliente = new Cliente("Gabriel Marques", "Guarujá", "49998035074", "01190011956", "PF");

            //action
            controlador.InserirNovo(novoCliente);

            //assert
            var clienteEncontrado = controlador.SelecionarPorId(novoCliente.Id);
            clienteEncontrado.Should().Be(novoCliente);
        }
    }
}
