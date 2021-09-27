﻿using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.ServicoModule
{
    public class ServicoDAO : IServicoRepository
    {
        #region Queries
        private const string sqlInserirServico =
  @"INSERT INTO TBTAXASSERVICOS 
	                (
		                [NOME_TAXA], 
		                [PRECO_TAXA], 
		                [TIPO_CALCULO]
	                ) 
	                VALUES
	                (
                        @NOME_TAXA, 
                        @PRECO_TAXA,
                        @TIPO_CALCULO
	                )";

        private const string sqlEditarServico =
            @"UPDATE TBTAXASSERVICOS
                    SET
                        [NOME_TAXA] = @NOME_TAXA,
		                [PRECO_TAXA] = @PRECO_TAXA, 
		                [TIPO_CALCULO] = @TIPO_CALCULO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirServico =
            @"DELETE 
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarServicoPorId =
            @"SELECT
                        [ID],
		                [NOME_TAXA], 
		                [PRECO_TAXA], 
		                [TIPO_CALCULO]
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosServicos =
            @"SELECT
                        [ID],
		                [NOME_TAXA], 
		                [PRECO_TAXA], 
		                [TIPO_CALCULO]
	                FROM
                        TBTAXASSERVICOS";

        private const string sqlExisteServico =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAXASSERVICOS]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarTaxaServico =
         @"SELECT
                        
                        [ID],
		                [NOME_TAXA], 
		                [PRECO_TAXA], 
		                [TIPO_CALCULO]
	                FROM
                       TBTAXASSERVICOS
                    WHERE 
                        COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";
        #endregion

        private readonly Logger logger;

        public ServicoDAO(Logger log)
        {
            logger = log;
        }

        public void Inserir(Servico registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirServico, ObtemParametrosServico(registro));

                logger.Information("SUCESSO AO INSERIR SERVIÇO ID: {Id} | DATA: {DataEHora}", registro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR SERVIÇO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", registro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public void Editar(int id, Servico registro)
        {
            try
            {
                registro.Id = id;
                Db.Update(sqlEditarServico, ObtemParametrosServico(registro));

                logger.Information("SUCESSO AO EDITAR SERVIÇO ID: {Id} | DATA: {DataEHora}", registro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR SERVIÇO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", registro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirServico, AdicionarParametro("ID", id));

                logger.Information("SUCESSO AO REMOVER SERVIÇO ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER SERVIÇO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteServico, AdicionarParametro("ID", id));
        }

        public Servico SelecionarPorId(int id)
        {
            try
            {
                Servico servico = Db.Get(sqlSelecionarServicoPorId, ConverterEmServico, AdicionarParametro("ID", id));

                if (servico != null)
                    logger.Debug("SUCESSO AO SELECIONAR SERVIÇO ID: {Id} | DATA: {DataEHora}", servico.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR SERVIÇO ID: {Id} | DATA: {DataEHora}", servico.Id, DateTime.Now.ToString());

                return servico;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR SERVIÇO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<Servico> SelecionarTodos()
        {
            try
            {
                List<Servico> servico = Db.GetAll(sqlSelecionarTodosServicos, ConverterEmServico);

                if (servico != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS SERVIÇOS | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS SERVIÇOS | DATA: {DataEHora}", DateTime.Now.ToString());

                return servico;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS SERVIÇOS | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }
        private Dictionary<string, object> ObtemParametrosServico(Servico servico)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", servico.Id);
            parametros.Add("NOME_TAXA", servico.Nome);
            parametros.Add("PRECO_TAXA", servico.Preco);
            parametros.Add("TIPO_CALCULO", servico.TipoCalculo);

            return parametros;
        }

        public List<Servico> SelecionarPesquisa(string coluna, string pesquisa)
        {
            try
            {
                string sql = sqlSelecionarTaxaServico.Replace("COLUNADEPESQUISA", coluna);
                List<Servico> servico = Db.GetAll(sql, ConverterEmServico, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (servico != null)
                    logger.Debug("SUCESSO AO SELECIONAR SERVIÇO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR SERVIÇO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());

                return servico;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR SERVIÇO | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        private Servico ConverterEmServico(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME_TAXA"]);
            decimal? preco = Convert.ToDecimal(reader["PRECO_TAXA"]);
            int tipoCalculo = Convert.ToInt32(reader["TIPO_CALCULO"]);

            Servico servico = new Servico(nome, preco, tipoCalculo);

            servico.Id = id;

            return servico;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
