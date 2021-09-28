using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
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

            logger.Aqui().Debug("REGISTRANDO CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                
                descontoRepository.Inserir(desconto);

                logger.Aqui().Debug("CUPOM DE DESCONTO {DescontoNome} REGISTRADO COM SUCESSO", desconto.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

                return false;
            }
            
        }

        public bool EditarDesconto(int id, Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            logger.Aqui().Debug("EDITANDO CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                descontoRepository.Editar(id, desconto);

                logger.Aqui().Debug("CUPOM DE DESCONTO {DescontoNome} EDITADO COM SUCESSO", desconto.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

                return false;
            }        
        }

        public bool ExcluirDesconto(int id)
        {        
            logger.Aqui().Debug("REMOVENDO CUPOM DE DESCONTO {Id}", id);

            var desconto = descontoRepository.SelecionarPorId(id);

            var excluiu = descontoRepository.Excluir(id);

            if (excluiu)
                logger.Aqui().Debug("CUPOM DE DESCONTO {Id} REMOVIDO COM SUCESSO", desconto.Id);
            else
                logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id}.", desconto.Id);

            return excluiu;
        }

        public Desconto SelecionarPorId(int id)
        {
            logger.Aqui().Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id}", id);

            Desconto desconto =  descontoRepository.SelecionarPorId(id);

            if (desconto == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO ID {Id}", desconto.Id);
            else
                logger.Aqui().Debug("CUPOM DE DESCONTO ID {Id} SELECIONADO COM SUCESSO", desconto.Id);

            return desconto;
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            logger.Aqui().Debug("SELECIONANDO TODOS OS CUPONS DE DESCONTOS");

            List<Desconto> desconto = descontoRepository.SelecionarTodos();

            if(desconto.Count == 0)
                logger.Aqui().Information("NÃO HÁ CUPONS DE DESCONTOS CADASTRADOS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CUPOM(NS) DE DESCONTO(S) EXISTENTE(S)", desconto.Count);

            return desconto;
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            logger.Aqui().Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} EXISTE", codigo);

            var verificou =  descontoRepository.VerificarCodigoExistente(codigo);

            if (!verificou)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo}", codigo);
            else
                logger.Aqui().Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO", codigo);

            return verificou;


        }
        public Desconto VerificarCodigoValido(string codigo)
        {
            logger.Aqui().Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} É VÁLIDO", codigo);

            Desconto desconto = descontoRepository.VerificarCodigoValido(codigo);

            if (desconto == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo}", codigo);
            else
                logger.Aqui().Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO", codigo);

            return desconto;
        }

        public List<Desconto> SelecionarPesquisa(string comboBox, string pesquisa)
        {
            logger.Aqui().Debug("SELECIONADO CUPONS DE DESCONTOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);

            List<Desconto> descontos = descontoRepository.SelecionarPesquisa(comboBox, pesquisa);


            if (descontos.Count == 0)
                logger.Aqui().Information("NÃO HÁ CUPONS DE DESCONTOS CADASTRADOS DE ACORDO COM A PESQUISA {Pesquisa}", pesquisa);
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CUPOM(NS) DE DESCONTO(S) EXISTENTE(S) DE ACORDO COM A PESQUISA {Pesquisa}", descontos.Count, pesquisa);

            return descontos;
        }
    }
}
