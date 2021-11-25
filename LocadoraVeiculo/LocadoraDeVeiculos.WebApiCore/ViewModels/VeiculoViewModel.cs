using System;

namespace LocadoraDeVeiculos.WebApiCore.ViewModels
{
    public class VeiculoViewModel
    {
        public class VeiculoListViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cor { get; set; }
            public string Marca { get; set; }
            public int? Ano { get; set; }
            public int? NumeroPortas { get; set; }
            public string TipoCombustivel { get; set; }
            public int DisponibilidadeVeiculo { get; set; }
            public int IdGrupoVeiculo { get; set; }
            public string GrupoVeiculoNomeTipo { get; set; }
        }

        public class VeiculoDetailsViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string NumeroPlaca { get; set; }
            public string NumeroChassi { get; set; }
            public string Foto { get; set; }
            public string Cor { get; set; }
            public string Marca { get; set; }
            public int? Ano { get; set; }
            public int? NumeroPortas { get; set; }
            public int? CapacidadeTanque { get; set; }
            public int? CapacidadePessoas { get; set; }
            public string TamanhoPortaMalas { get; set; }
            public int? KmInicial { get; set; }
            public string TipoCombustivel { get; set; }
            public int IdGrupoVeiculo { get; set; }

        }

        public class VeiculoCreateViewModel
        {
            public string Nome { get; set; }
            public string NumeroPlaca { get; set; }
            public string NumeroChassi { get; set; }
            public string Foto { get; set; }
            public string Cor { get; set; }
            public string Marca { get; set; }
            public int Ano { get; set; }
            public int NumeroPortas { get; set; }
            public int CapacidadeTanque { get; set; }
            public int CapacidadePessoas { get; set; }
            public string TamanhoPortaMalas { get; set; }
            public int KmInicial { get; set; }
            public string TipoCombustivel { get; set; }
            public int IdGrupoVeiculo { get; set; }
        }

        public class VeiculoEditViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string NumeroPlaca { get; set; }
            public string NumeroChassi { get; set; }
            public string Foto { get; set; }
            public string Cor { get; set; }
            public string Marca { get; set; }
            public int? Ano { get; set; }
            public int? NumeroPortas { get; set; }
            public int? CapacidadeTanque { get; set; }
            public int? CapacidadePessoas { get; set; }
            public string TamanhoPortaMalas { get; set; }
            public int? KmInicial { get; set; }
            public string TipoCombustivel { get; set; }
            public int IdGrupoVeiculo { get; set; }
        }
    }
}
