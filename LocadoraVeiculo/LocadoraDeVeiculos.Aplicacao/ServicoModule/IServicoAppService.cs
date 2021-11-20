using LocadoraDeVeiculos.Dominio.ServicoModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ServicoModule
{
    public interface IServicoAppService
    {
        bool Editar(Servico servico);
        bool Excluir(Servico servico);
        bool Inserir(Servico servico);
        Servico GetById(int id);
        List<Servico> GetAll();
    }
}