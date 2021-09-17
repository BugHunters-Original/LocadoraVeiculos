using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.IntegrationTests.ParceiroModule
{
    [TestClass]
    class ParceiroIntegrationTest
    {
        ParceiroDAO repository = null;

        public ParceiroIntegrationTest()
        {
            repository = new();
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
            repository.Inserir(novoParceiro);

            //assert
            var parceiroEncontrado = repository.SelecionarPorId(novoParceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);
            LimparBancos();
        }

        [TestMethod]
        public void DeveAtualizar_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Luisa F");

            repository.Inserir(novoParceiro);

            var novoParceiroEditado = new Parceiro("Luisa S");

            //action
            repository.Editar(novoParceiro.Id, novoParceiroEditado);

            //assert
            Parceiro parceiroAtualizado = repository.SelecionarPorId(novoParceiro.Id);
            parceiroAtualizado.Should().Be(novoParceiroEditado);
            LimparBancos();
        }

        [TestMethod]
        public void DeveExcluir_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Luisa F");
            repository.Inserir(novoParceiro);

            //action            
            repository.Excluir(novoParceiro.Id);

            //assert
            Parceiro parceiroEncontrado = repository.SelecionarPorId(novoParceiro.Id);
            parceiroEncontrado.Should().BeNull();
            LimparBancos();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_PorId()
        {
            //arrange
            var novoParceiro = new Parceiro("Gabriel");
            repository.Inserir(novoParceiro);

            //action
            Parceiro parceiroEncontrado = repository.SelecionarPorId(novoParceiro.Id);

            //assert
            parceiroEncontrado.Should().NotBeNull();
            LimparBancos();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            //arrange
            var parceiro1 = new Parceiro("Gabriel");
            repository.Inserir(parceiro1);

            var parceiro2 = new Parceiro("Arthur");
            repository.Inserir(parceiro2);

            var parceiro3 = new Parceiro("Andrey");
            repository.Inserir(parceiro3);

            //action
            var parceiros = repository.SelecionarTodos();

            //assert
            parceiros.Should().HaveCount(3);
            parceiros[0].Nome.Should().Be("Gabriel");
            parceiros[1].Nome.Should().Be("Arthur");
            parceiros[2].Nome.Should().Be("Andrey");
            LimparBancos();
        }
    }
}
