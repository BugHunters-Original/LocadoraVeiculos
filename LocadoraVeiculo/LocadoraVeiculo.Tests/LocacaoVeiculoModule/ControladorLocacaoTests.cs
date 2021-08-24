using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculo.Tests.LocacaoModule
{
    [TestClass]
    public class ControladorLocacaoTests
    {
        ControladorLocacao controladorLocacao = null;
        ControladorVeiculo controladorVeiculo = null;
        ControladorGrupoVeiculo controladorGrupo = null;
        ControladorClienteCNPJ controladorCliente = null;
        ControladorClienteCPF controladorCondutor = null;
        ControladorServico controladorServico = null;

        Veiculo veiculo;
        GrupoVeiculo grupo;
        ClienteCNPJ cliente;
        ClienteCPF condutor;

        Servico servico;

        byte[] imagem;
        decimal? precoServicos = null;
        DateTime dataSaida, dataRetorno;
        int dias;

        public ControladorLocacaoTests()
        {

            controladorVeiculo = new ControladorVeiculo();
            controladorCliente = new ControladorClienteCNPJ();
            controladorCondutor = new ControladorClienteCPF();
            controladorGrupo = new ControladorGrupoVeiculo();
            controladorServico = new ControladorServico();
            controladorLocacao = new ControladorLocacao();

            LimparBanco();

            dataSaida = new DateTime(2021, 08, 19);
            dataRetorno = new DateTime(2021, 08, 19);
            dias = Convert.ToInt32((dataSaida - dataRetorno).TotalDays);

            cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61");
            controladorCliente.InserirNovo(cliente);

            condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), cliente);
            controladorCondutor.InserirNovo(condutor);


            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            grupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            controladorGrupo.InserirNovo(grupo);

            veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupo);
            controladorVeiculo.InserirNovo(veiculo);


            servico = new Servico("Seguro", 2500, 0);
            controladorServico.InserirNovo(servico);
            precoServicos = servico.Preco;

        }

        private static void LimparBanco()
        {
            Db.Update("DELETE FROM [TBLOCACAO]");
            Db.Update("DELETE FROM [TBTAXASDALOCACAO]");
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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            //action
            controladorLocacao.InserirNovo(novaLocacao);

            //assert
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(novaLocacao.Id);
            locacaoEncontrada.Should().Be(novaLocacao);

            LimparBanco();
        }

        [TestMethod]
        public void DeveAtualizar_Locacao()
        {
            //arrange                                  

            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);

            var novaLocacaoEditada = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "KM Controlado", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPControlado * dias, null);

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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);

            //action
            controladorLocacao.Excluir(novaLocacao.Id);

            //assert        
            LocacaoVeiculo locacaoAtualizada = controladorLocacao.SelecionarPorId(novaLocacao.Id);
            locacaoAtualizada.Should().BeNull();


            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            //arrange
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);

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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                 "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);

            var novaLocacao2 = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                 "KM Controlado", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPLivre * dias, null);

            controladorLocacao.InserirNovo(novaLocacao2);

            var novaLocacao3 = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                   "KM Livre", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPLivre * dias, null);

            controladorLocacao.InserirNovo(novaLocacao3);

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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);

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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);
            controladorLocacao.ConcluirLocacao(novaLocacao.Id, novaLocacao);

            var novaLocacaoNaoConcluida = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacaoNaoConcluida);


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
            var novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacao);
            controladorLocacao.ConcluirLocacao(novaLocacao.Id, novaLocacao);

            var novaLocacaoNaoConcluida = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 1, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);

            controladorLocacao.InserirNovo(novaLocacaoNaoConcluida);


            //action

            var locacoesNaoConcluida = controladorLocacao.SelecionarTodasLocacoesPendentes();

            //assert
            locacoesNaoConcluida.Should().HaveCount(1);
            locacoesNaoConcluida[0].Should().Be(novaLocacaoNaoConcluida);
            LimparBanco();
        }
    }
}
