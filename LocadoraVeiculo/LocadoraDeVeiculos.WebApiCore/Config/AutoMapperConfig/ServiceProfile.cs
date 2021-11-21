using AutoMapper;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using static LocadoraDeVeiculos.Dominio.ServicoModule.Servico;
using static LocadoraDeVeiculos.WebApi.ViewModels.ServicoViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Servico, ServicoListViewModel>();

            CreateMap<Servico, ServicoDetailsViewModel>()
            .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (int)src.CalculoTipo));

            CreateMap<ServicoCreateViewModel, Servico>()
            .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (TipoCalculo)src.CalculoTipo));

            CreateMap<ServicoEditViewModel, Servico>()
            .ForMember(dest => dest.CalculoTipo, opt => opt.MapFrom(src => (TipoCalculo)src.CalculoTipo));
        }
    }
}
