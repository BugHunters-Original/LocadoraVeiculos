using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
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

            LogSerilog.Logger.Aqui().Debug("REGISTRANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                parceiroRepository.Inserir(parceiro);

                LogSerilog.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} REGISTRADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool EditarParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            LogSerilog.Logger.Aqui().Debug("EDITANDO PARCEIRO {ParceiroNome}", parceiro.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                parceiroRepository.Editar(parceiro);

                LogSerilog.Logger.Aqui().Debug("PARCEIRO {ParceiroNome} EDITADO COM SUCESSO", parceiro.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR PARCEIRO {ParceiroNome}", parceiro.Nome);

                return false;
            }
        }

        public bool ExcluirParceiro(Parceiro parceiro)
        {
            LogSerilog.Logger.Aqui().Debug("REMOVENDO PARCEIRO {Id}", parceiro.Id);

            var excluiu = parceiroRepository.Excluir(parceiro);

            if (excluiu)
                LogSerilog.Logger.Aqui().Debug("PARCEIRO {Id} REMOVIDO COM SUCESSO", parceiro.Id);
            else
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER PARCEIRO {Id}.", parceiro.Id);

            return excluiu;
        }

        public Parceiro SelecionarPorId(int id)
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO O PARCEIRO ID: {Id}", id);

            var parceiro = parceiroRepository.GetById(id);

            if (parceiro == null)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR PARCEIRO ID {Id}", parceiro.Id);
            else
                LogSerilog.Logger.Aqui().Debug("PARCEIRO ID {Id} SELECIONADO COM SUCESSO", parceiro.Id);

            return parceiro;
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO TODOS OS PARCEIROS");

            List<Parceiro> parceiro = parceiroRepository.GetAll();

            if (parceiro.Count == 0)
                LogSerilog.Logger.Aqui().Information("NÃO HÁ PARCEIROS CADASTRADOS");
            else
                LogSerilog.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} PARCEIRO(S) EXISTENTE(S)", parceiro.Count);

            return parceiro;
        }
    }
}
