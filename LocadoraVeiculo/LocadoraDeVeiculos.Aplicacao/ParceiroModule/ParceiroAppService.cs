using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Serilog.Core;
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

        public void RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Information($"Registrando parceiro {parceiro}...");

                parceiroRepository.Inserir(parceiro);

                logger.Debug($"Parceiro {parceiro} registrado com sucesso!");
            }
        }

        public void EditarParceiro(int id, Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando parceiro {parceiro.Nome}...");

                parceiroRepository.Editar(id, parceiro);

                logger.Debug($"Parceiro {parceiro.Nome} Editando com sucesso!");
            }
        }

        public bool ExcluirParceiro(int id)
        {
            Parceiro parceiro = parceiroRepository.SelecionarPorId(id);
            var excluiu = parceiroRepository.Excluir(id);

            if (excluiu)
                logger.Debug($"Excluiu Parceiro {parceiro.Nome} com ID {parceiro.Id}!");
            else
                logger.Error($"Não excluiu Parceiro {parceiro.Nome} com ID {parceiro.Id}!");

            return excluiu;
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
