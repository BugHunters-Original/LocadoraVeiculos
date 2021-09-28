using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule
{
    

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

            logger.Debug("REGISTRANDO GRUPO DE VEÍCULOS {grupoVeiculoNome} ", grupoVeiculo.NomeTipo);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")            {
               

                grupoVeiculoRepository.Inserir(grupoVeiculo);

                logger.Debug("GRUPO DE VEÍCULO {grupoVeiculoNome} REGISTRADO COM SUCESSO", grupoVeiculo.NomeTipo);

               
            }

            else            
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

            

        }

        public void EditarNovoGrupoVeiculo(int id, GrupoVeiculo grupoVeiculo)
        {

            string resultadoValidacaoDominio = grupoVeiculo.Validar();

            logger.Debug("EDITANDO GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {               

                grupoVeiculoRepository.Editar(id, grupoVeiculo);

                logger.Debug("GRUPO VEÍCULO {grupoVeiculoNome} EDITADO COM SUCESSO", grupoVeiculo.NomeTipo);

                
            }

            else            
                logger.Error("NÃO FOI POSSÍVEL EDITAR GRUPO VEÍCULO {grupoVeiculoNome}", grupoVeiculo.NomeTipo);

               
            
        }

        public bool ExcluirGrupoVeiculo(int id)
        {
            logger.Debug("REMOVENDO GRUPO VEÍCULO{Id}", id);

           
            var excluiu = grupoVeiculoRepository.Excluir(id);

            if (excluiu)
                logger.Debug("GRUPO DE VEÍCULOS {Id} REMOVIDO COM SUCESSO", id);
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id}.", id);

            return excluiu;

        }

        public List<GrupoVeiculo> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO GRUPOS DE VEÍCULOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<GrupoVeiculo> grupos =  grupoVeiculoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (grupos.Count == 0)
                logger.Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", grupos.Count, pesquisa);

            return grupos;

        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id}", id);

            GrupoVeiculo grupoVeiculo = grupoVeiculoRepository.SelecionarPorId(id);

            if (grupoVeiculo == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O GRUPO DE VEÍCULO ID {Id}", grupoVeiculo.Id);
            else
                logger.Debug("GRUPO DE VEÍCULO ID {Id} SELECIONADO COM SUCESSO", grupoVeiculo.Id);

            return grupoVeiculo;
           
        }

        public List<GrupoVeiculo> SelecionarTodosGruposVeiculos()
        {
            logger.Debug("SELECIONANDO TODOS OS GRUPOS VEÍCULOS");

            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoRepository.SelecionarTodos();

            if (grupoVeiculos.Count == 0)
                logger.Information("NÃO HÁ GRUPOS DE VEÍCULOS CADASTRADOS");
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} GRUPO(S) DE VEÍCULO(S) EXISTENTE(S)", grupoVeiculos.Count);

            return grupoVeiculos;
        }
    }
}
