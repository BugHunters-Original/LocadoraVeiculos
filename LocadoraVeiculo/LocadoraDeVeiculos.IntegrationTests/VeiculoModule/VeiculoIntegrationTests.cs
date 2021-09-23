using FluentAssertions;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraDeVeiculos.IntegrationTests.VeiculoModule
{
    [TestClass]
    public class VeiculoIntegrationTests
    {
        GrupoVeiculoDAO grupoVeiculoDAO;
        VeiculoDAO veiculoDAO;
        GrupoVeiculo grupo;


        byte[] imagem;

        public VeiculoIntegrationTests()
        {
            grupoVeiculoDAO = new GrupoVeiculoDAO();
            veiculoDAO = new VeiculoDAO();
            Db.Update("DELETE FROM [TBTIPOVEICULO]");
            Db.Update("DELETE FROM [TBVEICULOS]");

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
            var veiculoEncontrado = veiculoDAO.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(veiculo);
            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(veiculo);

            var VeiculoEditado = new Veiculo("uneiras", "7654321", "12345678901234567", imagem, "preto", "audi", 2012, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);

            //action
            veiculoDAO.Editar(veiculo.Id, VeiculoEditado);

            //assert
            var veiculoAtualizado = veiculoDAO.SelecionarPorId(veiculo.Id);
            veiculoAtualizado.Should().Be(VeiculoEditado);
            LimparBanco();
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            //arrange            
            var veiculo = new Veiculo("marea", "1234567", "12345678901234567", imagem, "azul", "fiat", 2000, 2, 80, 1, 'G', 1000, "gasolina", 1, grupo);
            veiculoDAO.Inserir(veiculo);

            //action            
            veiculoDAO.Excluir(veiculo.Id);

            //assert
            var veiculoEncontrado = veiculoDAO.SelecionarPorId(veiculo.Id);
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
            var veiculoEncontrado = veiculoDAO.SelecionarPorId(veiculo.Id);

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
            var veiculos = veiculoDAO.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Nome.Should().Be("marea");
            veiculos[1].Nome.Should().Be("uno");
            veiculos[2].Nome.Should().Be("corsa");
            LimparBanco();
        }

        public void LimparBanco()
        {
            Db.Update("DELETE FROM [TBVEICULOS]");
            Db.Update("DELETE FROM [TBTIPOVEICULO]");
        }
    }
}

