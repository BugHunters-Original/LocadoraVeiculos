using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Shared;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.LocacaoModule
{
    public class LocacaoVeiculo : EntidadeBase, IEquatable<LocacaoVeiculo>
    {
        public LocacaoVeiculo(Cliente cliente, Veiculo veiculo, ClienteCPF condutor, DateTime dataSaida,
               DateTime dataRetorno, string tipoLocacao, int tipoCliente, decimal? precoServicos, decimal? kmRodado, int dias, string statusLocacao)
        {
            Cliente = cliente;
            Veiculo = veiculo;
            Condutor = condutor;
            DataSaida = dataSaida;
            DataRetorno = dataRetorno;
            TipoLocacao = tipoLocacao;
            TipoCliente = tipoCliente;
            PrecoServicos = precoServicos;
            Dias = dias;
            KmRodado = kmRodado;
            StatusLocacao = statusLocacao;
        }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public ClienteCPF Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string TipoLocacao { get; set; }
        public int TipoCliente { get; set; }
        public decimal? PrecoServicos { get; set; }
        public int Dias { get; private set; }
        public decimal? KmRodado { get; }
        public string StatusLocacao { get; private set; }

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
                && PrecoServicos == other.PrecoServicos
                && KmRodado == other.KmRodado;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as LocacaoVeiculo);
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
            hashCode = hashCode * -1521134295 + KmRodado.GetHashCode();
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
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

    }
}
