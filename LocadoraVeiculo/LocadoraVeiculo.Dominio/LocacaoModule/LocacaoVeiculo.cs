using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.Shared;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.LocacaoModule
{
    public class LocacaoVeiculo : EntidadeBase, IEquatable<LocacaoVeiculo>
    {
        public LocacaoVeiculo(Cliente cliente, Veiculo veiculo, Desconto desconto, ClienteCPF condutor, DateTime dataSaida,
               DateTime dataRetorno, string tipoLocacao, int tipoCliente, decimal? precoServicos, int dias,
               string statusLocacao, decimal? precoCombustivel, decimal? precoPlano, decimal? precoTotal, List<Servico> servicos)
        {
            Cliente = cliente;
            Veiculo = veiculo;
            Desconto = desconto;
            Condutor = condutor;
            DataSaida = dataSaida;
            DataRetorno = dataRetorno;
            TipoLocacao = tipoLocacao;
            TipoCliente = tipoCliente;
            PrecoServicos = precoServicos;
            Dias = dias;
            StatusLocacao = statusLocacao;
            PrecoCombustivel = precoCombustivel;
            PrecoPlano = precoPlano;
            PrecoTotal = precoTotal;
            Servicos = servicos;
        }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public Desconto Desconto { get; set; }
        public ClienteCPF Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string TipoLocacao { get; set; }
        public string StatusLocacao { get; set; }
        public int TipoCliente { get; set; }
        public int Dias { get; set; }
        public decimal? PrecoServicos { get; set; }
        public decimal? PrecoCombustivel { get; set; }
        public decimal? PrecoPlano { get; set; }
        public decimal? PrecoTotal { get; set; }
        public List<Servico> Servicos { get; set; }

        public bool Equals(LocacaoVeiculo other)
        {
            return other != null
                && Id == other.Id
                && Cliente.Equals(other.Cliente)
                && Veiculo.Equals(other.Veiculo)
                && Condutor.Equals(other.Condutor)
                && DataSaida == other.DataSaida
                && DataRetorno == other.DataRetorno
                && TipoLocacao == other.TipoLocacao
                && TipoCliente == other.TipoCliente
                && PrecoServicos == other.PrecoServicos;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as LocacaoVeiculo);
        }

        public override string ToString()
        {
            return "Cliente:" + Cliente + " Carro:" + Veiculo;
        }
        public override int GetHashCode()
        {
            int hashCode = 381890681;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Cliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Veiculo>.Default.GetHashCode(Veiculo);
            hashCode = hashCode * -1521134295 + EqualityComparer<ClienteCPF>.Default.GetHashCode(Condutor);
            hashCode = hashCode * -1521134295 + DataSaida.GetHashCode();
            hashCode = hashCode * -1521134295 + DataRetorno.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipoLocacao);
            hashCode = hashCode * -1521134295 + TipoCliente.GetHashCode();
            hashCode = hashCode * -1521134295 + PrecoServicos.GetHashCode();
            return hashCode;
        }

        public override string Validar()
        {
            string valido = "";

            if (Cliente == null)
                valido += "O campo Cliente está inválido";

            if (Veiculo == null)
                valido += QuebraDeLinha(valido) + "O campo Veículo está inválido";

            if (Condutor == null)
                valido += QuebraDeLinha(valido) + "O campo Condutor está inválido";

            if (DataSaida > DataRetorno)
                valido += QuebraDeLinha(valido) + "O campo Data está inválido";

            if (TipoLocacao != "Plano Diário" && TipoLocacao != "KM Controlado" && TipoLocacao != "KM Livre")
                valido += QuebraDeLinha(valido) + "O campo Tipo Locação está inválido";

            if (TipoCliente != 0 && TipoCliente != 1)
                valido += QuebraDeLinha(valido) + "O campo Tipo Cliente está inválido";

            if (Condutor == null || Condutor.DataValidade <= DataRetorno)
                valido += QuebraDeLinha(valido) + "O condutor necessita de uma CNH válida";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

    }
}
