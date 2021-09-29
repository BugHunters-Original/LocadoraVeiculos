using FluentAssertions;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.DescontoModule;
using LocadoraDeVeiculos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;
using System;

namespace LocadoraDeVeiculos.Test.DescontoModule
{
    [TestClass]
    public class ControladorDescontoTest
    {
        DescontoDAO descontoDAO = null;
        ParceiroDAO parceiroDAO = null;

        Logger logger;

        Parceiro parceiro;

        public ControladorDescontoTest()
        {
            descontoDAO = new DescontoDAO();
            parceiroDAO = new ParceiroDAO();
            LimparBancos();

            parceiro = new Parceiro("Arthur");
            parceiroDAO.Inserir(parceiro);
        }

        private static void LimparBancos()
        {
            Db.Update("DELETE FROM [TBDESCONTO]");
            Db.Update("DELETE FROM [TBPARCEIROS]");
        }

        [TestMethod]
        public void DeveInserir_Desconto()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            descontoDAO.Inserir(desconto);

            //assert
            var descontoEncontrado = descontoDAO.SelecionarPorId(desconto.Id);
            descontoEncontrado.Should().Be(desconto);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Desconto()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(desconto);
            var descontoEditado = new Desconto("xuxu", 100, "Porcentagem", new DateTime(2030, 11, 11), parceiro, "Radio", "dimdim", 50, 2);

            //action
            descontoDAO.Editar(desconto.Id, descontoEditado);

            //assert
            var descontoAtualizado = descontoDAO.SelecionarPorId(desconto.Id);
            descontoAtualizado.Should().Be(descontoEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Desconto()
        {
            //arrange            
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(desconto);

            //action            
            descontoDAO.Excluir(desconto.Id);

            //assert
            var descontoEncontrado = descontoDAO.SelecionarPorId(desconto.Id);
            descontoEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(desconto);

            //action
            var descontoEncontrado = descontoDAO.SelecionarPorId(desconto.Id);

            //assert
            descontoEncontrado.Should().NotBeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var d1 = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(d1);

            var d2 = new Desconto("xuxu", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(d2);

            var d3 = new Desconto("leilao", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);
            descontoDAO.Inserir(d3);

            //action
            var veiculos = descontoDAO.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Codigo.Should().Be("dinheiro");
            veiculos[1].Codigo.Should().Be("xuxu");
            veiculos[2].Codigo.Should().Be("leilao");
            LimparBancos();
        }
    }
}
