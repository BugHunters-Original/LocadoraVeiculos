using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.IntegrationTests.ParceiroModule
{
    [TestClass]
    public class ParceiroIntegrationTest
    {
        ParceiroDAO repository = null;
        static LocacaoContext context = null;
        public ParceiroIntegrationTest()
        {
            context = new();
            repository = new(context);
            LimparBancos();
        }

        private static void LimparBancos()
        {
            var desc = context.Descontos;
            context.Descontos.RemoveRange(desc);

            var list = context.Parceiros;
            context.Parceiros.RemoveRange(list);

        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            //arrange
            var novoParceiro = new Parceiro("Andrey");

            //action
            repository.Inserir(novoParceiro);

            //assert
            var parceiroEncontrado = repository.GetById(novoParceiro.Id);
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
            repository.Editar(novoParceiroEditado);

            //assert
            Parceiro parceiroAtualizado = repository.GetById(novoParceiro.Id);
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
            repository.Excluir(novoParceiro);

            //assert
            Parceiro parceiroEncontrado = repository.GetById(novoParceiro.Id);
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
            Parceiro parceiroEncontrado = repository.GetById(novoParceiro.Id);

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
            var parceiros = repository.GetAll();

            //assert
            parceiros.Should().HaveCount(3);
            parceiros[0].Nome.Should().Be("Gabriel");
            parceiros[1].Nome.Should().Be("Arthur");
            parceiros[2].Nome.Should().Be("Andrey");
            LimparBancos();
        }
    }
}
