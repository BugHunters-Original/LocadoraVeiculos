namespace LocadoraDeVeiculos.WebApi.ViewModels
{
    public class ServicoViewModel
    {
        public class ServicoListViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

        }

        public class ServicoDetailsViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public decimal Preco { get; set; }

            public string CalculoTipo { get; set; }

        }

        public class ServicoCreateViewModel
        {
            public string Nome { get; set; }

            public decimal Preco { get; set; }

            public int CalculoTipo { get; set; }
        }

        public class ServicoEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public decimal Preco { get; set; }

            public int CalculoTipo { get; set; }
        }
    }
}
