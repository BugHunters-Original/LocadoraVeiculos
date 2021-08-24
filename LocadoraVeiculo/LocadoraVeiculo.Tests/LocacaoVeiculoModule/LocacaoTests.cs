using FluentAssertions;
using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculo.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoTests
    {
        ClienteCPF condutor;
        ClienteCNPJ cliente;
        byte[] imagem;

        GrupoVeiculo grupo;
        Veiculo veiculo;
        Servico servico;
        decimal? precoServicos;
        DateTime dataSaida, dataRetorno;
        int dias = 0;

        public LocacaoTests()
        {
            cliente = new ClienteCNPJ("Gabriel Marques", "Guarujá", "(49)99803-5074", "77.637.684/0111-61");

            condutor = new ClienteCPF("Pedro", "(49)12345-6789", "Coral", "011.900.119-57",
                                        "6.187.754", "12345678910", new DateTime(2022, 06, 22), cliente);
            dataSaida = new DateTime(2021, 08, 19);
            dataRetorno = new DateTime(2021, 08, 19);
            dias = Convert.ToInt32((dataSaida - dataRetorno).TotalDays);

            imagem = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            grupo = new GrupoVeiculo("Econômico", 10, 10, 10, 10, 10, 10);
            veiculo = new Veiculo("Carro", "AAA8888", "12345678912345678", imagem, "vermelho", "Ford", 2009, 9, 200, 1, 'M', 90, "Álcool", 1, grupo);


            servico = new Servico("Seguro", 2500, 0);

            precoServicos = servico.Preco;

        }
        [TestMethod]
        public void DeveValidar_Locacao()
        {
            //arrange

            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano Diário", 0, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Data()
        {
            //arrange
            var dataSaidaInvalida = new DateTime(2021, 08, 19);
            var dataRetornoInvalida = new DateTime(2021, 08, 30);

            var diasInvalidos = Convert.ToInt32((dataSaida - dataRetorno).TotalDays);

            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaidaInvalida, dataRetornoInvalida,
                                  "Plano Diário", 0, precoServicos, diasInvalidos, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Plano()
        {
            //arrange

            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                  "Plano", 0, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo Locação está inválido");
        }

        [TestMethod]
        public void DeveValidar_Cliente()
        {
            //arrange
            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(null, veiculo, condutor, dataSaida, dataRetorno,
                                   "Plano Diário", 0, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Cliente está inválido");
        }

        [TestMethod]
        public void DeveValidar_TipoCliente()
        {
            //arrange
            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(cliente, veiculo, condutor, dataSaida, dataRetorno,
                                   "Plano Diário", 2, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Tipo Cliente está inválido");
        }

        [TestMethod]
        public void DeveValidar_Condutor()
        {
            //arrange
            LocacaoVeiculo novaLocacao = new LocacaoVeiculo(cliente, veiculo, null, dataSaida, dataRetorno,
                                    "Plano Diário", 0, precoServicos, dias, "Em Aberto", null, grupo.ValorDiarioPDiario * dias, null);


            //action
            var resultadoValidacao = novaLocacao.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Condutor está inválido");
        }


    }
}
