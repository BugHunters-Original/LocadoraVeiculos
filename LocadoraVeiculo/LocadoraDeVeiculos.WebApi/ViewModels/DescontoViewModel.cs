namespace LocadoraDeVeiculos.WebApi.ViewModels
{
    public class DescontoViewModel
    {
        public class DescontoListViewModel 
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Codigo { get; set; }

            public decimal Valor { get; set; }

            public string Tipo { get; set; }

            public DateTime Validade { get; set; }

            public int IdParceiro { get; set; }

            public string Meio { get; set; }

            public decimal ValorMinimo { get; set; }

            public int Usos { get; set; }

            public string ParceiroNome { get; set; }
        }

        public class DescontoDetailsViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Codigo { get; set; }

            public decimal Valor { get; set; }

            public int Tipo { get; set; }

            public DateTime Validade { get; set; }

            public int IdParceiro { get; set; }

            public string Meio { get; set; }

            public decimal ValorMinimo { get; set; }

            public int Usos { get; set; }

        }

        public class DescontoCreateViewModel
        {
            public string Nome { get; set; }

            public string Codigo { get; set; }

            public decimal Valor { get; set; }

            public int Tipo { get; set; }

            public DateTime Validade { get; set; }

            public int IdParceiro { get; set; }

            public string Meio { get; set; }

            public decimal ValorMinimo { get; set; }
        }

        public class DescontoEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public decimal Valor { get; set; }

            public int Tipo { get; set; }

            public DateTime Validade { get; set; }

            public int IdParceiro { get; set; }

            public string Meio { get; set; }

            public decimal ValorMinimo { get; set; }
        }
    }
}
