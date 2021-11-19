using LocadoraDeVeiculos.Dominio.ParceiroModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public interface IParceiroAppService
    {
        bool Editar(Parceiro parceiro);
        bool Excluir(Parceiro parceiro);
        List<Parceiro> GetAll();
        Parceiro GetById(int id);
        bool Inserir(Parceiro parceiro);
    }
}