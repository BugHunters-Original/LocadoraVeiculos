using LocadoraDeVeiculos.Dominio.ParceiroModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public interface IParceiroAppService
    {
        bool EditarParceiro(Parceiro parceiro);
        bool ExcluirParceiro(Parceiro parceiro);
        bool RegistrarNovoParceiro(Parceiro parceiro);
        Parceiro SelecionarPorId(int id);
        List<Parceiro> SelecionarTodosParceiros();
    }
}