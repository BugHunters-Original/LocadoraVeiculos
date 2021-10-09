using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ParceiroModule
{
    public class Parceiro : EntidadeBase, IEquatable<Parceiro>
    {
        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public Parceiro()
        {
            Descontos = new HashSet<Desconto>();
        }

        public string Nome { get; set; }
        public virtual ICollection<Desconto> Descontos { get; set; }

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Parceiro);
        }

        public override int GetHashCode()
        {
            int hashCode = -1643562096;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }

        public bool Equals(Parceiro other)
        {
            return other != null
               && Id == other.Id
               && Nome == other.Nome;
        }
    }
}
