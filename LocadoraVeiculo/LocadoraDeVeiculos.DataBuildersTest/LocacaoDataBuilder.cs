using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.DataBuildersTest
{
    public class LocacaoDataBuilder
    {
        private Locacao locacao;

        public LocacaoDataBuilder()
        {
            locacao = new Locacao();
        }
        public LocacaoDataBuilder ParaCliente(ClienteBase cliente)
        {
            locacao.Cliente = cliente;
            return this;
        }
        public LocacaoDataBuilder DoVeiculo(Veiculo veiculo)
        {
            locacao.Veiculo = veiculo;
            return this;
        }
        public LocacaoDataBuilder ComDesconto(Desconto desconto)
        {
            locacao.Desconto = desconto;
            return this;
        }
        public LocacaoDataBuilder ComCondutor(ClienteCPF condutor)
        {
            locacao.Condutor = condutor;
            return this;
        }
        public LocacaoDataBuilder NaDataDeSaida(DateTime dataSaida)
        {
            locacao.DataSaida = dataSaida;
            return this;
        }
        public LocacaoDataBuilder NaDataDeRetorno(DateTime dataRetorno)
        {
            locacao.DataRetorno = dataRetorno;
            return this;
        }
        public LocacaoDataBuilder ComOPlano(string plano)
        {
            locacao.TipoLocacao = plano;
            return this;
        }
        public LocacaoDataBuilder ComOTipoCliente(int tipo)
        {
            locacao.TipoCliente = tipo;
            return this;
        }
        public LocacaoDataBuilder ComOsServicos(List<Servico> servicos)
        {
            locacao.Servicos = servicos;
            return this;
        }
        public LocacaoDataBuilder NoStatus(string status)
        {
            locacao.StatusLocacao = status;
            return this;
        }
        public Locacao Build()
        {
            return locacao;
        }
    }
}
