using LocadoraDeVeiculos.Dominio.DescontoModule;
using Serilog.Core;
using System;
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

            logger.Debug("REGISTRANDO CUPOM DE DESCONTO {DescontoNome} | {DataEHora} ", desconto.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                
                descontoRepository.Inserir(desconto);

                logger.Debug("CUPOM DE DESCONTO {DescontoNome} REGISTRADO COM SUCESSO | {DataEHora}", desconto.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR CUPOM DE DESCONTO {DescontoNome} | {DataEHora}", desconto.Nome, DateTime.Now.ToString());

                return false;
            }
            
        }

        public bool EditarDesconto(int id, Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            logger.Debug("EDITANDO CUPOM DE DESCONTO {DescontoNome} | {DataEHora} ", desconto.Nome, DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                descontoRepository.Editar(id, desconto);

                logger.Debug("CUPOM DE DESCONTO {DescontoNome} EDITADO COM SUCESSO | {DataEHora}", desconto.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR CUPOM DE DESCONTO {DescontoNome} | {DataEHora}", desconto.Nome, DateTime.Now.ToString());

                return false;
            }        
        }

        public bool ExcluirDesconto(int id)
        {
           

            logger.Debug("REMOVENDO CUPOM DE DESCONTO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var desconto = descontoRepository.SelecionarPorId(id);

            var excluiu = descontoRepository.Excluir(id);

            if (excluiu)
                logger.Debug("CUPOM DE DESCONTO {Id} REMOVIDO COM SUCESSO | {DataEHora}", desconto.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id} | {DataEHora}.", desconto.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public Desconto SelecionarPorId(int id)
        {
            logger.Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            Desconto desconto =  descontoRepository.SelecionarPorId(id);

            if (desconto == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO ID {Id} | {DataEHora}", desconto.Id, DateTime.Now.ToString());
            else
                logger.Debug("CUPOM DE DESCONTO ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", desconto.Id, DateTime.Now.ToString());

            return desconto;
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            logger.Debug("SELECIONANDO TODOS OS CUPONS DE DESCONTOS | {DataEHora}", DateTime.Now.ToString());

            List<Desconto> desconto = descontoRepository.SelecionarTodos();

            if(desconto.Count == 0)
                logger.Information("NÃO HÁ CUPONS DE DESCONTOS CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} CUPOM(NS) DE DESCONTO(S) EXISTENTE(S) | {DataEHora}", desconto.Count, DateTime.Now.ToString());

            return desconto;
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            logger.Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} EXISTE | {DataEHora}", codigo, DateTime.Now.ToString());

            var verificou =  descontoRepository.VerificarCodigoExistente(codigo);

            if (!verificou)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} | {DataEHora}", codigo, DateTime.Now.ToString());
            else
                logger.Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO | {DataEHora}", codigo, DateTime.Now.ToString());

            return verificou;


        }
        public Desconto VerificarCodigoValido(string codigo)
        {
            logger.Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} É VÁLIDO | {DataEHora}", codigo, DateTime.Now.ToString());

            Desconto desconto = descontoRepository.VerificarCodigoValido(codigo);

            if (desconto == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} | {DataEHora}", codigo, DateTime.Now.ToString());
            else
                logger.Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO | {DataEHora}", codigo, DateTime.Now.ToString());

            return desconto;
        }

        public List<Desconto> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Debug("SELECIONADO CUPONS DE DESCONTOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());

            List<Desconto> descontos = descontoRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (descontos.Count == 0)
                logger.Information("NÃO HÁ CUPONS DE DESCONTOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", pesquisa, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} CUPOM(NS) DE DESCONTO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa} | {DataEHora}", descontos.Count, pesquisa, DateTime.Now.ToString());

            return descontos;
        }
    }
}
