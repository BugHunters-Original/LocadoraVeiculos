using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.WebApi.Controllers.Shared;
using static LocadoraDeVeiculos.WebApi.ViewModels.FuncionarioViewModel;

namespace LocadoraDeVeiculos.WebApi.Shared
{
    public class FuncionarioController : BaseController<Funcionario, FuncionarioListViewModel, FuncionarioDetailsViewModel, FuncionarioCreateViewModel, FuncionarioEditViewModel>
    {
        public FuncionarioController(IFuncionarioAppService appService, IMapper mapper) : base(appService, mapper)
        {

        }
    }
}
