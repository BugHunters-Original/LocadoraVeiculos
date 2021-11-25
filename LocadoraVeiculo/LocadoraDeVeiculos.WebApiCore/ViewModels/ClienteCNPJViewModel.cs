using System.Collections.Generic;

namespace LocadoraDeVeiculos.WebApiCore.ViewModels
{
    public class ClienteCNPJViewModel
    {
        public class ClienteCNPJListViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Email { get; set; }
        }

        public class ClienteCNPJDetailsViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string Cnpj { get; set; }

            public string Email { get; set; }

            //public ICollection<object> Condutores { get; set; }

        }

        public class ClienteCNPJCreateViewModel
        {
            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string Cnpj { get; set; }

            public string Email { get; set; }
        }

        public class ClienteCNPJEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Endereco { get; set; }

            public string Telefone { get; set; }

            public string Cnpj { get; set; }

            public string Email { get; set; }
        }
    }
}
