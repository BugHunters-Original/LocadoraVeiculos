using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
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

        private readonly Logger logger;

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                funcionario.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(funcionario));

                logger.Information("SUCESSO AO INSERIR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora}", funcionario.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", funcionario.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public void Editar(int id, Funcionario funcionario)
        {
            try
            {
                funcionario.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(funcionario));

                logger.Information("SUCESSO AO EDITAR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora}", funcionario.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", funcionario.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));

                logger.Information("SUCESSO AO REMOVER FUNCIONÁRIO ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER FUNCIONÁRIO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

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
            try
            {
                Funcionario funcionario = Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));

                if (funcionario != null)
                    logger.Debug("SUCESSO AO SELECIONAR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora}", funcionario.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora}", funcionario.Id, DateTime.Now.ToString());

                return funcionario;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR FUNCIONÁRIO ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<Funcionario> SelecionarTodos()
        {
            try
            {
                List<Funcionario> funcionarios = Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);

                if (funcionarios != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS FUNCIONÁRIOS | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS FUNCIONÁRIOS | DATA: {DataEHora}", DateTime.Now.ToString());

                return funcionarios;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS FUNCIONÁRIOS | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<Funcionario> SelecionarPesquisa(string coluna, string pesquisa)
        {  
            try
            {
                string sql = sqlSelecionarFuncionarioPorNome.Replace("COLUNADEPESQUISA", coluna);
                List<Funcionario> funcionarios = Db.GetAll(sql, ConverterEmFuncionario, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (funcionarios != null)
                    logger.Debug("SUCESSO AO SELECIONAR FUNCIONARIO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR FUNCIONARIO COM A PESQUISA: {Pesquisa} | DATA: {DataEHora}", pesquisa, DateTime.Now.ToString());

                return funcionarios;

            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR FUNCIONARIO | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
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
