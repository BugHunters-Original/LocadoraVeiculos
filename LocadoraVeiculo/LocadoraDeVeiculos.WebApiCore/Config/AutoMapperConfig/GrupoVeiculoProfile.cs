using AutoMapper;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using static LocadoraDeVeiculos.WebApi.ViewModels.GrupoVeiculoViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class GrupoVeiculoProfile : Profile
    {
        public GrupoVeiculoProfile()
        {
            CreateMap<GrupoVeiculo, GrupoVeiculoListViewModel>();

            CreateMap<GrupoVeiculo, GrupoVeiculoDetailsViewModel>();

            CreateMap<GrupoVeiculoCreateViewModel, GrupoVeiculo>();

            CreateMap<GrupoVeiculoEditViewModel, GrupoVeiculo>();
        }
    }
}
