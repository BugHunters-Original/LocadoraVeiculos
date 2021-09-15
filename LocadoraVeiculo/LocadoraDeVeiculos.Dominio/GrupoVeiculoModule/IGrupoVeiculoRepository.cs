using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.GrupoVeiculoModule
{
    public interface IGrupoVeiculoRepository
    {

        void InserirGrupoVeiculo(GrupoVeiculo grupoVeiculo);
        void EditarGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo);
        bool ExcluirGrupoVeiculo(int id);
        bool Existe(int id);
        GrupoVeiculo SelecionarPorId(int id);
        List<GrupoVeiculo> SelecionarTodos();
        List<GrupoVeiculo> SelecionarPesquisa(string coluna, string pesquisa);
    }
}
