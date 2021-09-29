using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.DescontoModule
{
    public class DescontoDAO : IDescontoRepository
    {
        #region Queries
        private const string sqlInserirDesconto =
            @"INSERT INTO [TBDESCONTO]
                (
                    [CODIGO],       
                    [VALOR], 
                    [TIPO],
                    [VALIDADE],                    
                    [ID_PARCEIRO],                                                           
                    [MEIO],
                    [NOMECUPOM],
                    [VALORMINIMO],
                    [USOS]
                )
            VALUES
                (
                    @CODIGO,
                    @VALOR,
                    @TIPO,
                    @VALIDADE,
                    @ID_PARCEIRO,
                    @MEIO,
                    @NOMECUPOM,
                    @VALORMINIMO,
                    @USOS
                )";
        private const string sqlEditarDesconto =
            @" UPDATE [TBDESCONTO]
                SET 
                    [CODIGO] = @CODIGO, 
                    [VALOR] = @VALOR, 
                    [TIPO] = @TIPO,
                    [VALIDADE] = @VALIDADE, 
                    [ID_PARCEIRO] = @ID_PARCEIRO,
                    [MEIO] = @MEIO,
                    [NOMECUPOM] = @NOMECUPOM,
                    [VALORMINIMO] = @VALORMINIMO,
                    [USOS] = @USOS

                WHERE [ID] = @ID";
        private const string sqlExcluirDesconto =
            @"DELETE FROM [TBDESCONTO] 
                WHERE [ID] = @ID";
        private const string sqlSelecionarTodosDescontos =
            @"SELECT 
                    D.[ID],       
                    D.[CODIGO],       
                    D.[VALOR], 
                    D.[TIPO],
                    D.[VALIDADE],                    
                    D.[ID_PARCEIRO],                                                           
                    D.[MEIO],
                    D.[NOMECUPOM],
                    D.[VALORMINIMO],
                    D.[USOS],
                    P.[ID],
                    P.[NOME_PARCEIRO]
            FROM
                [TBDESCONTO] AS D INNER JOIN
                [TBPARCEIROS] AS P
            ON
                D.ID_PARCEIRO = P.ID";
        private const string sqlSelecionarDescontoPorId =
            @"SELECT 
                    D.[ID],       
                    D.[CODIGO],       
                    D.[VALOR], 
                    D.[TIPO],
                    D.[VALIDADE],                    
                    D.[ID_PARCEIRO],                                                           
                    D.[MEIO],
                    D.[NOMECUPOM],
                    D.[VALORMINIMO],
                    D.[USOS],
                    P.[ID],
                    P.[NOME_PARCEIRO]
            FROM
                [TBDESCONTO] AS D INNER JOIN
                [TBPARCEIROS] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[ID] = @ID";
        private const string sqlSelecionarDescontoPorCodigo =
            @"SELECT 
                    D.[ID],       
                    D.[CODIGO],       
                    D.[VALOR], 
                    D.[TIPO],
                    D.[VALIDADE],                    
                    D.[ID_PARCEIRO],                                                           
                    D.[MEIO],
                    D.[NOMECUPOM],
                    D.[VALORMINIMO],
                    D.[USOS],
                    P.[ID],
                    P.[NOME_PARCEIRO]
            FROM
                [TBDESCONTO] AS D INNER JOIN
                [TBPARCEIROS] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[CODIGO] = @CODIGO";
        private const string sqlExisteDesconto =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBDESCONTO]
            WHERE 
                [ID] = @ID";
        private const string sqlExisteCodigo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBDESCONTO]
            WHERE 
                [CODIGO] = @CODIGO";

        private const string sqlSelecionarDeconto =
            @"SELECT
                        
                    D.[ID],       
                    D.[CODIGO],       
                    D.[VALOR], 
                    D.[TIPO],
                    D.[VALIDADE],                    
                    D.[ID_PARCEIRO],                                                           
                    D.[MEIO],
                    D.[NOMECUPOM],
                    D.[VALORMINIMO],
                    D.[USOS],
                    P.[ID],
                    P.[NOME_PARCEIRO]

	                FROM
                    [TBDESCONTO] AS D INNER JOIN
                    [TBPARCEIROS] AS P
                    ON
                D.ID_PARCEIRO = P.ID

                    WHERE 
                        D.COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";
        #endregion

        public void Inserir(Desconto desconto)
        {
            try
            {
                desconto.Id = Db.Insert(sqlInserirDesconto, ObtemParametrosDesconto(desconto));

                Log.Logger.Information("SUCESSO AO INSERIR DESCONTO ID: {Id}  ", desconto.Id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO INSERIR DESCONTO ID: {Id}  ", desconto.Id );
            }
        }

        public void Editar(int id, Desconto desconto)
        {
            try
            {
                desconto.Id = id;
                Db.Update(sqlEditarDesconto, ObtemParametrosDesconto(desconto));

                Log.Logger.Information("SUCESSO AO EDITAR DESCONTO ID: {Id}  ", desconto.Id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR DESCONTO ID: {Id}  ", desconto.Id );
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirDesconto, AdicionarParametro("ID", id));

                Log.Logger.Information("SUCESSO AO REMOVER DESCONTO ID: {Id}  ", id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER DESCONTO ID: {Id}  ", id );

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteDesconto, AdicionarParametro("ID", id));
        }

        public Desconto VerificarCodigoValido(string codigo)
        {
            try
            {
                Desconto desconto = Db.Get(sqlSelecionarDescontoPorCodigo, ConverterEmDesconto, AdicionarParametro("CODIGO", codigo));

                if (desconto != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR DESCONTO ID: {Id}  ", desconto.Id );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR DESCONTO ID: {Id}  ", desconto.Id );

                return desconto;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR DESCONTO  " );

                return null;
            }
        }

        public bool VerificarCodigoExistente(string codigo)
        {
           return  Db.Exists(sqlExisteCodigo, AdicionarParametro("CODIGO", codigo));
        }

        public List<Desconto> SelecionarPesquisa(string coluna, string pesquisa)
        {
            try
            {
                string sql = sqlSelecionarDeconto.Replace("COLUNADEPESQUISA", coluna);
                List<Desconto> descontos = Db.GetAll(sql, ConverterEmDesconto, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (descontos != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR DESCONTO COM A PESQUISA: {Pesquisa}  ", pesquisa );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR DESCONTO COM A PESQUISA: {Pesquisa}  ", pesquisa );

                return descontos;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR DESCONTO  " );

                return null;
            }

        }

        public Desconto SelecionarPorId(int id)
        {
            try
            {
                Desconto desconto = Db.Get(sqlSelecionarDescontoPorId, ConverterEmDesconto, AdicionarParametro("ID", id));

                if (desconto != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR DESCONTO ID: {Id}  ", desconto.Id );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR DESCONTO ID: {Id}  ", desconto.Id );

                return desconto;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR DESCONTO ID: {Id}  ", id );

                return null;
            }
        }

        public List<Desconto> SelecionarTodos()
        {
            try
            {
                List<Desconto> descontos = Db.GetAll(sqlSelecionarTodosDescontos, ConverterEmDesconto);

                if (descontos != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS DESCONTOS  " );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS DESCONTOS  " );

                return descontos;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS DESCONTOS  ");

                return null;
            }
        }

        private Desconto ConverterEmDesconto(IDataReader reader)
        {
            var codigo = Convert.ToString(reader["CODIGO"]);
            var valor = Convert.ToDecimal(reader["VALOR"]);
            var tipo = Convert.ToString(reader["TIPO"]);
            var validade = Convert.ToDateTime(reader["VALIDADE"]);
            var meio = Convert.ToString(reader["MEIO"]);
            var nomeCupom = Convert.ToString(reader["NOMECUPOM"]);
            var valorMinimo = Convert.ToDecimal(reader["VALORMINIMO"]);
            var usos = Convert.ToInt32(reader["USOS"]);

            Parceiro parceiroDesconto = null;
            if (reader["ID_PARCEIRO"] != DBNull.Value)
            {
                var nome = Convert.ToString(reader["NOME_PARCEIRO"]);
                parceiroDesconto = new Parceiro(nome);
                parceiroDesconto.Id = Convert.ToInt32(reader["ID_PARCEIRO"]);
            }

            Desconto desconto = new Desconto(codigo, valor, tipo, validade, parceiroDesconto, meio, nomeCupom, valorMinimo, usos);

            desconto.Id = Convert.ToInt32(reader["ID"]);

            return desconto;
        }

        private Dictionary<string, object> ObtemParametrosDesconto(Desconto desconto)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", desconto.Id);
            parametros.Add("CODIGO", desconto.Codigo);
            parametros.Add("VALOR", desconto.Valor);
            parametros.Add("TIPO", desconto.Tipo);
            parametros.Add("VALIDADE", desconto.Validade);
            parametros.Add("ID_PARCEIRO", desconto.Parceiro.Id);
            parametros.Add("MEIO", desconto.Meio);
            parametros.Add("NOMECUPOM", desconto.Nome);
            parametros.Add("VALORMINIMO", desconto.ValorMinimo);
            parametros.Add("USOS", desconto.Usos);

            return parametros;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
