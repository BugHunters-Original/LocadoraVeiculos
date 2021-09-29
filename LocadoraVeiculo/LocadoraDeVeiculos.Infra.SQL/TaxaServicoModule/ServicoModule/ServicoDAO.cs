﻿using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
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


        public void Inserir(Servico registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirServico, ObtemParametrosServico(registro));

                Log.Logger.Information("SUCESSO AO INSERIR SERVIÇO ID: {Id}  ", registro.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO INSERIR SERVIÇO ID: {Id}  ", registro.Id);
            }
        }

        public void Editar(int id, Servico registro)
        {
            try
            {
                registro.Id = id;
                Db.Update(sqlEditarServico, ObtemParametrosServico(registro));

                Log.Logger.Information("SUCESSO AO EDITAR SERVIÇO ID: {Id}  ", registro.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR SERVIÇO ID: {Id}  ", registro.Id);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirServico, AdicionarParametro("ID", id));

                Log.Logger.Information("SUCESSO AO REMOVER SERVIÇO ID: {Id}  ", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER SERVIÇO ID: {Id}  ", id);

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
                    Log.Logger.Debug("SUCESSO AO SELECIONAR SERVIÇO ID: {Id}  ", servico.Id);
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR SERVIÇO ID: {Id}  ", servico.Id);

                return servico;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR SERVIÇO ID: {Id}  ", id);

                return null;
            }
        }

        public List<Servico> SelecionarTodos()
        {
            try
            {
                List<Servico> servico = Db.GetAll(sqlSelecionarTodosServicos, ConverterEmServico);

                if (servico != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS SERVIÇOS  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS SERVIÇOS  ");

                return servico;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS SERVIÇOS  ");

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
