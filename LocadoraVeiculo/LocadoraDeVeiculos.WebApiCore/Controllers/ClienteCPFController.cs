using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.ClienteCPFViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Controllers
{
    public class ClienteCPFController : BaseController<ClienteCPF, ClienteCPFListViewModel, ClienteCPFDetailsViewModel, ClienteCPFCreateViewModel, ClienteCPFEditViewModel>
    {
        public ClienteCPFController(IClienteCPFAppService appService, IMapper mapper, INotificador notificador) : base(appService, mapper, notificador)
        {
        }
    }
}
