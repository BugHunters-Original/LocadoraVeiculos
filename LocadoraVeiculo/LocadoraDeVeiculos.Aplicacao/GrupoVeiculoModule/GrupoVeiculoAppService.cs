using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{
    public class ResultadoOperacao
    {
        public bool sucesso;
        public string mensagem;
    }

    public class GrupoVeiculoAppService
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;
        private readonly Logger logger;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository, Logger logger)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
            this.logger = logger;
        }

        public void RegistrarNovoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            logger.Debug($"REGISTRANDO GRUPO VEÍCULO {grupoVeiculo}...");

            if (resultadoValidacaoDominio == "ESTA_VALIDO")            {
               

                grupoVeiculoRepository.Inserir(grupoVeiculo);

                logger.Debug("GRUPO DE VEÍCULO {grupoVeiculoNome} REGISTRADO COM SUCESSO | {DataEHora}", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

               
            }

            else            
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR GRUPO VEÍCULO {grupoVeiculoNome} | {DataEHora}", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

            

        }

        public void EditarNovoGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo)
        {

            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            logger.Debug("EDITANDO GRUPO VEÍCULO {grupoVeiculoNome} | {DataEHora} ", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {               

                grupoVeiculoRepository.Editar(id, grupoVeiculo);

                logger.Debug("GRUPO VEÍCULO {grupoVeiculoNome} EDITADO COM SUCESSO | {DataEHora}", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

                
            }

            else            
                logger.Error("NÃO FOI POSSÍVEL EDITAR GRUPO VEÍCULO {grupoVeiculoNome} | {DataEHora}", grupoVeiculo.NomeTipo, DateTime.Now.ToString());

               
            
        }

        public ResultadoOperacao ExcluirGrupoVeiculo(GrupoVeiculo grupoVeiculoSelecionado)
        {
            ResultadoOperacao resultadoOperacao = new();
            resultadoOperacao.sucesso = grupoVeiculoRepository.Excluir(grupoVeiculoSelecionado.Id);            

            if (resultadoOperacao.sucesso)
            {
                resultadoOperacao.mensagem = $"Grupo de Veiculos: [{grupoVeiculoSelecionado.NomeTipo}] removido com sucesso";
                logger.Debug($"Excluiu Grupo Veículo {grupoVeiculoSelecionado.NomeTipo} com ID {grupoVeiculoSelecionado.Id}!");
            }
            else
            {
                resultadoOperacao.mensagem = "Erro ao tentar excluir um grupo de veículos. Verifique se esse registro nao tem um veículo relacionado a ele";
                logger.Error($"Não excluiu Grupo Veículo {grupoVeiculoSelecionado.NomeTipo} com ID {grupoVeiculoSelecionado.Id}!");
            }

            return resultadoOperacao;
        }

        public List<GrupoVeiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO GRUPOS DE VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<GrupoVeiculo> grupos =  grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (grupos.Count == 0)
                logger.Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", grupos.Count, pesquisa, DateTime.Now.ToString());

            return grupos;

        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            GrupoVeiculo grupoVeiculo = grupoVeiculoRepository.SelecionarPorId(id);

            if (grupoVeiculo == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O GRUPO DE VEÍCULO ID {Id} | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            else
                logger.Debug("GRUPO DE VEÍCULO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());

            return grupoVeiculo;
           
        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            logger.Debug("SELECIONANDO TODOS OS GRUPOS VEÍCULOS | {DataEHora}", DateTime.Now.ToString());

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoRepository.SelecionarTodos();

            if (grupoVeiculos.Count == 0)
                logger.Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) | {DataEHora}", grupoVeiculos.Count, DateTime.Now.ToString());

            return grupoVeiculos;
        }
    }
}
