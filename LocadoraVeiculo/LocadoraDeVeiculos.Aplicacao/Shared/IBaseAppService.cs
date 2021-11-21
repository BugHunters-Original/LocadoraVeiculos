using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.Shared
{
    public interface IBaseAppService<T> where T: EntidadeBase
    {
        bool Editar(T registro);
        bool Excluir(T registro);
        List<T> GetAll();
        T GetById(int id);
        bool Inserir(T registro);
    }
}
