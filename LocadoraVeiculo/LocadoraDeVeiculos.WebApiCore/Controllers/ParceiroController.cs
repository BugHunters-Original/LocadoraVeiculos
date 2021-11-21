using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.WebApi.ViewModels.ParceiroViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    public class ParceiroController : BaseController<Parceiro, ParceiroListViewModel, ParceiroDetailsViewModel, ParceiroCreateViewModel, ParceiroEditViewModel>
    {
        public ParceiroController(IParceiroAppService appService, IMapper mapper) : base(appService, mapper)
        {

        }
    }

}
