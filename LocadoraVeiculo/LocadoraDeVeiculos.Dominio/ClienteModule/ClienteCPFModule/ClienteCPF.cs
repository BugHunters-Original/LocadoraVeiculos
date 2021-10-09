using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule
{
    public class ClienteCPF : ClienteBase, IEquatable<ClienteCPF>
    {
        public ClienteCPF()
        {

        }
        public ClienteCPF(string nome, string telefone, string endereco, string CPF,
            string RG, string CNH, DateTime dataValidade, string email, ClienteCNPJ cliente = null)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = CPF;
            Rg = RG;
            Cnh = CNH;
            DataValidade = dataValidade;
            Cliente = cliente;
            Email = email;
        }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidade { get; set; }
        public int? IdCliente { get; set; }
        public ClienteCNPJ Cliente { get; set; }
        public Locacao Locacao { get; set; }

        public bool Equals(ClienteCPF other)
        {
            if(other?.Cliente == null)
                return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Cpf == other.Cpf
                && Cnh == other.Cnh
                && DataValidade == other.DataValidade
                && Email == other.Email;

            return other != null
                && Cliente.Equals(other?.Cliente)
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Cpf == other.Cpf
                && Cnh == other.Cnh
                && DataValidade == other.DataValidade
                && Email == other.Email;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ClienteCPF);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Endereco);
            hash.Add(Telefone);
            hash.Add(Email);
            hash.Add(Cpf);
            hash.Add(Rg);
            hash.Add(Cnh);
            hash.Add(DataValidade);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return Nome;
        }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Nome))
                valido += QuebraDeLinha(valido) + "O campo Nome está inválido";

            if (string.IsNullOrEmpty(Email))
                valido += QuebraDeLinha(valido) + "O campo Email está em branco";

            try
            {
                MailAddress m = new MailAddress(Email);
            }
            catch (FormatException)
            {
                valido += QuebraDeLinha(valido) + "O campo Email está inválido";
            }

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            if (Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            if (Cpf.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo CPF está inválido";

            if (Rg.Length != 9)
                valido += QuebraDeLinha(valido) + "O campo RG está inválido";

            if (Cnh.Length != 11)
                valido += QuebraDeLinha(valido) + "O campo CNH está inválido";

            if (DataValidade < DateTime.Now)
                valido += QuebraDeLinha(valido) + "O campo Data de Validade CNH está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }

    }
}
