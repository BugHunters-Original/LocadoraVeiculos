﻿using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.CondutorModule
{
    public class Condutor : EntidadeBase, IEquatable<Condutor>
    {
        public Condutor(string nome, string telefone, string endereco, string CPF,
            string RG, string CNH, DateTime dataValidade, Cliente cliente)
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
        public Cliente Cliente { get; set; }

        public bool Equals(Condutor other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Endereco == other.Endereco
                && Telefone == other.Telefone
                && Cpf == other.Cpf
                && Cnh == other.Cnh
                && DataValidade == other.DataValidade
                && Cliente == other.Cliente;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Condutor);
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
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Cliente);
            return hashCode;
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

            if (string.IsNullOrEmpty(Cpf))
                valido += QuebraDeLinha(valido) + "O campo CPF está inválido";

            if (string.IsNullOrEmpty(Rg))
                valido += QuebraDeLinha(valido) + "O campo RG está inválido";

            if (string.IsNullOrEmpty(Cnh))
                valido += QuebraDeLinha(valido) + "O campo CNH está inválido";

            if (DataValidade > DateTime.Now)
                valido += QuebraDeLinha(valido) + "O campo Data de Validade CNH está inválido";

            if (valido == "")
                valido = "ESTA_VALIDO";

            return valido;
        }
    }
}