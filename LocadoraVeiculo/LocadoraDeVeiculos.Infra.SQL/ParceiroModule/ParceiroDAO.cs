using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.ParceiroModule
{
    public class ParceiroDAO : IParceiroRepository
    {
        #region Queries
        private const string sqlInserirParceiro =
       @"INSERT INTO TBPARCEIROS
	                (
		                [NOME_PARCEIRO]
	                ) 
	                VALUES
	                (
                        @NOME_PARCEIRO
	                )";

        private const string sqlEditarParceiro =
            @"UPDATE TBPARCEIROS
                    SET
                        [NOME_PARCEIRO] = @NOME_PARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirParceiro =
            @"DELETE 
	                FROM
                        TBPARCEIROS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarParceiroPorId =
            @"SELECT
                        [ID],
		                [NOME_PARCEIRO]
	                FROM
                        TBPARCEIROS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosParceiros =
            @"SELECT
                        [ID],
		                [NOME_PARCEIRO]
	                FROM
                        TBPARCEIROS";

        private const string sqlExisteParceiro =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBPARCEIROS]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarParceiro =
         @"SELECT
                        [ID],
		                [NOME_PARCEIRO]
	                FROM
                       TBPARCEIROS
                    WHERE 
                        COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";
        #endregion

        public void Inserir(Parceiro parceiro)
        {
            try
            {
                parceiro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(parceiro));
                Log.Logger.Information("SUCESSO AO INSERIR PARCEIRO ID: {Id}  ", parceiro.Id );
            }
            catch (Exception ex)
            {
                 Log.Logger.Error(ex , "ERRO AO INSERIR PARCEIRO ID: {Id}  ", parceiro.Id );
            }
        }
        public void Editar(int id, Parceiro parceiro)
        {
            try
            {
                parceiro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(parceiro));

                Log.Logger.Information("SUCESSO AO EDITAR PARCEIRO ID: {Id}  ", parceiro.Id );
            }
            catch (Exception ex)
            {
                 Log.Logger.Error(ex , "ERRO AO EDITAR PARCEIRO ID: {Id}  ", parceiro.Id );
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));

                Log.Logger.Information("SUCESSO AO REMOVER PARCEIRO ID: {Id}  ", id );
            }
            catch (Exception ex)
            {
                 Log.Logger.Error(ex , "ERRO AO REMOVER PARCEIRO ID: {Id}  ", id );

                return false;
            }

            return true;
        }
        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteParceiro, AdicionarParametro("ID", id));
        }

        public Parceiro SelecionarPorId(int id)
        {
            try
            {
                Parceiro parceiro = Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));

                if (parceiro != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR PARCEIRO ID: {Id}  ", parceiro.Id );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR PARCEIRO ID: {Id}  ", parceiro.Id );

                return parceiro;

            }
            catch (Exception ex)
            {
                 Log.Logger.Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR PARCEIRO ID: {Id}  ", id );

                return null;
            }
        }
        public List<Parceiro> SelecionarTodos()
        {
            try
            {
                List<Parceiro> parceiro = Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);

                if (parceiro != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS PARCEIROS  " );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS PARCEIROS  " );

                return parceiro;
            }
            catch (Exception ex)
            {
                 Log.Logger.Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS PARCEIROS  " );

                return null;
            }
        }

        private Parceiro ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME_PARCEIRO"]);

            Parceiro parceiro = new Parceiro(nome);

            parceiro.Id = id;

            return parceiro;
        }
        private Dictionary<string, object> ObtemParametrosParceiro(Parceiro parceiro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", parceiro.Id);
            parametros.Add("NOME_PARCEIRO", parceiro.Nome);

            return parametros;
        }
        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

    }
}
