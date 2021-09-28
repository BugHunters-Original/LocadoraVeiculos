using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService
    {
        private readonly IParceiroRepository parceiroRepository;

        public ParceiroAppService(IParceiroRepository parceiroRepo)
        {
            parceiroRepository = parceiroRepo;
        }

        public bool RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            Log.Logger.Aqui().Debug("REGISTRANDO PARCEIRO {ParceiroNome} | {DataEHora} ", parceiro.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                Log.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome} | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            Log.Logger.Aqui().Debug("EDITANDO PARCEIRO {ParceiroNome} | {DataEHora} ", parceiro.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(id, parceiro);

                Log.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome} | {DataEHora}", parceiro.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool ExcluirParceiro(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO PARCEIRO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var parceiro = parceiroRepository.SelecionarPorId(id);

            var excluiu = parceiroRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO | {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id} | {DataEHora}.", parceiro.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public List<Parceiro> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            Log.Logger.Aqui().Debug("SELECIONADO PARCEIROS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Parceiro> parceiros = parceiroRepository.SelecionarPesquisa(comboBox, pesquisa);

            if (parceiros.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ PARCEIROS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", parceiros.Count, pesquisa, DateTime.Now.ToString());

            return parceiros;
        }

        public Parceiro SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O PARCEIRO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var parceiro = parceiroRepository.SelecionarPorId(id);

            if (parceiro == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id} | {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", parceiro.Id, DateTime.Now.ToString());

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS PARCEIROS | {DataEHora}", DateTime.Now.ToString());

            List<Parceiro> parceiro = parceiroRepository.SelecionarTodos();

            if (parceiro.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ PARCEIROS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S) | {DataEHora}", parceiro.Count, DateTime.Now.ToString());

            return parceiro;
        }
    }
}
