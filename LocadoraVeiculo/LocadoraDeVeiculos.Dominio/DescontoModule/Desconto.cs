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
        public Desconto(string codigo, decimal valor, string tipo, DateTime validade,
            Parceiro parceiro, string meio, string nome, decimal valorMinimo)
        {
            Nome = nome;
            Codigo = codigo;
            Valor = valor;
            Tipo = tipo;
            Validade = validade;
            Parceiro = parceiro;
            Meio = meio;
            ValorMinimo = valorMinimo;
        }

        public Desconto()
        {

        }

        public string Nome { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorMinimo { get; set; }
        public string Tipo { get; set; }
        public DateTime Validade { get; set; }
        public Parceiro Parceiro { get; set; }
        public string Meio { get; set; }
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

        public override int GetHashCode()
        {
            int hashCode = -157931640;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Codigo);
            hashCode = hashCode * -1521134295 + Valor.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tipo);
            hashCode = hashCode * -1521134295 + Validade.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Parceiro>.Default.GetHashCode(Parceiro);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Meio);
            return hashCode;
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

            if (Valor > 100 && Tipo == "Porcentagem")
                valido += QuebraDeLinha(valido) + "O campo Valor não pode ter uma porcentagem maior que 100%";

            if (string.IsNullOrEmpty(Tipo))
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

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
    }
}
