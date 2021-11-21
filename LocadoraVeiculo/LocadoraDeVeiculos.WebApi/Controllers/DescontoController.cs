using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LocadoraDeVeiculos.Dominio.DescontoModule.Desconto;
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
