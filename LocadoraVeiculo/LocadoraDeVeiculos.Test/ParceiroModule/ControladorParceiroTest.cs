using FluentAssertions;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Test.ParceiroModule
{

    [TestClass]
    public class ControladorParceiroTest
    {
        ControladorParceiro controlador = null;

        public ControladorParceiroTest()
        {
            controlador = new ControladorParceiro();
            LimparBancos();
        }

        private static void LimparBancos()
        {
            Db.Update("DELETE FROM [TBDESCONTO]");
            Db.Update("DELETE FROM [TBPARCEIROS]");

        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Andrey");

            //action
            controlador.InserirNovo(novoParceiro);

            //assert
            var parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Luisa F");

            controlador.InserirNovo(novoParceiro);

            var novoParceiroEditado = new Parceiro("Luisa S");

            //action
            controlador.Editar(novoParceiro.Id, novoParceiroEditado);

            //assert
            Parceiro parceiroAtualizado = controlador.SelecionarPorId(novoParceiro.Id);
            parceiroAtualizado.Should().Be(novoParceiroEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Luisa F");
            controlador.InserirNovo(novoParceiro);

            //action            
            controlador.Excluir(novoParceiro.Id);

            //assert
            Parceiro parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.Id);
            parceiroEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_PorId()
        {
            //arrange
            var novoParceiro = new Parceiro("Gabriel");
            controlador.InserirNovo(novoParceiro);

            //action
            Parceiro parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.Id);

            //assert
            parceiroEncontrado.Should().NotBeNull();
            LimparBancos();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var parceiro1 = new Parceiro("Gabriel");
            controlador.InserirNovo(parceiro1);

            var parceiro2 = new Parceiro("Arthur");
            controlador.InserirNovo(parceiro2);

            var parceiro3 = new Parceiro("Andrey");
            controlador.InserirNovo(parceiro3);

            //action
            var parceiros = controlador.SelecionarTodos();

            //assert
            parceiros.Should().HaveCount(3);
            parceiros[0].Nome.Should().Be("Gabriel");
            parceiros[1].Nome.Should().Be("Arthur");
            parceiros[2].Nome.Should().Be("Andrey");
            LimparBancos();
        }
    }
}
