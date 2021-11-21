using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApi.ViewModels.ServicoViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    public class ServicoController : BaseController<Servico, ServicoListViewModel, ServicoDetailsViewModel, ServicoCreateViewModel, ServicoEditViewModel>
    {
        public ServicoController(IServicoAppService appService, IMapper mapper) : base(appService, mapper)
        {

        }
    }
}
