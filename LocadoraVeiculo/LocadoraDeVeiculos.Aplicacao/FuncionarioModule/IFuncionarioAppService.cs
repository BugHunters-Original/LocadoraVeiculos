using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.FuncionarioModule
{
    public interface IFuncionarioAppService
    {
        bool Editar(Funcionario funcionario);
        bool Excluir(Funcionario funcionario);
        bool Inserir(Funcionario funcionario);
        Funcionario GetById(int id);
        List<Funcionario> GetAll();
    }
}