using FluentAssertions;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.SQL.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.FuncionarioModule
{
    [TestClass]
    public class ControladorFuncionarioTests
    {

        FuncionarioDAO funcionarioDAO = null;

        public ControladorFuncionarioTests()
        {
            funcionarioDAO = new FuncionarioDAO();
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
            funcionarioDAO.Inserir(novoFuncionario);

            //assert
            var funcionarioEncontrado = funcionarioDAO.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(funcionario);

            var novoFuncionario = new Funcionario("Luisa Farias", 4000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");

            //action
            funcionarioDAO.Editar(funcionario.Id, novoFuncionario);

            //assert
            Funcionario funcionarioAtualizado = funcionarioDAO.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
            LimparBanco();
        }



        [TestMethod]
        public void DeveExcluir_Funcionario()
        {
            //arrange            
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(funcionario);

            //action            
            funcionarioDAO.Excluir(funcionario.Id);

            //assert
            Funcionario funcionarioEncontrado = funcionarioDAO.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().BeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Funcionario_PorId()
        {
            //arrange
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(funcionario);

            //action
            Funcionario funcionarioEncontrado = funcionarioDAO.SelecionarPorId(funcionario.Id);

            //assert
            funcionarioEncontrado.Should().NotBeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_TodosFuncionarios()
        {
            //arrange
            var f1 = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(f1);

            var f2 = new Funcionario("Arthur", 6000, new DateTime(2021, 03, 03), "099.427.999-09", "user_arthur", "9999999999");
            funcionarioDAO.Inserir(f2);

            var f3 = new Funcionario("Andrey", 6000, new DateTime(2021, 03, 03), "099.427.999-09", "user_andrey", "88888898989");
            funcionarioDAO.Inserir(f3);

            //action
            var funcionarios = funcionarioDAO.SelecionarTodos();

            //assert
            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("Andrey");
            funcionarios[1].Nome.Should().Be("Arthur");
            funcionarios[2].Nome.Should().Be("Luisa Farias");
            LimparBanco();
        }
    }
}

