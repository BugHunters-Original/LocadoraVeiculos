using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.SQL.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.SQL.LocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.ServicoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Core;
using System;

namespace LocadoraDeVeiculos.Test.LocacaoModule
{
    [TestClass]
    public class LocacaoIntegrationTests
    {
        LocacaoDAO controladorLocacao = null;
        VeiculoDAO controladorVeiculo = null;
        GrupoVeiculoDAO controladorGrupo = null;
        ClienteCNPJDAO controladorCliente = null;
        ClienteCPFDAO controladorCondutor = null;
        ServicoDAO controladorServico = null;

        Veiculo veiculo;
        GrupoVeiculo grupo;
        ClienteCNPJ cliente;
        ClienteCPF condutor;

        Servico servico;

        byte[] imagem;
        decimal? precoServicos = null;
        DateTime dataSaida, dataRetorno;
        int dias;

        public LocacaoIntegrationTests()
        {
            controladorVeiculo = new VeiculoDAO();
            controladorCliente = new ClienteCNPJDAO();
            controladorCondutor = new ClienteCPFDAO();
            controladorGrupo = new GrupoVeiculoDAO();
            controladorServico = new ServicoDAO();
            controladorLocacao = new LocacaoDAO();

            LimparBanco();

            dataSaida = new DateTime(2021, 08, 19);
            dataRetorno = new DateTime(2021, 08, 19);
            dias = Convert.ToInt32((dataSaida - dataRetorno).TotalDays);

            cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas220601@gmail.com");
            controladorCliente.Inserir(cliente);

            condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "gabas220601@gmail.com", cliente);
            controladorCondutor.Inserir(condutor);


            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            grupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            controladorGrupo.Inserir(grupo);

            veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupo);
            controladorVeiculo.Inserir(veiculo);


            servico = new Servico("Seguro", 2500, 0);
            controladorServico.Inserir(servico);
            precoServicos = servico.Preco;

        }

        private static void LimparBanco()
        {
            Db.Update("DELETE FROM [TBTAXASDALOCACAO]");
            Db.Update("DELETE FROM [TBLOCACAO]");
            Db.Update("DELETE FROM [TBVEICULOS]");
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
            Db.Update("DELETE FROM [TBTIPOVEICULO]");
            Db.Update("DELETE FROM [TBCLIENTECNPJ]");
            Db.Update("DELETE FROM [TBCLIENTECPF]");
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
        }

        [TestMethod]
        public void DeveInserir_Locacao()
        {

            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            //action
            controladorLocacao.Inserir(novaLocacao);

            //assert
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(novaLocacao.Id);
            locacaoEncontrada.Should().Be(novaLocacao);

            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Locacao()
        {
            //arrange                                  

            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);

            var novaLocacaoEditada = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "KM Controlado", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPControlado * dias, null, null);

            //action
            controladorLocacao.Editar(novaLocacao.Id, novaLocacaoEditada);

            //assert        
            var locacaoAtualizada = controladorLocacao.SelecionarPorId(novaLocacao.Id);
            locacaoAtualizada.Should().Be(novaLocacaoEditada);


            LimparBanco();
        }

        [TestMethod]
        public void DeveExcluir_Locacao()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            controladorLocacao.Excluir(novaLocacao.Id);

            //assert        
            Locacao locacaoAtualizada = controladorLocacao.SelecionarPorId(novaLocacao.Id);
            locacaoAtualizada.Should().BeNull();


            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(novaLocacao.Id);

            //assert
            locacaoEncontrada.Should().NotBeNull();
            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Todas()
        {
            //arrange           
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);

            var novaLocacao2 = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "KM Controlado", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPLivre * dias, null, null);

            controladorLocacao.Inserir(novaLocacao2);

            var novaLocacao3 = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "KM Livre", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPLivre * dias, null, null);

            controladorLocacao.Inserir(novaLocacao3);

            //action
            var locacoes = controladorLocacao.SelecionarTodos();

            //assert
            locacoes.Should().HaveCount(3);
            locacoes[0].TipoLocacao.Should().Be("Plano Diário");
            locacoes[1].TipoLocacao.Should().Be("KM Controlado");
            locacoes[2].TipoLocacao.Should().Be("KM Livre");
            LimparBanco();
        }

        [TestMethod]
        public void DeveDevolver_Locacao()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            controladorLocacao.ConcluirLocacao(novaLocacao.Id, novaLocacao);
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(novaLocacao.Id);

            //assert
            locacaoEncontrada.StatusLocacao.Should().Be("Concluída");
            LimparBanco();
        }

        [TestMethod]
        public void SelecionarLocacoesConcluidas()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);
            controladorLocacao.ConcluirLocacao(novaLocacao.Id, novaLocacao);

            var novaLocacaoNaoConcluida = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacaoNaoConcluida);


            //action

            var locacoesConcluidas = controladorLocacao.SelecionarTodasLocacoesConcluidas();

            //assert
            locacoesConcluidas.Should().HaveCount(1);
            locacoesConcluidas[0].Should().Be(novaLocacao);
            LimparBanco();
        }

        [TestMethod]
        public void SelecionarLocacoesPendentes()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacao);
            controladorLocacao.ConcluirLocacao(novaLocacao.Id, novaLocacao);

            var novaLocacaoNaoConcluida = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null, null);

            controladorLocacao.Inserir(novaLocacaoNaoConcluida);


            //action

            var locacoesNaoConcluida = controladorLocacao.SelecionarTodasLocacoesPendentes();

            //assert
            locacoesNaoConcluida.Should().HaveCount(1);
            locacoesNaoConcluida[0].Should().Be(novaLocacaoNaoConcluida);
            LimparBanco();
        }
    }
}