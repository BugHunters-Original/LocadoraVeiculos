using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Test.ClienteNPJModule
{
    [TestClass]
    public class ClienteCNPJIntegrationTests
    {
        ClienteCNPJDAO cnpjDAO = null;

        public ClienteCNPJIntegrationTests()
        {
            cnpjDAO = new ClienteCNPJDAO();
            LimparBanco();
        }

        private static void LimparBanco()
        {
            Db.Update("DELETE FROM [TBTAXASDALOCACAO]");
            Db.Update("DELETE FROM [TBLOCACAO]");
            Db.Update("DELETE FROM [TBCLIENTECPF]");
            Db.Update("DELETE FROM [TBCLIENTECNPJ]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            //arrange
            var novoCliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            cnpjDAO.Inserir(novoCliente);

            //assert
            var clienteEncontrado = cnpjDAO.SelecionarPorId(novoCliente.Id);
            clienteEncontrado.Should().Be(novoCliente);

            LimparBanco();
        }
        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            var novoCliente = new ClienteCNPJ("Andrey Silva", "Santa Helena", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            cnpjDAO.Editar(cliente.Id, novoCliente);

            //assert
            ClienteCNPJ clienteAtualizado = cnpjDAO.SelecionarPorId(cliente.Id);
            clienteAtualizado.Should().Be(novoCliente);
            LimparBanco();
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            //arrange            
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            //action            
            cnpjDAO.Excluir(cliente.Id);

            //assert
            ClienteCNPJ clienteEncontrado = cnpjDAO.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();

            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            //action
            ClienteCNPJ clienteEncontrado = cnpjDAO.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var c1 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c1);

            var c2 = new ClienteCNPJ("Andrey Silva", "Santa Helena", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c2);

            var c3 = new ClienteCNPJ("NDD", "Coral", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c3);

            //action
            var contatos = cnpjDAO.SelecionarTodos();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].Nome.Should().Be("Gabriel Marques");
            contatos[1].Nome.Should().Be("Andrey Silva");
            contatos[2].Nome.Should().Be("NDD");
            LimparBanco();
        }
    }
}
