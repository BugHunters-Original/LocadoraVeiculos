using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        }

        private static void LimparBancos()
        {
            var Taxas= context.TaxasDaLocacao;
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
            var novoClienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            cnpjDAO.Inserir(novoClienteCNPJ);


            //action

            var novoClienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", novoClienteCNPJ);

            cpfDAO.Inserir(novoClienteCPF);

            //assert
            var condutorEncontrado = cpfDAO.GetById(novoClienteCPF.Id);
            condutorEncontrado.Should().Be(novoClienteCPF);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");

            cnpjDAO.Inserir(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", clienteCNPJ);

            cpfDAO.Inserir(clienteCPF);

            //action
            var novoClienteCPF = new ClienteCPF("Juca", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", clienteCNPJ);

            cpfDAO.Editar(novoClienteCPF);

            //assert
            var clienteCPFEncontrado = cpfDAO.GetById(clienteCPF.Id);
            clienteCPFEncontrado.Should().Be(novoClienteCPF);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
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
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            //arrange
            var clienteCNPJ = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");

            cnpjDAO.Inserir(clienteCNPJ);

            var clienteCPF = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", clienteCNPJ);

            cpfDAO.Inserir(clienteCPF);

            //action
            var clienteCPFEncontrado = cpfDAO.GetById(clienteCPF.Id);

            //assert
            clienteCPFEncontrado.Should().NotBeNull();
            LimparBancos();
        }
        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            //arrange
            var ct1 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            cnpjDAO.Inserir(ct1);

            var cd1 = new ClienteCPF("Andrey Silva", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", ct1);

            cpfDAO.Inserir(cd1);

            var ct2 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            cnpjDAO.Inserir(ct2);

            var cd2 = new ClienteCPF("Gabriel Marques", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", ct2);

            cpfDAO.Inserir(cd2);

            var ct3 = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "01190011956", "gabas220601@gmail.com");
            cnpjDAO.Inserir(ct3);

            var cd3 = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", ct3);

            cpfDAO.Inserir(cd3);
            //action
            var clientesCPF = cpfDAO.GetAll();

            //assert
            clientesCPF.Should().HaveCount(3);
            clientesCPF[0].Nome.Should().Be("Andrey Silva");
            clientesCPF[1].Nome.Should().Be("Gabriel Marques");
            clientesCPF[2].Nome.Should().Be("Pedro");
            LimparBancos();
        }
    }
}
