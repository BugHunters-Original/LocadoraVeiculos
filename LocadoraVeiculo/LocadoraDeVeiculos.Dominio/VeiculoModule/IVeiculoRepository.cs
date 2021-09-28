using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Dominio.VeiculoModule
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        int ReturnQuantidadeDisponiveis();
        int ReturnQuantidadeAlugados();
        List<Veiculo> SelecionarTodosDisponiveis();
        List<Veiculo> SelecionarTodosAlugados();
        void EditarDisponibilidade(Veiculo atual, Veiculo antigo);
        void DevolverVeiculo(Veiculo veiculo);
        void LocarVeiculo(Veiculo veiculo);
        void AtualizarQuilometragem(Veiculo veiculo);
    }

}
