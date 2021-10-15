using FluentAssertions;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;
using System;
using Serilog;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

namespace LocadoraDeVeiculos.Test.DescontoModule
{
    [TestClass]
    public class ControladorDescontoTest
    {
        DescontoDAO descontoDAO = null;
        ParceiroDAO parceiroDAO = null;
        static LocacaoContext context = null;

        Parceiro parceiro = new Parceiro("Arthur");

        public ControladorDescontoTest()
        {
            context = new();
            descontoDAO = new DescontoDAO(context);
            parceiroDAO = new ParceiroDAO(context);
            LimparBancos();

            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

            parceiroDAO.Inserir(parceiro);
        }

        private static void LimparBancos()
        {
            context.Descontos.Clear();

            context.Parceiros.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
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


            //action
            desconto.Codigo = "xuxu";
            descontoDAO.Editar(desconto);

            //assert
            var descontoAtualizado = descontoDAO.GetById(desconto.Id);
            descontoAtualizado.Codigo.Should().Be("xuxu");

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
