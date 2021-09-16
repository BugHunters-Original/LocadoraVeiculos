using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Shared
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        public void Inserir(T registro);

        public void Editar(int id, T registro);

        public bool Excluir(int id);

        public bool Existe(int id);
        public T SelecionarPorId(int id);

        public List<T> SelecionarTodos();

        public List<T> SelecionarPesquisa(string combobox, string pesquisa);
    }
}
