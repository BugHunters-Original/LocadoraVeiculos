using FluentAssertions;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.FuncionarioModule
{
    [TestClass]
    public class ControladorFuncionarioTests
    {

        ControladorFuncionario controlador = null;

        public ControladorFuncionarioTests()
        {
            controlador = new ControladorFuncionario();
            LimparBanco();

        }

        private static void LimparBanco()
        {
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
        }

        [TestMethod]
        public void DeveInserir_Funcionario()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");

            //action
            controlador.InserirNovo(novoFuncionario);

            //assert
            var funcionarioEncontrado = controlador.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controlador.InserirNovo(funcionario);

            var novoFuncionario = new Funcionario("Luisa Farias", 4000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");

            //action
            controlador.Editar(funcionario.Id, novoFuncionario);

            //assert
            Funcionario funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
            LimparBanco();
        }



        [TestMethod]
        public void DeveExcluir_Funcionario()
        {
            //arrange            
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controlador.InserirNovo(funcionario);

            //action            
            controlador.Excluir(funcionario.Id);

            //assert
            Funcionario funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().BeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Funcionario_PorId()
        {
            //arrange
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controlador.InserirNovo(funcionario);

            //action
            Funcionario funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);

            //assert
            funcionarioEncontrado.Should().NotBeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_TodosFuncionarios()
        {
            //arrange
            var f1 = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            controlador.InserirNovo(f1);

            var f2 = new Funcionario("Arthur", 6000, new DateTime(2021, 03, 03), "099.427.999-09", "user_arthur", "9999999999");
            controlador.InserirNovo(f2);

            var f3 = new Funcionario("Andrey", 6000, new DateTime(2021, 03, 03), "099.427.999-09", "user_andrey", "88888898989");
            controlador.InserirNovo(f3);

            //action
            var funcionarios = controlador.SelecionarTodos();

            //assert
            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("Andrey");
            funcionarios[1].Nome.Should().Be("Arthur");
            funcionarios[2].Nome.Should().Be("Luisa Farias");
            LimparBanco();
        }
    }
}

