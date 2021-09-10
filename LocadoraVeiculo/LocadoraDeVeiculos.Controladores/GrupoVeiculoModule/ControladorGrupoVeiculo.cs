using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.GrupoVeiculoModule
{
    public class ControladorGrupoVeiculo : Controlador<GrupoVeiculo>
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

        public override string InserirNovo(GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(registro));
            }
            return resultadoValidacao;
        }

        public override string Editar(int id, GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarTipoGrupoVeiculo, ObtemParametrosTipoGrupoVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTipoGrupoVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<GrupoVeiculo> SelecionarPesquisa(string coluna, string pesquisa)
        {
            string sql = sqlSelecionarGrupoVeiculoPesquisa.Replace("COLUNADEPESQUISA", coluna);
            return Db.GetAll(sql, ConverterEmGrupoVeiculo, AdicionarParametro("@SEGUNDAREF", pesquisa));
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTipoGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public override GrupoVeiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTipoGrupoVeiculoPorId, ConverterEmGrupoVeiculo, AdicionarParametro("ID", id));
        }

        public override List<GrupoVeiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosTipoGrupoVeiculo, ConverterEmGrupoVeiculo);
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




    }
}
