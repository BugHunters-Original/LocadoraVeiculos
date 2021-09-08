using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.ServicoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.ServicoModule
{
    public class ControladorServico : Controlador<Servico>
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

        public override string Editar(int id, Servico registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarServico, ObtemParametrosServico(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirServico, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteServico, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(Servico registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirServico, ObtemParametrosServico(registro));
            }

            return resultadoValidacao;
        }

        public override Servico SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarServicoPorId, ConverterEmServico, AdicionarParametro("ID", id));
        }

        public override List<Servico> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosServicos, ConverterEmServico);
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

        public List<Servico> SelecionarPesquisa(string coluna, string pesquisa)
        {
            string sql = sqlSelecionarTaxaServico.Replace("COLUNADEPESQUISA", coluna);
            return Db.GetAll(sql, ConverterEmServico, AdicionarParametro("@SEGUNDAREF", pesquisa));
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
    }
}
