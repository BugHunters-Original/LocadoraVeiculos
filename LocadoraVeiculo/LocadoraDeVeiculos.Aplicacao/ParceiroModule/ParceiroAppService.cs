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

            logger.Debug("REGISTRANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                logger.Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            logger.Debug("EDITANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(id, parceiro);

                logger.Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool ExcluirParceiro(int id)
        {
            logger.Debug("REMOVENDO PARCEIRO {Id}", id);

            var parceiro = parceiroRepository.SelecionarPorId(id);

            var excluiu = parceiroRepository.Excluir(id);

            if (excluiu)
                logger.Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id}.", parceiro.Id);

            return excluiu;
        }

        public List<Parceiro> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO PARCEIROS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Parceiro> parceiros = parceiroRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (parceiros.Count == 0)
                logger.Information("NÃO HÁ PARCEIROS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", parceiros.Count, pesquisa);

            return parceiros;
        }

        public Parceiro SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O PARCEIRO ID: {Id}", id);

            var parceiro = parceiroRepository.SelecionarPorId(id);

            if (parceiro == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id}", parceiro.Id);
            else
                logger.Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO", parceiro.Id);

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            logger.Debug("SELECIONANDO TODOS OS PARCEIROS");

            List<Parceiro> parceiro = parceiroRepository.SelecionarTodos();

            if (parceiro.Count == 0)
                logger.Information("NÃO HÁ PARCEIROS CADASTRADOS");
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S)", parceiro.Count);

            return parceiro;
        }
    }
}
