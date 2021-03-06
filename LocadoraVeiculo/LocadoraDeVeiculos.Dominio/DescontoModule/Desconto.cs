using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.DescontoModule
{
    public class Desconto : EntidadeBase, IEquatable<Desconto>
    {
        public Desconto(string codigo, decimal valor, TipoDesconto tipo, DateTime validade,
            Parceiro parceiro, string meio, string nome, decimal valorMinimo, int usos)
        {
            Nome = nome;
            Codigo = codigo;
            Valor = valor;
            Tipo = tipo;
            Validade = validade;
            Parceiro = parceiro;
            Meio = meio;
            ValorMinimo = valorMinimo;
            Usos = usos;
            Locacoes = new HashSet<Locacao>();
        }

        public Desconto()
        {

        }

        public string Nome { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorMinimo { get; set; }
        public TipoDesconto Tipo { get; set; }
        public DateTime Validade { get; set; }
        public Parceiro Parceiro { get; set; }
        public int IdParceiro { get; set; }
        public string Meio { get; set; }
        public int Usos { get; set; }
        public ICollection<Locacao> Locacoes { get; set; }
        public override string ToString()
        {
            return Nome;
        }
        public bool Equals(Desconto other)
        {
            return other != null
            && Id == other.Id
            && Codigo == other.Codigo
            && Valor == other.Valor
            && Tipo == other.Tipo
            && Validade == other.Validade
            && Parceiro.Equals(other.Parceiro)
            && Meio == other.Meio;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Desconto);
        }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Codigo))
                valido += QuebraDeLinha(valido) + "O campo Codigo está inválido";

            if (string.IsNullOrEmpty(Nome))
                valido += QuebraDeLinha(valido) + "O campo Nome está inválido";

            if (ValorMinimo <= 0)
                valido += QuebraDeLinha(valido) + "O campo Valor Mínimo não pode ser zero ou negativo";

            if (Valor <= 0)
                valido += QuebraDeLinha(valido) + "O campo Valor não pode ser zero ou negativo";

            if (Valor > 100 && Tipo == TipoDesconto.Percentual)
                valido += QuebraDeLinha(valido) + "O campo Valor não pode ter uma porcentagem maior que 100%";

            if (Validade < DateTime.Now)
                valido += QuebraDeLinha(valido) + "O campo Data de Validade está inválido";

            if (Parceiro == null)
                valido += QuebraDeLinha(valido) + "O campo Parceiro não pode ser nulo";

            if (string.IsNullOrEmpty(Meio))
                valido += QuebraDeLinha(valido) + "O campo Meio está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Codigo);
            hash.Add(Valor);
            hash.Add(ValorMinimo);
            hash.Add(Tipo);
            hash.Add(Validade);
            hash.Add(Parceiro);
            hash.Add(IdParceiro);
            hash.Add(Meio);
            hash.Add(Usos);
            hash.Add(Locacoes);
            return hash.ToHashCode();
        }

        public enum TipoDesconto
        {
            Percentual, Fixo
        }

    }
}
