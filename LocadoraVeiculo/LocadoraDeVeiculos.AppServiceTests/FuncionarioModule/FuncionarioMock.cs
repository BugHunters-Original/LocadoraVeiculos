﻿using FluentAssertions;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocadoraDeVeiculos.AppServiceTests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioMock
    {
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, LogManager.GetLogger("Funcionario"));

            funcionarioService.RegistrarNovoFuncionario(funcionario.Object);

            funcionarioMock.Verify(x => x.Inserir(funcionario.Object));
        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("O campo Senha possui menos de sete dígitos");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, LogManager.GetLogger("Funcionario"));

            var inseriu = funcionarioService.RegistrarNovoFuncionario(funcionario.Object);

            inseriu.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, LogManager.GetLogger("Funcionario"));

            funcionarioService.EditarFuncionario(funcionario.Object.Id, funcionario.Object);

            funcionarioMock.Verify(x => x.Editar(funcionario.Object.Id, funcionario.Object));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("O campo Senha possui menos de sete dígitos");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, LogManager.GetLogger("Funcionario"));

            var inseriu = funcionarioService.EditarFuncionario(funcionario.Object.Id, funcionario.Object);

            inseriu.Should().BeFalse();
        }
    }
}
