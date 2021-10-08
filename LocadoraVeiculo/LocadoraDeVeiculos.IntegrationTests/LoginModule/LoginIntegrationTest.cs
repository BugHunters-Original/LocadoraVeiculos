using FluentAssertions;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.LoginModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.IntegrationTests.LoginModule
{
    [TestClass]
    public class LoginIntegrationTest
    {
        FuncionarioDAO repositoryFunc = null;
        LoginDAO repositoryLogin = null;
        static LocacaoContext context = null;

        public LoginIntegrationTest()
        {
            context = new();
            repositoryFunc = new(context);
            repositoryLogin = new();

            var Func = context.Funcionarios;
            context.Funcionarios.RemoveRange(Func);

        }

        [TestMethod]
        public void DeveRetornar_LoginValido()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            repositoryFunc.Inserir(novoFuncionario);

            //action
            var resultado = repositoryLogin.ValidarLogin("luisa_f", "1234567");

            //assert
            resultado.Should().Be("valido");
        }

        [TestMethod]
        public void DeveRetornar_SenhaIncorreta()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            repositoryFunc.Inserir(novoFuncionario);

            //action
            var resultado = repositoryLogin.ValidarLogin("luisa_f", "00000");

            //assert
            resultado.Should().Be("Senha Incorreta");
        }

        [TestMethod]
        public void DeveRetornar_UsuarioInexistente()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            repositoryFunc.Inserir(novoFuncionario);

            //action
            var resultado = repositoryLogin.ValidarLogin("luisa", "1234567");

            //assert
            resultado.Should().Be("Usuário Inexistente");
        }

        [TestMethod]
        public void DeveRetornar_Valido_AdminAdmin()
        {
            //arrange

            //action
            var resultado = repositoryLogin.ValidarLogin("admin", "admin");

            //assert
            resultado.Should().Be("valido");
        }
    }
}
