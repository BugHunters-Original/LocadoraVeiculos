using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase, IEquatable<Locacao>
    {
        public Locacao(ClienteBase cliente, Veiculo veiculo, Desconto desconto, ClienteCPF condutor, DateTime dataSaida,
               DateTime dataRetorno, TipoLocacao tipoLocacao, TipoCliente tipoCliente, decimal? precoServicos, int dias,
               decimal? precoCombustivel, decimal? precoPlano, decimal? precoTotal, List<Servico> servicos)
        {
            Cliente = cliente;
            Veiculo = veiculo;
            Desconto = desconto;
            Condutor = condutor;
            DataSaida = dataSaida;
            DataRetorno = dataRetorno;
            LocacaoTipo = tipoLocacao;
            ClienteTipo = tipoCliente;
            PrecoServicos = precoServicos;
            Dias = dias;
            PrecoCombustivel = precoCombustivel;
            PrecoPlano = precoPlano;
            PrecoTotal = precoTotal;
            Servicos = servicos;
        }
        public Locacao()
        {

        }
        public int? IdCliente { get; set; }
        public ClienteBase Cliente { get; set; }
        public int? IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
        public int? IdDesconto { get; set; }
        public Desconto Desconto { get; set; }
        public int? IdCondutor { get; set; }
        public ClienteCPF Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public TipoLocacao LocacaoTipo { get; set; }
        public StatusLocacao Status { get; set; } = StatusLocacao.Pendente;
        public TipoCliente ClienteTipo { get; set; }
        public int Dias { get; set; }
        public decimal? PrecoServicos { get; set; }
        public decimal? PrecoCombustivel { get; set; }
        public decimal? PrecoPlano { get; set; }
        public decimal? PrecoTotal { get; set; }
        public List<Servico> Servicos { get; set; }
        public ICollection<TaxaDaLocacao> TaxasDaLocacao { get; set; }

        public bool Equals(Locacao other)
        {
            return other != null
                && Id == other.Id
                && Cliente.Equals(other.Cliente)
                && Veiculo.Equals(other.Veiculo)
                && Condutor.Equals(other.Condutor)
                && DataSaida == other.DataSaida
                && DataRetorno == other.DataRetorno
                && LocacaoTipo == other.LocacaoTipo
                && ClienteTipo == other.ClienteTipo
                && PrecoServicos == other.PrecoServicos;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public override string ToString()
        {
            return "Cliente:" + Cliente + " Carro:" + Veiculo;
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

            if (ClienteTipo != TipoCliente.Fisico && ClienteTipo != TipoCliente.Juridico)
                valido += QuebraDeLinha(valido) + "O campo Tipo Cliente está inválido";

            if(LocacaoTipo != TipoLocacao.Livre && LocacaoTipo != TipoLocacao.Controlado && LocacaoTipo != TipoLocacao.Diario)
                valido += QuebraDeLinha(valido) + "O campo Tipo Locação está inválido";

            if (Condutor == null || Condutor.DataValidade <= DataRetorno)
                valido += QuebraDeLinha(valido) + "O condutor necessita de uma CNH válida";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdCliente);
            hash.Add(Cliente);
            hash.Add(IdVeiculo);
            hash.Add(Veiculo);
            hash.Add(IdDesconto);
            hash.Add(Desconto);
            hash.Add(IdCondutor);
            hash.Add(Condutor);
            hash.Add(DataSaida);
            hash.Add(DataRetorno);
            hash.Add(LocacaoTipo);
            hash.Add(Status);
            hash.Add(ClienteTipo);
            hash.Add(Dias);
            hash.Add(PrecoServicos);
            hash.Add(PrecoCombustivel);
            hash.Add(PrecoPlano);
            hash.Add(PrecoTotal);
            hash.Add(Servicos);
            hash.Add(TaxasDaLocacao);
            return hash.ToHashCode();
        }

        public enum StatusLocacao
        {
            Pendente, Concluido
        }
        public enum TipoLocacao
        {
            Diario, Livre, Controlado
        }
        public enum TipoCliente
        {
            Fisico, Juridico
        }
    }
}
