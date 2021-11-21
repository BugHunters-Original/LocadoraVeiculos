using AutoMapper;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using static LocadoraDeVeiculos.WebApi.ViewModels.FuncionarioViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioListViewModel>();

            CreateMap<Funcionario, FuncionarioDetailsViewModel>();

            CreateMap<FuncionarioCreateViewModel, Funcionario>();

            CreateMap<FuncionarioEditViewModel, Funcionario>();
        }
    }
}
