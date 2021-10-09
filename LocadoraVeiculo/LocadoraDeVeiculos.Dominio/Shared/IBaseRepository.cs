using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Shared
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        public bool Inserir(T registro);

        public bool Editar(T registro);

        public bool Excluir(T registro);

        public bool Existe(int id);

        public T GetById(int id);

        public List<T> GetAll();
    }
}
