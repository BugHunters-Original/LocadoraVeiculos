using AutoMapper;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using static LocadoraDeVeiculos.Dominio.DescontoModule.Desconto;
using static LocadoraDeVeiculos.WebApi.ViewModels.DescontoViewModel;

namespace LocadoraDeVeiculos.WebApi.Config.AutoMapperConfig
{
    public class DescontoProfile : Profile
    {
        public DescontoProfile()
        {
            CreateMap<Desconto, DescontoListViewModel>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));

            CreateMap<Desconto, DescontoDetailsViewModel>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));

            CreateMap<DescontoCreateViewModel, Desconto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));

            CreateMap<DescontoEditViewModel, Desconto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));

        }

    }
}
