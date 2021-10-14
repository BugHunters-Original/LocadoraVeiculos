using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog;

namespace LocadoraDeVeiculos.AppServiceTests.ClienteCNPJModule
{
    [TestClass]
    public class ClienteCNPJMock
    {
        public ClienteCNPJMock()
        {
            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object);

            clienteCNPJService.RegistrarNovoClienteCNPJ(cliente);

            clienteMock.Verify(x => x.Inserir(cliente));
        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCNPJ("123456789123456789")).Returns(true);

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object);

            var inseriu = clienteCNPJService.RegistrarNovoClienteCNPJ(cliente);

            inseriu.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object);

            clienteCNPJService.EditarClienteCNPJ(cliente);

            clienteMock.Verify(x => x.Editar(cliente));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCNPJ("123456789123456789")).Returns(true);

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object);

            var editou = clienteCNPJService.EditarClienteCNPJ(cliente);

            editou.Should().BeFalse();
        }
    }
}
