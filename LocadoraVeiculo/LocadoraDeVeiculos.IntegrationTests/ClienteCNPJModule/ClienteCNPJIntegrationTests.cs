using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace LocadoraDeVeiculos.Test.ClienteNPJModule
{
    [TestClass]
    public class ClienteCNPJIntegrationTests
    {
        ClienteCNPJDAO cnpjDAO = null;
        static LocacaoContext context = null;

        public ClienteCNPJIntegrationTests()
        {
            context = new();
            cnpjDAO = new ClienteCNPJDAO(context);
            LimparBanco();

            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBanco()
        {
            context.TaxasDaLocacao.Clear();

            context.Locacoes.Clear();

            context.ClientesCPF.Clear();

            context.ClientesCNPJ.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            LimparBanco();
            //arrange
            var novoCliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            cnpjDAO.Inserir(novoCliente);

            //assert
            var clienteEncontrado = cnpjDAO.GetById(novoCliente.Id);
            clienteEncontrado.Should().Be(novoCliente);

        }
        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            LimparBanco();
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            cliente.Nome = "Andrey Silva";

            //action
            cnpjDAO.Editar(cliente);

            //assert
            ClienteCNPJ clienteAtualizado = cnpjDAO.GetById(cliente.Id);
            clienteAtualizado.Nome.Should().Be("Andrey Silva");
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            LimparBanco();
            //arrange            
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            //action            
            cnpjDAO.Excluir(cliente);

            //assert
            ClienteCNPJ clienteEncontrado = cnpjDAO.GetById(cliente.Id);
            clienteEncontrado.Should().BeNull();

        }
        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            LimparBanco();
            //arrange
            var cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(cliente);

            //action
            ClienteCNPJ clienteEncontrado = cnpjDAO.GetById(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            LimparBanco();
            //arrange
            var c1 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c1);

            var c2 = new ClienteCNPJ("Andrey Silva", "Santa Helena", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c2);

            var c3 = new ClienteCNPJ("NDD", "Coral", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            cnpjDAO.Inserir(c3);

            //action
            var contatos = cnpjDAO.GetAll();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].Nome.Should().Be("Gabriel Marques");
            contatos[1].Nome.Should().Be("Andrey Silva");
            contatos[2].Nome.Should().Be("NDD");
        }
    }
}
