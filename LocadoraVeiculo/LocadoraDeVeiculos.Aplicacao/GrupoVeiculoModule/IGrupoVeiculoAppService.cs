using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{
    public interface IGrupoVeiculoAppService
    {
        bool Editar(GrupoVeiculo grupoVeiculo);
        bool Excluir(GrupoVeiculo grupoVeiculo);
        List<GrupoVeiculo> GetAll();
        GrupoVeiculo GetById(int id);
        bool Inserir(GrupoVeiculo grupoVeiculo);
    }
}