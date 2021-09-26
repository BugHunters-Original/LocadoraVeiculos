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

            logger.Debug($"Registrando cupom de desconto {desconto.Nome}...");

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                
                descontoRepository.Inserir(desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} registrado com sucesso!");

                return true;
            }
            else
            {
                logger.Error($"Não foi possível registrar o cupom de desconto: {desconto.Nome}.");

                return false;
            }
            
        }

        public bool EditarDesconto(int id, Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            logger.Debug($"Editando cupom de desconto {desconto.Nome}...");

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                descontoRepository.Editar(id, desconto);

                logger.Debug($"Cupom de desconto {desconto.Nome} Editando com sucesso!");

                return true;
            }
            else
            {
                logger.Error($"Não foi possível editar o cupom de desconto: {desconto.Nome}.");

                return false;
            }        
        }

        public bool ExcluirDesconto(int id)
        {
            logger.Debug($"Excluindo o desconto ID: {id}.");

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
            logger.Debug($"Selecionando o Cupom de desconto ID: {id}.");

            Desconto desconto =  descontoRepository.SelecionarPorId(id);

            if (desconto == null)
                logger.Warning($"Não foi possível encontrar o Cupom de desconto com ID: {id}");
            else
                logger.Debug($"Selecionou o Cupom de desconto ID: {id}, NOME: {desconto.Nome}.");

            return desconto;
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            logger.Debug($"Selecionando todos os Cupons de descontos.");

            List<Desconto> desconto = descontoRepository.SelecionarTodos();

            if(desconto.Count == 0)
                logger.Warning($"Não há Cupons de descontos cadastrados");
            else
                logger.Debug($"Selecionou os {desconto.Count} Cupons de descontos existentes.");

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

        public List<Desconto> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            return descontoRepository.SelecionarPesquisa(comboBox, pesquisa);
        }
    }
}
