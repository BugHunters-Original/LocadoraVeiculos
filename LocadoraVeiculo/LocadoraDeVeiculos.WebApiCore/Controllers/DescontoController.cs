using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    public class DescontoController : BaseController<Desconto, DescontoListViewModel, DescontoDetailsViewModel, DescontoCreateViewModel, DescontoEditViewModel>
    {
        public DescontoController(IDescontoAppService appService, IMapper mapper) : base(appService, mapper)
        {

        }
    }
}
