using LocadoraDeVeiculos.Dominio.ParceiroModule;
using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string RegistrarNovoParceiro(Parceiro parceiro)
        {
            string resultadoValidacaoDominio = parceiro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando parceiro {parceiro}...");

                parceiroRepository.InserirParceiro(parceiro);

                logger.Debug($"Parceiro {parceiro} registrado com sucesso!");
            }

            return resultadoValidacaoDominio;
        }
        public List<Parceiro> SelecionarTodosParceiros()
        {
            return parceiroRepository.SelecionarTodos();
        }
    }

}
