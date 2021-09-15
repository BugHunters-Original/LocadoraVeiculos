using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.DescontoModule
{
    public interface IDescontoRepository
    {
        void InserirDesconto(Desconto desconto);
        void EditarDesconto(int id, Desconto desconto);
        bool ExcluirDesconto(int id);
        bool Existe(int id);
        Desconto SelecionarPorId(int id);
        List<Desconto> SelecionarTodos();
        List<Desconto> SelecionarPesquisa(string coluna, string pesquisa);
    }
}
