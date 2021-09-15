
using System.Collections.Generic;



namespace LocadoraDeVeiculos.Dominio.VeiculoModule
{
    public interface IVeiculoRepository
    {
        void InserirVeiculo(Veiculo veiculo);
        void EditarVeiculo(int id, Veiculo veiculo);
        bool ExcluirVeiculo(int id);
        bool Existe(int id);
        Veiculo SelecionarPorId(int id);
        List<Veiculo> SelecionarTodos();
        int ReturnQuantidadeDisponiveis();
        int ReturnQuantidadeAlugados();
        List<Veiculo> SelecionarTodosDisponiveis();
        List<Veiculo> SelecionarTodosAlugados();
        void EditarDisponibilidade(Veiculo atual, Veiculo antigo);
        List<Veiculo> SelecionarPesquisa(string coluna, string pesquisa);
    }

}
