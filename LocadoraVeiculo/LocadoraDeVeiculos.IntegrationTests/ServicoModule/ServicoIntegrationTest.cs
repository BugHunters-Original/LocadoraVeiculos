using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace LocadoraDeVeiculos.IntegrationTests.ServicoModule
{
    [TestClass]
    public class ServicoIntegrationTest
    {
        ServicoDAO repository = null;
        static LocacaoContext context = null;

        public ServicoIntegrationTest()
        {
            context = new();
            repository = new ServicoDAO(context);
            LimparBanco();
            
            Infra.LogManager.Serilogger.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static void LimparBanco()
        {
            context.Servicos.Clear();

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        [TestMethod]
        public void DeveInserir_Servico()
        {
            LimparBanco();
            //arrange
            var novoServico = new Servico("GPS", 12, 1);

            //action
            repository.Inserir(novoServico);

            //assert
            var clienteEncontrado = repository.GetById(novoServico.Id);
            clienteEncontrado.Should().Be(novoServico);
        }
        [TestMethod]
        public void DeveAtualizar_Servico()
        {
            LimparBanco();
            //arrange
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);


            //action
            servico.Nome = "CADEIRINHA";

            repository.Editar(servico);

            //assert
            Servico servicoAtualizado = repository.GetById(servico.Id);
            servicoAtualizado.Nome.Should().Be("CADEIRINHA");
        }
        [TestMethod]
        public void DeveExcluir_Servico()
        {
            LimparBanco();
            //arrange            
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);

            //action            
            repository.Excluir(servico);

            //assert
            Servico servicoEncontrado = repository.GetById(servico.Id);
            servicoEncontrado.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionar_Servico_PorId()
        {
            LimparBanco();
            //arrange
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);

            //action
            Servico servicoEncontrado = repository.GetById(servico.Id);

            //assert
            servicoEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveSelecionar_TodosServicos()
        {
            LimparBanco();
            //arrange
            var s1 = new Servico("GPS", 12, 1);
            repository.Inserir(s1);

            var s2 = new Servico("CADEIRINHA", 24, 1);
            repository.Inserir(s2);

            var s3 = new Servico("SEGURO", 50, 1);
            repository.Inserir(s3);

            //action
            var servicos = repository.GetAll();

            //assert
            servicos.Should().HaveCount(3);
            servicos[0].Nome.Should().Be("GPS");
            servicos[1].Nome.Should().Be("CADEIRINHA");
            servicos[2].Nome.Should().Be("SEGURO");
        }
    }
}
