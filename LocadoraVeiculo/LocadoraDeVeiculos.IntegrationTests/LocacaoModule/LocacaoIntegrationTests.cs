using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Serilog;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

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
        static LocacaoContext context = null;

        Veiculo veiculo;
        GrupoVeiculo grupo;
        ClienteCNPJ cliente;
        ClienteCPF condutor;
        Veiculo veiculo1;

        ClienteCNPJ cliente1;
        ClienteCPF condutor1;
        Veiculo veiculo2;

        ClienteCNPJ cliente2;
        ClienteCPF condutor2;

        Servico servico;
        Servico servico1;
        Servico servico2;

        byte[] imagem;
        decimal? precoServicos = null;
        DateTime dataSaida, dataRetorno;
        int dias;

        public LocacaoIntegrationTests()
        {
            context = new();
            controladorVeiculo = new VeiculoDAO(context);
            controladorCliente = new ClienteCNPJDAO(context);
            controladorCondutor = new ClienteCPFDAO(context);
            controladorGrupo = new GrupoVeiculoDAO(context);
            controladorServico = new ServicoDAO(context);
            controladorLocacao = new LocacaoDAO(context);

            Infra.LogManager.Log.Logger = new Serilog.LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

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

            //2

            cliente1 = new ClienteCNPJ("Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas2201@gmail.com");
            controladorCliente.Inserir(cliente1);

            condutor1 = new ClienteCPF("Arthur", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "g220601@gmail.com", cliente1);
            controladorCondutor.Inserir(condutor1);


            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };

            veiculo1 = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupo);
            controladorVeiculo.Inserir(veiculo1);


            servico1 = new Servico("Seguro", 2500, 0);
            controladorServico.Inserir(servico1);

            //3

            cliente2 = new ClienteCNPJ("Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61", "gabas2201@gmail.com");
            controladorCliente.Inserir(cliente2);

            condutor2 = new ClienteCPF("Arthur", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), "g220601@gmail.com", cliente2);
            controladorCondutor.Inserir(condutor2);


            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };


            veiculo2 = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupo);
            controladorVeiculo.Inserir(veiculo2);


            servico2 = new Servico("Seguro", 2500, 0);
            controladorServico.Inserir(servico2);

        }

        private static void LimparBanco()
        {
            context.TaxasDaLocacao.Clear();

            context.Locacoes.Clear();

            context.Veiculos.Clear();

            context.GruposVeiculo.Clear();

            context.Funcionarios.Clear();

            context.ClientesCPF.Clear();

            context.ClientesCNPJ.Clear();

            context.Servicos.Clear();

            context.SaveChanges();

        }
        [TestMethod]
        public void DeveInserir_Locacao()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            //action
            controladorLocacao.Inserir(novaLocacao);

            //assert
            var locacaoEncontrada = controladorLocacao.GetById(novaLocacao.Id);

            locacaoEncontrada.Cliente.Id.Should().Be(novaLocacao.Cliente.Id);
            locacaoEncontrada.Veiculo.Id.Should().Be(novaLocacao.Veiculo.Id);
            locacaoEncontrada.Condutor.Id.Should().Be(novaLocacao.Condutor.Id);
            locacaoEncontrada.PrecoServicos.Should().Be(novaLocacao.PrecoServicos);
            locacaoEncontrada.DataRetorno.Should().Be(novaLocacao.DataRetorno);


            LimparBanco();

        }

        [TestMethod]
        public void DeveAtualizar_Locacao()
        {
            //arrange                                  

            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                     "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            novaLocacao.PrecoTotal = 4;

            //action
            controladorLocacao.Editar(novaLocacao);

            //assert        
            var locacaoAtualizada = controladorLocacao.GetById(novaLocacao.Id);

            locacaoAtualizada.PrecoTotal.Should().Be(4);

            LimparBanco();
        }

        [TestMethod]
        public void DeveExcluir_Locacao()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                     "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            controladorLocacao.Excluir(novaLocacao);

            //assert        
            Locacao locacaoAtualizada = controladorLocacao.GetById(novaLocacao.Id);
            locacaoAtualizada.Should().BeNull();

            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                         "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            var locacaoEncontrada = controladorLocacao.GetById(novaLocacao.Id);

            //assert
            locacaoEncontrada.Should().NotBeNull();

            LimparBanco();
        }

        [TestMethod]
        public void DeveSelecionar_Todas()
        {
            //arrange           
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            var novaLocacao2 = new Locacao(cliente1, veiculo1, null, condutor1, dataSaida, dataRetorno,
                                    "KM Controlado", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPLivre * dias, 1, null);

            var novaLocacao3 = new Locacao(cliente2, veiculo2, null, condutor2, dataSaida, dataRetorno,
                                    "KM Livre", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPLivre * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);
            controladorLocacao.Inserir(novaLocacao2);
            controladorLocacao.Inserir(novaLocacao3);

            //action
            var locacoes = controladorLocacao.GetAll();

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
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            //action
            controladorLocacao.ConcluirLocacao(novaLocacao);
            var locacaoEncontrada = controladorLocacao.GetById(novaLocacao.Id);

            //assert
            locacaoEncontrada.StatusLocacao.Should().Be("Concluída");

            LimparBanco();
        }

        [TestMethod]
        public void SelecionarLocacoesConcluidas()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            controladorLocacao.ConcluirLocacao(novaLocacao);
            //action

            var locacoesConcluidas = controladorLocacao.SelecionarTodasLocacoesConcluidas();

            //assert
            locacoesConcluidas.Should().HaveCount(1);
            locacoesConcluidas[0].StatusLocacao.Should().Be("Concluída");

            LimparBanco();
        }

        [TestMethod]
        public void SelecionarLocacoesPendentes()
        {
            //arrange
            var novaLocacao = new Locacao(cliente, veiculo, null, condutor, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacao);

            controladorLocacao.ConcluirLocacao(novaLocacao);

            var novaLocacaoNaoConcluida = new Locacao(cliente1, veiculo1, null, condutor1, dataSaida, dataRetorno,
                                    "Plano Diário", 1, precoServicos, dias, "Em Aberto", 1, grupo.ValorDiarioPDiario * dias, 1, null);

            controladorLocacao.Inserir(novaLocacaoNaoConcluida);


            //action

            var locacoesNaoConcluida = controladorLocacao.SelecionarTodasLocacoesPendentes();

            //assert
            locacoesNaoConcluida.Should().HaveCount(1);

            locacoesNaoConcluida[0].StatusLocacao.Should().Be("Em Aberto");

            LimparBanco();
        }
    }
}