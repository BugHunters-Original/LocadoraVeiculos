using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using log4net;
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
        private readonly ILog logger;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository, ILog logger)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
            this.logger = logger;
        }

        public void RegistrarNovoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando grupo veículo {grupoVeiculo}...");

                grupoVeiculoRepository.Inserir(grupoVeiculo);

                logger.Debug($"Grupo Veículo {grupoVeiculo} registrado com sucesso!");
            }

        }

        public void EditarNovoGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo)
        {

            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {grupoVeiculo.NomeTipo}...");

                grupoVeiculoRepository.Editar(id, grupoVeiculo);

                logger.Debug($"Grupo Veículo {grupoVeiculo.NomeTipo} editando com sucesso!");
            }
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
            return grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return grupoVeiculoRepository.SelecionarPorId(id);
        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            return grupoVeiculoRepository.SelecionarTodos();
        }
    }
}
