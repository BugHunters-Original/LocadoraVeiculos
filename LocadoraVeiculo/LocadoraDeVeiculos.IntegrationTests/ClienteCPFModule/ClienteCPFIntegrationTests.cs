using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Serilog;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

namespace LocadoraDeVeiculos.Test.ClienteCPFModule
{
    [TestClass]
    public class ClienteCPFIntegrationTests
    {
        ClienteCNPJDAO cnpjDAO = null;
        ClienteCPFDAO cpfDAO = null;
        static LocacaoContext context = null;

        public ClienteCPFIntegrationTests()
        {
            context = new();
            cnpjDAO = new ClienteCNPJDAO(context);
            cpfDAO = new ClienteCPFDAO(context);
            LimparBancos();

            Infra.Logger.Serilogger.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBancos()
        {
            context.TaxasDaLocacao.Clear();

            context.Locacoes.Clear();

            context.ClientesCNPJ.Clear();

            context.ClientesCPF.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            LimparBancos();
            
            //action

            var novoClienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", null);

            cpfDAO.Inserir(novoClienteCPF);

            //assert
            var condutorEncontrado = cpfDAO.GetById(novoClienteCPF.Id);

            condutorEncontrado.Should().Be(novoClienteCPF);
        }

        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            LimparBancos();
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            cnpjDAO.Inserir(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", clienteCNPJ);

            cpfDAO.Inserir(clienteCPF);

            //action
            clienteCPF.Email = "arthurrrrrrrrr@gmail.com";


            cpfDAO.Editar(clienteCPF);

            //assert
            var clienteCPFEncontrado = cpfDAO.GetById(clienteCPF.Id);
            clienteCPFEncontrado.Email.Should().Be("arthurrrrrrrrr@gmail.com");
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            LimparBancos();
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");

            cnpjDAO.Inserir(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", clienteCNPJ);

            cpfDAO.Inserir(clienteCPF);

            //action
            cpfDAO.Excluir(clienteCPF);

            //assert
            var condutorEncontrado = cpfDAO.GetById(clienteCPF.Id);
            condutorEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            LimparBancos();
            //arrange
            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", null);

            cpfDAO.Inserir(clienteCPF);

            //action
            var clienteCPFEncontrado = cpfDAO.GetById(clienteCPF.Id);

            //assert
            clienteCPFEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            LimparBancos();
            //arrange

            var cd1 = new ClienteCPF("Andrey Silva", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", null);

            cpfDAO.Inserir(cd1);

            var cd2 = new ClienteCPF("Gabriel Marques", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", null);

            cpfDAO.Inserir(cd2);

            var cd3 = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", null);

            cpfDAO.Inserir(cd3);
            //action
            var clientesCPF = cpfDAO.GetAll();

            //assert
            clientesCPF.Should().HaveCount(3);
            clientesCPF[0].Nome.Should().Be("Andrey Silva");
            clientesCPF[1].Nome.Should().Be("Gabriel Marques");
            clientesCPF[2].Nome.Should().Be("Pedro");
        }
    }
}
