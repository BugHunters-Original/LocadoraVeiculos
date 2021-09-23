using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using log4net;
using System;
using Moq;

namespace LocadoraDeVeiculos.AppServiceTests.ClienteCPFModule
{
    [TestClass]
    public class ClienteCPFMock
    {
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2099, 09, 22), "gabas220601@gmail.com");

            Mock<IClienteCPFRepository> clienteMock = new();

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object, LogManager.GetLogger("Cliente CPF"));

            clienteCPFService.RegistrarNovoClienteCPF(cliente);

            clienteMock.Verify(x => x.Inserir(It.IsAny<ClienteCPF>()));
        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2021, 09, 22), "gabas220601@gmail.com");

            Mock<IClienteCPFRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCPF("011.900.119.56")).Returns(true);

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object, LogManager.GetLogger("Cliente CPF"));

            var inseriu = clienteCPFService.RegistrarNovoClienteCPF(cliente);

            inseriu.Should().BeFalse();

        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2099, 09, 22), "gabas220601@gmail.com");



            Mock<IClienteCPFRepository> clienteMock = new();

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object, LogManager.GetLogger("Cliente CPF"));

            clienteCPFService.EditarClienteCPF(cliente.Id, cliente);

            clienteMock.Verify(x => x.Editar(cliente.Id, cliente));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2021, 09, 22), "gabas220601@gmail.com");

            Mock<IClienteCPFRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCPF("011.900.119.56")).Returns(true);

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object, LogManager.GetLogger("Cliente CPF"));

            var editou = clienteCPFService.EditarClienteCPF(cliente.Id, cliente);

            editou.Should().BeFalse();
        }
    }
}
