using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{
    public class GrupoVeiculoAppService : IGrupoVeiculoAppService
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
        }

        public bool Inserir(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO GRUPO DE VEÍCULOS {grupoVeiculoNome} | {DataEHora} ", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.Inserir(grupoVeiculo);

                Serilogger.Logger.Aqui().Debug("GRUPO DE VEÍCULO {grupoVeiculoNome} REGISTRADO COM SUCESSO", grupoVeiculo.NomeTipo);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

                return false;
            }
        }

        public bool Editar(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO GRUPO VEÍCULO {grupoVeiculoNome} | {DataEHora} ", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.Editar(grupoVeiculo);

                Serilogger.Logger.Aqui().Debug("GRUPO VEÍCULO {grupoVeiculoNome} EDITADO COM SUCESSO", grupoVeiculo.NomeTipo);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

                return false;
            }
        }

        public bool Excluir(GrupoVeiculo grupoVeiculo)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO GRUPO VEÍCULO{Id} | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());

            var excluiu = grupoVeiculoRepository.Excluir(grupoVeiculo);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("GRUPO DE VEÍCULOS {Id} REMOVIDO COM SUCESSO | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id} | {DataEHora}.", grupoVeiculo.Id, DateTime.Now.ToString());

            return excluiu;

        }



        public GrupoVeiculo GetById(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            GrupoVeiculo grupoVeiculo = grupoVeiculoRepository.GetById(id);

            if (grupoVeiculo == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O GRUPO DE VEÍCULO ID {Id} | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            else
                Serilogger.Logger.Aqui().Debug("GRUPO DE VEÍCULO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());

            return grupoVeiculo;

        }

        public List<GrupoVeiculo> GetAll()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS GRUPOS VEÍCULOS | {DataEHora}", DateTime.Now.ToString());

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoRepository.GetAll();

            if (grupoVeiculos.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) | {DataEHora}", grupoVeiculos.Count, DateTime.Now.ToString());

            return grupoVeiculos;
        }
    }
}
