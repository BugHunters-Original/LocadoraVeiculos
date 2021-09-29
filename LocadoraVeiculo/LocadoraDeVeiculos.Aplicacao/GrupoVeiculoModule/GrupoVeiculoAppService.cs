using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{


    public class GrupoVeiculoAppService
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
        }

        public void RegistrarNovoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            Log.Logger.Aqui().Debug("REGISTRANDO GRUPO DE VEÍCULOS {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.Inserir(grupoVeiculo);

                Log.Logger.Aqui().Debug("GRUPO DE VEÍCULO {grupoVeiculoNome} REGISTRADO COM SUCESSO", grupoVeiculo.NomeTipo);
            }
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

        }

        public void EditarNovoGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            Log.Logger.Aqui().Debug("EDITANDO GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.Editar(id, grupoVeiculo);
                Log.Logger.Aqui().Debug("GRUPO VEÍCULO {grupoVeiculoNome} EDITADO COM SUCESSO", grupoVeiculo.NomeTipo);
            }
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

        }

        public bool ExcluirGrupoVeiculo(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO GRUPO VEÍCULO{Id}", id);


            var excluiu = grupoVeiculoRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("GRUPO DE VEÍCULOS {Id} REMOVIDO COM SUCESSO", id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id}.", id);

            return excluiu;

        }

        public List<GrupoVeiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            Log.Logger.Aqui().Debug("SELECIONADO GRUPOS DE VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<GrupoVeiculo> grupos = grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (grupos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", grupos.Count, pesquisa);

            return grupos;

        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id}", id);

            GrupoVeiculo grupoVeiculo = grupoVeiculoRepository.SelecionarPorId(id);

            if (grupoVeiculo == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O GRUPO DE VEÍCULO ID {Id}", grupoVeiculo.Id);
            else
                Log.Logger.Aqui().Debug("GRUPO DE VEÍCULO ID {Id} SELECIONADO COM SUCESSO", grupoVeiculo.Id);

            return grupoVeiculo;

        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS GRUPOS VEÍCULOS");

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoRepository.SelecionarTodos();

            if (grupoVeiculos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S)", grupoVeiculos.Count);

            return grupoVeiculos;
        }
    }
}
