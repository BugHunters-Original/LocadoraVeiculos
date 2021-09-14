using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ParceiroModule
{
    public interface IParceiroRepository
    {
        void InserirParceiro(Parceiro parceiro);
        void EditarParceiro(int id, Parceiro parceiro);
        bool ExcluirParceiro(int id);
        bool Existe(int id);
        Parceiro SelecionarPorId(int id);
        List<Parceiro> SelecionarTodos();
        List<Parceiro> SelecionarPesquisa(string coluna, string pesquisa);

    }
}
