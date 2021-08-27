using FluentAssertions;
using LocadoraVeiculo.Controladores.DescontoModule;
using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Tests.DescontoModule
{
    [TestClass]
    public class ControladorDescontoTest
    {
        ControladorDesconto controlador = null;
        ControladorParceiro controladorParceiro = null;
        ParceiroDesconto parceiro;

        public ControladorDescontoTest()
        {
            controlador = new ControladorDesconto();
            controladorParceiro = new ControladorParceiro();
            LimparBancos();

            parceiro = new ParceiroDesconto("Arthur");
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
            var desconto = new Desconto("dinheiro",50, "Porcentagem",new DateTime(2030, 10, 10),parceiro,"YouTube");

            //action
            controlador.InserirNovo(desconto);

            //assert
            var descontoEncontrado = controlador.SelecionarPorId(desconto.Id);
            descontoEncontrado.Should().Be(desconto);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Veiculo()
        {
            //arrange
            var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube");
            controlador.InserirNovo(desconto);
            var descontoEditado = new Desconto("xuxu", 100, "Porcentagem", new DateTime(2030, 11, 11), parceiro, "Radio");

            //action
            controlador.Editar(desconto.Id, descontoEditado);

            //assert
            var descontoAtualizado = controlador.SelecionarPorId(desconto.Id);
            descontoAtualizado.Should().Be(descontoEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Veiculo()
        {
            ////arrange            
            //var desconto = new Desconto("dinheiro", 50, "Porcentagem", new DateTime(2030, 10, 10), parceiro, "YouTube"); 
            //controlador.InserirNovo(desconto);

            ////action            
            //controlador.Excluir(veiculo.Id);

            ////assert
            //var veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            //veiculoEncontrado.Should().BeNull();
            //LimparBancos();
        }
    }
}
