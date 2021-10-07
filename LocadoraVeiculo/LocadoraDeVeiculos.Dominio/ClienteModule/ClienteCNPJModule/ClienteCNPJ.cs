using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule
{
    public class ClienteCNPJ : ClienteBase, IEquatable<ClienteCNPJ>
    {
        public int IdClienteCNPJ { get; set; }
        public string Cnpj { get; set; }
        public ICollection<ClienteCPF> Condutores { get; set; }
        public ClienteCNPJ()
        {

        }
        public ClienteCNPJ(string nome, string endereco, string telefone, string cnpj, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cnpj = cnpj;
            Email = email;
            Condutores = new HashSet<ClienteCPF>();
        }

        public override string Validar()
        {
            string valido = "";

            if (string.IsNullOrEmpty(Email))
                return "O campo Email está branco";

            try
            {
                MailAddress m = new MailAddress(Email);
            }
            catch (FormatException)
            {
                valido += QuebraDeLinha(valido) + "O campo Email está inválido";
            }

            if (string.IsNullOrEmpty(Nome))
                valido += "O campo Nome está inválido";

            if (string.IsNullOrEmpty(Endereco))
                valido += QuebraDeLinha(valido) + "O campo Endereço está inválido";

            if (Telefone.Length != 14)
                valido += QuebraDeLinha(valido) + "O campo Telefone está inválido";

            if (Cnpj.Length != 18)
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
                && Cnpj == other.Cnpj
                && Email == other.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Endereco, Telefone, Email, Cnpj);
        }
    }
}
