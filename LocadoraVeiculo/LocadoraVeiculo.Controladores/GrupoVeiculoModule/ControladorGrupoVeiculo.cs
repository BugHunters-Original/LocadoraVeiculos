using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.GrupoVeiculoModule
{
    public class ControladorGrupoVeiculo : Controlador<GrupoVeiculo>
    {

        #region Queries
        private const string sqlInserirTipoGrupoVeiculo =
            @"INSERT INTO [TBTIPOVEICULO]
                (
                    [NOME],       
                    [VALOR_DIARIO_PDIARIO], 
                    [PRECO_KMDIARIO],
                    [VALOR_DIARIO_PCONTROLADO],                    
                    [KMDIA__KMCONTROLADO],                                                           
                    [PRECO_KMLIVRE]        
                )
            VALUES
                (
                    @NOME,
                    @VALOR_DIARIO_PDIARIO,
                    @PRECO_KMDIARIO,
                    @VALOR_DIARIO_PCONTROLADO,
                    @KMDIA__KMCONTROLADO,
                    @PRECO_KMLIVRE
                )";

        private const string sqlEditarTipoGrupoVeiculo =
            @" UPDATE [TBTIPOVEICULO]
                SET 
                    [NOME] = @NOME, 
                    [VALOR_DIARIO_PDIARIO] = @VALOR_DIARIO_PDIARIO, 
                    [PRECO_KMDIARIO] = @PRECO_KMDIARIO,
                    [VALOR_DIARIO_PCONTROLADO] = @VALOR_DIARIO_PCONTROLADO, 
                    [KMDIA__KMCONTROLADO] = @KMDIA__KMCONTROLADO,
                    [PRECO_KMLIVRE] =@PRECO_KMLIVRE

                WHERE [ID] = @ID";

        private const string sqlExcluirTipoGrupoVeiculo =
            @"DELETE FROM [TBTIPOVEICULO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosTipoGrupoVeiculo =
            @"SELECT 
                [ID],       
                [NOME],
                [VALOR_DIARIO_PDIARIO],
                [PRECO_KMDIARIO],             
                [VALOR_DIARIO_PCONTROLADO],                    
                [KMDIA__KMCONTROLADO],                                
                [PRECO_KMLIVRE]
            FROM
                [TBTIPOVEICULO]";

        private const string sqlSelecionarTipoGrupoVeiculoPorId =
            @"SELECT 
                [ID],       
                [NOME],
                [VALOR_DIARIO_PDIARIO],
                [PRECO_KMDIARIO],             
                [VALOR_DIARIO_PCONTROLADO],                    
                [KMDIA__KMCONTROLADO],                                
                [PRECO_KMLIVRE]
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
            var categoriaVeiculo = Convert.ToString(reader["NOME"]);
            var valor_Diario_PDiario = Convert.ToInt32(reader["VALOR_DIARIO_PDIARIO"]);
            var preco_KMDiario = Convert.ToInt32(reader["PRECO_KMDIARIO"]);
            var valor_Diario_PControlado = Convert.ToInt32(reader["VALOR_DIARIO_PCONTROLADO"]);
            var kmDia__KMControlado = Convert.ToInt32(reader["KMDIA__KMCONTROLADO"]);
            var preco_KMLivre = Convert.ToInt32(reader["PRECO_KMLIVRE"]);

            GrupoVeiculo grupoVeiculo = new GrupoVeiculo(categoriaVeiculo, valor_Diario_PDiario, preco_KMDiario, valor_Diario_PControlado, kmDia__KMControlado, preco_KMLivre);
            grupoVeiculo.Id = Convert.ToInt32(reader["ID"]);

            return grupoVeiculo;
        }

        private Dictionary<string, object> ObtemParametrosTipoGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoVeiculo.Id);
            parametros.Add("NOME", grupoVeiculo.categoriaVeiculo);
            parametros.Add("VALOR_DIARIO_PDIARIO", grupoVeiculo.valor_Diario_PDiario);
            parametros.Add("PRECO_KMDIARIO", grupoVeiculo.preco_KMDiario);
            parametros.Add("VALOR_DIARIO_PCONTROLADO", grupoVeiculo.valor_Diario_PControlado);
            parametros.Add("KMDIA__KMCONTROLADO", grupoVeiculo.kmDia__KMControlado);
            parametros.Add("PRECO_KMLIVRE", grupoVeiculo.preco_KMLivre);

            return parametros;
        }
    }
}
