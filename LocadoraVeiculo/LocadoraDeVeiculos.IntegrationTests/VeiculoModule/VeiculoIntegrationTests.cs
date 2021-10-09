using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;

namespace LocadoraDeVeiculos.IntegrationTests.VeiculoModule
{
    [TestClass]
    public class VeiculoIntegrationTests
    {
        GrupoVeiculoDAO grupoVeiculoDAO;
        VeiculoDAO veiculoDAO;
        GrupoVeiculo grupo;
        static LocacaoContext context = null;

        byte[] imagem;

        public VeiculoIntegrationTests()
        {
            context = new();
            grupoVeiculoDAO = new GrupoVeiculoDAO(context);
            veiculoDAO = new VeiculoDAO(context);

            LimparBanco();
            Log.IniciarLog();

            grupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            grupoVeiculoDAO.Inserir(grupo);
            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);

            //action
            veiculoDAO.Inserir(veiculo);

            //assert
            var veiculoEncontrado = veiculoDAO.GetById(veiculo.Id);
            veiculoEncontrado.Nome.Should().Be("marea");
            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(veiculo);

            veiculo.Marca = "audi";
            //action
            veiculoDAO.Editar(veiculo);

            //assert
            var veiculoAtualizado = veiculoDAO.GetById(veiculo.Id);
            veiculoAtualizado.Marca.Should().Be("audi");
            LimparBanco();
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange            
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(veiculo);

            //action            
            veiculoDAO.Excluir(veiculo);

            //assert
            var veiculoEncontrado = veiculoDAO.GetById(veiculo.Id);
            veiculoEncontrado.Should().BeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(veiculo);

            //action
            var veiculoEncontrado = veiculoDAO.GetById(veiculo.Id);

            //assert
            veiculoEncontrado.Should().NotBeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var v1 = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(v1);

            var v2 = new Veiculo("uno", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(v2);

            var v3 = new Veiculo("corsa", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(v3);

            //action
            var veiculos = veiculoDAO.GetAll();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Nome.Should().Be("marea");
            veiculos[1].Nome.Should().Be("uno");
            veiculos[2].Nome.Should().Be("corsa");
            LimparBanco();
        }

        public void LimparBanco()
        {
            var Veic = context.Veiculos;
            context.Veiculos.RemoveRange(Veic);

            var GrupoV = context.GruposVeiculo;
            context.GruposVeiculo.RemoveRange(GrupoV);
        }
    }
}

