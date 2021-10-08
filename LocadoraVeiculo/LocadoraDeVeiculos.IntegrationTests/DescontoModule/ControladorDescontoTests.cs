using FluentAssertions;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
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
        static LocacaoContext context = null;

        Parceiro parceiro;

        public ControladorDescontoTest()
        {
            context = new();
            descontoDAO = new DescontoDAO(context);
            parceiroDAO = new ParceiroDAO(context);
            LimparBancos();

            parceiro = new Parceiro("Arthur");
            parceiroDAO.Inserir(parceiro);
        }

        private static void LimparBancos()
        {
            var Desc = context.Descontos;
            context.Descontos.RemoveRange(Desc);

            var Parc = context.Parceiros;
            context.Parceiros.RemoveRange(Parc);
        }

        [TestMethod]
        public void DeveInserir_Desconto()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube", "dimdim", 50, 1);

            //action
            descontoDAO.Inserir(desconto);

            //assert
            var descontoEncontrado = descontoDAO.GetById(desconto.Id);
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
            descontoDAO.Editar(descontoEditado);

            //assert
            var descontoAtualizado = descontoDAO.GetById(desconto.Id);
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
            descontoDAO.Excluir(desconto);

            //assert
            var descontoEncontrado = descontoDAO.GetById(desconto.Id);
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
            var descontoEncontrado = descontoDAO.GetById(desconto.Id);

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
            var veiculos = descontoDAO.GetAll();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Codigo.Should().Be("dinheiro");
            veiculos[1].Codigo.Should().Be("xuxu");
            veiculos[2].Codigo.Should().Be("leilao");
            LimparBancos();
        }
    }
}
