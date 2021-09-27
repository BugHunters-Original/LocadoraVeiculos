using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService
    {
        private readonly IParceiroRepository parceiroRepository;
        private readonly Logger logger;

        public ParceiroAppService(IParceiroRepository parceiroRepo, Logger logger)
        {
            parceiroRepository = parceiroRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            logger.Debug("REGISTRANDO PARCEIRO {ParceiroNome} | {DataEHora} ", parceiro.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                logger.Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome} | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            logger.Debug("EDITANDO PARCEIRO {ParceiroNome} | {DataEHora} ", parceiro.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(id, parceiro);

                logger.Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome} | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool ExcluirParceiro(int id)
        {
            logger.Debug("REMOVENDO PARCEIRO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var parceiro = parceiroRepository.SelecionarPorId(id);

            var excluiu = parceiroRepository.Excluir(id);

            if (excluiu)
                logger.Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO | {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id} | {DataEHora}.", parceiro.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public List<Parceiro> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO PARCEIROS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Parceiro> parceiros = parceiroRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (parceiros.Count == 0)
                logger.Information("NÃO HÁ PARCEIROS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", parceiros.Count, pesquisa, DateTime.Now.ToString());

            return parceiros;
        }

        public Parceiro SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O PARCEIRO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var parceiro = parceiroRepository.SelecionarPorId(id);

            if (parceiro == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id} | {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            else
                logger.Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", parceiro.Id, DateTime.Now.ToString());

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            logger.Debug("SELECIONANDO TODOS OS PARCEIROS | {DataEHora}", DateTime.Now.ToString());

            List<Parceiro> parceiro = parceiroRepository.SelecionarTodos();

            if (parceiro.Count == 0)
                logger.Information("NÃO HÁ PARCEIROS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S) | {DataEHora}", parceiro.Count, DateTime.Now.ToString());

            return parceiro;
        }
    }
}
