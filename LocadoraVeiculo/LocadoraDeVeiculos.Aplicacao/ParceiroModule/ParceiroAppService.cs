using LocadoraDeVeiculos.Dominio.ParceiroModule;
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

                parceiroRepository.InserirParceiro(parceiro);

                logger.Debug($"Parceiro {parceiro} registrado com sucesso!");
            }
        }

        public void EditarParceiro(int id, Parceiro funcionario)
        {
            string resultadoValidacaoDominio = funcionario.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando funcionário {funcionario.Nome}...");

                parceiroRepository.EditarParceiro(id, funcionario);

                logger.Debug($"Funcionário {funcionario.Nome} Editando com sucesso!");
            }
        }

        public bool ExcluirParceiro(int id)
        {
            return parceiroRepository.ExcluirParceiro(id);
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
