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

            logger.Debug("REGISTRANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                taxaServicoRepository.Inserir(servico);

                logger.Debug("SERVIÇO {ServicoNome} REGISTRADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool EditarServico(int id, Servico servico)
        {
            string resultadoValidacaoDominio = servico.Validar();

            logger.Debug("EDITANDO SERVIÇO {ServicoNome}", servico.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                taxaServicoRepository.Editar(id, servico);

                logger.Debug("SERVIÇO {ServicoNome} EDITADO COM SUCESSO", servico.Nome);

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR SERVIÇO {ServicoNome}", servico.Nome);

                return false;
            }
        }

        public bool ExcluirServico(int id)
        {
            logger.Debug("REMOVENDO SERVIÇO {Id}", id);

            var parceiro = taxaServicoRepository.SelecionarPorId(id);

            var excluiu = taxaServicoRepository.Excluir(id);

            if (excluiu)
                logger.Debug("SERVIÇO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER SERVIÇO {Id}.", parceiro.Id);

            return excluiu;
        }

        public List<Servico> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO SERVIÇO DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Servico> servicos = taxaServicoRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (servicos.Count == 0)
                logger.Information("NÃO HÁ SERVIÇOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", servicos.Count, pesquisa);

            return servicos;
        }

        public Servico SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O SERVIÇO ID: {Id}", id);

            var servico = taxaServicoRepository.SelecionarPorId(id);

            if (servico == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR SERVIÇO ID {Id}", servico.Id);
            else
                logger.Debug("SERVIÇO ID {Id} SELECIONADO COM SUCESSO", servico.Id);

            return servico;
        }

        public List<Servico> SelecionarTodosServicos()
        {
            logger.Debug("SELECIONANDO TODOS OS SERVIÇOS");

            List<Servico> servicos = taxaServicoRepository.SelecionarTodos();

            if (servicos.Count == 0)
                logger.Information("NÃO HÁ SERVIÇOS CADASTRADOS");
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} SERVIÇO(S) EXISTENTE(S)", servicos.Count);

            return servicos;
        }
    }
}
