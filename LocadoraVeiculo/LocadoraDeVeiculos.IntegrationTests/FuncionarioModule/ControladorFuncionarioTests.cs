using FluentAssertions;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.FuncionarioModule
{
    [TestClass]
    public class ControladorFuncionarioTests
    {

        FuncionarioDAO funcionarioDAO = null;
        static LocacaoContext context = null;

        public ControladorFuncionarioTests()
        {
            context = new();
            funcionarioDAO = new FuncionarioDAO(context);
            LimparBanco();
            Log.IniciarLog();
        }

        private static void LimparBanco()
        {
            var Func = context.Funcionarios;
            context.Funcionarios.RemoveRange(Func);
        }

        [TestMethod]
        public void DeveInserir_Funcionario()
        {
            //arrange
            var novoFuncionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");

            //action
            funcionarioDAO.Inserir(novoFuncionario);

            //assert
            var funcionarioEncontrado = funcionarioDAO.GetById(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(funcionario);

            //action
            funcionario.Salario = 100000;
            funcionarioDAO.Editar(funcionario);

            //assert
            Funcionario funcionarioAtualizado = funcionarioDAO.GetById(funcionario.Id);
            funcionarioAtualizado.Salario.Should().Be(100000);
            LimparBanco();
        }



        [TestMethod]
        public void DeveExcluir_Funcionario()
        {
            //arrange            
            var funcionario = new Funcionario("Luisa Farias", 3000, new DateTime(2021, 03, 03), "099.427.999-09", "luisa_f", "1234567");
            funcionarioDAO.Inserir(funcionario);

            //action            
            funcionarioDAO.Excluir(funcionario);

            //assert
            Funcionario funcionarioEncontrado = funcionarioDAO.GetById(funcionario.Id);
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
            Funcionario funcionarioEncontrado = funcionarioDAO.GetById(funcionario.Id);

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
            var funcionarios = funcionarioDAO.GetAll();

            //assert
            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("Luisa Farias");
            funcionarios[1].Nome.Should().Be("Arthur");
            funcionarios[2].Nome.Should().Be("Andrey");

            LimparBanco();
        }
    }
}

