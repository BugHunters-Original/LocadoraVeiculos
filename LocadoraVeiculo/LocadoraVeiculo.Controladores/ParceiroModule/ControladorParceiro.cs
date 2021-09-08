using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.ParceiroModule
{
    public class ControladorParceiro : Controlador<ParceiroDesconto>
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

        public override string Editar(int id, ParceiroDesconto registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteParceiro, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(ParceiroDesconto registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(registro));
            }

            return resultadoValidacao;
        }

        public override ParceiroDesconto SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        }

        public override List<ParceiroDesconto> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);
        }
        private Dictionary<string, object> ObtemParametrosParceiro(ParceiroDesconto parceiro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", parceiro.Id);
            parametros.Add("NOME_PARCEIRO", parceiro.Nome);

            return parametros;
        }
        private ParceiroDesconto ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME_PARCEIRO"]);

            ParceiroDesconto parceiro = new ParceiroDesconto(nome);

            parceiro.Id = id;

            return parceiro;
        }

        public List<ParceiroDesconto> SelecionarPesquisa(string coluna, string pesquisa)
        {
            string sql = sqlSelecionarParceiro.Replace("COLUNADEPESQUISA", coluna);
            return Db.GetAll(sql, ConverterEmParceiro, AdicionarParametro("@SEGUNDAREF", pesquisa));
        }
    }
}
