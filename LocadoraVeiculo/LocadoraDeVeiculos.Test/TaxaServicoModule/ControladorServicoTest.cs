using FluentAssertions;
using LocadoraDeVeiculos.Controladores.ServicoModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Tests.TaxaServicoModule
{
    [TestClass]
    public class ControladorServicoTest
    {
        ControladorServico controlador = null;

        public ControladorServicoTest()
        {
            controlador = new ControladorServico();
            LimparBanco();
        }

        private static void LimparBanco()
        {
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
        }

        [TestMethod]
        public void DeveInserir_Servico()
        {
            //arrange
            var novoServico = new Servico("GPS", 12, 1);

            //action
            controlador.InserirNovo(novoServico);

            //assert
            var clienteEncontrado = controlador.SelecionarPorId(novoServico.Id);
            clienteEncontrado.Should().Be(novoServico);
            LimparBanco();
        }
        [TestMethod]
        public void DeveAtualizar_Servico()
        {
            //arrange
            var servico = new Servico("GPS", 12, 1);
            controlador.InserirNovo(servico);

            var novoServico = new Servico("CADEIRINHA", 20, 1);

            //action
            controlador.Editar(servico.Id, novoServico);

            //assert
            Servico servicoAtualizado = controlador.SelecionarPorId(servico.Id);
            servicoAtualizado.Should().Be(novoServico);
            LimparBanco();
        }
        [TestMethod]
        public void DeveExcluir_Servico()
        {
            //arrange            
            var servico = new Servico("GPS", 12, 1);
            controlador.InserirNovo(servico);

            //action            
            controlador.Excluir(servico.Id);

            //assert
            Servico servicoEncontrado = controlador.SelecionarPorId(servico.Id);
            servicoEncontrado.Should().BeNull();
            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_Servico_PorId()
        {
            //arrange
            var servico = new Servico("GPS", 12, 1);
            controlador.InserirNovo(servico);

            //action
            Servico servicoEncontrado = controlador.SelecionarPorId(servico.Id);

            //assert
            servicoEncontrado.Should().NotBeNull();
            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_TodosServicos()
        {
            //arrange
            var s1 = new Servico("GPS", 12, 1);
            controlador.InserirNovo(s1);

            var s2 = new Servico("CADEIRINHA", 24, 1);
            controlador.InserirNovo(s2);

            var s3 = new Servico("SEGURO", 50, 1);
            controlador.InserirNovo(s3);

            //action
            var servicos = controlador.SelecionarTodos();

            //assert
            servicos.Should().HaveCount(3);
            servicos[0].Nome.Should().Be("GPS");
            servicos[1].Nome.Should().Be("CADEIRINHA");
            servicos[2].Nome.Should().Be("SEGURO");
            LimparBanco();
        }
    }
}
