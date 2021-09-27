using LocadoraDeVeiculos.Dominio.ServicoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ServicoModule
{
    public class ServicoAppService
    {
        private readonly IServicoRepository taxaServicoRepository;
        private readonly Logger logger;

        public ServicoAppService(IServicoRepository taxaServicoRepo, Logger logger)
        {
            taxaServicoRepository = taxaServicoRepo;
            this.logger = logger;
        }

        public bool InserirServico(Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            logger.Debug("REGISTRANDO SERVIÇO {ServicoNome} | {DataEHora} ", servico.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                taxaServicoRepository.Inserir(servico);

                logger.Debug("SERVIÇO {ServicoNome} REGISTRADO COM SUCESSO | {DataEHora}", servico.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR SERVIÇO {ServicoNome} | {DataEHora}", servico.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool EditarServico(int id, Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            logger.Debug("EDITANDO SERVIÇO {ServicoNome} | {DataEHora} ", servico.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                taxaServicoRepository.Editar(id, servico);

                logger.Debug("SERVIÇO {ServicoNome} EDITADO COM SUCESSO | {DataEHora}", servico.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR SERVIÇO {ServicoNome} | {DataEHora}", servico.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool ExcluirServico(int id)
        {
            logger.Debug("REMOVENDO SERVIÇO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var parceiro = taxaServicoRepository.SelecionarPorId(id);

            var excluiu = taxaServicoRepository.Excluir(id);

            if (excluiu)
                logger.Debug("SERVIÇO {Id} REMOVIDO COM SUCESSO | {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER SERVIÇO {Id} | {DataEHora}.", parceiro.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public List<Servico> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO SERVIÇO DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Servico> servicos = taxaServicoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (servicos.Count == 0)
                logger.Information("NÃO HÁ SERVIÇOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", servicos.Count, pesquisa, DateTime.Now.ToString());

            return servicos;
        }

        public Servico SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O SERVIÇO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var servico = taxaServicoRepository.SelecionarPorId(id);

            if (servico == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR SERVIÇO ID {Id} | {DataEHora}", servico.Id, DateTime.Now.ToString());
            else
                logger.Debug("SERVIÇO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", servico.Id, DateTime.Now.ToString());

            return servico;
        }

        public List<Servico> SelecionarTodosServicos()
        {
            logger.Debug("SELECIONANDO TODOS OS SERVIÇOS | {DataEHora}", DateTime.Now.ToString());

            List<Servico> servicos = taxaServicoRepository.SelecionarTodos();

            if (servicos.Count == 0)
                logger.Information("NÃO HÁ SERVIÇOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S) | {DataEHora}", servicos.Count, DateTime.Now.ToString());

            return servicos;
        }
    }
}
