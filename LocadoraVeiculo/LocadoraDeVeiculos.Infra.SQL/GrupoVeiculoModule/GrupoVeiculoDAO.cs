using System;
using System.Collections.Generic;
using System.Data;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;

namespace LocadoraDeVeiculos.Infra.SQL.GrupoVeiculoModule
{
    public class GrupoVeiculoDAO : IGrupoVeiculoRepository
    {

        #region Queries
        private const string sqlInserirTipoGrupoVeiculo =
            @"INSERT INTO [TBTIPOVEICULO]
                (
                    [NOMETIPO],       
                    [VALOR_DIARIO_PDIARIO], 
                    [VALOR_KMRODADO_PDIARIO],
                    [VALOR_DIARIO_PCONTROLADO],                    
                    [LIMITE_PCONTROLADO],                                                           
                    [VALOR_KMRODAD_PCONTROLADO],        
                    [VALOR_DIARIO_PLIVRE]        
                )
            VALUES
                (
                    @NOMETIPO,
                    @VALOR_DIARIO_PDIARIO,
                    @VALOR_KMRODADO_PDIARIO,
                    @VALOR_DIARIO_PCONTROLADO,
                    @LIMITE_PCONTROLADO,
                    @VALOR_KMRODAD_PCONTROLADO,
                    @VALOR_DIARIO_PLIVRE
                )";

        private const string sqlEditarTipoGrupoVeiculo =
            @" UPDATE [TBTIPOVEICULO]
                SET 
                    [NOMETIPO] = @NOMETIPO, 
                    [VALOR_DIARIO_PDIARIO] = @VALOR_DIARIO_PDIARIO, 
                    [VALOR_KMRODADO_PDIARIO] = @VALOR_KMRODADO_PDIARIO,
                    [VALOR_DIARIO_PCONTROLADO] = @VALOR_DIARIO_PCONTROLADO, 
                    [LIMITE_PCONTROLADO] = @LIMITE_PCONTROLADO,
                    [VALOR_KMRODAD_PCONTROLADO] =@VALOR_KMRODAD_PCONTROLADO,
                    [VALOR_DIARIO_PLIVRE] =@VALOR_DIARIO_PLIVRE

                WHERE [ID] = @ID";

        private const string sqlExcluirTipoGrupoVeiculo =
            @"DELETE FROM [TBTIPOVEICULO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosTipoGrupoVeiculo =
            @"SELECT 
                [ID],       
                    [NOMETIPO],       
                    [VALOR_DIARIO_PDIARIO], 
                    [VALOR_KMRODADO_PDIARIO],
                    [VALOR_DIARIO_PCONTROLADO],                    
                    [LIMITE_PCONTROLADO],                                                           
                    [VALOR_KMRODAD_PCONTROLADO],        
                    [VALOR_DIARIO_PLIVRE]  
            FROM
                [TBTIPOVEICULO]";

        private const string sqlSelecionarTipoGrupoVeiculoPorId =
            @"SELECT 
                [ID],       
                    [NOMETIPO],       
                    [VALOR_DIARIO_PDIARIO], 
                    [VALOR_KMRODADO_PDIARIO],
                    [VALOR_DIARIO_PCONTROLADO],                    
                    [LIMITE_PCONTROLADO],                                                           
                    [VALOR_KMRODAD_PCONTROLADO],        
                    [VALOR_DIARIO_PLIVRE]  
            FROM
                [TBTIPOVEICULO]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteTipoGrupoVeiculo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTIPOVEICULO]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarGrupoVeiculoPesquisa =
          @"SELECT
                       [ID],       
                    [NOMETIPO],       
                    [VALOR_DIARIO_PDIARIO], 
                    [VALOR_KMRODADO_PDIARIO],
                    [VALOR_DIARIO_PCONTROLADO],                    
                    [LIMITE_PCONTROLADO],                                                           
                    [VALOR_KMRODAD_PCONTROLADO],        
                    [VALOR_DIARIO_PLIVRE] 

	                FROM
                       [TBTIPOVEICULO]
                    WHERE 
                        COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";
        #endregion

        private Logger logger;

