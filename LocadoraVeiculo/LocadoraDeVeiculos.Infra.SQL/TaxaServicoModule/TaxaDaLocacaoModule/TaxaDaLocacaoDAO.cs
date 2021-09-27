﻿using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.SQL.DescontoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.ServicoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.TaxaDaLocacaoModule
{
    public class TaxaDaLocacaoDAO : ITaxaRepository
    {
        #region Queries
        private const string sqlInserirTaxaLocacao =
       @"INSERT INTO TBTAXASDALOCACAO
	                (   
		                [ID_LOCACAO], 
		                [ID_TAXA] 		                
	                ) 
	                VALUES
	                (
		                @ID_LOCACAO, 
		                @ID_TAXA		              
	                )";

        private const string sqlExcluirTaxaLocacao =
            @"DELETE 
	                FROM
                        TBTAXASDALOCACAO
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";

        private const string sqlEditarTaxaLocacao =
            @"UPDATE TBTAXASDALOCACAO
                    SET
		                [ID_LOCACAO] = @ID_LOCACAO, 
		                [ID_TAXA] = @ID_TAXA
		                
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";

        private const string sqlSelecionarTaxaLocacaoPorId =
            @"SELECT    
                        T.[ID],
		                T.[ID_LOCACAO], 
		                T.[ID_TAXA],
                        L.[ID_CONDUTOR], 
		                L.[ID_CLIENTELOCADOR], 
		                L.[ID_VEICULO],
		                L.[ID_DESCONTO],
                        L.[DATA_SAIDA], 
		                L.[DATA_RETORNOESPERADO],
                        L.[PLANO],
                        L.[TIPOCLIENTE],
                        L.[PRECOSERVICOS],
                        L.[DIAS],
                        L.[STATUS],    
                        L.[PRECOCOMBUSTIVEL],    
                        L.[PRECOPLANO],    
                        L.[PRECOTOTAL]
	                FROM
                        TBTAXASDALOCACAO AS T INNER JOIN
                        TBLOCACAO AS L
                      ON
                        L.ID = T.ID_LOCACAO
                   WHERE 
                        T.ID_LOCACAO = @ID_LOCACAOTAXA";

        private const string sqlSelecionarTaxaLocacaoEspecifica =
           @"SELECT                
		                [ID_LOCACAO], 
		                [ID_TAXA]
		                
	                FROM
                        TBTAXASDALOCACAO
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";
        #endregion

        private readonly Logger logger;

        public TaxaDaLocacaoDAO(Logger log)
        {
            logger = log;
        }

        public void InserirTaxa(TaxaDaLocacao registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirTaxaLocacao, ObtemParametrosTaxaLocacao(registro));

                logger.Information("SUCESSO AO INSERIR TAXA ID: {Id} | DATA: {DataEHora}", registro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR TAXA ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", registro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public void EditarTaxa(int id, TaxaDaLocacao registro)
        {
            try
            {
                registro.Id = id;
                Db.Update(sqlEditarTaxaLocacao, ObtemParametrosTaxaLocacao(registro));

                logger.Information("SUCESSO AO EDITAR TAXA ID: {Id} | DATA: {DataEHora}", registro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR TAXA ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", registro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public bool ExcluirTaxa(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTaxaLocacao, AdicionarParametro("ID_LOCACAO", id));

                logger.Information("SUCESSO AO REMOVER TAXA ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER TAXA ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public TaxaDaLocacao SelecionarPorId(int id)
        {
            try
            {
                TaxaDaLocacao taxa = Db.Get(sqlSelecionarTaxaLocacaoPorId, ConverterEmTaxaLocacao, AdicionarParametro("ID", id));

                if (taxa != null)
                    logger.Debug("SUCESSO AO SELECIONAR TAXA ID: {Id} | DATA: {DataEHora}", taxa.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TAXA ID: {Id} | DATA: {DataEHora}", taxa.Id, DateTime.Now.ToString());

                return taxa;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TAXA ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<TaxaDaLocacao> SelecionarTodos()
        {
            try
            {
                List<TaxaDaLocacao> taxa = Db.GetAll(sqlSelecionarTaxaLocacaoEspecifica, ConverterEmTaxaLocacao);

                if (taxa != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODAS AS TAXAS | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS TAXAS | DATA: {DataEHora}", DateTime.Now.ToString());

                return taxa;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS TAXAS | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id)
        {
            try
            {
                List<TaxaDaLocacao> taxa = Db.GetAll(sqlSelecionarTaxaLocacaoPorId, ConverterEmTaxaLocacao, AdicionarParametro("ID_LOCACAOTAXA", id));

                if (taxa != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO | DATA: {DataEHora}", DateTime.Now.ToString());

                return taxa;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS TAXAS DE UMA LOCAÇÃO | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<TaxaDaLocacao> SelecionarPesquisa(string coluna, string pesquisa)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosTaxaLocacao(TaxaDaLocacao taxaLocacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxaLocacao.Id);
            parametros.Add("ID_LOCACAO", taxaLocacao.LocacaoEscolhida.Id);
            parametros.Add("ID_TAXA", taxaLocacao.TaxaLocacao.Id);

            return parametros;
        }

        private TaxaDaLocacao ConverterEmTaxaLocacao(IDataReader reader)
        {
            int id_taxa = Convert.ToInt32(reader["ID_TAXA"]);

            var controladorServico = new ServicoDAO(logger);
            Servico servico = controladorServico.SelecionarPorId(id_taxa);

            int tipoCliente = Convert.ToInt32(reader["TIPOCLIENTE"]);
            int idCondutor = Convert.ToInt32(reader["ID_CONDUTOR"]);
            int idClienteLocador = Convert.ToInt32(reader["ID_CLIENTELOCADOR"]);
            int idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);

            Desconto desconto = null;
            if (reader["ID_DESCONTO"] != DBNull.Value)
            {
                var controladorDesconto = new DescontoDAO(logger);
                int idDesconto = Convert.ToInt32(reader["ID_DESCONTO"]);
                desconto = controladorDesconto.SelecionarPorId(idDesconto);
            }

            DateTime dataSaida = Convert.ToDateTime(reader["DATA_SAIDA"]);
            DateTime dataRetorno = Convert.ToDateTime(reader["DATA_RETORNOESPERADO"]);
            string plano = Convert.ToString(reader["PLANO"]);
            int dias = Convert.ToInt32(reader["DIAS"]);
            string status = Convert.ToString(reader["STATUS"]);


            decimal? precoGas = null;
            if (reader["PRECOCOMBUSTIVEL"] != DBNull.Value)
                precoGas = Convert.ToDecimal(reader["PRECOCOMBUSTIVEL"]);

            decimal? precoPlano = null;
            if (reader["PRECOPLANO"] != DBNull.Value)
                precoPlano = Convert.ToDecimal(reader["PRECOPLANO"]);

            decimal? precoTotal = null;
            if (reader["PRECOTOTAL"] != DBNull.Value)
                precoTotal = Convert.ToDecimal(reader["PRECOTOTAL"]);

            decimal? precoServico = null;
            if (reader["PRECOSERVICOS"] != DBNull.Value)
                precoServico = Convert.ToDecimal(reader["PRECOSERVICOS"]);

            var controladorCPF = new ClienteCPFDAO(logger);
            var controladorCNPJ = new ClienteCNPJDAO(logger);
            VeiculoDAO controladorVeiculo = new();

            ClienteCPF condutor = controladorCPF.SelecionarPorId(idCondutor);
            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);

            ClienteBase clienteLocador;

            if (tipoCliente == 1)
                clienteLocador = controladorCNPJ.SelecionarPorId(idClienteLocador);
            else
                clienteLocador = controladorCPF.SelecionarPorId(idClienteLocador);



            Locacao locacao = new Locacao(clienteLocador, veiculo, desconto, condutor,
                                                    dataSaida, dataRetorno, plano, tipoCliente, precoServico,
                                                    dias, status, precoGas, precoPlano, precoTotal, null);


            TaxaDaLocacao taxaLocacao = new TaxaDaLocacao(servico, locacao);



            return taxaLocacao;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
