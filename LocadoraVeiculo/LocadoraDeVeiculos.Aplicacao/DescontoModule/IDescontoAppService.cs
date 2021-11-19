using LocadoraDeVeiculos.Dominio.DescontoModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.DescontoModule
{
    public interface IDescontoAppService
    {
        bool Editar(Desconto desconto);
        bool Excluir(Desconto desconto);
        bool Inserir(Desconto desconto);
        Desconto GetById(int id);
        List<Desconto> GetAll();
        bool VerificarCodigoExistente(string codigo);
        Desconto VerificarCodigoValido(string codigo);
    }
}