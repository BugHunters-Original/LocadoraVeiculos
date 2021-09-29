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

            Log.Logger.Aqui().Debug("REGISTRANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                Log.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            Log.Logger.Aqui().Debug("EDITANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(id, parceiro);

                Log.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool ExcluirParceiro(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO PARCEIRO {Id}", id);

            var parceiro = parceiroRepository.SelecionarPorId(id);

            var excluiu = parceiroRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id}.", parceiro.Id);

            return excluiu;
        }

        public Parceiro SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O PARCEIRO ID: {Id}", id);

            var parceiro = parceiroRepository.SelecionarPorId(id);

            if (parceiro == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id}", parceiro.Id);
            else
                Log.Logger.Aqui().Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO", parceiro.Id);

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS PARCEIROS");

            List<Parceiro> parceiro = parceiroRepository.SelecionarTodos();

            if (parceiro.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ PARCEIROS CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S)", parceiro.Count);

            return parceiro;
        }
    }
}
