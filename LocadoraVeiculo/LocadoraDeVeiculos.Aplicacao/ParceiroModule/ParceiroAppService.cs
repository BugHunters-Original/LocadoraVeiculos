﻿using LocadoraDeVeiculos.Dominio.ParceiroModule;
using log4net;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService
    {
        private readonly IParceiroRepository parceiroRepository;
        private readonly ILog logger;

        public ParceiroAppService(IParceiroRepository parceiroRepo, ILog logger)
        {
            parceiroRepository = parceiroRepo;
            this.logger = logger;
        }

        public void RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando parceiro {parceiro}...");

                parceiroRepository.Inserir(parceiro);

                logger.Debug($"Parceiro {parceiro} registrado com sucesso!");
            }
        }

        public void EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {parceiro.Nome}...");

                parceiroRepository.Editar(id, parceiro);

                logger.Debug($"Funcionário {parceiro.Nome} Editando com sucesso!");
            }
        }

        public bool ExcluirParceiro(int id)
        {
            return parceiroRepository.Excluir(id);
        }

        public List<Parceiro> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return parceiroRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public Parceiro SelecionarPorId(int id)
        {
            return parceiroRepository.SelecionarPorId(id);
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            return parceiroRepository.SelecionarTodos();
        }
    }
}
