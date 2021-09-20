﻿using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using log4net;
using Moq;

namespace LocadoraDeVeiculos.AppServiceTests.ClienteCNPJModule
{
    [TestClass]
    public class ClienteCNPJMock
    {
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object, LogManager.GetLogger("Cliente CNPJ"));

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

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object, LogManager.GetLogger("Cliente CNPJ"));

            var inseriu = clienteCNPJService.RegistrarNovoClienteCNPJ(cliente);

            inseriu.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object, LogManager.GetLogger("Cliente CNPJ"));

            clienteCNPJService.EditarClienteCNPJ(cliente.Id, cliente);

            clienteMock.Verify(x => x.Editar(cliente.Id, cliente));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            ClienteCNPJ cliente = new("Gabriel", "Guarujá", "(49)99803-5074",
                                                  "123456789123456789", "gabas220601@gmail.com");

            Mock<IClienteCNPJRepository> clienteMock = new();

            clienteMock.Setup(x => x.ExisteCNPJ("123456789123456789")).Returns(true);

            ClienteCNPJAppService clienteCNPJService = new(clienteMock.Object, LogManager.GetLogger("Cliente CNPJ"));

            var editou = clienteCNPJService.EditarClienteCNPJ(cliente.Id, cliente);

            editou.Should().BeFalse();
        }
    }

}
