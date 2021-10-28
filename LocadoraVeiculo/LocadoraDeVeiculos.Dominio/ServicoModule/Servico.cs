using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ServicoModule
{
    public class Servico : EntidadeBase, IEquatable<Servico>
    {
        public Servico(string nome, decimal? preco, TipoCalculo tipoCalculo)
        {
            Nome = nome;
            Preco = preco;
            CalculoTipo = tipoCalculo;
        }
        public Servico()
        {
            TaxasDaLocacao = new HashSet<TaxaDaLocacao>();
        }

        public string Nome { get; set; }
        public decimal? Preco { get; set; }
        public TipoCalculo CalculoTipo { get; set; }

        public ICollection<TaxaDaLocacao> TaxasDaLocacao { get; set; }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (Preco <= 0 || Preco == null)
                valido += QuebraDeLinha(valido) + "O campo Preço está inválido";

            if (CalculoTipo != TipoCalculo.Fixo && CalculoTipo != TipoCalculo.Diario)
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            string tipo = CalculoTipo == TipoCalculo.Diario ? "Diário" : "Fixo";
            return "R$" + Preco + " " + tipo + " " + Nome;
        }

        public bool Equals(Servico other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Preco == other.Preco
                && CalculoTipo == other.CalculoTipo;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Servico);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Preco, CalculoTipo, TaxasDaLocacao);
        }

        public enum TipoCalculo
        {
            Fixo, Diario
        }
    }
}
