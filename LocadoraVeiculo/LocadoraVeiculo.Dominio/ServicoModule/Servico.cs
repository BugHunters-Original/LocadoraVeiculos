using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.ServicoModule
{
    public class Servico : EntidadeBase, IEquatable<Servico>
    {
        public Servico(string nome, decimal preco, int tipoCalculo)
        {
            Nome = nome;
            Preco = preco;
            TipoCalculo = tipoCalculo;
        }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int TipoCalculo { get; set; }
        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (Preco <= 0)
                valido += QuebraDeLinha(valido) + "O campo Preço está inválido";

            if (TipoCalculo != 1 && TipoCalculo != 0)
                valido += QuebraDeLinha(valido) + "O campo Tipo está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            return Nome;
        }

        public bool Equals(Servico other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Preco == other.Preco
                && TipoCalculo == other.TipoCalculo;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Servico);
        }

        public override int GetHashCode()
        {
            int hashCode = -549020184;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + Preco.GetHashCode();
            hashCode = hashCode * -1521134295 + TipoCalculo.GetHashCode();
            return hashCode;
        }
    }
}
