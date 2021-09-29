using System.Collections.Generic;

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
    }
}
