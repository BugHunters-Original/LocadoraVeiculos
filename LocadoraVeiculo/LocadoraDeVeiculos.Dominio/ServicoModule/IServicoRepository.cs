using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ServicoModule
{
    public interface IServicoRepository
    {
        void InserirServico(Servico funcionario);
        void EditarServico(int id, Servico servico);
        bool ExcluirServico(int id);
        bool Existe(int id);
        Servico SelecionarPorId(int id);
        List<Servico> SelecionarTodos();
        List<Servico> SelecionarPesquisa(string coluna, string pesquisa);
    }
}
