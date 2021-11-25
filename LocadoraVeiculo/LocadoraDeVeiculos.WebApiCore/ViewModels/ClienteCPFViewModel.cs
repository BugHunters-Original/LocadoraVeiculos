using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.WebApiCore.ViewModels
{
    public class ClienteCPFViewModel
    {
        public class ClienteCPFListViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Email { get; set; }
        }

        public class ClienteCPFDetailsViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string CPF { get; set; }

            public string Email { get; set; }

            public string Rg { get; set; }

            public string Cnh { get; set; }

            public DateTime DataValidade { get; set; }

            public int? IdCliente { get; set; }

            //public List<object> LocacoesParticipando { get; set; }

        }

        public class ClienteCPFCreateViewModel
        {
            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string CPF { get; set; }

            public string Email { get; set; }

            public string Rg { get; set; }

            public string Cnh { get; set; }

            public DateTime DataValidade { get; set; }

            public int? IdCliente { get; set; }
        }

        public class ClienteCPFEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string CPF { get; set; }

            public string Email { get; set; }

            public string Rg { get; set; }

            public string Cnh { get; set; }

            public DateTime DataValidade { get; set; }

            public int? IdCliente { get; set; }
        }
    }
}
