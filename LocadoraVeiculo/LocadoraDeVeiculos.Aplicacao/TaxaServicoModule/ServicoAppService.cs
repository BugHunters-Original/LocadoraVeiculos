using LocadoraDeVeiculos.Dominio.ServicoModule;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ServicoModule
{
    public class ServicoAppService
    {
        private readonly IServicoRepository taxaServicoRepository;
        private readonly ILog logger;

        public ServicoAppService(IServicoRepository taxaServicoRepo, ILog logger)
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
            return taxaServicoRepository.Excluir(id);
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
