using LocadoraDeVeiculos.Dominio.ServicoModule;
using Serilog.Core;
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

        public void InserirServico(Servico registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando Serviço {registro.Nome}...");

                taxaServicoRepository.Inserir(registro);

                logger.Debug($"Serviço {registro.Nome} registrado com sucesso!");
            }
        }

        public void EditarServico(int id, Servico registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando Serviço {registro.Nome}...");

                taxaServicoRepository.Editar(id, registro);

                logger.Debug($"Serviço {registro.Nome} Editado com sucesso!");
            }
        }

        public bool ExcluirServico(int id)
        {
            var servico = taxaServicoRepository.SelecionarPorId(id);
            var excluiu = taxaServicoRepository.Excluir(id);

            if (excluiu)
                logger.Debug($"Excluiu Serviço {servico.Nome} com ID {servico.Id}!");
            else
                logger.Error($"Não excluiu Serviço {servico.Nome} com ID {servico.Id}!");

            return excluiu;
        }

        public List<Servico> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return taxaServicoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public Servico SelecionarPorId(int id)
        {
            return taxaServicoRepository.SelecionarPorId(id);
        }

        public List<Servico> SelecionarTodosServicos()
        {
            return taxaServicoRepository.SelecionarTodos();
        }
    }
}
