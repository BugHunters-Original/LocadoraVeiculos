using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.FuncionarioModule
{
    public class ControladorFuncionario : Controlador<Funcionario>
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
		                [CPF], 
		                [DATA_ENTRADA],
                        [USUARIO], 
		                [SENHA]
	                FROM
                       TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosFuncionarios =
                    @"SELECT
                        [ID],
		                [NOME], 
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
        public override string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
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

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public override Funcionario SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("CPF", funcionario.Cpf_funcionario);
            parametros.Add("SALARIO", funcionario.Salario);
            parametros.Add("DATA_ENTRADA", funcionario.DataEntrada);
            parametros.Add("USUARIO", funcionario.Usuario);
            parametros.Add("SENHA", funcionario.Senha);

            return parametros;
        }
    }
}
