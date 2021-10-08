using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        private static void LimparBanco()
        {
            var Taxas = context.TaxasDaLocacao;
            context.TaxasDaLocacao.RemoveRange(Taxas);

            var Loca = context.Locacoes;
            context.Locacoes.RemoveRange(Loca);

            var CliCpf = context.ClientesCPF;
            context.ClientesCPF.RemoveRange(CliCpf);

            var CliCnpj = context.ClientesCNPJ;
            context.ClientesCNPJ.RemoveRange(CliCnpj);
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            //arrange
            var novoCliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            //action
            cnpjDAO.Inserir(novoCliente);

            //assert
            var clienteEncontrado = cnpjDAO.GetById(novoCliente.Id);
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
            cnpjDAO.Editar(novoCliente);

            //assert
            ClienteCNPJ clienteAtualizado = cnpjDAO.GetById(cliente.Id);
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
            cnpjDAO.Excluir(cliente);

            //assert
            ClienteCNPJ clienteEncontrado = cnpjDAO.GetById(cliente.Id);
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
            ClienteCNPJ clienteEncontrado = cnpjDAO.GetById(cliente.Id);

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
            var contatos = cnpjDAO.GetAll();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].Nome.Should().Be("Gabriel Marques");
            contatos[1].Nome.Should().Be("Andrey Silva");
            contatos[2].Nome.Should().Be("NDD");
            LimparBanco();
        }
    }
}
