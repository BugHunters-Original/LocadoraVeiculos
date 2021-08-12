using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.ClienteModule
{
    public class ClienteCNPJ : Cliente, IEquatable<ClienteCNPJ>
    {
        public ClienteCNPJ(string nome, string endereco, string telefone, string cnpj)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public string Cnpj { get; set; }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            if (string.IsNullOrEmpty(Telefone) || Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            if (string.IsNullOrEmpty(Cnpj) || Cnpj.Length != 18)
                valido += QuebraDeLinha(valido) + "O campo CNPJ está inválido";

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
                && Cnpj == other.Cnpj;
        }

        public override int GetHashCode()
        {
            int hashCode = -103464265;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cnpj);
            return hashCode;
        }
    }
}
