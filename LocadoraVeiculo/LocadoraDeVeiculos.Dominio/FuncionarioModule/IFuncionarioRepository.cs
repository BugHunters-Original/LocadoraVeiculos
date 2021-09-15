using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.FuncionarioModule
{
    public interface IFuncionarioRepository
    {
        void InserirFuncionario(Funcionario funcionario);
        void EditarFuncionario(int id, Funcionario funcionario);
        bool ExcluirFuncionario(int id);
        bool Existe(int id);
        Funcionario SelecionarPorId(int id);
        List<Funcionario> SelecionarTodos();
        List<Funcionario> SelecionarPesquisa(string coluna, string pesquisa);
    }
}
