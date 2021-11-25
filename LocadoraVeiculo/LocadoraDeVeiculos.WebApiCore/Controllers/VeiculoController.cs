using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.VeiculoViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Controllers
{
    public class VeiculoController : BaseController<Veiculo, VeiculoListViewModel, VeiculoDetailsViewModel, VeiculoCreateViewModel, VeiculoEditViewModel>
    {
        public VeiculoController(IVeiculoAppService appService, IMapper mapper, INotificador notificador) : base(appService, mapper, notificador)
        {

        }
    }
}
