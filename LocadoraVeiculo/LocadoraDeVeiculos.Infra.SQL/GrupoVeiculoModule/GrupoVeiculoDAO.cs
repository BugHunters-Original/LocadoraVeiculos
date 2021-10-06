using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Shared;
using System.Collections.Generic;
using System.Data;
using System;

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

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTipoGrupoVeiculo, AdicionarParametro("ID", id));

                Log.Logger.Information("SUCESSO AO REMOVER GRUPO DE VEÍCULO ID: {Id}  ", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER GRUPO DE VEÍCULO ID: {Id}  ", id);

                return false;
            }

            return true;
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
                    Log.Logger.Debug("SUCESSO AO SELECIONAR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);

                return grupoVeiculo;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR GRUPO DE VEÍCULO ID: {Id}  ", id);

                return null;
            }
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            try
            {
                List<GrupoVeiculo> grupoVeiculo = Db.GetAll(sqlSelecionarTodosTipoGrupoVeiculo, ConverterEmGrupoVeiculo);

                if (grupoVeiculo != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS GRUPOS DE VEÍCULOS  ");
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS GRUPOS DE VEÍCULOS  ");

                return grupoVeiculo;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS GRUPOS DE VEÍCULOS  ");

                return null;
            }

        }

        public void Inserir(GrupoVeiculo grupoVeiculo)
        {
            try
            {
                grupoVeiculo.Id = Db.Insert(sqlInserirTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(grupoVeiculo));

                Log.Logger.Information("SUCESSO AO INSERIR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO INSERIR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);
            }
        }

        public void Editar(int id, GrupoVeiculo grupoVeiculo)
        {
            try
            {
                grupoVeiculo.Id = id;
                Db.Update(sqlEditarTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(grupoVeiculo));

                Log.Logger.Information("SUCESSO AO EDITAR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR GRUPO DE VEÍCULO ID: {Id}  ", grupoVeiculo.Id);
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
