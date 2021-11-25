using AutoMapper;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.ClienteCNPJViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class ClienteCNPJProfile : Profile
    {
        public ClienteCNPJProfile()
        {
            CreateMap<ClienteCNPJ, ClienteCNPJListViewModel>();

            CreateMap<ClienteCNPJ, ClienteCNPJDetailsViewModel>();

            CreateMap<ClienteCNPJCreateViewModel, ClienteCNPJ>();

            CreateMap<ClienteCNPJEditViewModel, ClienteCNPJ>();
        }
    }
}
