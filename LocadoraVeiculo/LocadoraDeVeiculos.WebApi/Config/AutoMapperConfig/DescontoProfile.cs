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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Desconto, DescontoListViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));

                cfg.CreateMap<Desconto, DescontoDetailsViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (int)src.Tipo));

                cfg.CreateMap<DescontoCreateViewModel, Desconto>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));

                cfg.CreateMap<DescontoEditViewModel, Desconto>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoDesconto)src.Tipo));
            });
        }

    }
}
