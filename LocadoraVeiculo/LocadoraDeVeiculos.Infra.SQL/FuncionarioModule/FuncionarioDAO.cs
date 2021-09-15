using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDAO : IFuncionarioRepository
    {
        #region Queries
        private const string sqlInserirFuncionario =
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [NOME],       
                    [SALARIO], 
                    [CPF],
                    [DATA_ENTRADA],                    
                    [USUARIO],                                                           
                    [SENHA]            
                )
            VALUES
                (
                    @NOME,
                    @SALARIO,
                    @CPF,
                    @DATA_ENTRADA,
                    @USUARIO,
                    @SENHA
                    
                )";

        private const string sqlEditarFuncionario =
            @" UPDATE [TBFUNCIONARIO]
                SET 
                    [NOME] = @NOME,       
                    [SALARIO] = @SALARIO, 
                    [CPF] = @CPF,
                    [DATA_ENTRADA] = @DATA_ENTRADA,                    
                    [USUARIO] = @USUARIO,                                                           
                    [SENHA] = @SENHA

                WHERE [ID] = @ID";

        private const string sqlExcluirFuncionario =
            @"DELETE FROM [TBFUNCIONARIO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarFuncionarioPorId =
           @"SELECT
                       [ID],
		                [NOME], 
                        [SALARIO],
		                [CPF], 
		                [DATA_ENTRADA],
                        [USUARIO], 
		                [SENHA]
	                FROM
                       TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarFuncionarioPorNome =
           @"SELECT
                        [ID],
		                [NOME], 
                        [SALARIO],
		                [CPF], 
		                [DATA_ENTRADA],
                        [USUARIO], 
		                [SENHA]
	                FROM
                       TBFUNCIONARIO
                    WHERE 
                        COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";

        private const string sqlSelecionarTodosFuncionarios =
                    @"SELECT
                        [ID],
		                [NOME], 
                        [SALARIO],
		                [CPF], 
		                [DATA_ENTRADA],
                        [USUARIO], 
		                [SENHA]
	                FROM
                        TBFUNCIONARIO ORDER BY NOME;";

        private const string sqlExisteFuncionario =
           @"SELECT 
                COUNT(*) 
            FROM 
                [TBFUNCIONARIO]
            WHERE 
                [ID] = @ID";
        #endregion

        public void InserirFuncionario(Funcionario funcionario)
        {
                funcionario.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(funcionario));
        }

        public void EditarFuncionario(int id, Funcionario funcionario)
        {   
                funcionario.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(funcionario));       
        }

        public bool ExcluirFuncionario(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public Funcionario SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
        }

        public List<Funcionario> SelecionarPesquisa(string coluna, string pesquisa)
        {
            string sql = sqlSelecionarFuncionarioPorNome.Replace("COLUNADEPESQUISA", coluna);
            return Db.GetAll(sql, ConverterEmFuncionario, AdicionarParametro("@SEGUNDAREF", pesquisa));
        }

        private Funcionario ConverterEmFuncionario(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string cpf = Convert.ToString(reader["CPF"]);
            DateTime data_entrada = Convert.ToDateTime(reader["DATA_ENTRADA"]);
            decimal salario = Convert.ToDecimal(reader["SALARIO"]);

            string usuario = Convert.ToString(reader["USUARIO"]);
            string senha = Convert.ToString(reader["SENHA"]);


            Funcionario funcionario = new Funcionario(nome, salario, data_entrada, cpf, usuario, senha);

            funcionario.Id = id;

            return funcionario;
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("CPF", funcionario.CpfFuncionario);
            parametros.Add("SALARIO", funcionario.Salario);
            parametros.Add("DATA_ENTRADA", funcionario.DataEntrada);
            parametros.Add("USUARIO", funcionario.Usuario);
            parametros.Add("SENHA", funcionario.Senha);

            return parametros;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
