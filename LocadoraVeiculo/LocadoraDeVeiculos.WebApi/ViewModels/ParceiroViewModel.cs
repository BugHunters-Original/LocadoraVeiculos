using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;

namespace LocadoraDeVeiculos.WebApi.ViewModels
{
    public class ParceiroViewModel
    {
        public class ParceiroListViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }
        }

        public class ParceiroDetailsViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public List<DescontoListViewModel> Cupons { get; set; }
        }

        public class ParceiroCreateViewModel
        {
            public string Nome { get; set; }
        }

        public class ParceiroEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }
        }
    }
}
