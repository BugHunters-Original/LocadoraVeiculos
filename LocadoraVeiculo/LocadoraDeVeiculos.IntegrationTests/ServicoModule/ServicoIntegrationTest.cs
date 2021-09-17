using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.ServicoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.IntegrationTests.ServicoModule
{
    [TestClass]
    public class ServicoIntegrationTest
    {
        ServicoDAO repository = null;

        public ServicoIntegrationTest()
        {
            repository = new ServicoDAO();
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
            repository.Inserir(novoServico);

            //assert
            var clienteEncontrado = repository.SelecionarPorId(novoServico.Id);
            clienteEncontrado.Should().Be(novoServico);
            LimparBanco();
        }
        [TestMethod]
        public void DeveAtualizar_Servico()
        {
            //arrange
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);

            var novoServico = new Servico("CADEIRINHA", 20, 1);

            //action
            repository.Editar(servico.Id, novoServico);

            //assert
            Servico servicoAtualizado = repository.SelecionarPorId(servico.Id);
            servicoAtualizado.Should().Be(novoServico);
            LimparBanco();
        }
        [TestMethod]
        public void DeveExcluir_Servico()
        {
            //arrange            
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);

            //action            
            repository.Excluir(servico.Id);

            //assert
            Servico servicoEncontrado = repository.SelecionarPorId(servico.Id);
            servicoEncontrado.Should().BeNull();
            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_Servico_PorId()
        {
            //arrange
            var servico = new Servico("GPS", 12, 1);
            repository.Inserir(servico);

            //action
            Servico servicoEncontrado = repository.SelecionarPorId(servico.Id);

            //assert
            servicoEncontrado.Should().NotBeNull();
            LimparBanco();
        }
        [TestMethod]
        public void DeveSelecionar_TodosServicos()
        {
            //arrange
            var s1 = new Servico("GPS", 12, 1);
            repository.Inserir(s1);

            var s2 = new Servico("CADEIRINHA", 24, 1);
            repository.Inserir(s2);

            var s3 = new Servico("SEGURO", 50, 1);
            repository.Inserir(s3);

            //action
            var servicos = repository.SelecionarTodos();

            //assert
            servicos.Should().HaveCount(3);
            servicos[0].Nome.Should().Be("GPS");
            servicos[1].Nome.Should().Be("CADEIRINHA");
            servicos[2].Nome.Should().Be("SEGURO");
            LimparBanco();
        }
    }
}
