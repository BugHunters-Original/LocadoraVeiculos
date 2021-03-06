using FluentAssertions;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Test.DescontoModule
{
    [TestClass]
    public class ControladorDescontoTest
    {
        ControladorDesconto controlador = null;
        ControladorParceiro controladorParceiro = null;
        Parceiro parceiro;

        public ControladorDescontoTest()
        {
            controlador = new ControladorDesconto();
            controladorParceiro = new ControladorParceiro();
            LimparBancos();

            parceiro = new Parceiro("Arthur");
            controladorParceiro.InserirNovo(parceiro);
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
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);

            //action
            controlador.InserirNovo(desconto);

            //assert
            var descontoEncontrado = controlador.SelecionarPorId(desconto.Id);
            descontoEncontrado.Should().Be(desconto);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Desconto()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(desconto);
            var descontoEditado = new Desconto("xuxu", 100, "Porcentagem", new DateTime(2030, 11, 11), parceiro, "Radio", "dimdim", 50);

            //action
            controlador.Editar(desconto.Id, descontoEditado);

            //assert
            var descontoAtualizado = controlador.SelecionarPorId(desconto.Id);
            descontoAtualizado.Should().Be(descontoEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Desconto()
        {
            //arrange            
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(desconto);

            //action            
            controlador.Excluir(desconto.Id);

            //assert
            var descontoEncontrado = controlador.SelecionarPorId(desconto.Id);
            descontoEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(desconto);

            //action
            var descontoEncontrado = controlador.SelecionarPorId(desconto.Id);

            //assert
            descontoEncontrado.Should().NotBeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var d1 = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(d1);

            var d2 = new Desconto("xuxu", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(d2);

            var d3 = new Desconto("leilao", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50);
            controlador.InserirNovo(d3);

            //action
            var veiculos = controlador.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Codigo.Should().Be("dinheiro");
            veiculos[1].Codigo.Should().Be("xuxu");
            veiculos[2].Codigo.Should().Be("leilao");
            LimparBancos();
        }
    }
}
