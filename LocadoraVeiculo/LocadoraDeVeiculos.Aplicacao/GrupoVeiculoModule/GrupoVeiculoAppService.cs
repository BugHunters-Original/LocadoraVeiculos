﻿using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
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

            Log.Logger.Aqui().Debug("REGISTRANDO GRUPO DE VEÍCULOS {grupoVeiculoNome} | {DataEHora} ", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

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

            Log.Logger.Aqui().Debug("EDITANDO GRUPO VEÍCULO {grupoVeiculoNome} | {DataEHora} ", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

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
            Log.Logger.Aqui().Debug("REMOVENDO GRUPO VEÍCULO{Id} | {DataEHora}", id, DateTime.Now.ToString());


            var excluiu = grupoVeiculoRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("GRUPO DE VEÍCULOS {Id} REMOVIDO COM SUCESSO | {DataEHora}", id, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id} | {DataEHora}.", id, DateTime.Now.ToString());

            return excluiu;

        }

        public List<GrupoVeiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            Log.Logger.Aqui().Debug("SELECIONADO GRUPOS DE VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<GrupoVeiculo> grupos = grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (grupos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", grupos.Count, pesquisa, DateTime.Now.ToString());

            return grupos;

        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            GrupoVeiculo grupoVeiculo = grupoVeiculoRepository.SelecionarPorId(id);

            if (grupoVeiculo == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O GRUPO DE VEÍCULO ID {Id} | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("GRUPO DE VEÍCULO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());

            return grupoVeiculo;

        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS GRUPOS VEÍCULOS | {DataEHora}", DateTime.Now.ToString());

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoRepository.SelecionarTodos();

            if (grupoVeiculos.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) | {DataEHora}", grupoVeiculos.Count, DateTime.Now.ToString());

            return grupoVeiculos;
        }
    }
}
