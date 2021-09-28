using LocadoraDeVeiculos.Dominio.ParceiroModule;
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

        private readonly Logger logger;

        public ParceiroDAO(Logger log)
        {
            logger = log;
        }

        public void Inserir(Parceiro parceiro)
        {
            try
            {
                parceiro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(parceiro));
                logger.Information("SUCESSO AO INSERIR PARCEIRO ID: {Id} | DATA: {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR PARCEIRO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", parceiro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }
        public void Editar(int id, Parceiro parceiro)
        {
            try
            {
                parceiro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(parceiro));

                logger.Information("SUCESSO AO EDITAR PARCEIRO ID: {Id} | DATA: {DataEHora}", parceiro.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR PARCEIRO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", parceiro.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));

                logger.Information("SUCESSO AO REMOVER PARCEIRO ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER PARCEIRO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

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
                    logger.Debug("SUCESSO AO SELECIONAR PARCEIRO ID: {Id} | DATA: {DataEHora}", parceiro.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR PARCEIRO ID: {Id} | DATA: {DataEHora}", parceiro.Id, DateTime.Now.ToString());

                return parceiro;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR PARCEIRO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }
        public List<Parceiro> SelecionarTodos()
        {
            try
            {
                List<Parceiro> parceiro = Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);

                if (parceiro != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS PARCEIROS | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS PARCEIROS | DATA: {DataEHora}", DateTime.Now.ToString());

                return parceiro;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS PARCEIROS | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }
        public List<Parceiro> SelecionarPesquisa(string coluna, string pesquisa)
        {
            try
            {
                string sql = sqlSelecionarParceiro.Replace("COLUNADEPESQUISA", coluna);
                List<Parceiro> parceiro = Db.GetAll(sql, ConverterEmParceiro, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (parceiro != null)
                    logger.Debug("SUCESSO AO SELECIONAR PARCEIRO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR PARCEIRO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());

                return parceiro;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR PARCEIRO | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

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
