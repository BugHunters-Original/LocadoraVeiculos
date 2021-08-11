using LocadoraVeiculo.CondutorModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ClienteModule
{
    public class ClienteCNPJ : EntidadeBase, IEquatable<ClienteCNPJ>
    {
        public ClienteCNPJ(string nome, string endereco, string telefone, string cpf_cnpj)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cpf_cnpj = cpf_cnpj;
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf_cnpj { get; set; }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            if (string.IsNullOrEmpty(Telefone) || Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            if (string.IsNullOrEmpty(Cpf_cnpj))
                valido += QuebraDeLinha(valido) + "O campo CPF/CNPJ está inválido";

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
            return Equals(obj as ClienteCNPJ);
        }
        public bool Equals(ClienteCNPJ other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Cpf_cnpj == other.Cpf_cnpj;
        }

        public override int GetHashCode()
        {
            int hashCode = -103464265;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cpf_cnpj);
            return hashCode;
        }
    }
}
