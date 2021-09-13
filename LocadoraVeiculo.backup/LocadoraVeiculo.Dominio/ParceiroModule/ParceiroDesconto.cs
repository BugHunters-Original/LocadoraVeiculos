using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ParceiroModule
{
    public class ParceiroDesconto : EntidadeBase, IEquatable<ParceiroDesconto>
    {
        public ParceiroDesconto(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += QuebraDeLinha(valido) + "O campo Nome está inválido";
            if (valido == "")
                return "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            return Nome;
        }

        public bool Equals(ParceiroDesconto other)
        {
            return other != null
            && Id == other.Id
            && Nome == other.Nome;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ParceiroDesconto);
        }

        public override int GetHashCode()
        {
            int hashCode = -1643562096;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
