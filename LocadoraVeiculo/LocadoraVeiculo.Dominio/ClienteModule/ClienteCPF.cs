using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.ClienteModule
{
    public class ClienteCPF : Cliente, IEquatable<ClienteCPF>
    {
        public ClienteCPF(string nome, string telefone, string endereco, string CPF,
            string RG, string CNH, DateTime dataValidade, ClienteCNPJ cliente = null)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = CPF;
            Rg = RG;
            Cnh = CNH;
            DataValidade = dataValidade;
            Cliente = cliente;
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidade { get; set; }
        public ClienteCNPJ Cliente { get; set; }

        public bool Equals(ClienteCPF other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Cpf == other.Cpf
                && Cnh == other.Cnh
                && DataValidade == other.DataValidade
                && Cliente.Equals(other.Cliente);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ClienteCPF);
        }

        public override int GetHashCode()
        {
            int hashCode = 1775420395;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cpf);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rg);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cnh);
            hashCode = hashCode * -1521134295 + DataValidade.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ClienteCNPJ>.Default.GetHashCode(Cliente);
            return hashCode;
        }
        public override string ToString()
        {
            return Nome;
        }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            if (string.IsNullOrEmpty(Telefone) || Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            if (string.IsNullOrEmpty(Cpf) || Cpf.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo CPF está inválido";

            if (string.IsNullOrEmpty(Rg) || Rg.Length != 9)
                valido += QuebraDeLinha(valido) + "O campo RG está inválido";

            if (string.IsNullOrEmpty(Cnh) || Cnh.Length != 11)
                valido += QuebraDeLinha(valido) + "O campo CNH está inválido";

            if (DataValidade < DateTime.Now)
                valido += QuebraDeLinha(valido) + "O campo Data de Validade CNH está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
    }
}
