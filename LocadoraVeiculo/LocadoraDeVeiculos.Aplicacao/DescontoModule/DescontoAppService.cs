using LocadoraDeVeiculos.Dominio.DescontoModule;
using Serilog.Core;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.DescontoModule
{
    public class DescontoAppService
    {
        private readonly IDescontoRepository descontoRepository;
        private readonly Logger logger;

        public DescontoAppService(IDescontoRepository descontoRepo, Logger logger)
        {
            descontoRepository = descontoRepo;
            this.logger = logger;
        }


        public bool RegistrarNovoDesconto(Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando cupom de desconto {desconto.Nome}...");

                descontoRepository.Inserir(desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} registrado com sucesso!");

                return true;
            }

            return false;
        }

        public bool EditarDesconto(int id, Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando cupom de desconto {desconto.Nome}...");

                descontoRepository.Editar(id, desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} Editando com sucesso!");

                return true;
            }

            return false;
        }

        public List<Desconto> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return descontoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }

        public bool ExcluirDesconto(int id)
        {
            var desconto = descontoRepository.SelecionarPorId(id);
            var excluiu = descontoRepository.Excluir(id);

            if (excluiu)
                logger.Debug($"Excluiu Cupom de desconto {desconto.Codigo} com ID {desconto.Id}!");
            else
                logger.Error($"Não excluiu Cupom de desconto {desconto.Codigo} com ID {desconto.Id}!");

            return excluiu;
        }

        public Desconto SelecionarPorId(int id)
        {
            Desconto desconto =  descontoRepository.SelecionarPorId(id);

            logger.Debug($"Selecionando desconto ID: {id}, NOME: {desconto.Nome}.");

            return desconto;
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            List<Desconto> desconto = descontoRepository.SelecionarTodos();

            if(desconto.Count == 0)
                logger.Debug($"Não há descontos cadastrados");
            else
                logger.Debug($"Selecionando todos os {desconto.Count} descontos.");

            return desconto;
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return descontoRepository.VerificarCodigoExistente(codigo);
        }
        public Desconto VerificarCodigoValido(string codigo)
        {
            return descontoRepository.VerificarCodigoValido(codigo);
        }
    }
}
