using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.ClienteModule
{
    public class ControladorClienteCNPJ : Controlador<ClienteCNPJ>
    {
        private const string sqlInserirCliente =
       @"INSERT INTO TBCLIENTECNPJ 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CNPJ],
                        [EMAIL]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @ENDERECO,
                        @TELEFONE,
		                @CNPJ,
		                @EMAIL
	                )";

        private const string sqlEditarCliente =
            @"UPDATE TBCLIENTECNPJ
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [CNPJ] = @CNPJ,
                        [EMAIL] = @EMAIL
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCliente =
            @"DELETE 
	                FROM
                        TBCLIENTECNPJ
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarClientePorId =
            @"SELECT
                        [ID],
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CNPJ],
                        [EMAIL]
	                FROM
                        TBCLIENTECNPJ
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosClientes =
            @"SELECT
                        [ID],
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CNPJ],
                        [EMAIL]
	                FROM
                        TBCLIENTECNPJ";

        private const string sqlExisteCliente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTECNPJ]
            WHERE 
                [ID] = @ID";
        public override string Editar(int id, ClienteCNPJ registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCliente, ObtemParametrosCliente(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(ClienteCNPJ registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosCliente(registro));
            }

            return resultadoValidacao;
        }

        public override ClienteCNPJ SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));
        }

        public override List<ClienteCNPJ> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);
        }
        private Dictionary<string, object> ObtemParametrosCliente(ClienteCNPJ cliente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cliente.Id);
            parametros.Add("NOME", cliente.Nome);
            parametros.Add("ENDERECO", cliente.Endereco);
            parametros.Add("TELEFONE", cliente.Telefone);
            parametros.Add("CNPJ", cliente.Cnpj);
            parametros.Add("EMAIL", cliente.Email);

            return parametros;
        }
        private ClienteCNPJ ConverterEmCliente(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            string email = Convert.ToString(reader["EMAIL"]);

            ClienteCNPJ cliente = new ClienteCNPJ(nome, endereco, telefone, cnpj, email);

            cliente.Id = id;

            return cliente;
        }
    }
}
