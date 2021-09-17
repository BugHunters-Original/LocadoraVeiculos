using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
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
                    [VALORMINIMO]
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
                    @VALORMINIMO
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
                    [VALORMINIMO] = @VALORMINIMO

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
            desconto.Id = Db.Insert(sqlInserirDesconto, ObtemParametrosDesconto(desconto));
        }

        public void Editar(int id, Desconto desconto)
        {
            desconto.Id = id;
            Db.Update(sqlEditarDesconto, ObtemParametrosDesconto(desconto));
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirDesconto, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
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
            return Db.Get(sqlSelecionarDescontoPorCodigo, ConverterEmDesconto, AdicionarParametro("CODIGO", codigo));
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return Db.Exists(sqlExisteCodigo, AdicionarParametro("CODIGO", codigo));
        }

        public List<Desconto> SelecionarPesquisa(string coluna, string pesquisa)
        {
            string sql = sqlSelecionarDeconto.Replace("COLUNADEPESQUISA", coluna);
            return Db.GetAll(sql, ConverterEmDesconto, AdicionarParametro("@SEGUNDAREF", pesquisa));
        }

        public Desconto SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarDescontoPorId, ConverterEmDesconto, AdicionarParametro("ID", id));
        }

        public List<Desconto> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosDescontos, ConverterEmDesconto);
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

            Parceiro parceiroDesconto = null;
            if (reader["ID_PARCEIRO"] != DBNull.Value)
            {
                var nome = Convert.ToString(reader["NOME_PARCEIRO"]);
                parceiroDesconto = new Parceiro(nome);
                parceiroDesconto.Id = Convert.ToInt32(reader["ID_PARCEIRO"]);
            }

            Desconto desconto = new Desconto(codigo, valor, tipo, validade, parceiroDesconto, meio, nomeCupom, valorMinimo);

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

            return parametros;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
