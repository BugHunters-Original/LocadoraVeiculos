using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

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
            
            Infra.LogManager.LogSerilog.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBancos()
        {
            context.Descontos.Clear();

            context.Parceiros.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            LimparBancos();
            //arrange
            var novoParceiro = new Parceiro("Andrey");

            //action
            repository.Inserir(novoParceiro);

            //assert
            var parceiroEncontrado = repository.GetById(novoParceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveAtualizar_Parceiro()
        {
            LimparBancos();
            //arrange
            var novoParceiro = new Parceiro("Luisa F");

            repository.Inserir(novoParceiro);

            //action
            novoParceiro.Nome = "Luisa S";
            repository.Editar(novoParceiro);

            //assert
            Parceiro parceiroAtualizado = repository.GetById(novoParceiro.Id);
            parceiroAtualizado.Nome.Should().Be("Luisa S");
        }

        [TestMethod]
        public void DeveExcluir_Parceiro()
        {
            LimparBancos();
            //arrange
            var novoParceiro = new Parceiro("Luisa F");
            repository.Inserir(novoParceiro);

            //action            
            repository.Excluir(novoParceiro);

            //assert
            Parceiro parceiroEncontrado = repository.GetById(novoParceiro.Id);
            parceiroEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_PorId()
        {
            LimparBancos();
            //arrange
            var novoParceiro = new Parceiro("Gabriel");
            repository.Inserir(novoParceiro);

            //action
            Parceiro parceiroEncontrado = repository.GetById(novoParceiro.Id);

            //assert
            parceiroEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Todos()
        {
            LimparBancos();
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
        }
    }
}
