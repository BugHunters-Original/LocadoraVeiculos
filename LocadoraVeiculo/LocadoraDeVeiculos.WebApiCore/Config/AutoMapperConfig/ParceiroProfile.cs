using AutoMapper;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;
using static LocadoraDeVeiculos.WebApi.ViewModels.ParceiroViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class ParceiroProfile : Profile
    {
        public ParceiroProfile()
        {
            CreateMap<Parceiro, ParceiroListViewModel>();

            CreateMap<Parceiro, ParceiroDetailsViewModel>();

            CreateMap<ParceiroCreateViewModel, Parceiro>();

            CreateMap<ParceiroEditViewModel, Parceiro>();

            CreateMap<Desconto, DescontoListViewModel>();

        }
    }
}
