using LocadoraVeiculo.CondutorModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ClienteModule
{
    public class Cliente : EntidadeBase
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
    }
}
