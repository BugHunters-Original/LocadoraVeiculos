using FluentAssertions;
using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculo.Tests.ParceiroModule
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
            Db.Update("DELETE FROM [TBPARCEIROS]");
            
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            //arrange
            var novoParceiro = new ParceiroDesconto("Andrey");

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
            var novoParceiro = new ParceiroDesconto("Luisa F");

            controlador.InserirNovo(novoParceiro);

            var novoParceiroEditado = new ParceiroDesconto("Luisa S");

            //action
            controlador.Editar(novoParceiro.Id, novoParceiroEditado);

            //assert
            ParceiroDesconto parceiroAtualizado = controlador.SelecionarPorId(novoParceiro.Id);
            parceiroAtualizado.Should().Be(novoParceiroEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Parceiro()
        {         
            //arrange
            var novoParceiro = new ParceiroDesconto("Luisa F");
            controlador.InserirNovo(novoParceiro);

            //action            
            controlador.Excluir(novoParceiro.Id);

            //assert
            ParceiroDesconto parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.Id);
            parceiroEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_PorId()
        {
            //arrange
            var novoParceiro = new ParceiroDesconto("Gabriel");
            controlador.InserirNovo(novoParceiro);

            //action
            ParceiroDesconto parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.Id);

            //assert
            parceiroEncontrado.Should().NotBeNull();
            LimparBancos();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var parceiro1 = new ParceiroDesconto("Gabriel");
            controlador.InserirNovo(parceiro1);

            var parceiro2 = new ParceiroDesconto("Arthur");
            controlador.InserirNovo(parceiro2);

            var parceiro3 = new ParceiroDesconto("Andrey");
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
