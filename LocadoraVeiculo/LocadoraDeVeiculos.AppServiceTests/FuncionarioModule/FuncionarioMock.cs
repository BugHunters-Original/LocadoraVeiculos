using FluentAssertions;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog.Core;

namespace LocadoraDeVeiculos.AppServiceTests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioMock
    {
        Logger logger;
        public FuncionarioMock()
        {
            logger = LogManager.IniciarLog();
        }
        [TestMethod]
        public void Deve_chamar_inserir()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, logger);

            funcionarioService.RegistrarNovoFuncionario(funcionario.Object);

            funcionarioMock.Verify(x => x.Inserir(funcionario.Object));
        }

        [TestMethod]
        public void Não_Deve_inserir()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("O campo Senha possui menos de sete dígitos");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, logger);

            var inseriu = funcionarioService.RegistrarNovoFuncionario(funcionario.Object);

            inseriu.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_chamar_editar()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, logger);

            funcionarioService.EditarFuncionario(funcionario.Object.Id, funcionario.Object);

            funcionarioMock.Verify(x => x.Editar(funcionario.Object.Id, funcionario.Object));
        }

        [TestMethod]
        public void Não_Deve_editar()
        {
            Mock<Funcionario> funcionario = new Mock<Funcionario>();

            Mock<IFuncionarioRepository> funcionarioMock = new();

            funcionario.Setup(x => x.Validar()).Returns("O campo Senha possui menos de sete dígitos");

            FuncionarioAppService funcionarioService = new(funcionarioMock.Object, logger);

            var inseriu = funcionarioService.EditarFuncionario(funcionario.Object.Id, funcionario.Object);

            inseriu.Should().BeFalse();
        }
    }
}