        public GrupoVeiculoDAO(Logger log)
        {
            logger = log;
        }
        
        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTipoGrupoVeiculo, AdicionarParametro("ID", id));

                logger.Information("SUCESSO AO REMOVER GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id,  DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return false;
            }

            return true;
        }

        public List<GrupoVeiculo> SelecionarPesquisa(string coluna, string pesquisa)
        {
            try
            {
                string sql = sqlSelecionarGrupoVeiculoPesquisa.Replace("COLUNADEPESQUISA", coluna);
                List<GrupoVeiculo> grupoVeiculo = Db.GetAll(sql, ConverterEmGrupoVeiculo, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (grupoVeiculo != null)
                    logger.Debug("SUCESSO AO SELECIONAR GRUPO DE VEÍCULO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR GRUPO DE VEÍCULO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());

                return grupoVeiculo;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR GRUPO DE VEÍCULO | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteTipoGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            try
            {
                GrupoVeiculo grupoVeiculo = Db.Get(sqlSelecionarTipoGrupoVeiculoPorId, ConverterEmGrupoVeiculo, AdicionarParametro("ID", id));

                if (grupoVeiculo != null)
                    logger.Debug("SUCESSO AO SELECIONAR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());

                return grupoVeiculo;
         
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            try
            {
                List<GrupoVeiculo> grupoVeiculo = Db.GetAll(sqlSelecionarTodosTipoGrupoVeiculo, ConverterEmGrupoVeiculo);

                if (grupoVeiculo != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS GRUPOS DE VEÍCULOS | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS GRUPOS DE VEÍCULOS | DATA: {DataEHora}", DateTime.Now.ToString());

                return grupoVeiculo;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS GRUPOS DE VEÍCULOS | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
            
        }

        public void Inserir(GrupoVeiculo grupoVeiculo)
        {
            try
            {
                grupoVeiculo.Id = Db.Insert(sqlInserirTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(grupoVeiculo));

                logger.Information("SUCESSO AO INSERIR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", grupoVeiculo.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public void Editar(int id, GrupoVeiculo grupoVeiculo)
        {
            try
            {
                grupoVeiculo.Id = id;
                Db.Update(sqlEditarTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(grupoVeiculo));

                logger.Information("SUCESSO AO EDITAR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora}", grupoVeiculo.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR GRUPO DE VEÍCULO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", grupoVeiculo.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        private GrupoVeiculo ConverterEmGrupoVeiculo(IDataReader reader)
        {
            var nomeTipo = Convert.ToString(reader["NOMETIPO"]);
            var valorDiarioPDiario = Convert.ToDecimal(reader["VALOR_DIARIO_PDIARIO"]);
            var valorKmRodadoPDiario = Convert.ToDecimal(reader["VALOR_KMRODADO_PDIARIO"]);
            var valorDiarioPControlado = Convert.ToDecimal(reader["VALOR_DIARIO_PCONTROLADO"]);
            var limitePControlado = Convert.ToDecimal(reader["LIMITE_PCONTROLADO"]);
            var valorKmRodadoPControlado = Convert.ToDecimal(reader["VALOR_KMRODAD_PCONTROLADO"]);
            var valorDiarioPLivre = Convert.ToDecimal(reader["VALOR_DIARIO_PLIVRE"]);

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(nomeTipo, valorDiarioPDiario, valorKmRodadoPDiario, valorDiarioPControlado,
                                                                limitePControlado, valorKmRodadoPControlado, valorDiarioPLivre);
            grupoVeiculo.Id = Convert.ToInt32(reader["ID"]);

            return grupoVeiculo;
        }

        private Dictionary<string, object> ObtemParametrosTipoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoVeiculo.Id);
            parametros.Add("NOMETIPO", grupoVeiculo.NomeTipo);
            parametros.Add("VALOR_DIARIO_PDIARIO", grupoVeiculo.ValorDiarioPDiario);
            parametros.Add("VALOR_KMRODADO_PDIARIO", grupoVeiculo.ValorKmRodadoPDiario);
            parametros.Add("VALOR_DIARIO_PCONTROLADO", grupoVeiculo.ValorDiarioPControlado);
            parametros.Add("LIMITE_PCONTROLADO", grupoVeiculo.LimitePControlado);
            parametros.Add("VALOR_KMRODAD_PCONTROLADO", grupoVeiculo.ValorKmRodadoPControlado);
            parametros.Add("VALOR_DIARIO_PLIVRE", grupoVeiculo.ValorDiarioPLivre);

            return parametros;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
