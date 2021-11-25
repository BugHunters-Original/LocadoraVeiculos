using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            public List<DescontoListViewModel> Descontos { get; set; }
        }

        public class ParceiroCreateViewModel
        {
            [Required(ErrorMessage = "O campo Nome é obrigatório")]
            public string Nome { get; set; }
        }

        public class ParceiroEditViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }
        }
    }
}
