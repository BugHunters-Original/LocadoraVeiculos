using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.VeiculoModule
{
    public interface IVeiculoAppService : IBaseAppService<Veiculo>
    {
        void EditarDisponibilidade(Veiculo atual, Veiculo antigo);
        List<Veiculo> GetAllAlugados();
        int GetAllCountAlugados();
        int GetAllCountDisponiveis();
        List<Veiculo> GetAllDisponiveis();
    }
}