using FluentAssertions;
using LocadoraVeiculo.Controladores.FuncionarioModule;
using LocadoraVeiculo.Controladores.LoginModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Tests.LoginModule
{
    [TestClass]
    public class ControladorLoginTest
    {
        ControladorFuncionario controladorFuncionario = null;
        ControladorLogin controlador = null;

        public ControladorLoginTest()
        {
            controladorFuncionario = new ControladorFuncionario();
            controlador = new ControladorLogin();
            Db.Update("DELETE FROM [TBFUNCIONARIO]");

        }

        [TestMethod]
        public void DeveRetornar_LoginValido()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controladorFuncionario.InserirNovo(novoFuncionario);

            //action
            var resultado = controlador.ValidarLogin("luisa_f", "1234567");

            //assert
            resultado.Should().Be("valido");
        }

        [TestMethod]
        public void DeveRetornar_SenhaIncorreta()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controladorFuncionario.InserirNovo(novoFuncionario);

            //action
            var resultado = controlador.ValidarLogin("luisa_f", "00000");

            //assert
            resultado.Should().Be("Senha Incorreta");
        }

        [TestMethod]
        public void DeveRetornar_UsuarioInexistente()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controladorFuncionario.InserirNovo(novoFuncionario);

            //action
            var resultado = controlador.ValidarLogin("luisa", "1234567");

            //assert
            resultado.Should().Be("Usuário Inexistente");
        }

        [TestMethod]
        public void DeveRetornar_Valido_AdminAdmin()
        {
            //arrange

            //action
            var resultado = controlador.ValidarLogin("admin", "admin");

            //assert
            resultado.Should().Be("valido");
        }
    }
}
