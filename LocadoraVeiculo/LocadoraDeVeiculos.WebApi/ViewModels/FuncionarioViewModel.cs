namespace LocadoraDeVeiculos.WebApi.ViewModels
{
    public class FuncionarioViewModel
    {
        public class FuncionarioListViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public DateTime DataEntrada { get; set; }
        }

        public class FuncionarioDetailsViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal? Salario { get; set; }
            public DateTime DataEntrada { get; set; }
            public string CpfFuncionario { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }

        }

        public class FuncionarioCreateViewModel
        {
            public string Nome { get; set; }
            public decimal? Salario { get; set; }
            public DateTime DataEntrada { get; set; }
            public string CpfFuncionario { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }

        public class FuncionarioEditViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal? Salario { get; set; }
            public DateTime DataEntrada { get; set; }
            public string CpfFuncionario { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }
    }
}
