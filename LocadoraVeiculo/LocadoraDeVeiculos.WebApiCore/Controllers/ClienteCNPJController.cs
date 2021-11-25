using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.ClienteCNPJViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Controllers
{
    public class ClienteCNPJController : BaseController<ClienteCNPJ, ClienteCNPJListViewModel, ClienteCNPJDetailsViewModel, ClienteCNPJCreateViewModel, ClienteCNPJEditViewModel>
    {
        public ClienteCNPJController(IClienteCNPJAppService appService, IMapper mapper, INotificador notificador) : base(appService, mapper, notificador)
        {
        }
    }
}
