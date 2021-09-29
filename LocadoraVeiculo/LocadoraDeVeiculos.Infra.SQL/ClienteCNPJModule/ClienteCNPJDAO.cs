using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Shared;
using System.Collections.Generic;
using System.Data;
using System;

namespace LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule
{
    public class ClienteCNPJDAO : IClienteCNPJRepository
    {
        #region Queries
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

        private const string sqlExisteCNPJ =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTECNPJ]
            WHERE 
                [CNPJ] = @CNPJ";
        #endregion

        public void Inserir(ClienteCNPJ registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosCliente(registro));

                Log.Logger.Information("SUCESSO AO INSERIR CLIENTE CNPJ ID: {Id}  ", registro.Id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex ,"ERRO AO INSERIR CLIENTE CNPJ ID: {Id}  ", registro.Id);
            }
        }
        public void Editar(int id, ClienteCNPJ registro)
        {
            try
            {
                registro.Id = id;
                Db.Update(sqlEditarCliente, ObtemParametrosCliente(registro));

                Log.Logger.Information("SUCESSO AO EDITAR CLIENTE CNPJ ID: {Id}  ", registro.Id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR CLIENTE CNPJ ID: {Id}  ", registro.Id);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));

                Log.Logger.Information("SUCESSO AO REMOVER CLIENTE CNPJ ID: {Id}  ", id );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER CLIENTE CNPJ ID: {Id}  ", id);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }
        public bool ExisteCNPJ(string cnpj)
        {
            try
            {
                bool existe = Db.Exists(sqlExisteCNPJ, AdicionarParametro("CNPJ", cnpj));

                if (existe)
                    Log.Logger.Information("O CNPJ {Cnpj} JÁ EXISTE NO SISTEMA  ", cnpj );
                else
                    Log.Logger.Debug("O CNPJ {Cnpj} NÃO EXISTE NO SISTEMA ", cnpj );

                return existe;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR O CNPJ {Cnpj}  ", cnpj);

                return true;
            }
        }

        public ClienteCNPJ SelecionarPorId(int id)
        {
            try
            {
                ClienteCNPJ clienteCNPJ = Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));

                if (clienteCNPJ != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR CLIENTE CNPJ ID: {Id}  ", clienteCNPJ.Id );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR CLIENTE CNPJ ID: {Id}  ", clienteCNPJ.Id );

                return clienteCNPJ;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR CLIENTE CNPJ ID: {Id}  ", id );

                return null;
            }
        }

        public List<ClienteCNPJ> SelecionarTodos()
        {
            try
            {
                List<ClienteCNPJ> clientesCNPJ = Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);

                if (clientesCNPJ != null)
                    Log.Logger.Debug("SUCESSO AO SELECIONAR TODOS OS CLIENTES CNPJ  " );
                else
                    Log.Logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS CLIENTES CNPJ  " );

                return clientesCNPJ;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS CLIENTES CNPJ  " );

                return null;
            }
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

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

    }
}
