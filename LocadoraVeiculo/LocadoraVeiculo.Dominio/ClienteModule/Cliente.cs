using LocadoraVeiculo.CondutorModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ClienteModule
{
    public class Cliente : EntidadeBase, IEquatable<Cliente>
    {
        public Cliente(string nome, string endereco, string telefone, string cpf_cnpj, string tipo)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cpf_cnpj = cpf_cnpj;
            Tipo = tipo;
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Tipo { get; set; }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "Nome em branco";

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "Endereço em branco";

            if (string.IsNullOrEmpty(Telefone) || Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "Telefone em branco";

            if (string.IsNullOrEmpty(Cpf_cnpj))
                valido += QuebraDeLinha(valido) + "CPF ou CNPJ em branco";

            if (string.IsNullOrEmpty(Tipo))
                valido += QuebraDeLinha(valido) + "Tipo em branco";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }
        public bool Equals(Cliente other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Tipo == other.Tipo
                && Cpf_cnpj == other.Cpf_cnpj;
        }
        public override int GetHashCode()
        {
            int hashCode = -974552850;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cpf_cnpj);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tipo);
            return hashCode;
        }
    }
}
