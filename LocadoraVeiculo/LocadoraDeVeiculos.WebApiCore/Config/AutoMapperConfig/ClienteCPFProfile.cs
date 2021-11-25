using AutoMapper;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.ClienteCPFViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class ClienteCPFProfile : Profile
    {
        public ClienteCPFProfile()
        {
            CreateMap<ClienteCPF, ClienteCPFListViewModel>();

            CreateMap<ClienteCPF, ClienteCPFDetailsViewModel>();

            CreateMap<ClienteCPFCreateViewModel, ClienteCPF>();

            CreateMap<ClienteCPFEditViewModel, ClienteCPF>();
        }
    }
}
