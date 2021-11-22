using AutoMapper;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using System;
using System.Buffers.Text;
using System.Text;
using static LocadoraDeVeiculos.WebApiCore.ViewModels.VeiculoViewModel;

namespace LocadoraDeVeiculos.WebApiCore.Config.AutoMapperConfig
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoListViewModel>();

            CreateMap<Veiculo, VeiculoDetailsViewModel>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Encoding.ASCII.GetString(src.Foto)));

            CreateMap<VeiculoCreateViewModel, Veiculo>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Foto)))
                .ForMember(dest => dest.TamanhoPortaMalas, opt => opt.MapFrom(src => src.TamanhoPortaMalas[0]));

            CreateMap<VeiculoEditViewModel, Veiculo>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Foto)))
                .ForMember(dest => dest.TamanhoPortaMalas, opt => opt.MapFrom(src => src.TamanhoPortaMalas[0]));

        }
    }
}
