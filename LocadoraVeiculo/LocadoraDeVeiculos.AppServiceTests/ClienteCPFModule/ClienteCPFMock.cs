using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Moq;
using Serilog;

namespace LocadoraDeVeiculos.AppServiceTests.ClienteCPFModule
{
    [TestClass]
    public class ClienteCPFMock
    {
        public ClienteCPFMock()
        {
            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2099, 09, 22), "gabas220601@gmail.com");

            Mock<IClienteCPFRepository> clienteMock = new();

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object);

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

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object);

            var inseriu = clienteCPFService.RegistrarNovoClienteCPF(cliente);

            inseriu.Should().BeFalse();

        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2099, 09, 22), "gabas220601@gmail.com");



            Mock<IClienteCPFRepository> clienteMock = new();

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object);

            clienteCPFService.EditarClienteCPF(cliente);

            clienteMock.Verify(x => x.Editar(cliente));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            ClienteCPF cliente = new("Gabriel", "(49)99803-5074", "Guarujá", "011.900.119.56", "123456789",
                                     "12345678912", new DateTime(2021, 09, 22), "gabas220601@gmail.com");

            Mock<IClienteCPFRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCPF("011.900.119.56")).Returns(true);

            ClienteCPFAppService clienteCPFService = new(clienteMock.Object);

            var editou = clienteCPFService.EditarClienteCPF(cliente);

            editou.Should().BeFalse();
        }
    }
}
