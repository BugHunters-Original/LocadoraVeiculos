﻿using FluentAssertions;
using LocadoraVeiculo.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioTests
    {
        [TestMethod]
        public void DeveValidar_Funcionario()
        {
            //arrange
            Funcionario funcionario = new Funcionario("José Pedro", Convert.ToDecimal(2000.00), new DateTime(2021, 03, 03), "09942747979", "JP_USER", "1234567");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_CPF()
        {
            //arrange
            Funcionario funcionario = new Funcionario("José Pedro", Convert.ToDecimal(2000.0), new DateTime(2021, 03, 03), "099427", "JP_USER", "1234567");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo CPF está inválido");
        }

        [TestMethod]
        public void DeveValidar_Senha()
        {
            //arrange
            Funcionario funcionario = new Funcionario("José Pedro", Convert.ToDecimal(2000.0), new DateTime(2021, 03, 03), "09942799909", "JP_USER", "1234");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo senha possui menos de sete dígitos");
        }


        [TestMethod]
        public void DeveValidar_Nome()
        {
            //arrange
            Funcionario funcionario = new Funcionario("", Convert.ToDecimal(2000.0), new DateTime(2021, 03, 03), "09942799909", "JP_USER", "1234567");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("Digite o nome do funcionário");
        }

        [TestMethod]
        public void DeveValidar_Data()
        {
            //arrange
            Funcionario funcionario = new Funcionario("Luisa", Convert.ToDecimal(2000.0), DateTime.MinValue, "09942799909", "JP_USER", "1234567");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Data é obrigatório");
        }

        [TestMethod]
        public void DeveValidar_Salario()
        {
            //arrange
            Funcionario funcionario = new Funcionario("Luisa", Convert.ToDecimal(-2000.0), new DateTime(2021, 03, 03), "09942799909", "JP_USER", "1234567");

            //action
            var resultadoValidacao = funcionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Salário é obrigatório e maior que 0");
        }
    }
}
