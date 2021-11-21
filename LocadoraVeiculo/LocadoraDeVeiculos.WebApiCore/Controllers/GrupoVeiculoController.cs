using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApi.ViewModels.GrupoVeiculoViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    public class GrupoVeiculoController : BaseController<GrupoVeiculo, GrupoVeiculoListViewModel, GrupoVeiculoDetailsViewModel, GrupoVeiculoCreateViewModel, GrupoVeiculoEditViewModel>
    {
        public GrupoVeiculoController(IGrupoVeiculoAppService appService, IMapper mapper) : base(appService, mapper)
        {

        }
    }

}
