namespace LocadoraDeVeiculos.WebApi.ViewModels
{
    public class GrupoVeiculoViewModel
    {
        public class GrupoVeiculoListViewModel
        {
            public int Id { get; set; }

            public string NomeTipo { get; set; }
        }

        public class GrupoVeiculoDetailsViewModel
        {
            public int Id { get; set; }

            public string NomeTipo { get; set; }

            public decimal? ValorDiarioPDiario { get; set; }

            public decimal? ValorKmRodadoPDiario { get; set; }

            public decimal? ValorDiarioPControlado { get; set; }

            public decimal? LimitePControlado { get; set; }

            public decimal? ValorKmRodadoPControlado { get; set; }

            public decimal? ValorDiarioPLivre { get; set; }

            //public virtual ICollection<Veiculo> Veiculos { get; set; }
        }

        public class GrupoVeiculoCreateViewModel
        {
            public string NomeTipo { get; set; }

            public decimal? ValorDiarioPDiario { get; set; }

            public decimal? ValorKmRodadoPDiario { get; set; }

            public decimal? ValorDiarioPControlado { get; set; }

            public decimal? LimitePControlado { get; set; }

            public decimal? ValorKmRodadoPControlado { get; set; }

            public decimal? ValorDiarioPLivre { get; set; }
        }

        public class GrupoVeiculoEditViewModel
        {
            public int Id { get; set; }

            public string NomeTipo { get; set; }

            public decimal? ValorDiarioPDiario { get; set; }

            public decimal? ValorKmRodadoPDiario { get; set; }

            public decimal? ValorDiarioPControlado { get; set; }

            public decimal? LimitePControlado { get; set; }

            public decimal? ValorKmRodadoPControlado { get; set; }

            public decimal? ValorDiarioPLivre { get; set; }
        }
    }
}
